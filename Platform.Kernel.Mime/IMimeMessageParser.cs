using System.IO;

namespace Platform.Kernel.Mime
{
    public interface IMimeMessageParser
    {
        IMimeMessage ParseMimeMessage(string content);
        IMimeMessage ParseMimeMessage(Stream content);
    }
}
