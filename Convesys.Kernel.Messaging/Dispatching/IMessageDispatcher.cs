using System.Threading;
using System.Threading.Tasks;

namespace Convesys.Kernel.Messaging.Dispatching
{
    public interface IMessageDispatcher
    {
        Task SendMessage(Message message, CancellationToken cancallationToken);
    }
}