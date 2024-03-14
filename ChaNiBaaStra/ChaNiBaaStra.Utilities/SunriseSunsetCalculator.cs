using System;
using SunriseCalculator;
using SwissEphNet;
using TimeZoneConverter;
namespace ChaNiBaaStra.Utilities
{
    public static class SunriseSunsetCalculator
    {
        public static Tuple<DateTime, DateTime> GetSunriseSunset(DateTime date, double longitude, double latitude)
        {
            SunriseCalc newYorkCity = new SunriseCalc(latitude: latitude, longitude: longitude, date);

            // Get today's sunrise and sunset times for New York City, in UTC.
            newYorkCity.GetRiseAndSet(out DateTime todaysSunriseUTC, out DateTime todaysSunsetUTC);

            DateTime SunRise = todaysSunriseUTC.AddHours(longitude / 15 + 1);
            DateTime SunSet = todaysSunsetUTC.AddHours(longitude / 15 +1);

            return Tuple.Create(SunRise, SunSet);
        }

        //public static Tuple<DateTime, DateTime> GetSunriseSunset(DateTime date, double longitude, double latitude)
        //{
        //    const int SE_MAXCH = 256;
        //    string serr = new string(new char[SE_MAXCH]);
        //    int epheflag = SwissEph.SEFLG_SWIEPH;
        //    int gregflag = SwissEph.SEFLG_SIDEREAL;
        //    double geo_altitude = 0.0;
        //    double[] datm = new double[2] { 1013.25, 15 }; // atmospheric pressure and temperature

        //    SwissEph d = new SwissEph();
        //    d.swe_set_topo(longitude, latitude, geo_altitude);
        //    d.swe_set_ephe_path(null);

        //    int ipl = SwissEph.SE_SUN; // Object whose rising or setting is wanted
        //    string starname = ""; // Name of star, if a star's rising is wanted
        //    double trise; // For rising time
        //    double tset;  // For setting time

        //    // Calculate the Julian day number of the date at 0:00 UT
        //    double tjd = d.swe_julday(date.Year, date.Month, date.Day, 0, gregflag);

        //    // Calculation flag for Hindu risings/settings
        //    int rsmi = SwissEph.SE_CALC_RISE | SwissEph.SE_BIT_HINDU_RISING;
        //    trise = 0;
        //    int return_code = d.swe_rise_trans(tjd, ipl, starname, epheflag, rsmi, new double[] { longitude, latitude, geo_altitude }, datm[0], datm[1], ref trise, ref serr);
        //    if (return_code == SwissEph.ERR)
        //    {
        //        // Error action
        //        Console.WriteLine(serr);
        //    }

        //    // Convert Julian day number of the rising time into date and time
        //    double riseHour = 0;
        //    int riseYear = date.Year, riseMonth = date.Month, riseDay = date.Day;
        //    d.swe_revjul(trise, gregflag, ref riseYear, ref riseMonth, ref riseDay, ref riseHour);

        //    // Convert decimal hour value to hour and minute components
        //    int riseHourInt = (int)riseHour;
        //    int riseMinute = (int)((riseHour - riseHourInt) * 60);

        //    // Convert UTC time to local time (IST)
        //    int iyear_out, imonth_out, iday_out, ihour_out, imin_out;
        //    double dsec_out;
        //    iyear_out = 0; imonth_out = 0; iday_out = 0; ihour_out = 0; imin_out = 0; dsec_out = 0;
        //    DateTime sunriseUTC = new DateTime(riseYear, riseMonth, riseDay, riseHourInt, riseMinute, 0);

        //    d.swe_utc_time_zone(sunriseUTC.Year, sunriseUTC.Month, sunriseUTC.Day, sunriseUTC.Hour, sunriseUTC.Minute, sunriseUTC.Second, -1*longitude/15,
        //        ref iyear_out, ref imonth_out, ref iday_out, ref ihour_out, ref imin_out, ref dsec_out);
        //    DateTime sunriseLocal = new DateTime(iyear_out, imonth_out, iday_out, ihour_out, imin_out, (int)dsec_out);
        //    sunriseLocal = TimeZoneConverter.ConvertUtcToLocationTime(sunriseUTC, longitude, latitude);


        //    // Calculation flag for sunset
        //    rsmi = SwissEph.SE_CALC_SET | SwissEph.SE_BIT_DISC_CENTER | SwissEph.SE_BIT_NO_REFRACTION;
        //    tset = 0;
        //    return_code = d.swe_rise_trans(tjd, ipl, starname, epheflag, rsmi, new double[] { longitude, latitude, geo_altitude }, datm[0], datm[1], ref tset, ref serr);
        //    if (return_code == SwissEph.ERR)
        //    {
        //        // Error action
        //        Console.WriteLine(serr);
        //    }

        //    // Convert Julian day number of the sunset time into date and time
        //    double setHour = 0;
        //    int setYear = date.Year, setMonth = date.Month, setDay = date.Day;
        //    d.swe_revjul(tset, gregflag, ref setYear, ref setMonth, ref setDay, ref setHour);

        //    // Convert decimal hour value to hour and minute components
        //    int setHourInt = (int)setHour;
        //    int setMinute = (int)((setHour - setHourInt) * 60);

        //    // Convert UTC time to local time (IST)
        //    //DateTime sunsetUTC = new DateTime(setYear, setMonth, setDay, setHourInt, setMinute, 0);
        //    iyear_out = 0; imonth_out = 0; iday_out = 0; ihour_out = 0; imin_out = 0; dsec_out = 0;
        //    DateTime sunsetUTC = new DateTime(setYear, setMonth, setDay, setHourInt, setMinute, 0);

        //    d.swe_utc_time_zone(sunsetUTC.Year, sunsetUTC.Month, sunsetUTC.Day, sunsetUTC.Hour, sunsetUTC.Minute, sunsetUTC.Second, -1* longitude / 15,
        //        ref iyear_out, ref imonth_out, ref iday_out, ref ihour_out, ref imin_out, ref dsec_out);
        //    DateTime sunsetLocal = new DateTime(iyear_out, imonth_out, iday_out, ihour_out, imin_out, (int)dsec_out);
        //    sunsetLocal = TimeZoneConverter.ConvertUtcToLocationTime(sunriseUTC, latitude, longitude);
        //    //DateTime sunsetLocal = sunsetUTC.ToLocalTime();

        //    return Tuple.Create(sunriseLocal, sunsetLocal);
        //}


        public class TimeZoneConverter
        {
            public static DateTime ConvertUtcToLocationTime(DateTime utcTime, double latitude, double longitude)
            {
                TimeZoneInfo timeZone = GetTimeZoneId(latitude, longitude);
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeZone);
            }

            static TimeZoneInfo GetTimeZoneId(double latitude, double longitude)
            {
                foreach (var timeZoneId in TimeZoneInfo.GetSystemTimeZones())
                {
                    if (timeZoneId.Id == "Dateline Standard Time") continue;
                    if (!timeZoneId.Id.Contains("UTC")) continue;

                    TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId.Id);
                    if (timeZone.GetUtcOffset(DateTime.UtcNow).Equals(timeZone.GetUtcOffset(DateTime.UtcNow.AddHours(1))))
                    {
                        if (timeZone.GetUtcOffset(DateTime.UtcNow).TotalSeconds == timeZone.BaseUtcOffset.TotalSeconds)
                        {
                            // Add a condition to check if the longitude falls within the valid range for the time zone

                            double minLongitude = timeZone.GetUtcOffset(DateTime.UtcNow).TotalSeconds > 0 ? timeZone.GetUtcOffset(DateTime.UtcNow).TotalSeconds : -timeZone.GetUtcOffset(DateTime.UtcNow).TotalSeconds;
                            double maxLongitude = minLongitude + 3600;

                            if (longitude >= minLongitude && longitude <= maxLongitude)
                            {
                                return timeZoneId;
                            }
                        }
                    }
                }
                return null; // Time zone not found for the specified coordinates
            }
            private static bool IsInDst(TimeZoneInfo timeZone)
            {
                return timeZone.IsDaylightSavingTime(DateTime.UtcNow);
            }

        }
        public struct NewStruct
        {
            public DateTime sunrise;
            public DateTime sunset;

            public NewStruct(DateTime sunrise, DateTime sunset)
            {
                this.sunrise = sunrise;
                this.sunset = sunset;
            }

            public override bool Equals(object obj)
            {
                return obj is NewStruct other &&
                       sunrise == other.sunrise &&
                       sunset == other.sunset;
            }

            public override int GetHashCode()
            {
                int hashCode = -1900153301;
                hashCode = hashCode * -1521134295 + sunrise.GetHashCode();
                hashCode = hashCode * -1521134295 + sunset.GetHashCode();
                return hashCode;
            }

            public void Deconstruct(out DateTime sunrise, out DateTime sunset)
            {
                sunrise = this.sunrise;
                sunset = this.sunset;
            }

            public static implicit operator (DateTime sunrise, DateTime sunset)(NewStruct value)
            {
                return (value.sunrise, value.sunset);
            }

            public static implicit operator NewStruct((DateTime sunrise, DateTime sunset) value)
            {
                return new NewStruct(value.sunrise, value.sunset);
            }
        }
    }
}
