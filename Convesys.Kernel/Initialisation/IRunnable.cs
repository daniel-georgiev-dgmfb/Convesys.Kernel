using System;
using System.Threading;
using System.Threading.Tasks;
using Twilight.Kernel.DependencyResolver;

namespace Twilight.Kernel.Initialisation
{
    public interface IRunnable
    {
        Task Run(IDependencyResolver resolver, Func<ServiceContext> contextFactory, CancellationToken cancellationToken);
    }
}