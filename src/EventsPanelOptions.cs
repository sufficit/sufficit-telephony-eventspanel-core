using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony.EventsPanel
{
    public class EventsPanelOptions : IEquatable<EventsPanelOptions>, IEventsPanelOptions
    {
        /// <summary>
        /// Value in Milliseconds <br />  
        /// If RefreshRate == 0, FastReload, RealTime operation, may crash WASM 
        /// </summary>
        public uint RefreshRate { get; set; }

        public bool ShowTrunks { get; set; }

        public int MaxButtons { get; set; }

        public bool AutoFill { get; set; }

        public bool Equals(EventsPanelOptions? other)
            => other != null &&
            other.RefreshRate == RefreshRate &&
            other.ShowTrunks == ShowTrunks &&
            other.MaxButtons == MaxButtons &&
            other.AutoFill == AutoFill;
    }
}
