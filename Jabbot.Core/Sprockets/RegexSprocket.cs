using System.Text.RegularExpressions;
using Jabbot.Core.Models;

namespace Jabbot.Core.Sprockets
{
	public abstract class RegexSprocket : ISprocket
	{
		public abstract Regex Pattern { get; }

		public bool HandleMessage(IBot bot, ChatMessage message)
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

			ProcessMatch(match, bot, message);

			return true;
		}

		protected abstract void ProcessMatch(Match match, IBot bot, ChatMessage message);
	}
}