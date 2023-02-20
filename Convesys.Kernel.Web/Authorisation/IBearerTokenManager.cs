using System.Threading;
using System.Threading.Tasks;

namespace Twilight.Kernel.Web.Authorisation
{
    public interface IBearerTokenManager
    {
        Task<TokenDescriptor> GetToken(IBearerTokenContext tokenContext, CancellationToken cancellationToken);
    }
}