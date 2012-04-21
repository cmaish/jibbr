using System;

namespace Jabbot.Core.Models
{
	public class ChatMessage
	{
		public ChatMessage(string message, string user, string room)
		{
			Content = message;
			User = new User { Name = user };
			Room = room;
		}

		public string Id { get; set; }
		public string Content { get; set; }
		public DateTimeOffset When { get; set; }
		public User User { get; set; }
		public string Room { get; set; }
	}
}