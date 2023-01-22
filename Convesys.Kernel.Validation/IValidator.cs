using System.Threading.Tasks;

namespace Convesys.Kernel.Validation
{
    public interface IValidator
    {
        Task Validate(ValidationContext context);
    }

    public interface IValidator<in TValidationItem, TValidationStatus> 
    {
        Task<TValidationStatus> Validate(TValidationItem validationItem);
    }
}