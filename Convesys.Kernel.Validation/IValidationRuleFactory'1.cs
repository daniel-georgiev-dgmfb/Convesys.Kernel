using System;
using System.Collections.Generic;

namespace Twilight.Kernel.Validation
{
    public interface IValidationRuleFactory<T> : IValidationRuleFactory
    {
        IEnumerable<IValidationRule> GetValidationRules(Func<T, IEnumerable<object>> resolver);
        
        IEnumerable<IValidationRule> GetValidationRules(Func<T, bool> filter);
    }
}