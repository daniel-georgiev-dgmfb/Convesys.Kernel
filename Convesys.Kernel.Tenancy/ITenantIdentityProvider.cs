using System.Collections.Generic;
using System.Threading.Tasks;

namespace Twilight.Kernel.Tenancy
{
    /// <summary>
    /// Resolve tenant identifier from for the current request
    /// </summary>
    public interface ITenantIdentityProvider
    {
        /// <summary>
        /// Resolves tenant identifier.
        /// </summary>
        /// <returns>Tenant descriptor.</returns>
        Task<TenantDescriptor> GetTenantDescriptor(TenantResolutionContext context);

        /// <summary>
        /// Resolves tenant descriptors.
        /// </summary>
        /// <param name="resolvers">Tenant resolvers collection</param>
        /// <returns></returns>
        Task<TenantDescriptor> GetTenantDescriptor(TenantResolutionContext context, IEnumerable<ITenantResolver> resolvers);
    }
}