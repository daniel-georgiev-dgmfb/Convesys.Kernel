using System;

namespace Platform.Kernel.Authentication
{
    public interface ICredentialsProvider<T>
    {
        T GetCredential(Uri uri, string authType);
    }
}