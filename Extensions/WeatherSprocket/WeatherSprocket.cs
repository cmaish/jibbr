using System.Collections.Generic;
using Jabbot.CommandSprockets;

namespace WeatherSprocket
{
	public class WeatherSprocket : CommandSprocket
	{
		public override IEnumerable<string> SupportedInitiators
		{
			get { yield return "weather"; }
		}

		public override IEnumerable<string> SupportedCommands
		{
			get { yield return "93063"; }
		}

		public override bool ExecuteCommand()
		{
			Bot.Say("Temp: 64F", Message.Receiver);

			return true;
		}
	}
}