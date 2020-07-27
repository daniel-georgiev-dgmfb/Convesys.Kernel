﻿using System;
using System.Collections.Generic;
using Convesys.Kernel.Mime;

namespace Convesys.Kernel.Smtp
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