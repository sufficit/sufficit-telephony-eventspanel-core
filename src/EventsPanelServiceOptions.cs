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
            ShowTrunks = true;
            AutoGenerateQueueCards = true;
            Cards = new HashSet<EventsPanelCardInfo>();
        }

        public bool AutoGenerateQueueCards { get; set; }

        public bool IgnoreLocal { get; set; }

        public HashSet<EventsPanelCardInfo> Cards { get; set; }

        public bool Equals(EventsPanelServiceOptions? other)
            => other != null && 
            other.RefreshRate == RefreshRate &&
            other.AutoGenerateQueueCards == AutoGenerateQueueCards &&
            other.ShowTrunks == ShowTrunks &&
            other.MaxButtons == MaxButtons &&
            other.AutoFill == AutoFill &&
            other.IgnoreLocal == IgnoreLocal &&
            other.Cards.SetEquals(Cards);        
    }
}
