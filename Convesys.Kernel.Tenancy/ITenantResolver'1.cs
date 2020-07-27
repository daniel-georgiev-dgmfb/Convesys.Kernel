using System;
using System.Threading.Tasks;

namespace Convesys.Kernel.Tenancy
{
    /// <summary>
    /// Resolve tenant descriptor
    /// </summary>
    public interface ITenantResolver
    {
        /// <summary>
        /// Try to resolve tenant descriptor
        /// </summary>
        /// <param name="context">Tenant resolution context</param>
        /// <param name="next">Next resolver in the chain.</param>
        /// <returns></returns>
        Task ResolveTenant(TenantResolutionContext context, Func<TenantResolutionContext, Task> next);
    }
}