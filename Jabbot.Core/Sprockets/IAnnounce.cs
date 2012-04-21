using System;

namespace Jabbot.Core.Sprockets
{
	public interface IAnnounce
	{
		TimeSpan Interval { get; }
		void Execute(IBot bot);
	}
}