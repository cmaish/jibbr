using System.Threading.Tasks;

namespace Jabbot.Core
{
	public static class BotExtensions
	{
		public static Task SendToAllRooms(this IBot bot, string text)
		{
			return bot.GetRooms()
				.ContinueWith(c =>
				              	{
				              		foreach (var room in c.Result)
				              		{
				              			bot.Send(text, room).Wait();
				              		}
				              	});
		}
	}
}