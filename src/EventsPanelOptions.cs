using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony.EventsPanel
{
    public class EventsPanelOptions : IEquatable<EventsPanelOptions>, IEventsPanelOptions
    {
        /// <summary>
        /// Value in Milliseconds <br />  
        /// If RefreshRate == 0, FastReload, RealTime operation, may crash WASM 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint RefreshRate { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool ShowTrunks { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MaxButtons { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool AutoFill { get; set; }

        public bool Equals(EventsPanelOptions? other)
            => other != null &&
            other.RefreshRate == RefreshRate &&
            other.ShowTrunks == ShowTrunks &&
            other.MaxButtons == MaxButtons &&
            other.AutoFill == AutoFill;
    }
}
