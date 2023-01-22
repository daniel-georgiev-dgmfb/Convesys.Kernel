using Convesys.Kernel.Web;
using Convesys.Kernel.Web.Authorisation;
using System;

namespace Convesys.Kernel.Tenancy
{
    /// <summary>
    /// Represents the context of the tenant resolution
    /// </summary>
    public class TenantResolutionContext : IEquatable<TenantResolutionContext>
    {
        #region Static operators
        /// <summary>
		///     Overrides == operator to compare models on their IDs
		/// </summary>
		/// <param name="context1"></param>
		/// <param name="context2"></param>
		/// <returns></returns>
		public static bool operator ==(TenantResolutionContext context1, TenantResolutionContext context2)
        {
            if (((object)context1) == null || ((object)context2) == null)
                return Object.Equals(context1, context2);

            return context1.Equals(context2);
        }

        /// <summary>
        ///     Overrides != operator to compare models on their IDs
        /// </summary>
        /// <param name="context1"></param>
        /// <param name="context2"></param>
        /// <returns></returns>
        public static bool operator !=(TenantResolutionContext context1, TenantResolutionContext context2)
        {
            if (((object)context1) == null || ((object)context2) == null)
                return !Object.Equals(context1, context2);

            return !(context1.Equals(context2));
        }
        #endregion

        /// <summary>
        /// Return true if the tenant has been set otherwise false
        /// </summary>
        public bool IsResolved { get { return this.TenantDescriptor != null; } }

        /// <summary>
        /// Represents resolved tenant attributes
        /// </summary>
        public TenantDescriptor TenantDescriptor { get; private set; }

        /// <summary>
        /// Tenant service endpoint
        /// </summary>
        public Endpoint TenantEndpoint { get; }

        /// <summary>
        /// Credentials to abtain a bearer token
        /// </summary>
        public IBearerTokenContext ClientCredentials { get; }

        public TenantResolutionContext(Endpoint endpoint, IBearerTokenContext clientCredentials)
        {
            if (endpoint == null)
                throw new ArgumentNullException(nameof(endpoint));
            if (clientCredentials == null)
                throw new ArgumentNullException(nameof(clientCredentials));

            this.TenantEndpoint = endpoint;
            this.ClientCredentials = clientCredentials;
        }

        /// <summary>
        /// Set tenant descriptor
        /// </summary>
        /// <param name="tenantDescriptor"></param>
        public void Resolved(TenantDescriptor tenantDescriptor)
        {
            this.TenantDescriptor = tenantDescriptor;
        }

        public bool Equals(TenantResolutionContext other)
        {
            if (other == null)
                return false;

            if (!this.IsResolved || !other.IsResolved)
                return false;
            if (this.TenantEndpoint == null || other.TenantEndpoint == null)
                return false;

            return this.TenantDescriptor == other.TenantDescriptor && this.TenantEndpoint == other.TenantEndpoint;
        }

        /// <summary>
		///     Overrides Object.Equals to compare descriptors on tenant id
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var otherModel = obj as TenantResolutionContext;

            if (otherModel == null)
                return false;
            return this.Equals(otherModel);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            if(this.TenantEndpoint != null)
                hash = unchecked((hash * 7) + this.TenantEndpoint.GetHashCode());
            if(this.TenantDescriptor != null)
                hash = unchecked((hash * 7) + this.TenantDescriptor.GetHashCode());
            return hash;
        }
    }
}