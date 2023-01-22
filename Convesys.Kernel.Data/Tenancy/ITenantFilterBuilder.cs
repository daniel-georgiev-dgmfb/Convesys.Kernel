using System;
using System.Linq;

namespace Convesys.Kernel.Data.Tenancy
{
    public interface ITenantFilterBuilder
    {
        IQueryable<T> ApplyFilter<T>(IQueryable<T> query, Guid tenantId) where T : BaseTenantModel;
        T AssignTenantId<T>(T item, Guid tenantId) where T : BaseTenantModel;
    }
}