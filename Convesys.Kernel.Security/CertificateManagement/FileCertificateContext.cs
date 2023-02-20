using System.Security;

namespace Twilight.Kernel.Security.CertificateManagement
{
    public class FileCertificateContext : CertificateContext
    {
        public string CertificatePath { get; set; }
        public SecureString Password { get; set; }
    }
}