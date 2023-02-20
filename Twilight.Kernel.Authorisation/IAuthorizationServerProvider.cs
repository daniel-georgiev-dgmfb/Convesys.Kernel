using System.Threading.Tasks;
using Convesys.Kernel.Authorisation.Contexts;

namespace Convesys.Kernel.Authorisation
{
    public interface IAuthorizationServerProvider
    {
        Task TokenEndpointResponse<TContext>(TContext context) where TContext : class, ITokenEndpointResponseContext;
    }
}