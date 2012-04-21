using System.Text.RegularExpressions;
using Jabbot.Core;
using Jabbot.Core.Models;
using Jabbot.Core.Sprockets;

namespace IPityTheFoolSprocket
{
	public class PityTheFoolSprocket : RegexSprocket
	{
		public override Regex Pattern
		{
			get { return new Regex(@".*(?:fool|pity)+.*", RegexOptions.IgnoreCase); }
		}

		public override void ProcessMatch(Match match, ChatMessage chatMessage, IBot bot)
		{
			bot.Send("http://xamldev.dk/IPityTheFool.gif", chatMessage.User.Name);
		}
	}
}