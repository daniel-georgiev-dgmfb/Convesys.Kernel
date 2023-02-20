using System;
using System.Collections.Generic;
using Twilight.Kernel.Mime;

namespace Twilight.Kernel.Smtp
{
    public interface IMessageTransaction
    {
        Guid TransactionId { get; }

        Guid TenantId { get; }

        Mailbox From { get; set; }

        IList<Mailbox> To { get; }

        IMimeMessage Message { get; set; }
        
        void Reset();
    }
}