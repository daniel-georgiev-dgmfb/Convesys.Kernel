using System;

namespace Twilight.Kernel.Transport
{
    public interface ITransaction : IDisposable
    {
        void Begin();
        void Commit();
        void Abort();
    }
}