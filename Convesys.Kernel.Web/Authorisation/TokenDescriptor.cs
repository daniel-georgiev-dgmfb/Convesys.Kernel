using System;

namespace Twilight.Kernel.Web.Authorisation
{
    public class TokenDescriptor : IEquatable<TokenDescriptor>
    {
        private readonly uint _expireIn;
        #region Static operators
        /// <summary>
        ///     Overrides == operator to compare models on their IDs
        /// </summary>
        /// <param name="descriptor1"></param>
        /// <param name="descriptor2"></param>
        /// <returns></returns>
        public static bool operator ==(TokenDescriptor descriptor1, TokenDescriptor descriptor2)
        {
            if (((object)descriptor1) == null || ((object)descriptor2) == null)
                return Object.Equals(descriptor1, descriptor2);

            return descriptor1.Equals(descriptor2);
        }

        /// <summary>
        ///     Overrides != operator to compare models on their IDs
        /// </summary>
        /// <param name="descriptor1"></param>
        /// <param name="descriptor2"></param>
        /// <returns></returns>
        public static bool operator !=(TokenDescriptor descriptor1, TokenDescriptor descriptor2)
        {
            if (((object)descriptor1) == null || ((object)descriptor2) == null)
                return !Object.Equals(descriptor1, descriptor2);

            return !(descriptor1.Equals(descriptor2));
        }

        #endregion

        public TokenDescriptor(string tokenType, string token, DateTimeOffset issuedAt, uint expireIn)
        {
            if (String.IsNullOrWhiteSpace(tokenType))
                throw new ArgumentNullException(nameof(tokenType));
            if (String.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(nameof(token));
            if (issuedAt > DateTimeOffset.Now)
                throw new InvalidOperationException("Issued time in the future.");

            this.TokenType = tokenType;
            this.Token = token;
            this._expireIn = expireIn;
            this.IssuedAt = issuedAt;
        }

        public DateTimeOffset IssuedAt { get; private set; }

        public DateTimeOffset ExpireOn
        {
            get
            {
                return this.IssuedAt.AddSeconds(this._expireIn);
            }
        }

        public string Token { get; private set; }

        public string TokenType { get; private set; }

        public bool IsExpired { get { return DateTimeOffset.Now > this.ExpireOn; } }

        public bool Equals(TokenDescriptor other)
        {
            if (other == null)
                return false;

            return Object.Equals(this.TokenType, other.TokenType) && Object.Equals(this.Token, other.Token) && Object.Equals(this.ExpireOn, other.ExpireOn);
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

            var otherModel = obj as TokenDescriptor;

            if (otherModel == null)
                return false;
            return this.Equals(otherModel);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            if (this.Token != null)
                hash = unchecked((hash * 7) + this.Token.GetHashCode());
            if (this.TokenType != null)
                hash = unchecked((hash * 7) + this.TokenType.GetHashCode());
            hash = unchecked((hash * 7) + this.ExpireOn.GetHashCode());
            return hash;
        }
    }
}