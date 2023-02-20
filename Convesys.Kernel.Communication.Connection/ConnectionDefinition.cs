using Twilight.Kernel.Communication.Common;
using System;

namespace Twilight.Kernel.Communication.Connection
{
    public class ConnectionDefinition : BaseDefinition, ICloneable, IEquatable<ConnectionDefinition>
    {
        #region properties

        /// <summary>
        ///     Gets or sets the IP address.
        /// </summary>
        /// <value>
        ///     The IP address.
        /// </value>
        public long IPAddress { get; set; }

        /// <summary>
        ///     Gets or sets the port.
        ///     Probably never used.
        ///     Not used for PC21 connections.
        ///     Unlikely to be used for CR1 connections.
        ///     Will be used, but as a constant, for E2210 MXIO devices.
        /// </summary>
        /// <value>
        ///     The port.
        /// </value>
        public int Port { get; set; }

        /// <summary>
        ///     Gets or sets the channel.
        /// </summary>
        /// <value>
        ///     The channel.
        /// </value>
        public byte Channel { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Clones this instance.
        /// </summary>
        /// <returns></returns>
        public ConnectionDefinition Clone()
        {
            return new ConnectionDefinition
            {
                Id = this.Id,
                IPAddress = this.IPAddress,
                Port = this.Port,
                Channel = this.Channel
            };
        }

        /// <summary>
        ///     Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        ///     A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(ConnectionDefinition other)
        {
            if (other == null)
                return false;

            return
            (
            other.IPAddress == this.IPAddress &&
            other.Port == this.Port &&
            other.Channel == this.Channel
            );
        }

        #endregion
    }
}