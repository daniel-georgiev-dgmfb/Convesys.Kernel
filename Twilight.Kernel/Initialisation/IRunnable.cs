using System;
using System.Threading;
using System.Threading.Tasks;
using Convesys.Kernel.DependencyResolver;

namespace Convesys.Kernel.Initialisation
{
    public interface IRunnable
    {
        Task Run(IDependencyResolver resolver, Func<ServiceContext> contextFactory, CancellationToken cancellationToken);
    }
}