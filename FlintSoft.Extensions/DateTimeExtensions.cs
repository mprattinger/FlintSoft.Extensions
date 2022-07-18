using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FlintSoft.Extensions
{
    public static class DateTimeExtensions
    {
        public static (DateTime first, DateTime last) GetTimestampsForADay(this DateTime adate)
        {
            var f = DateTime.Parse($"{adate.ToShortDateString()}");
            var l = DateTime.Parse($"{adate.AddDays(1).ToShortDateString()}");
            return (f, l);
        }

        public static bool IsSaturday(this DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday) return true;
            else return false;
        }

        public static bool IsSunday(this DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Sunday) return true;
            else return false;
        }

        public static DateTime NormalizeDateTime(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
        }

        public static DateTime NormalizeFullHour(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
        }

        public static DateTime FirstDayOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime FirstDayOfMonth(this DateTime dayOfMonth)
        {
            return new DateTime(dayOfMonth.Year, dayOfMonth.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime dayOfMonth)
        {
            return dayOfMonth.FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstDayOfYear(this DateTime dayOfMonth)
        {
            return new DateTime(dayOfMonth.Year, 1, 1);
        }

        public static DateTime LastDayOfYear(this DateTime dayOfMonth)
        {
            return dayOfMonth.FirstDayOfYear().AddYears(1).AddDays(-1);
        }

        public static DateTime Next(this DateTime dt, DayOfWeek dow) {
            int start = (int)dt.DayOfWeek;
            int target = (int)dow;
            if (target <= start)
                target += 7;
            return dt.AddDays(target - start);
        }

        public static string ToMonthView(this DateTime date, CultureInfo ci = null)
        {
            CultureInfo cultureInfo;
            if (ci == null) cultureInfo = new CultureInfo("de-AT");
            else cultureInfo = ci;

            return date.ToString("MMMM yyyy", cultureInfo);
        }

        public static int GetYears(this TimeSpan timespan)
        {
            return (int)(timespan.Days / 365.2425);
        }
        public static int GetMonths(this TimeSpan timespan)
        {
            return (int)(timespan.Days / 30.436875);
        }

        public static string NiceTimespan(this TimeSpan ts)
        {
            var h = ts.Hours < 10 ? $"0{ts.Hours}" : ts.Hours.ToString();
            var m = ts.Minutes < 10 ? $"0{ts.Minutes}" : ts.Minutes.ToString();

            return $"{h}:{m} ({ts.TotalHours})";
        }
    }
}
