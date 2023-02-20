using System;

namespace Convesys.Kernel.Authentication
{
    public interface ICredentialsProvider<T>
    {
        T GetCredential(Uri uri, string authType);
    }
}