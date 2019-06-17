using System;
using System.Collections.Generic;
using System.Text;

namespace TeamTech.Common
{
    public static class TimeZoneUtils
    {
        /// <summary>
        /// Returns TimeZone adjusted time for a given from a Utc or local time.
        /// Date is first converted to UTC then adjusted.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="timeZoneId"></param>
        /// <returns></returns>
        public static DateTime ToTimeZoneTime(this DateTime time, string timeZoneId)
        {
            var tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var date = TimeZoneInfo.ConvertTimeFromUtc(time, tzi);
            return date;
        }

        public static DateTime? ToTimeZoneTime(this DateTime? time, string timeZoneId)
        {
            var tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var date = time.HasValue ? TimeZoneInfo.ConvertTimeFromUtc(time.Value, tzi) : (DateTime?)null;
            return date;
        }
    }
}
