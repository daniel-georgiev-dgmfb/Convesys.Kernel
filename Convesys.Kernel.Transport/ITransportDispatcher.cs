using System.Threading;
using System.Threading.Tasks;

namespace Twilight.Kernel.Transport
{
    public interface ITransportDispatcher
    {
        ITransportManager TransportManager { get; }
        Task SendMessage<TMessage>(TMessage message, CancellationToken cancellationToken) where TMessage : Twilight.Kernel.Messaging.Message;
    }
}
