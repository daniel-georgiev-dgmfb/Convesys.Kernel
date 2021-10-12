using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Message.Handling
{
    public interface IMessageHandler<TMessage> where TMessage : Platform.Kernel.Message.Handling
    {
		Task Handle(TMessage command, CancellationToken cancellationToken);
	}
}