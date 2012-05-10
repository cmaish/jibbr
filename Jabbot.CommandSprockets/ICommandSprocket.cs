using System.Collections.Generic;
using Jabbot.Core;
using Jabbot.Core.Models;
using Jabbot.Core.Sprockets;

namespace Jabbot.CommandSprockets
{
	public interface ICommandSprocket : ISprocket
	{
		string[] Arguments { get; }
		IBot Bot { get; }
		string Command { get; }
		bool HasArguments { get; }
		string Intitiator { get; }
		ChatMessage ChatMessage { get; }
		IEnumerable<string> SupportedCommands { get; }
		IEnumerable<string> SupportedInitiators { get; }
		bool ExecuteCommand();
		bool MayHandle(string initiator, string command);
	}
}