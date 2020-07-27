using System;

namespace Convesys.Kernel.Web
{
    public class Endpoint : IEquatable<Endpoint>
    {
        public Uri Endpont { get; }

        #region Static operators
        /// <summary>
		///     Overrides == operator to compare endpoints on their uri
		/// </summary>
		/// <param name="endpoint1"></param>
		/// <param name="endpoint2"></param>
		/// <returns></returns>
		public static bool operator ==(Endpoint endpoint1, Endpoint endpoint2)
        {
            if (((object)endpoint1) == null || ((object)endpoint2) == null)
                return Object.Equals(endpoint1, endpoint2);

            return endpoint1.Equals(endpoint2);
        }

        /// <summary>
        ///     Overrides != operator to compare models on their IDs
        /// </summary>
        /// <param name="endpoint1"></param>
        /// <param name="endpoint2"></param>
        /// <returns></returns>
        public static bool operator !=(Endpoint endpoint1, Endpoint endpoint2)
        {
            if (((object)endpoint1) == null || ((object)endpoint2) == null)
                return !Object.Equals(endpoint1, endpoint2);

            return !(endpoint1.Equals(endpoint2));
        }
        #endregion
        public Endpoint(string uri)
        {
            if (String.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException(nameof(uri));
            this.Endpont = new Uri(uri);
        }

        public Endpoint(Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));
            this.Endpont = uri;
        }

        public Endpoint(string baseUrl, string relative)
        {
            if (String.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentNullException(nameof(baseUrl));
            if (String.IsNullOrWhiteSpace(relative))
                throw new ArgumentNullException(nameof(relative));

            this.Endpont = new Uri(new Uri(baseUrl), relative);
        }

        public override string ToString()
        {
            return this.Endpont.ToString();
        }

        public bool Equals(Endpoint other)
        {
            if (other == null)
                return false;
            return this.Endpont == other.Endpont;
        }

        public override int GetHashCode()
        {
            return this.Endpont.GetHashCode();
        }

        /// <summary>
		///     Overrides Object.Equals to compare endpoint uri
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var otherModel = obj as Endpoint;

            if (otherModel == null)
                return false;
            return this.Equals(otherModel);
        }
    }
}