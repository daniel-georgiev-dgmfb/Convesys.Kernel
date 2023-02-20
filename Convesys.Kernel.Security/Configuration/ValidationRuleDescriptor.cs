using Twilight.Kernel.Reflection;

namespace Twilight.Kernel.Security.Configuration
{
    public class ValidationRuleDescriptor : TypeDescriptor
    {
        public ValidationRuleDescriptor(string fullQualifiedName) : base(fullQualifiedName)
        {
        }
        
        public ValidationScope Scope { get; }
    }
}