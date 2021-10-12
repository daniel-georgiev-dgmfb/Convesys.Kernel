using Platform.Kernel.Reflection.Reflection;
using System;
using System.Linq;

namespace Platform.Kernel.Reflection
{
	public class TypeDescriptor
    {
        public string FullQualifiedName { get; }
        
        public TypeDescriptor(string fullQualifiedName)
        {
            this.FullQualifiedName = fullQualifiedName;
        }
        public Type Type
        {
            get
            {
                return this.TypeFromName();
            }
        }
        
        private Type TypeFromName()
        {
            return Type.GetType(this.FullQualifiedName, (an) =>
            {
                if (String.IsNullOrWhiteSpace(this.FullQualifiedName))
                    return null;
                var assembly = AssemblyScanner.ScannableAssemblies
                .FirstOrDefault(x => x.FullName == an.FullName);
                if (assembly == null)
                    throw new InvalidOperationException(String.Format("Assembly name: {0} can't be resolved.", an));
                return assembly;
            }, (a, s, b) => a.GetType(s, b));
        }
    }
}