using System;
using System.Threading.Tasks;

namespace Convesys.Kernel.Validation
{
    public interface IValidationRule
    {
        Task Validate(ValidationContext context, Func<ValidationContext, Task> next);
    }
}