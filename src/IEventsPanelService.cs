using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sufficit.Telephony.EventsPanel
{
    public interface IEventsPanelService
    {
        void Configure(AMIHubClientOptions options);

        bool IsConfigured { get; }

        Task StartAsync(CancellationToken cancellationToken);

        Task StopAsync(CancellationToken cancellationToken);
    }
}
