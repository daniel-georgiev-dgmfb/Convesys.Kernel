using System;

namespace Convesys.Kernel.Data.Tenancy
{
    public abstract class BaseTenantModel : BaseModel
    {
        public Guid TenantId { get; protected set; }
    }
}