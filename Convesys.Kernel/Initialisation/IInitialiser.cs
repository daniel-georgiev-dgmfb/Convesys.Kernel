using System;
using System.Threading.Tasks;
using Twilight.Kernel.DependencyResolver;

namespace Twilight.Kernel.Initialisation
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