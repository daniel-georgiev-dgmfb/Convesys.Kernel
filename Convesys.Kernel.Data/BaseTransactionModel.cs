using System;

namespace Twilight.Kernel.Data
{
    public abstract class BaseTransactionModel : BaseModel
    {
        public Guid TransactionId { get; set; }
        public Guid TenantId { get; set; }
    }
}