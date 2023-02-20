using System.Threading;
using System.Threading.Tasks;
using Twilight.Kernel.Mime;
using Twilight.Kernel.Smtp.IO;

namespace Twilight.Kernel.Smtp.Mime
{
    public interface IMimeMessageDeserializer
    {
        Task<IMimeMessage> DeserializeAsync(INetworkClient networkClient, CancellationToken cancellationToken = default(CancellationToken));
    }
}