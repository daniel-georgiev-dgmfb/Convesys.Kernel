using System;
using System.Collections.Specialized;
using System.Linq;

namespace Twilight.Kernel.Data.Tenancy
{
    public interface ITenantManager
    {
        NameValueCollection ResolveTenantConnectionString();
        Guid ResolveTenant();

        IQueryable<T> ApplyFilter<T>(IQueryable<T> query) where T : BaseTenantModel;
        T AssignTenantId<T>(T item) where T : BaseTenantModel;
        string TenantConnectionString { get; }
    }
}