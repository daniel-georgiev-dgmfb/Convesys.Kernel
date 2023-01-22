using System.Threading;
using System.Threading.Tasks;

namespace Convesys.Kernel.Transport
{
    public interface ITransportDispatcher
    {
        ITransportManager TransportManager { get; }
        Task SendMessage<TMessage>(TMessage message, CancellationToken cancellationToken) where TMessage : Convesys.Kernel.Messaging.Message;
    }
}
