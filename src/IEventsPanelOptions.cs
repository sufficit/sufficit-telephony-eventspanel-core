using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony.EventsPanel
{
    public interface IEventsPanelOptions : IEventsPanelCardsAreaOptions
    { 
        /// <summary>
        /// Value in Milliseconds <br />  
        /// If RefreshRate == 0, FastReload, RealTime operation, may crash WASM 
        /// </summary>
        uint RefreshRate { get; }

        int MaxButtons { get; }

        /// <summary>
        /// Should auto generate new cards from received events
        /// </summary>
        bool AutoFill { get; }

        /// <summary>
        /// Maximum number of calls to display in queue cards <br />
        /// 0 = unlimited, default = 5 <br />
        /// When limit is exceeded, shows the oldest calls (longest waiting time)
        /// </summary>
        int MaxQueueCalls { get; }
    }
}
