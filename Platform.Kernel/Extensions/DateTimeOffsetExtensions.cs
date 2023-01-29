using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Kernel.Extensions
{
    static public class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Betweens the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lowDate">The low date.</param>
        /// <param name="highDate">The high date.</param>
        /// <param name="ignoreTime">if set to <c>true</c> [ignore time].</param>
        /// <returns></returns>
        public static bool Between(this DateTimeOffset value, DateTimeOffset lowDate, DateTimeOffset highDate, bool ignoreTime = false)
        {
            return (value.GreaterThan(lowDate, ignoreTime) && value.LessThan(highDate, ignoreTime));
        }

        /// <summary>
        /// Determines whether the specified value is after.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="test">The test.</param>
        /// <param name="ignoreTime">if set to <c>true</c> [ignore time].</param>
        /// <returns>
        ///   <c>true</c> if the specified value is after; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAfter(this DateTimeOffset value, DateTimeOffset test, bool ignoreTime = false)
        {
            return value.GreaterThan(test, ignoreTime);
        }

        /// <summary>
        /// Determines whether the specified value is before.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="test">The test.</param>
        /// <param name="ignoreTime">if set to <c>true</c> [ignore time].</param>
        /// <returns>
        ///   <c>true</c> if the specified value is before; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBefore(this DateTimeOffset value, DateTimeOffset test, bool ignoreTime = false)
        {
            return value.LessThan(test, ignoreTime);
        }

        /// <summary>
        /// Betweens the equal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lowDate">The low date.</param>
        /// <param name="highDate">The high date.</param>
        /// <param name="ignoreTime">if set to <c>true</c> [ignore time].</param>
        /// <returns></returns>
        public static bool BetweenOrEqual(this DateTimeOffset value, DateTimeOffset lowDate, DateTimeOffset highDate, bool ignoreTime = false)
        {
            return (value.GreaterThanOrEqual(lowDate, ignoreTime) && value.LessThanOrEqual(highDate, ignoreTime));
        }

        /// <summary>
        /// Greaters the than.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lowDate">The low date.</param>
        /// <param name="ignoreTime">if set to <c>true</c> [ignore time].</param>
        /// <returns></returns>
        public static bool GreaterThan(this DateTimeOffset value, DateTimeOffset lowDate, bool ignoreTime = false)
        {
            if (ignoreTime)
            {
                return (value.DatePart() > lowDate.DatePart());
            }
            else
            {
                return (value > lowDate);
            }
        }

        /// <summary>
        /// Greaters the than or equal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lowDate">The low date.</param>
        /// <param name="ignoreTime">if set to <c>true</c> [ignore time].</param>
        /// <returns></returns>
        public static bool GreaterThanOrEqual(this DateTimeOffset value, DateTimeOffset lowDate, bool ignoreTime = false)
        {
            if (ignoreTime)
            {
                return (value.DatePart() >= lowDate.DatePart());
            }
            else
            {
                return (value >= lowDate);
            }
        }

        /// <summary>
        /// Lesses the than.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="highDate">The high date.</param>
        /// <param name="ignoreTime">if set to <c>true</c> [ignore time].</param>
        /// <returns></returns>
        public static bool LessThan(this DateTimeOffset value, DateTimeOffset highDate, bool ignoreTime = false)
        {
            if (ignoreTime)
            {
                return value.DatePart() < highDate.DatePart();
            }
            else
            {
                return (value < highDate);
            }
        }

        /// <summary>
        /// Lesses the than or equal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="highDate">The high date.</param>
        /// <param name="ignoreTime">if set to <c>true</c> [ignore time].</param>
        /// <returns></returns>
        public static bool LessThanOrEqual(this DateTimeOffset value, DateTimeOffset highDate, bool ignoreTime = false)
        {
            if (ignoreTime)
            {
                return (value.DatePart() <= highDate.DatePart());
            }
            else
            {
                return (value <= highDate);
            }
        }

        /// <summary>
        /// Dates the part.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTimeOffset DatePart(this DateTimeOffset value)
        {
            return new DateTimeOffset(new DateTime(value.Year, value.Month, value.Day));
        }

        /// <summary>
        /// Subtracts the days.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="days">The days.</param>
        /// <returns></returns>
        public static DateTimeOffset SubtractDays(this DateTimeOffset value, int days)
        {
            return value.AddDays(-days);
        }

        /// <summary>
        /// Gets the start date of the month represented by this datetime (i.e. 20th Nov 2013 13:24,  will return 1st Nov 2013 00:00:00).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTimeOffset GetMonthStartDate(this DateTimeOffset value)
        {
            return new DateTimeOffset(new DateTime(value.Year, value.Month, 1));
        }

        /// <summary>
        /// Gets the end date of the month represented by this datetime (i.e. 20th Nov 2013 13:24,  will return 30th Nov 2013 23:59:59).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTimeOffset GetMonthEndDate(this DateTimeOffset value)
        {
            return new DateTimeOffset(new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month), 23, 59, 59));
        }
    }
}
