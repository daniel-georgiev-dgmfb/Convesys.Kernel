using Platform.Kernel.Resilience.Retry;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Resilience
{
	public interface IRetry
    {
        Task Retry(RetryExecutionContext executionContext, Func<CancellationToken, Task> executeAction);
    }
}