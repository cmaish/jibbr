using System.Collections.Generic;
using Jabbot.Core;
using Jabbot.Core.Sprockets;

namespace Jabbot.ConsoleBotHost
{
    public interface IScheduler
    {
        void Start(IEnumerable<IAnnounce> tasks, IBot bot);
        void Stop();
    }
}
