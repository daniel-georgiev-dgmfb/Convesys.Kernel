using System.Net;

namespace Platform.Kernel.Authentication
{
    public interface ICredentialsProvider : ICredentials, ICredentialsByHost
    {
    }
}