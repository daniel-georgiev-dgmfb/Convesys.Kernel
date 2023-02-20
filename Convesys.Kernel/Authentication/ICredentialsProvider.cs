using System.Net;

namespace Twilight.Kernel.Authentication
{
    public interface ICredentialsProvider : ICredentials, ICredentialsByHost
    {
    }
}