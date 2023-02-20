using System;

namespace Twilight.Kernel.Smtp.Text
{
    public interface ITokenEnumeratorCheckpoint : IDisposable
    {
        /// <summary>
        /// Rollback to the checkpoint;
        /// </summary>
        void Rollback();
    }
}