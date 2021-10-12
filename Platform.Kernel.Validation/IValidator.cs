using System.Threading.Tasks;

namespace Platform.Kernel.Validation
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