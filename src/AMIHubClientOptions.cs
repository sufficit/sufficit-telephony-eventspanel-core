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

        public Uri Endpoint { get; set; } = default!;

        public override bool Equals(object obj)
            => obj is AMIHubClientOptions p && p.Endpoint == Endpoint;

        public override int GetHashCode()
            => Endpoint.GetHashCode();

        public Exception? Validate()
        {
            if(Endpoint != null)
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
