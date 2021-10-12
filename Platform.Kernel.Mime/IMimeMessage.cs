using System.Collections.Generic;

namespace Platform.Kernel.Mime
{
    public interface IMimeMessage
    {
        IEnumerable<MimeHeader> Headers { get; }
        IEnumerable<MimeEntity> BodyParts { get; }
        IEnumerable<MimeEntity> Attachments { get; }
        bool IsEncrypted { get; }
        long Size { get; }
        string ToString();
    }
}
