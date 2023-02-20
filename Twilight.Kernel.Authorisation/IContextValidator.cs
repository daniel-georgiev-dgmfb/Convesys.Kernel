using System.Threading.Tasks;

namespace Convesys.Kernel.Authorisation
{
    public interface IContextValidator<TContext>
    {
        Task ValidateContext(TContext context);
    }
}