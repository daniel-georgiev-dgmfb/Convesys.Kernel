using System;

namespace Convesys.Kernel.Smtp.Text
{
    public interface ITokenEnumeratorCheckpoint : IDisposable
    {
        /// <summary>
        /// Rollback to the checkpoint;
        /// </summary>
        void Rollback();
    }
}