using System;
using System.Collections.Specialized;

namespace Platform.Kernel.Tenancy
{
    /// <summary>
    /// Descriptor for a given tenant
    /// </summary>
    public class TenantDescriptor : IEquatable<TenantDescriptor>
    {
        private const string _tenantName = "TenantName";

        #region Static operators
        /// <summary>
		///     Overrides == operator to compare models on their IDs
		/// </summary>
		/// <param name="tenantDescriptor1"></param>
		/// <param name="tenantDescriptor2"></param>
		/// <returns></returns>
		public static bool operator ==(TenantDescriptor tenantDescriptor1, TenantDescriptor tenantDescriptor2)
        {
            if (((object)tenantDescriptor1) == null || ((object)tenantDescriptor2) == null)
                return Object.Equals(tenantDescriptor1, tenantDescriptor2);

            return tenantDescriptor1.Equals(tenantDescriptor2);
        }

        /// <summary>
        ///     Overrides != operator to compare models on their IDs
        /// </summary>
        /// <param name="tenantDescriptor1"></param>
        /// <param name="tenantDescriptor2"></param>
        /// <returns></returns>
        public static bool operator !=(TenantDescriptor tenantDescriptor1, TenantDescriptor tenantDescriptor2)
        {
            if (((object)tenantDescriptor1) == null || ((object)tenantDescriptor2) == null)
                return !Object.Equals(tenantDescriptor1, tenantDescriptor2);

            return !(tenantDescriptor1.Equals(tenantDescriptor2));
        }
        #endregion

        /// <summary>
        /// Tanant identifier
        /// </summary>
        public Guid TenantId { get; }

        /// <summary>
        /// Tenant name
        /// </summary>
        public string TenantName
        {
            get
            {
                return this.TenantAttributes.Get(TenantDescriptor._tenantName);
            }
        }

        /// <summary>
        /// Tenant connection string attributes
        /// </summary>
        public NameValueCollection TenantAttributes { get; }

        /// <summary>
        /// Instantiate an instance of TenantDescriptor
        /// </summary>
        /// <param name="id"></param>
        public TenantDescriptor(Guid id)
        {
            this.TenantId = id;
            this.TenantAttributes = new NameValueCollection();
        }

        public override string ToString()
        {
            return this.TenantId.ToString();
        }

        public bool Equals(TenantDescriptor other)
        {
            if (other == null)
                return false;

            return this.TenantId == other.TenantId;
        }

        public override int GetHashCode()
        {
            return this.TenantId.GetHashCode();
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

            var otherModel = obj as TenantDescriptor;

            if (otherModel == null)
                return false;
            return this.Equals(otherModel);
        }
    }
}