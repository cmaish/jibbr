using System.Text.RegularExpressions;
using JabbR.Client.Models;

namespace Jabbot.Core.Sprockets
{
	public abstract class RegexSprocket : ISprocket
	{
		public abstract Regex Pattern { get; }

		public bool HandleMessage(IBot bot, Message message, string room)
		{
			if (Pattern == null)
			{
				return false;
			}

			var match = Pattern.Match(message.Content);

			if (!match.Success)
			{
				return false;
			}

			ProcessMatch(match, bot, message, room);

			return true;
		}

		protected abstract void ProcessMatch(Match match, IBot bot, Message message, string room);
	}
}