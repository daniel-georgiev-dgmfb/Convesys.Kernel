using System;
using System.Threading.Tasks;

namespace Platform.Kernel.Validation
{
    public interface IValidationRule
    {
        Task Validate(ValidationContext context, Func<ValidationContext, Task> next);
    }
}