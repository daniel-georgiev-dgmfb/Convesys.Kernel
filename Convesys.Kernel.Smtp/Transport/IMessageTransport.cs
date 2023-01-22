using System.Threading;
using System.Threading.Tasks;
using Convesys.Kernel.Smtp.Protocol;

namespace Convesys.Kernel.Smtp.Transport
{
    public interface IMessageTransport
    {
        Task<bool> DispatchAsync(ISessionContext context, CancellationToken cancellationToken);
    }
}