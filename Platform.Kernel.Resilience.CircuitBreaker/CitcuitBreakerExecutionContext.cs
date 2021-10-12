using System;

namespace Platform.Kernel.Resilience.CircuitBreaker
{
	public class CitcuitBreakerExecutionContext : ExecutionContext
    {
        event EventHandler<CircuitBreakerOpenedEventArgs> CircuitBreakerOpened;
        event EventHandler CircuitBreakerReset;
    }
}
