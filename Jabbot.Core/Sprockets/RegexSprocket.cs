using System.Text.RegularExpressions;
using Jabbot.Core.Models;

namespace Jabbot.Core.Sprockets
{
	public  abstract class RegexSprocket : ISprocket
	{
		public abstract Regex Pattern { get; }

		public abstract void ProcessMatch(Match match, ChatMessage chatMessage, IBot bot);
	}
}