using System.Threading.Tasks;

namespace Platform.Kernel.Authorisation
{
    public interface IContextValidator<TContext>
    {
        Task ValidateContext(TContext context);
    }
}