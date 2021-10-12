using Platform.Kernel.Security.Configuration;
using System;
using System.Collections.Generic;

namespace Platform.Kernel.Security.Validation
{
	public interface ICertificateValidatorResolver
    {
        IEnumerable<TValidator> Resolve<TValidator>(Uri partnerId) where TValidator : class;
        IEnumerable<IPinningSertificateValidator> Resolve(BackchannelConfiguration configuration); 
        
    }
}