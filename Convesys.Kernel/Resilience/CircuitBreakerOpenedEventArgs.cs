using System;

namespace Twilight.Kernel.Resilience
{
    public class CircuitBreakerOpenedEventArgs
    {
        public Exception TriggerException { get; }
        public TimeSpan BreakDuration { get; }
        public CircuitBreakerOpenedEventArgs(Exception exception, TimeSpan breakDuration)
        {
            TriggerException = exception;
            BreakDuration = breakDuration;
        }
    }
}
