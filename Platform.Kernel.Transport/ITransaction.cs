using System;

namespace Platform.Kernel.Transport
{
    public interface ITransaction : IDisposable
    {
        void Begin();
        void Commit();
        void Abort();
    }
}