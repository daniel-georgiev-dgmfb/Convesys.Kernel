using System.Threading;
using System.Threading.Tasks;
using Twilight.Kernel.Smtp.Protocol;

namespace Twilight.Kernel.Smtp.Transport
{
    public interface IMessageTransport
    {
        Task<bool> DispatchAsync(ISessionContext context, CancellationToken cancellationToken);
    }
}