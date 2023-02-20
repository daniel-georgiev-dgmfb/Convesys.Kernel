using System;
using System.Collections.Generic;

namespace Platform.Kernel.Validation
{
    public interface IValidationRuleFactory
    {
        IEnumerable<IValidationRule> GetValidationRules(Type type);
        IEnumerable<IValidationRule> GetValidationRules();
        
    }
}