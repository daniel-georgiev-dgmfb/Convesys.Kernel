using System;
using System.Threading;
using System.Threading.Tasks;

namespace Convesys.Kernel.Resilience
{
    public interface ICircuitBreaker
    {

        event EventHandler<CircuitBreakerOpenedEventArgs> CircuitBreakerOpened;
        event EventHandler CircuitBreakerReset;
        Task ExecuteAsync(Func<CancellationToken, Task> executeAction, Func<Exception, Task> failureAction, CancellationToken cancellationToken);
    }
}
