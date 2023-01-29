using Platform.Kernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Kernel.Data.Temporal
{
    /// <summary>
    /// Describes an interval between two dates.
    /// </summary>
    public class Interval
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Interval"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public Interval(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Gets the interval start (from) date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTimeOffset Start { get; private set; }

        /// <summary>
        /// Gets the interval end (to) date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTimeOffset End { get; private set; }

        /// <summary>
        /// Invalidates this instance.
        /// </summary>
        public void Invalidate()
        {
            Invalidate(DateTimeOffset.Now);
        }

        /// <summary>
        /// Invalidates the specified end date.
        /// </summary>
        /// <param name="endDate">The end date.</param>
        public void Invalidate(DateTimeOffset fromThisDate)
        {
            End = fromThisDate;
        }

        /// <summary>
        /// Creates a new interval from now until the max date.
        /// </summary>
        /// <returns></returns>
        public static Interval FromNow()
        {
            return new Interval(Now, MaxDate);
        }

        /// <summary>
        /// Creates an interval from the given date until the max date.
        /// </summary>
        /// <param name="fromThisDate">From this date.</param>
        /// <returns></returns>
        public static Interval FromDate(DateTimeOffset fromThisDate)
        {
            return new Interval(fromThisDate, MaxDate);
        }


        /// <summary>
        /// Froms the date.
        /// </summary>
        /// <param name="fromThisDate">From this date.</param>
        /// <returns></returns>
        public static Interval FromDate(DateTime fromThisDate)
        {
            return new Interval(fromThisDate, MaxDate);
        }


        /// <summary>
        /// Froms the date.
        /// </summary>
        /// <param name="fromThisDate">From this date.</param>
        /// <param name="toThisDate">To this date.</param>
        /// <returns></returns>
        public static Interval FromDate(DateTime fromThisDate, DateTime toThisDate)
        {
            return new Interval(fromThisDate, toThisDate);
        }

        /// <summary>
        /// Froms the date.
        /// </summary>
        /// <param name="fromThisDate">From this date.</param>
        /// <param name="toThisDate">To this date.</param>
        /// <returns></returns>
        public static Interval FromDate(DateTimeOffset fromThisDate, DateTimeOffset toThisDate)
        {
            return new Interval(fromThisDate, toThisDate);
        }

        /// <summary>
        /// Gets the system date as of now.
        /// </summary>
        /// <value>
        /// The now date.
        /// </value>
        public static DateTimeOffset Now
        {
            get { return DateTimeOffset.UtcNow; }
        }

        /// <summary>
        /// Gets the forever (max) date.
        /// </summary>
        /// <value>
        /// The forever date.
        /// </value>
        public static DateTimeOffset MaxDate
        {
            get { return DateTimeOffset.MaxValue; }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0:o} to {1:o}", Start, End);
        }

        /// <summary>
        /// Determines whether the given date sits inside of the interval.
        /// </summary>
        /// <param name="test">The test.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified test]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(DateTimeOffset test)
        {
            return test.BetweenOrEqual(Start, End, false);
        }

        /// <summary>
        /// Determines whether the given date overlaps the interval.
        /// </summary>
        /// <param name="test">The test.</param>
        /// <returns></returns>
        public bool Overlaps(Interval test)
        {
            return test.Start.LessThanOrEqual(End) && test.End.GreaterThanOrEqual(Start);
        }
    }
}
