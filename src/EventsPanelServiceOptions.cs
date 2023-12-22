using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony.EventsPanel
{
    public class EventsPanelServiceOptions : EventsPanelOptions, IEquatable<EventsPanelServiceOptions>, IEventsPanelOptions
    {
        public const string SECTIONNAME = "Sufficit:Telephony:EventsPanel";

        public EventsPanelServiceOptions()
        {
            IgnoreLocal = true;
            AutoGenerateQueueCards = true;
            Cards = new HashSet<EventsPanelCardInfo>();
        }

        public bool AutoGenerateQueueCards { get; set; }

        public bool IgnoreLocal { get; set; }

        public HashSet<EventsPanelCardInfo> Cards { get; set; }

        public bool Equals(EventsPanelServiceOptions? other)
            => other != null && 
            other.AutoGenerateQueueCards == AutoGenerateQueueCards &&
            other.IgnoreLocal == IgnoreLocal &&
            other.Cards.SetEquals(Cards) &&
            other is EventsPanelOptions otherbase && otherbase.Equals(other);
    }
}
