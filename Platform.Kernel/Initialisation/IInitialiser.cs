using Platform.Kernel.DependencyResolver;
using System;
using System.Threading.Tasks;

namespace Platform.Kernel.Initialisation
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