using Platform.Kernel.Mime;
using Platform.Kernel.Smtp.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Smtp.Mime
{
	public interface IMimeMessageDeserializer
    {
        Task<IMimeMessage> DeserializeAsync(INetworkClient networkClient, CancellationToken cancellationToken = default(CancellationToken));
    }
}