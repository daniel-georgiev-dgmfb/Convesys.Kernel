using Platform.Kernel.DependencyResolver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Initialisation
{
	public interface IRunnable
    {
        Task Run(IDependencyResolver resolver, Func<ServiceContext> contextFactory, CancellationToken cancellationToken);
    }
}