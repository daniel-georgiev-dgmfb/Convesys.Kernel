using System;

namespace Platform.Kernel.Smtp.Text
{
    public interface ITokenEnumeratorCheckpoint : IDisposable
    {
        /// <summary>
        /// Rollback to the checkpoint;
        /// </summary>
        void Rollback();
    }
}