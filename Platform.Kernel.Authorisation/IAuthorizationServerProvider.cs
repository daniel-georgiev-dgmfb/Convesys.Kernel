using Platform.Kernel.Authorisation.Contexts;
using System.Threading.Tasks;

namespace Platform.Kernel.Authorisation
{
	public interface IAuthorizationServerProvider
    {
        Task TokenEndpointResponse<TContext>(TContext context) where TContext : class, ITokenEndpointResponseContext;
    }
}