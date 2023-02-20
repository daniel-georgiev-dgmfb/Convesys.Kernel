using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Twilight.Kernel.Transport
{
    public interface ITransport : IDisposable
    {
        ITransportConfiguration Configuration { get; }
        bool IsTransactional { get; }
        int PendingMessages { get; }
        Task Initialise(CancellationToken cancallationToken);
        Task Start(CancellationToken cancellationToken);
        Task Stop(CancellationToken cancallationToken);
        Task Send(byte[] message, CancellationToken cancellationToken);
        Task Send(byte[] message, ITransaction transaction, CancellationToken cancellationToken);
        Task<IEnumerable<byte[]>> ReadAllMessages(CancellationToken cancellationToken);
        Task CopyMessages(IEnumerable<byte[]> destination, CancellationToken cancellationToken);
    }
}