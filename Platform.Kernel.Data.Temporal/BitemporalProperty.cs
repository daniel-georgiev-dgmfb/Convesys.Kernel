using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Kernel.Data.Temporal
{
    public class BitemporalProperty<TValueType> : BitemporalTimeline<TValueType>, IBitemporalMarker
    {
        /// <summary>
        /// Gets the current value.
        /// </summary>
        /// <value>
        /// The current value.
        /// </value>
        public TValueType CurrentValue
        {
            get
            {
                return Value();
            }
        }

        /// <summary>
        /// Gets the current value.
        /// </summary>
        /// <returns></returns>
        public TValueType Value()
        {
            return Value(Interval.Now);
        }

        /// <summary>
        /// Returns the value valid on specified date based on what we know today.
        /// </summary>
        /// <param name="effectiveOn">The effective on date.</param>
        /// <returns></returns>
        public TValueType Value(DateTimeOffset effectiveOn)
        {
            return Value(Get(effectiveOn));
        }

        /// <summary>
        /// Returns the value valid on specified date as known on given date.
        /// </summary>
        /// <param name="effectiveOn">The effective on date</param>
        /// <param name="knownOn">The known on date</param>
        /// <returns></returns>
        public TValueType Value(DateTimeOffset effectiveOn, DateTimeOffset knownOn)
        {
            return Value(Get(effectiveOn, knownOn));
        }

        /// <summary>
        /// Gets the value from the BitemporalValue wrapper.
        /// </summary>
        /// <param name="bitemporalValue">The bitemporal value.</param>
        /// <returns></returns>
        private TValueType Value(BitemporalValue<TValueType> bitemporalValue)
        {
            return bitemporalValue == null ? default(TValueType) : bitemporalValue.Value;
        }

        /// <summary>
        /// Returns the bitemporal value as currently known. 
        /// </summary>
        /// <returns></returns>
        public BitemporalValue<TValueType> Get()
        {
            return Get(Interval.Now);
        }

        /// <summary>
        /// Returns the bitemporal value valid on the specified date based on what we know today.
        /// </summary>
        /// <param name="effectiveOn">The effective on.</param>
        /// <returns></returns>
        public BitemporalValue<TValueType> Get(DateTimeOffset effectiveOn)
        {
            return Get(effectiveOn, DateTimeOffset.UtcNow);
        }

        /// <summary>
        /// Returns the bitemporal value valid on specified date as known on the given date.
        /// </summary>
        /// <param name="effectiveOn">The effective on date</param>
        /// <param name="knownOn">The known on date.</param>
        /// <returns></returns>
        public BitemporalValue<TValueType> Get(DateTimeOffset effectiveOn, DateTimeOffset knownOn)
        {
            var item = GetList(effectiveOn, knownOn);

            return item;
        }

        /// <summary>
        /// Set the value of this bitemporal property. The new value will be valid from now onwards.
        /// </summary>
        /// <param name="value">The value.</param>
        public IBitemporalValue Set(TValueType value)
        {
            var now = Interval.FromNow();

            return Set(value, now, now);
        }

        /// <summary>
        /// Set the value of this bitemporal property for specified validity interval.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="effectiveInterval">The effective interval.</param>
        public IBitemporalValue Set(TValueType value, Interval effectiveInterval, bool continuous = false)
        {
            return Set(value, effectiveInterval, Interval.FromNow(), continuous);
        }

        /// <summary>
        /// Set the value of this bitemporal property for specified validity interval with the given transaction interval.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="effectiveInterval">The effective interval.</param>
        /// <param name="transactionInterval">The transaction interval.</param>
        /// <remarks>Use this carefully!  Should only be needed when migrating where we can to ensure transaction period are not lost
        /// for any historic data we migrate.</remarks>
        public IBitemporalValue Set(TValueType value, Interval effectiveInterval, Interval transactionInterval, bool continuous = false)
        {
            var bt = new BitemporalValue<TValueType>(value, effectiveInterval, transactionInterval, continuous);

            return AddTemporal(bt);
        }

        /// <summary>
        /// Invalidate the currently valid value.
        /// </summary>
        //public void Invalidate()
        //{
        //    var now = Interval.Now;
        //    GetList(now, now).ToList().ForEach(a => a.Invalidate());
        //}

        /// <summary>
        /// Invalidate the value that was effective on the given date.
        /// </summary>
        /// <param name="validOn">The valid on.</param>
        //public void Invalidate(DateTime effectiveOn)
        //{
        //    GetList(effectiveOn, Interval.Now).ToList().ForEach(a => a.Invalidate());
        //}

        /// <summary>
        /// Returns whether or not this property has a known value currently valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has value; otherwise, <c>false</c>.
        /// </returns>
        public bool HasValue()
        {
            return HasValue(Interval.Now);
        }

        /// <summary>
        /// Returns whether or not this property has a value valid on given date.
        /// </summary>
        /// <param name="effectiveOn">The effective on.</param>
        /// <returns>
        ///   <c>true</c> if [has value on] [the specified valid on]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasValue(DateTimeOffset effectiveOn)
        {
            return GetEvolution(effectiveOn).Count > 0;
        }

        /// <summary>
        /// Returns whether or not this property had a value valid on given date as known on specified date.
        /// </summary>
        /// <param name="effectiveOn">The effective on.</param>
        /// <param name="knownOn">The known on.</param>
        /// <returns>
        ///   <c>true</c> if [has value on] [the specified valid on]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasValue(DateTimeOffset effectiveOn, DateTimeOffset knownOn)
        {
            return GetList(effectiveOn, knownOn) != null;
        }

        /// <summary>
        /// Casts the plain instance of the class to it's underlying valuetype's value.
        /// </summary>
        /// <param name="wtp">The WTP.</param>
        /// <returns></returns>
        public static implicit operator TValueType(BitemporalProperty<TValueType> wtp)
        {
            if (wtp != null)
            {
                return wtp.CurrentValue;
            }
            else
            {
                return default(TValueType);
            }
        }

        /// <summary>
        /// ==s the specified a.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static bool operator ==(BitemporalProperty<TValueType> a, TValueType b)
        {
            if (a == null)
            {
                return false;
            }
            return a.Value().Equals(b);
        }

        /// <summary>
        /// !=s the specified a.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static bool operator !=(BitemporalProperty<TValueType> a, TValueType b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var obj = Value();
            return obj == null ? null : obj.ToString();
        }

        ///// <summary>
        ///// Bitemporals the property.
        ///// </summary>
        ///// <param name="rhs">The RHS.</param>
        ///// <returns></returns>
        //public static implicit operator BitemporalProperty<TValueType>(TValueType rhs)
        //{
        //    BitemporalProperty<TValueType> o = new BitemporalProperty<TValueType>();
        //    o.Set(rhs);
        //    return o;
        //}

    }
}
