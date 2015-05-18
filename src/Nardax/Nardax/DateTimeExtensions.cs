using System;
using System.Globalization;

namespace Nardax
{
    public static class DateTimeExtensions
    {
        public static DateTime Floor(this DateTime dateTime, TimeSpan timeSpan)
        {
            var ticks = dateTime.Ticks / timeSpan.Ticks;
            return new DateTime(ticks * timeSpan.Ticks);
        }

        public static DateTime Round(this DateTime dateTime, TimeSpan timeSpan)
        {
            var ticks = (dateTime.Ticks + (timeSpan.Ticks / 2) + 1) / timeSpan.Ticks;
            return new DateTime(ticks * timeSpan.Ticks);
        }

        public static DateTime Ceiling(this DateTime dateTime, TimeSpan timeSpan)
        {
            var ticks = (dateTime.Ticks + timeSpan.Ticks - 1) / timeSpan.Ticks;
            return new DateTime(ticks * timeSpan.Ticks);
        }

        public static DateTime Min(this DateTime dateTime, DateTime value)
        {
            return dateTime <= value ? dateTime : value;
        }

        public static DateTime Max(this DateTime dateTime, DateTime value)
        {
            return dateTime >= value ? dateTime : value;
        }

        public static int SecondsFrom(this DateTime dateTime, DateTime from)
        {
            var timeSpan = (dateTime - from);
            return Convert.ToInt32(timeSpan.TotalSeconds);
        }

        public static DateTime GetUnixEpoch()
        {
            return new DateTime(1970, 1, 1);
        }

        public static int SecondsFromUnixEpoch(this DateTime dateTime)
        {
            return dateTime.SecondsFrom(GetUnixEpoch());
        }

        public static double MillisecondOfDay(this DateTime dateTime)
        {
            return dateTime.TimeOfDay.TotalMilliseconds;
        }

        public static DateTime Midnight(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        public static DateTime Noon(this DateTime dateTime)
        {
            return dateTime.SetTime(12);
        }
        public static Boolean IsBetween(this DateTime dateTime, DateTime startDateTime, DateTime endDateTime)
        {
            return dateTime.IsBetween(startDateTime, endDateTime, true);
        }

        public static Boolean IsBetween(this DateTime dateTime, DateTime startDateTime, DateTime endDateTime, bool compareTime)
        {
            if (compareTime)
            {
                return dateTime >= startDateTime && dateTime <= endDateTime;
            }

            return dateTime.Date >= startDateTime.Date && dateTime.Date <= endDateTime.Date;
        }
        
        public static DateTime SetTime(this DateTime dateTime, int hour)
        {
            return SetTime(dateTime, hour, 0, 0, 0);
        }

        public static DateTime SetTime(this DateTime dateTime, int hour, int minute)
        {
            return SetTime(dateTime, hour, minute, 0, 0);
        }

        public static DateTime SetTime(this DateTime dateTime, int hour, int minute, int second)
        {
            return SetTime(dateTime, hour, minute, second, 0);
        }

        public static DateTime SetTime(this DateTime dateTime, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, minute, second, millisecond);
        }

        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        public static string ToString(this DateTime? date)
        {
            return date.ToString(null, DateTimeFormatInfo.CurrentInfo);
        }

        public static string ToString(this DateTime? date, string format)
        {
            return date.ToString(format, DateTimeFormatInfo.CurrentInfo);
        }

        public static string ToString(this DateTime? date, IFormatProvider provider)
        {
            return date.ToString(null, provider);
        }

        public static string ToString(this DateTime? date, string format, IFormatProvider provider)
        {
            if (date.HasValue)
            {
                return date.Value.ToString(format, provider);
            }

            return string.Empty;
        }

        public static string ToRelativeDateString(this DateTime date)
        {
            return GetRelativeDateValue(date, DateTime.Now);
        }

        public static string ToRelativeDateStringUtc(this DateTime date)
        {
            return GetRelativeDateValue(date, DateTime.UtcNow);
        }

        private static string GetRelativeDateValue(DateTime date, DateTime comparedTo)
        {
            var diff = comparedTo.Subtract(date);

            if (diff.TotalDays >= 365)
            {
                return string.Concat("on ", date.ToString("MMMM d, yyyy"));
            }

            if (diff.TotalDays >= 7)
            {
                return string.Concat("on ", date.ToString("MMMM d"));
            }

            if (diff.TotalDays > 1)
            {
                return string.Format("{0:N0} days ago", diff.TotalDays);
            }

            if (diff.TotalDays == 1)
            {
                return "yesterday";
            }

            if (diff.TotalHours >= 2)
            {
                return string.Format("{0:N0} hours ago", diff.TotalHours);
            }

            if (diff.TotalMinutes >= 60)
            {
                return "more than an hour ago";
            }

            if (diff.TotalMinutes >= 5)
            {
                return string.Format("{0:N0} minutes ago", diff.TotalMinutes);
            }

            if (diff.TotalMinutes >= 1)
            {
                return "a few minutes ago";
            }

            return "less than a minute ago";
        }
    }
}
