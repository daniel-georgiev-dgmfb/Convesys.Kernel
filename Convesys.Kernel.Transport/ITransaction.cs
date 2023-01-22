using System;

namespace Convesys.Kernel.Transport
{
    public interface ITransaction : IDisposable
    {
        void Begin();
        void Commit();
        void Abort();
    }
}