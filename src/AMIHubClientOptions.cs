using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony.EventsPanel
{
    public class AMIHubClientOptions
    {
        public const string SECTIONNAME = "Sufficit:Telephony:AMIHubClient";

        public bool AutoStart { get; set; } = true;

        public Uri? Endpoint { get; set; }

        public override bool Equals(object? obj)
            => obj is AMIHubClientOptions p && p.Endpoint == Endpoint && p.AutoStart == AutoStart;

        public override int GetHashCode()
            => (Endpoint!, AutoStart).GetHashCode();

        public Exception? Validate()
        {
            if (Endpoint != null)
            {
                return null;
            } 
            else { return new Exception("null or empty endpoint"); }
        }

        public AMIHubClientOptions ValidateAndThrow()
        {
            var ex = Validate();
            if(ex != null) throw ex;

            return this;
        }
    }
}
