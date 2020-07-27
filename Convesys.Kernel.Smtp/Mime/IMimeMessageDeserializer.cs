using System.Threading;
using System.Threading.Tasks;
using Convesys.Kernel.Mime;
using Convesys.Kernel.Smtp.IO;

namespace Convesys.Kernel.Smtp.Mime
{
    public interface IMimeMessageDeserializer
    {
        Task<IMimeMessage> DeserializeAsync(INetworkClient networkClient, CancellationToken cancellationToken = default(CancellationToken));
    }
}