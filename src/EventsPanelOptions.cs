using System;
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
        [JsonPropertyName("refreshrate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint RefreshRate { get; set; }

        [JsonPropertyName("onlypeers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? OnlyPeers { get; set; }

        [JsonPropertyName("maxbuttons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MaxButtons { get; set; }

        [JsonPropertyName("autofill")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool AutoFill { get; set; }

        public bool Equals(EventsPanelOptions? other)
            => other != null &&
            other.RefreshRate == RefreshRate &&
            other.OnlyPeers == OnlyPeers &&
            other.MaxButtons == MaxButtons &&
            other.AutoFill == AutoFill;

        public override bool Equals(object? obj)
            => Equals(obj as EventsPanelOptions);        

        public override int GetHashCode()
            => (RefreshRate, OnlyPeers, MaxButtons, AutoFill).GetHashCode();
    }
}
