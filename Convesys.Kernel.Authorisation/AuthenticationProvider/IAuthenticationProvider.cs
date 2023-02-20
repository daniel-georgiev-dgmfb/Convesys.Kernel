using System.Threading.Tasks;

namespace Twilight.Kernel.Authorisation.AuthenticationProvider
{
    public interface IAuthenticationProvider<TContext>
    {
        Task Authenticated(TContext context);

        Task ReturnEndpoint(TContext context);

        void ApplyRedirect(TContext context);
    }
}