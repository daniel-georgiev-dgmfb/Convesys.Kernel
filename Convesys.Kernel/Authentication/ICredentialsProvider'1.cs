using System;

namespace Twilight.Kernel.Authentication
{
    public interface ICredentialsProvider<T>
    {
        T GetCredential(Uri uri, string authType);
    }
}