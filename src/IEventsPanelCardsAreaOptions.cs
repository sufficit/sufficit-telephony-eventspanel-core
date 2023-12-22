using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony.EventsPanel
{
    public interface IEventsPanelCardsAreaOptions
    {
        /// <summary>
        /// Show only peers or should has a visible reserved space for showing trunks and queues cards
        /// </summary>
        bool? OnlyPeers { get; }

        Func<EventsPanelCardInfo, Task<string>>? CardAvatarHandler { get; set; }
    }
}
