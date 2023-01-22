using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Convesys.Kernel.Message.Handling
{
    public interface IHandlerInvoker
    {
        Task InvokeHandlers(IEnumerable<object> handlers, object message, CancellationToken cancallationToken);
    }
}