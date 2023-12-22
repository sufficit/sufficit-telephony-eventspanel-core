using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony.EventsPanel
{
    /// <summary>
    /// Basic info to Match a card to a monitor
    /// </summary>
    public class EventsPanelCardInfo : IEventsPanelCardInfo, IEquatable<EventsPanelCardInfo>
    {
        public EventsPanelCardInfo()
        {
            Exclusive = true;
            Label = "Unknown";
            Channels = new HashSet<string>();
        }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("kind")]
        public virtual EventsPanelCardKind Kind { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("exclusive")]
        public bool Exclusive { get; set; }

        [JsonPropertyName("channels")]
        public HashSet<string> Channels { get; set; }

        public bool Equals(EventsPanelCardInfo? other)
            => other != null &&
            other.Order == Order &&
            other.Kind == Kind &&
            other.Label == Label &&
            other.Exclusive == Exclusive &&
            other.Channels.SetEquals(Channels);
    }
}
