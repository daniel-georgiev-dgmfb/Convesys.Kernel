using System.Collections.Generic;
using System.Reflection;

namespace Platform.Kernel.Message.Handling
{
    public interface IHandlerResolverSettings
    {
        IEnumerable<Assembly> LimitAssembliesTo { get; }
        bool HasCustomAssemblyList { get; }
    }
}