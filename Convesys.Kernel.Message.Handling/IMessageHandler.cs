using System.Threading;
using System.Threading.Tasks;

namespace Twilight.Kernel.Message.Handling
{
    public interface IMessageHandler<TMessage> where TMessage : Twilight.Kernel.Messaging.Message
    {
		Task Handle(TMessage command, CancellationToken cancellationToken);
	}
}