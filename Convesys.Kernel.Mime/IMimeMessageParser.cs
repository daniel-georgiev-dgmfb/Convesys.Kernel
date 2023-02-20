using System.IO;

namespace Twilight.Kernel.Mime
{
    public interface IMimeMessageParser
    {
        IMimeMessage ParseMimeMessage(string content);
        IMimeMessage ParseMimeMessage(Stream content);
    }
}
