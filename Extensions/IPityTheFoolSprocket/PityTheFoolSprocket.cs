using System.Text.RegularExpressions;
using Jabbot;
using Jabbot.Models;
using Jabbot.Sprockets;

namespace IPityTheFoolSprocket
{
	public class PityTheFoolSprocket : RegexSprocket
	{
		public override Regex Pattern
		{
			get { return new Regex(@".*(?:fool|pity)+.*", RegexOptions.IgnoreCase); }
		}

		protected override void ProcessMatch(Match match, ChatMessage message, IBot bot)
		{
            bot.Say("http://4.bp.blogspot.com/-1-1_GAfGz1I/UIOp235sYFI/AAAAAAAALjI/qlJAoiQ41Mg/s1600/mr-t-mrt-pity-the-fool-pities-mohawk.jpg", message.Receiver);
		}
	}
}