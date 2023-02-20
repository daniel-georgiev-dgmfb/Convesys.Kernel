using System;
using System.Collections.Generic;
using Twilight.Kernel.Security.Configuration;

namespace Twilight.Kernel.Security.Validation
{
    public interface ICertificateValidatorResolver
    {
        IEnumerable<TValidator> Resolve<TValidator>(Uri partnerId) where TValidator : class;
        IEnumerable<IPinningSertificateValidator> Resolve(BackchannelConfiguration configuration); 
        
    }
}