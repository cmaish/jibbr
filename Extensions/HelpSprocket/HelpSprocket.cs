using System.Linq;
using Jabbot.Core;
using Jabbot.Core.Models;
using Jabbot.Core.Sprockets;

namespace Help
{
	public class HelpSprocket : ISprocket
	{
		public bool HandleMessage(IBot bot, ChatMessage message)
		{
			var acceptedCommands = new[] {bot.Name + " help", "@" + bot.Name + " help"};

			if (acceptedCommands.Contains(message.Content.Trim()))
			{
				bot.PrivateReply(message.User.Name, "A list of commands this bot currently supports:\n\thelp");

				return true;
			}

			return false;
		}
	}
}