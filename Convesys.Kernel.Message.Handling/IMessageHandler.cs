using System.Threading;
using System.Threading.Tasks;

namespace Convesys.Kernel.Message.Handling
{
    public interface IMessageHandler<TMessage> where TMessage : Convesys.Kernel.Messaging.Message
    {
		Task Handle(TMessage command, CancellationToken cancellationToken);
	}
}