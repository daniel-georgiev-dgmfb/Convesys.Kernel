using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Kernel.Data.Temporal
{
    public class BitemporalValue<TValueType> : IBitemporalValue, IBitemporalMarker
    {
        public bool IsTemporary
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitemporalValue{TValueType}"/> class.
        /// </summary>
        protected BitemporalValue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitemporalValue{TValueType}" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public BitemporalValue(TValueType value)
        {
            var now = Interval.FromNow();
            TransactionInterval = now;
            EffectiveInterval = now;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitemporalValue{TValueType}" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="effectiveInterval">The effective interval.</param>
        /// <exception cref="System.ArgumentException">The effective interval is required.</exception>
        public BitemporalValue(TValueType value, Interval effectiveInterval, bool continuous)
            : this(value, effectiveInterval, Interval.FromNow(), continuous)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="BitemporalValue{TValueType}" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="effectiveInterval">The effective interval.</param>
        /// <param name="transactionInterval">The transaction interval.</param>
        /// <exception cref="System.ArgumentNullException">effectiveInterval;The effective interval is required.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">transactionInterval;The transaction interval specified cannot have a future start date.</exception>
        public BitemporalValue(TValueType value, Interval effectiveInterval, Interval transactionInterval, bool continuous)
        {
            if (effectiveInterval == null)
            {
                throw new ArgumentNullException("effectiveInterval", "The effective interval is required.");
            }
            if (transactionInterval == null)
            {
                throw new ArgumentNullException("transactionInterval", "The transaction interval is required.");
            }
            if (transactionInterval.Start > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("transactionInterval", transactionInterval.Start, "The transaction interval specified cannot have a future start date.");
            }

            TransactionInterval = transactionInterval;

            EffectiveInterval = effectiveInterval;

            Value = value;

            if (continuous)
            {
                IsTemporary = continuous;

                TransactionInterval = new Interval(TransactionInterval.Start, EffectiveInterval.End);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public TValueType Value { get; set; }

        /// <summary>
        /// Gets the transaction interval.
        /// </summary>
        /// <value>
        /// The transaction interval.
        /// </value>
        public Interval TransactionInterval { get; private set; }

        /// <summary>
        /// Gets the effective interval.
        /// </summary>
        /// <value>
        /// The effective interval.
        /// </value>
        public Interval EffectiveInterval { get; private set; }

        /// <summary>
        /// Ends this instance.
        /// </summary>
        public void Invalidate()
        {
            Invalidate(Interval.Now);
        }

        /// <summary>
        /// Invalidates the specified invalidate date.
        /// </summary>
        /// <param name="invalidateDate">The invalidate date.</param>
        public void Invalidate(DateTimeOffset onThisDate)
        {
            TransactionInterval = new Interval(TransactionInterval.Start, onThisDate);
        }

        /// <summary>
        /// Invalidates the specified on this date.
        /// </summary>
        /// <param name="onThisDate">The on this date.</param>
        public void Invalidate(DateTime onThisDate)
        {
            Invalidate(new DateTimeOffset(onThisDate));
        }

        /// <summary>
        /// Copies the with.
        /// </summary>
        /// <param name="theseEffectiveDates">The effective interval.</param>
        /// <returns></returns>
        public BitemporalValue<TValueType> CopyWith(Interval theseEffectiveDates)
        {
            return new BitemporalValue<TValueType>(Value, theseEffectiveDates, IsTemporary);
        }

        /// <summary>
        /// Copies the with.
        /// </summary>
        /// <param name="theseEffectiveDates">The these effective dates.</param>
        /// <param name="theseTransactionDates">The these transaction dates.</param>
        /// <returns></returns>
        public BitemporalValue<TValueType> CopyWith(Interval theseEffectiveDates, Interval theseTransactionDates)
        {
            return new BitemporalValue<TValueType>(Value, theseEffectiveDates, theseTransactionDates, IsTemporary);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} ~ {1} ~ {2}", Value, EffectiveInterval, TransactionInterval);
        }
    }
}
