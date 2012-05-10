using JabbR.Client.Models;

namespace Jabbot.Core.Sprockets
{
	public interface ISprocket
	{
		bool HandleMessage(IBot bot, Message message, string room);
	}
}