using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Convesys.Kernel.Mime;

namespace Convesys.Kernel.Smtp
{
    public interface IMessageRelayer : IDisposable
    {
        Task RelayAsync(Guid transactionId,
            RelayEndpoint relayEndpoint,
            Mailbox From,
            IEnumerable<Mailbox> To,
            IMimeMessage mimeMessage,
            Func<Guid, Task> onSuccess,
            Func<Guid, IMimeMessage, Exception, Task> onFailure,
            Func<Guid, IMimeMessage, Exception, Task> onPartialFailure);

        Task CloseAsync();
    }
}