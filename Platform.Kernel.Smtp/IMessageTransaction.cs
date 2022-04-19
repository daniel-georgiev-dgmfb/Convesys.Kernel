using Platform.Kernel.Mime;
using System;
using System.Collections.Generic;

namespace Platform.Kernel.Smtp
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