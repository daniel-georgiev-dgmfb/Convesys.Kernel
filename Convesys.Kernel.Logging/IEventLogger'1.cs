using System;
using System.Threading.Tasks;

namespace Twilight.Kernel.Logging
{
    public interface IEventLogger<T> : IEventLogger
    {
        void Log<TState>(SeverityLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter);
    }
}