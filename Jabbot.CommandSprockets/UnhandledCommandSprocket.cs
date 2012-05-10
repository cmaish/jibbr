using System;
using System.Collections.Generic;
using System.Linq;
using Jabbot.Core;
using Jabbot.Core.Models;
using Jabbot.Core.Sprockets;

namespace Jabbot.CommandSprockets
{
	public abstract class UnhandledCommandSprocket : IUnhandledMessageSprocket
	{
		public abstract IEnumerable<string> SupportedInitiators { get; }
		public string Initiator { get; protected set; }
		public string Command { get; protected set; }
		public string[] Arguments { get; protected set; }
		public ChatMessage ChatMessage { get; protected set; }
		public IBot Bot { get; protected set; }

		public bool HasArguments
		{
			get { return Arguments.Length > 0; }
		}

		public bool HandleMessage(IBot bot, ChatMessage message)
		{
			try
			{
				var args = message.Content.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

				Initiator = args.Length > 0 ? args[0] : string.Empty;
				Command = args.Length > 1 ? args[1] : string.Empty;

				ChatMessage = message;
				Bot = bot;

				if (MayHandle(Initiator, Command))
				{
					Arguments = args.Skip(2).ToArray();

					return ExecuteCommand();
				}
			}
			catch (InvalidOperationException e)
			{
				bot.PrivateReply(message.User.Name, e.GetBaseException().Message);
			}

			return false;
		}

		public abstract bool ExecuteCommand();

		public virtual bool MayHandle(string initiator, string command)
		{
			return SupportedInitiators.Any(i => i.Equals(initiator, StringComparison.OrdinalIgnoreCase));
		}
	}
}