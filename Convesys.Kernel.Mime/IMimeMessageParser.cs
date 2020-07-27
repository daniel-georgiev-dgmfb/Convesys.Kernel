using System.IO;

namespace Convesys.Kernel.Mime
{
    public interface IMimeMessageParser
    {
        IMimeMessage ParseMimeMessage(string content);
        IMimeMessage ParseMimeMessage(Stream content);
    }
}
