using System;
using System.ComponentModel.Composition;

namespace Jabbot.Core.Sprockets
{
	[InheritedExport]
	public interface IAnnounce
	{
		TimeSpan Interval { get; }
		void Execute(IBot bot);
	}
}