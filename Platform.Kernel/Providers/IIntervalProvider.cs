using System;
using System.Security.Cryptography;

namespace Platform.Kernel.Providers
{
    public interface IIntervalProvider
    {
        TimeSpan Next();
        TimeSpan Next(RandomNumberGenerator randomNumberGenerator);
    }
}