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
    }
}
