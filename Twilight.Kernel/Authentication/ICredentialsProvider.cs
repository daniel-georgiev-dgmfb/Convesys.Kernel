using System.Net;

namespace Convesys.Kernel.Authentication
{
    public interface ICredentialsProvider : ICredentials, ICredentialsByHost
    {
    }
}