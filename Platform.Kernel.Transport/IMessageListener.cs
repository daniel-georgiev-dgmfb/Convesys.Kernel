using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Transport
{
    public interface IMessageListener
    {
        Task<bool> Start();
        Task<bool> Stop();
        Task<bool> AttachTo(ITransportManager transportManager);
        Task ReceiveMessage(byte[] message, CancellationToken cancellationToken);
        Task ReceiveMessageTransactional(byte[] message, ITransaction transaction, CancellationToken cancellationToken);
    }
}