using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Twilight.Kernel.Smtp.IO
{
    public interface INetworkClient : IDisposable
    {
        /// <summary>
        /// Returns a series a buffer segments until the continuation predicate indicates that the method should complete.
        /// </summary>
        /// <param name="continue">The predicate to apply to the byte to determine if the function should continue reading.</param>
        /// <param name="count">The number of bytes to consume.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The list of buffers that contain the bytes matching while the predicate was true.</returns>
        Task<IReadOnlyList<ArraySegment<byte>>> ReadAsync(Func<byte, bool> @continue, long count = Int64.MaxValue, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Write a list of byte array segments.
        /// </summary>
        /// <param name="buffers">The list of array segment buffers to write.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that asynchronously performs the operation.</returns>
        Task WriteAsync(IReadOnlyList<ArraySegment<byte>> buffers, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Flush the write buffers to the stream.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous flush operation.</returns>
        Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Upgrade to a secure stream.
        /// </summary>
        /// <param name="certificate">The X509Certificate used to authenticate the server.</param>
        /// <param name="protocols">The value that represents the protocol used for authentication.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that asynchronously performs the operation.</returns>
        Task UpgradeAsync(X509Certificate certificate, SslProtocols protocols, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns a value indicating whether or not the current client is secure.
        /// </summary>
        bool IsSecure { get; }
    }
}