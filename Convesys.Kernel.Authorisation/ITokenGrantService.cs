using System.Threading.Tasks;

namespace Twilight.Kernel.Authorisation
{
    public interface ITokenGrantService<TContext>
    {
        Task GrantToken(TContext context);
    }
}