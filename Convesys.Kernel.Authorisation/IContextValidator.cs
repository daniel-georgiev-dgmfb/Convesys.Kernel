using System.Threading.Tasks;

namespace Twilight.Kernel.Authorisation
{
    public interface IContextValidator<TContext>
    {
        Task ValidateContext(TContext context);
    }
}