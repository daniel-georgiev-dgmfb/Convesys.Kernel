using Platform.Kernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Kernel.Data.Temporal
{
    public abstract class BitemporalTimeline<TValueType> : IBitemporalMarker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BitemporalTimeline{TValueType}"/> class.
        /// </summary>
        protected BitemporalTimeline()
        {
            Timeline = new List<BitemporalValue<TValueType>>();
        }

        /// <summary>
        /// Gets the timeline.
        /// </summary>
        /// <value>
        /// The timeline.
        /// </value> 
        private List<BitemporalValue<TValueType>> Timeline { get; set; }

        /// <summary>
        /// Gets a list items that are valid and effective as of the dates provided.
        /// </summary>
        /// <param name="effectiveOn">The effective on date</param>
        /// <param name="knownOn">The known on date</param>
        /// <returns></returns>
        public BitemporalValue<TValueType> GetList(DateTimeOffset effectiveOn, DateTimeOffset knownOn)
        {
            var effective = Timeline.Where(d => d.EffectiveInterval.Contains(effectiveOn)).ToList();

            if (effective.Count == 0)
                return null;

            if (effective.Any(t => t.IsTemporary))
            {
                var allTemp = effective.Where(c => c.IsTemporary && (c.TransactionInterval.Contains(knownOn)
                        || c.TransactionInterval.End < knownOn)).ToList();

                if (allTemp.Count > 0)
                    return allTemp.OrderByDescending(s => s.EffectiveInterval.Start).FirstOrDefault();
            }

            if (effective.Count == 1)
                return effective.FirstOrDefault(t => t.TransactionInterval.Contains(knownOn) || (t.TransactionInterval.Contains(effectiveOn) && t.TransactionInterval.End < knownOn));

            var value = effective.FirstOrDefault(t => !t.IsTemporary && t.TransactionInterval.Contains(knownOn));

            return value;
        }

        /// <summary>
        /// Gets the history of the tracked value as know from the point in time of the observer.
        /// The history tells you about how the valid value changed over time.
        /// </summary>
        /// <param name="knownOn">The known on.</param>
        /// <returns></returns>
        public IList<BitemporalValue<TValueType>> GetHistory(DateTimeOffset knownOn)
        {
            return Timeline.Where(d => d.TransactionInterval.Contains(knownOn)).ToList();
        }

        /// <summary>
        /// Returns the history of the value as currently known.
        /// This informs you about how the valid value changed, as we currently know it.
        /// </summary>
        /// <returns></returns>
        public IList<BitemporalValue<TValueType>> GetHistory()
        {
            return GetHistory(Interval.Now);
        }

        /// <summary>
        /// Returns the evolution of the value currently valid.
        /// This informs you about how our knowledge about the value currently valid evolved.
        /// </summary>
        /// <returns></returns>
        public IList<BitemporalValue<TValueType>> GetEvolution()
        {
            return GetEvolution(Interval.Now);
        }


        /// <summary>
        /// Gets the evolution of the tracked value for specified effective date.
        /// The evolution tells you about how knowledge about the value valid at a certain date evolved.
        /// </summary>
        /// <param name="effectiveOn">The effective on.</param>
        /// <returns></returns>
        public IList<BitemporalValue<TValueType>> GetEvolution(DateTimeOffset effectiveOn)
        {
            return Timeline.Where(d => d.EffectiveInterval.Contains(effectiveOn)).OrderByDescending(d => d.EffectiveInterval.Start).ToList();
        }

        /// <summary>
        /// Adds the specified new value.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public IBitemporalValue AddTemporal(BitemporalValue<TValueType> newValue)
        {
            FutureTransactionCheck(newValue.TransactionInterval);

            var toInvalidate = new HashSet<BitemporalValue<TValueType>>();

            var history = GetHistory(Interval.Now);

            // find all records that overlap the new value
            if (!newValue.IsTemporary)
            {
                foreach (var possibleOverlap in history)
                {
                    if (newValue.EffectiveInterval.Overlaps(possibleOverlap.EffectiveInterval))
                    {
                        toInvalidate.Add(possibleOverlap);
                    }
                }

                var invalidationDate = newValue.TransactionInterval.Start;

                foreach (var toBeInvalidated in toInvalidate)
                {
                    toBeInvalidated.Invalidate(invalidationDate);
                }
            }

            var bt = (BitemporalValue<TValueType>)newValue.CopyWith(newValue.EffectiveInterval, newValue.TransactionInterval);

            Timeline.Add(bt);

            return bt;
        }

        /// <summary>
        /// Checks the data for any future dated transaction intervals
        /// </summary>
        /// <param name="transactionInterval">The transaction interval.</param>
        /// <exception cref="System.InvalidOperationException">Cannot work with bi-temporal data - data contains future transactions</exception>
        private void FutureTransactionCheck(Interval transactionInterval)
        {
            if (transactionInterval.Start > Interval.Now)
            {
                throw new InvalidOperationException("Future transaction dates are not supported.");
            }
            if (Timeline.Count(c => c.TransactionInterval.Start.GreaterThan(Interval.Now)) > 0)
            {
                throw new InvalidOperationException("Bi-temporal data contains future transactions.");
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in Timeline)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
