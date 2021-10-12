using System;
using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Resilience.CircuitBreaker
{
    public interface ICircuitBreaker
    {
        Task ExecuteAsync(CitcuitBreakerExecutionContext context, Func<CancellationToken, Task> executeAction, Func<Exception, Task> failureAction, CancellationToken cancellationToken);
    }
}
