using System.Security;

namespace Platform.Kernel.Security.CertificateManagement
{
    public class FileCertificateContext : CertificateContext
    {
        public string CertificatePath { get; set; }
        public SecureString Password { get; set; }
    }
}