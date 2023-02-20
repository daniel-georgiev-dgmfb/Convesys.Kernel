using System.Collections.Generic;
using System.Reflection;

namespace Twilight.Kernel.Message.Handling
{
    public interface IHandlerResolverSettings
    {
        IEnumerable<Assembly> LimitAssembliesTo { get; }
        bool HasCustomAssemblyList { get; }
    }
}