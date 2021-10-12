using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Transport
{
    public interface ITransportDispatcher
    {
        ITransportManager TransportManager { get; }
        Task SendMessage<TMessage>(TMessage message, CancellationToken cancellationToken) where TMessage : Platform.Kernel.Messaging.Message;
    }
}
