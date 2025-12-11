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

        /// <summary>
        /// Maximum number of calls to display in queue cards <br />
        /// 0 = unlimited, default = 5 <br />
        /// When limit is exceeded, shows the oldest calls (longest waiting time)
        /// </summary>
        [JsonPropertyName("maxqueuecalls")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MaxQueueCalls { get; set; } = 5;

        public bool Equals(EventsPanelOptions? other)
            => other != null &&
            other.RefreshRate == RefreshRate &&
            other.OnlyPeers == OnlyPeers &&
            other.MaxButtons == MaxButtons &&
            other.AutoFill == AutoFill &&
            other.MaxQueueCalls == MaxQueueCalls;

        public override bool Equals(object? obj)
            => Equals(obj as EventsPanelOptions);        

        public override int GetHashCode()
            => (RefreshRate, OnlyPeers, MaxButtons, AutoFill, MaxQueueCalls).GetHashCode();
    }
}
