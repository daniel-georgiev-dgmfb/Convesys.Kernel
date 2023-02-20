using System.Threading.Tasks;
using Twilight.Kernel.Authorisation.Contexts;

namespace Twilight.Kernel.Authorisation
{
    public interface IAuthorizationServerProvider
    {
        Task TokenEndpointResponse<TContext>(TContext context) where TContext : class, ITokenEndpointResponseContext;
    }
}