using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JabbR.Client;
using JabbR.Client.Models;
using Jabbot.Core.Sprockets;

namespace Jabbot.Core
{
	public class Bot : IBot, IDisposable
	{
		private readonly JabbRClient _client;
		private readonly IList<ISprocket> _sprockets = new List<ISprocket>();
		private readonly HashSet<Room> rooms = new HashSet<Room>();

		public Bot(JabbRClient client)
		{
			_client = client;

			_client.RoomCountChanged += UpdateRoomList;
		}

		public string Name { get; private set; }

		public IEnumerable<Room> Rooms
		{
			get { return rooms; }
		}

		public Task Send(string text, string room)
		{
			return _client.Send(text, room);
		}

		public Task PrivateReply(string userName, string message)
		{
			return _client.SendPrivateMessage(userName, message);
		}

		public Task<IEnumerable<string>> GetUsers(string room)
		{
			return _client.GetRoomInfo(room)
				.ContinueWith(c => c.Result.Users.Select(u => u.Name));
		}

		public Task<IEnumerable<string>> GetRooms()
		{
			return _client.GetRooms().ContinueWith(c => c.Result.Select(r => r.Name));
		}

		public void Dispose()
		{
			_client.RoomCountChanged -= UpdateRoomList;

			_client.Disconnect();
		}

		public void Connect(string botName, string botPassword)
		{
			Name = botName;

			var connectTask = _client.Connect(botName, botPassword);

			connectTask.Wait();

			foreach (var room in connectTask.Result.Rooms)
			{
				rooms.Add(room);
			}
		}

		public void AddSprocket(ISprocket sprocket)
		{
			_sprockets.Add(sprocket);
		}

		private void UpdateRoomList(Room affectedRoom, int roomCount)
		{
			if (rooms.Contains(affectedRoom))
			{
				rooms.RemoveWhere(r => r.Name == affectedRoom.Name);
			}
			else
			{
				rooms.Add(affectedRoom);
			}
		}
	}
}