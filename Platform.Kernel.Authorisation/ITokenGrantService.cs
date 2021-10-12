using System.Threading.Tasks;

namespace Platform.Kernel.Authorisation
{
    public interface ITokenGrantService<TContext>
    {
        Task GrantToken(TContext context);
    }
}