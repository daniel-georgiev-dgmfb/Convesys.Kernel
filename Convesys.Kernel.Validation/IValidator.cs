using System.Threading.Tasks;

namespace Twilight.Kernel.Validation
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