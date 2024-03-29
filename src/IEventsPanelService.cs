﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony.EventsPanel
{
    public interface IEventsPanelService
    {
        bool IsConfigured { get; }

        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
