using System.Threading.Tasks;

namespace Convesys.Kernel.Tenancy
{
    /// <summary>
    /// Exposes methods to interact with tenant service
    /// </summary>
    public interface ITenantManager
    {
        /// <summary>
        /// Build a tenant descriptor for the current request
        /// </summary>
        /// <returns></returns>
        Task<TenantDescriptor> GetTenantDescriptor(TenantResolutionContext context);
    }
}