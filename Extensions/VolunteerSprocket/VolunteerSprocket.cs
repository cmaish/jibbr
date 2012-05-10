using System;
using System.Linq;
using System.Text.RegularExpressions;
using Jabbot.Core;
using Jabbot.Core.Models;
using Jabbot.Core.Sprockets;

namespace VolunteerSprocket
{
	public class VolunteerSprocket : RegexSprocket
	{
		public override Regex Pattern
		{
			get { return new Regex(@"[-_./""\w\s]*volunteer some[-_./""\w\s]*"); }
		}

		protected override void ProcessMatch(Match match, IBot bot, ChatMessage message)
		{
			if (message.Content.StartsWith(bot.Name) || message.Content.StartsWith(string.Format("@{0}", bot.Name)))
			{
				var users = bot.GetUsers(message.Room).Result.Where(c => c != bot.Name).ToList();

				if (!users.Any())
				{
					bot.Send("Bot, you can't tell yourself to do that", message.Room);

					return;
				}

				var random = new Random();

				var randomUser = random.Next(0, users.Count - 1);

				bot.Send(string.Format("I volunteer {0} for that!", users[randomUser]), message.Room);
			}
		}
	}
}