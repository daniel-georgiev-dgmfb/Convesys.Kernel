using System.Threading;
using System.Threading.Tasks;

namespace Twilight.Kernel.Smtp.Protocol
{
    public interface ISmtpCommand
    {
        Task<bool> ExecuteAsync(ISessionContext context, CancellationToken cancellationToken);
        ISmtpServerOptions Options { get; }
    }
}
