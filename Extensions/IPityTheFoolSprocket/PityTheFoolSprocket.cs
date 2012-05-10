using System.Text.RegularExpressions;
using JabbR.Client.Models;
using Jabbot.Core;
using Jabbot.Core.Sprockets;

namespace IPityTheFoolSprocket
{
	public class PityTheFoolSprocket : RegexSprocket
	{
		public override Regex Pattern
		{
			get { return new Regex(@".*(?:fool|pity)+.*", RegexOptions.IgnoreCase); }
		}

		protected override void ProcessMatch(Match match, IBot bot, Message message, string room)
		{
			bot.Send("http://xamldev.dk/IPityTheFool.gif", message.User.Name);
		}
	}
}