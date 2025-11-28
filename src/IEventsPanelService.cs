using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony.EventsPanel
{
    /// <summary>
    /// Base interface for EventsPanel Service
    /// Minimal contract to allow both Server and Client implementations
    /// </summary>
    public interface IEventsPanelService
    {

        #region PROPERTIES

        /// <summary>
        /// Indicates if the service is properly configured
        /// </summary>
        bool IsConfigured { get; }

        #endregion
        #region METHODS

        /// <summary>
        /// Execute the service asynchronously
        /// </summary>
        Task ExecuteAsync(CancellationToken cancellationToken);

        #endregion

    }
}
