using System;
using System.Threading.Tasks;
using Convesys.Kernel.DependencyResolver;

namespace Convesys.Kernel.Initialisation
{
    /// <summary>
    /// Initialises the server
    /// </summary>
    public interface IInitialiser
    {
        byte Order { get; }
        Type Type { get; }
        bool AutoDiscoverable { get; }
        Task Initialise(IDependencyResolver dependencyResolver);
    }
}