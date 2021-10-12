using System;
using System.Threading.Tasks;

namespace Platform.Kernel.Security.Validation
{
    public interface ICertificateValidationRule
    {
        Task Validate(CertificateValidationContext context, Func<CertificateValidationContext, Task> next);
    }
}