﻿using System;
using Jabbot.Core;
using Jabbot.Core.Sprockets;

namespace SampleAnnouncement
{
	public class EchoAnnouncement : IAnnounce
	{
		public TimeSpan Interval
		{
            get { return TimeSpan.FromMinutes(10); }
		}

		public void Execute(IBot bot)
		{
			var offset = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
			var startingPoint = DateTime.UtcNow;
			var now = startingPoint.Add(offset.BaseUtcOffset);

			if (offset.IsDaylightSavingTime(startingPoint))
				now = now.AddHours(1);

			var message = string.Format("The time in AEDST (Sydney time) is now {0}", now.ToString("hh:mm:ss tt, dd MMMM yyyy"));

		    bot.SendToAllRooms(message);
		}
	}
}