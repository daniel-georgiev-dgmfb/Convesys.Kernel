using System.Threading;
using System.Threading.Tasks;

namespace Twilight.Kernel.Smtp.Storage
{
    public interface IMessageStore
    {
        Task<bool> SaveAsync(ISessionContext context, CancellationToken cancellationToken);
    }
}