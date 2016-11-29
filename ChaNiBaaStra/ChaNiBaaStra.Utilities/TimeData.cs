using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissEphNet;
using GeoTimeZone;

namespace ChaNiBaaStra.Utilities
{
    public class TimeData
    {
        public TimeData(DateTime utDateTime)
        {
            EnteredDateTime = utDateTime;
        }
        public DateTime EnteredDateTime { get; set; }

        public DateTime UTCDateTime { get { return EnteredDateTime.ToUniversalTime(); } }

        public double JulianDateTime { get { return EnteredDateTime.ToOADate() + 2415018.5; } }

        /* public static DateTime JulianToDateTime(double julianDate)
         {
             int jDate = Convert.ToInt32(julianDate);
             int day = jDate % 1000;
             int year = (jDate - day + 2000000) / 1000;
             var date1 = new DateTime(year, 1, 1);
             return date1.AddDays(day - 1);
         }*/
        /// <summary>
        /// Julian day conversion
        /// </summary>
        /// <param name="injulian"> Julian day in UT</param>
        /// <returns>Julian day in UT</returns>
        public static double JulianUTToJulianET(double injulian)
        {
            SwissEph swissEph = new SwissEph();
            return injulian + swissEph.swe_deltat(injulian); //where tjd = Julian day in UT, tjde = in ET
        }

        public static DateTime JulianToDateTime(double injulianUT, double zone)
        {
            double julianET = JulianUTToJulianET(injulianUT);
            SwissEph swissEph = new SwissEph();
            int year = 0;
            int month = 0;
            int day = 0;
            int h = 0;
            int m = 0;
            double s = 0;
            swissEph.swe_jdet_to_utc(julianET, 1, ref year, ref month, ref day, ref h, ref m, ref s);
            /*
            int JGREG = 15 + 31 * (10 + 12 * 1582);
            double HALFSECOND = 0.5;

            int jalpha, ja, jb, jc, jd, je, year, month, day;
            double julian = injulian + HALFSECOND / 86400.0;
            ja = (int)injulian;
            if (ja >= JGREG)
            {
                jalpha = (int)(((ja - 1867216) - 0.25) / 36524.25);
                ja = ja + 1 + jalpha - jalpha / 4;
            }

            jb = ja + 1524;
            jc = (int)(6680.0 + ((jb - 2439870) - 122.1) / 365.25);
            jd = 365 * jc + jc / 4;
            je = (int)((jb - jd) / 30.6001);
            day = jb - jd - (int)(30.6001 * je);
            month = je - 1;
            if (month > 12) month = month - 12;
            year = jc - 4715;
            if (month > 2) year--;
            if (year <= 0) year--;
            */
            DateTime utcDateTime = new DateTime(year, month, day, h, m, (int)s, DateTimeKind.Utc);

            double actualOffset = zone;
            TimeSpan ts = TimeZoneInfo.Local.BaseUtcOffset;
            double standardOffset = ts.TotalMinutes / 60.0;
            double adjustment = (actualOffset - standardOffset) * 60 * -1;

            double minAdjustment = (int)adjustment;
            double secAdjustment = (adjustment - minAdjustment) * 60;

            //return locationDateTime.AddMinutes((int)minAdjustment).AddSeconds(secAdjustment);

            return utcDateTime.ToLocalTime();
        }
    }
}
