using System.Threading.Tasks;

namespace Convesys.Kernel.Authorisation
{
    public interface ITokenGrantService<TContext>
    {
        Task GrantToken(TContext context);
    }
}