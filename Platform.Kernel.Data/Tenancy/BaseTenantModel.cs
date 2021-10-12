using System;

namespace Platform.Kernel.Data.Tenancy
{
    public abstract class BaseTenantModel : BaseModel
    {
        public Guid TenantId { get; protected set; }
    }
}