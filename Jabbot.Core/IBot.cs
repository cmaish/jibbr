using System.Collections.Generic;
using System.Threading.Tasks;
using JabbR.Client.Models;

namespace Jabbot.Core
{
	public interface IBot
	{
		string Name { get; }
		IEnumerable<Room> Rooms { get; }
		Task Send(string text, string room);
		Task PrivateReply(string userName, string message);
		Task<IEnumerable<string>> GetUsers(string room);
		Task<IEnumerable<string>> GetRooms();
	}
}