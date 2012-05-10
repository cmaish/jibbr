using Jabbot.Core.Models;

namespace Jabbot.Core.Sprockets
{
	public interface ISprocket
	{
		bool HandleMessage(IBot bot, ChatMessage message);
	}
}