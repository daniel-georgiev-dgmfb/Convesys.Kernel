using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Smtp.Transport
{
	public interface IMessageTransport
    {
        Task<bool> DispatchAsync(ISessionContext context, CancellationToken cancellationToken);
    }
}