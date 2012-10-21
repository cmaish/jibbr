using System.ComponentModel.Composition;
using Jabbot.Core.Models;

namespace Jabbot.Core.Sprockets
{
	[InheritedExport]
	public interface ISprocket
	{
		bool HandleMessage(IBot bot, ChatMessage message);
	}
}