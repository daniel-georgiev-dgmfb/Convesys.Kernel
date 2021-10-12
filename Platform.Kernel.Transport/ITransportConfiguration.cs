using System;
using System.Collections.Generic;

namespace Platform.Kernel.Transport
{
    public interface ITransportConfiguration
    {
        int MaxDegreeOfParallelism { get; set; }
        int ConcurrentListeners { get; set; }
        TimeSpan ConsumerPeriod { get; set; }
        ICollection<IMessageListener> Listeners { get; }
        TransportConnection TransportConnection { get; set; }
        bool IsTransactional { get; set; }
        Mode TransportMode { get; set; }
    }
}