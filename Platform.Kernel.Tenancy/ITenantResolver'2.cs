using System.Threading.Tasks;

namespace Platform.Kernel.Tenancy
{
    /// <summary>
    /// Resolve tenant descriptor from specified source
    /// </summary>
    /// <typeparam name="TSource">Source carrying information about the tenant</typeparam>
    /// <typeparam name="T"></typeparam>
    public interface ITenantResolver<TSource> : ITenantResolver
    {
        /// <summary>
        /// Resolve tenant from specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="context">Resolution context</param>
        /// <returns></returns>
        Task ResolveTenant(TSource source, TenantResolutionContext context);
    }
}