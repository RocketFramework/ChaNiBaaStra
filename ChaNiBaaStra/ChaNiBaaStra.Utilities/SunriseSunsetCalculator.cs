using System;
using SwissEphNet;

namespace ChaNiBaaStra.Utilities
{
    public static class SunriseSunsetCalculator
    {
        public static NewStruct CalculateSunriseSunset(double latitude, double longitude, DateTime date)
        {
            // Initialize SwissEphNet
            SwissEph swissEph = new SwissEph();

            // Set the observer's location
            double[] geopos = new double[] { latitude, longitude, 0 };

            // Calculate sunrise and sunset times
            double jdSunrise = 0;
            double jdSunset = 0;
            string serr = string.Empty;
            swissEph.swe_rise_trans(date.ToOADate(), SwissEph.SE_SUN, "", SwissEph.SEFLG_SWIEPH, SwissEph.SE_CALC_RISE, geopos, 0, 0, ref jdSunrise, ref serr);
            swissEph.swe_rise_trans(date.ToOADate(), SwissEph.SE_SUN, "", SwissEph.SEFLG_SWIEPH, SwissEph.SE_CALC_SET, geopos, 0, 0, ref jdSunset, ref serr);

            // Convert Julian dates to DateTime objects
            int year = 0;
            int month = 0;
                int day = 0; int hour = 0; int  minute = 0;
            double second = 0;
            swissEph.swe_jdut1_to_utc(jdSunrise, SwissEph.SE_GREG_CAL, ref year, ref month, ref day, ref hour, ref minute, ref second);
            DateTime sunrise = new DateTime(year, month, day, hour, minute, (int)second);

            year = 0;
            month = 0;
            day = 0;  hour = 0;  minute = 0;
            second = 0;
            swissEph.swe_jdut1_to_utc(jdSunset, SwissEph.SE_GREG_CAL, ref year, ref month, ref day, ref hour, ref minute, ref second);
            DateTime sunset = new DateTime(year, month, day, hour, minute, (int)second);

            return new NewStruct(sunrise, sunset);
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
