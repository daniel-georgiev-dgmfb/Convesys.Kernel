using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Web.Authorisation
{
    public interface IBearerTokenManager
    {
        Task<TokenDescriptor> GetToken(IBearerTokenContext tokenContext, CancellationToken cancellationToken);
    }
}