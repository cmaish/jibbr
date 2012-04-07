﻿using System.Collections.Generic;
using Jabbot.CommandSprockets;

namespace SampleSprocket
{
	public class HelloSprocket : CommandSprocket
	{
		public override IEnumerable<string> SupportedInitiators
		{
			get { yield return "hello"; }
		}

		public override IEnumerable<string> SupportedCommands
		{
			get { yield return "you"; }
		}

		public override bool ExecuteCommand()
		{
            // TODO: need to get current room
			Bot.Say(string.Format("Hello {0}", ChatMessage.User.Name), "");

			return true;
		}
	}
}