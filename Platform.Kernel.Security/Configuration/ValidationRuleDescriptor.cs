namespace Platform.Kernel.Security.Configuration
{
	public class ValidationRuleDescriptor : TypeDescriptor
    {
        public ValidationRuleDescriptor(string fullQualifiedName) : base(fullQualifiedName)
        {
        }
        
        public ValidationScope Scope { get; }
    }
}