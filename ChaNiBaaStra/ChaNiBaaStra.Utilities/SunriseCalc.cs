// An implementation of Paul Schlyter's sunrise calculator in C# under an MIT license.
// Version 0.1, initial commit.

using System;

namespace SunriseCalculator
{
    public enum Horizon
    {
        /// <summary>
        /// Normally, sunrise/set is considered to occur when the sun's upper limb is 35 arc
        /// minutes below the horizon (this accounts for the refraction of the Earth's atmosphere).
        /// </summary>
        Normal,

        /// <summary>
        /// Civil dawn or dusk marks the start or end of the brightest of the standard
        /// twilights, followed by <see cref="Nautical"/> and <see cref="Astronomical"/> twilights.
        /// It occurs when the center of the sun passes 6° below the horizon.
        /// </summary>
        Civil,

        /// <summary>
        /// Nautical dawn or dusk marks the start or end of the intermediate brightness of
        /// twilight, between <see cref="Civil"/> and <see cref="Astronomical"/> twilights.
        /// It occurs when the center of the sun passes 12° below the horizon.
        /// </summary>
        Nautical,

        /// <summary>
        /// Astronomical dawn or dusk marks the start or end of the dimmest of the standard
        /// twilights, followed by <see cref="Nautical"/> and <see cref="Civil"/> twilights.
        /// It occurs when the center of the sun passes 18° below the horizon.
        /// </summary>
        Astronomical,
    }

    public enum DiurnalResult
    {
        /// <summary>
        /// The diurnal arc is normal; the sun crosses the specified altitude on the specified day.
        /// </summary>
        NormalDay,

        /// <summary>
        /// The sun remains above the specified altitude for all 24h of the specified day. The time
        /// returned is when the sun is closest to the horizon (directly to the south in the
        /// northern hemisphere; to the north in the southern); sunrise is 12 hours before
        /// midday, and sunset is 12 hours after.
        /// </summary>
        SunAlwaysAbove,

        /// <summary>
        /// The sun remains below the specified altitude for all 24h of the specified day. Sunrise
        /// and sunset are both calculated as when the sun is closest to the horizon (directly to
        /// the south in the northern hemisphere; to the north in the southern).
        /// </summary>
        SunAlwaysBelow
    }

    public class SolarPosition
    {
        /// <summary> Radians to degrees conversion factor. </summary>
        private const double RadDeg = 180.0 / Math.PI;

        /// <summary> Degrees to radians conversion factor. </summary>
        private const double DegRad = Math.PI / 180.0;

        private const double SolarRadiusAt1AUDegrees = 0.2666;

        /// <summary>
        /// This value represents the days between January 1, 2000 at 00:00:00 (the start of the 
        /// current astronomical epoch) and local midday at the specified <see cref="Longitude"/>
        /// and <see cref="Date"/>.
        /// </summary>
        public readonly double LocalMeanSolarTimeEpoch;

        /// <summary>
        /// Creates an instance for the specified day at the specified longitude. Calculations 
        /// should be accurate for days from 1801 to 2099. Dates outside this range will be 
        /// accepted, but accuracy will be reduced.
        /// </summary>
        /// <param name="day">The day for which to calculate solar position values. Dates from 1801
        /// to 2099 will be yield the most accurate results.</param>
        /// <param name="longitude">The local longitude for which to calculate values. If accuracy 
        /// is not important, this can be zero.</param>
        /// <exception cref="ArgumentOutOfRangeException"><c>longitude</c> must be in range -180.0 to 180.0.</exception>
        public SolarPosition(DateTime day, double longitude)
        {
            if (double.IsNaN(longitude) || longitude < -180 || longitude > 180)
                throw new ArgumentOutOfRangeException(nameof(longitude), longitude, $"{nameof(longitude)} must be in range -180.0 to 180.0.");

            Date = day.Date;
            Longitude = longitude;
            LocalMeanSolarTimeEpoch = EpochHelper.EpochDayLocalMidday(day, longitude);
        }

        /// <summary>
        /// Mean anomaly of the sun, in radians.
        /// </summary>
        private double MeanAnomaly => Rev2Pi(356.0470 * DegRad + (0.9856002585 * DegRad) * LocalMeanSolarTimeEpoch);

        /// <summary>
        /// Mean longitude of perihelion, in radians.
        /// </summary>
        /// <remarks>The Suns' mean longitude = <see cref="MeanAnomaly"/> + <see cref="MeanLongitudeOfPerihelion"/>.</remarks>
        private double MeanLongitudeOfPerihelion => (282.9404 * DegRad + (4.70935E-5 * DegRad) * LocalMeanSolarTimeEpoch);

        /// <summary>
        /// Eccentricity of Earth's orbit. This value is unitless.
        /// </summary>
        private double EarthOrbitEccentricity => 0.016709 - 1.151E-9 * LocalMeanSolarTimeEpoch;

        /// <summary>
        /// Eccentric anomaly, the angle between the direction of periapsis and the current 
        /// position of the Earth on its orbit, in radians.
        /// </summary>
        private double EccentricAnomaly => MeanAnomaly + EarthOrbitEccentricity * Math.Sin(MeanAnomaly) * (1.0 + EarthOrbitEccentricity * Math.Cos(MeanAnomaly));

        /// <summary>
        /// X coordinate in orbit, in AU.
        /// </summary>
        private double OrbitXCoordinate => Math.Cos(EccentricAnomaly) - EarthOrbitEccentricity;

        /// <summary>
        /// Y coordinate in orbit, in AU.
        /// </summary>
        private double OrbitYCoordinate => Math.Sqrt(1.0 - Square(EarthOrbitEccentricity)) * Math.Sin(EccentricAnomaly);

        /// <summary>
        /// Distance to the sun, in AU.
        /// </summary>
        public double DistanceToSun => Hypotenuse(OrbitXCoordinate, OrbitYCoordinate);

        /// <summary>
        /// The sun's true anomaly, in radians.
        /// </summary>
        private double TrueAnomaly => Math.Atan2(OrbitYCoordinate, OrbitXCoordinate);

        /// <summary>
        /// The true solar longitude, in radians.
        /// </summary>
        private double TrueSolarLongitude => Rev2Pi(TrueAnomaly + MeanLongitudeOfPerihelion);

        /// <summary>
        /// The obliquity of the ecliptic, or the inclination of Earth's axis, in radians.
        /// </summary>
        public double ObliquityOfEcliptic => (23.4393 * DegRad - (3.563E-7 * DegRad) * LocalMeanSolarTimeEpoch);

        /// <summary>
        /// The ecliptic rectangular x coordinate of the sun's position in the sky.
        /// This is the same as the <see cref="EquatorialXCoordinate"/>.
        /// </summary>
        private double EclipticRectangularXCoordinate => DistanceToSun * Math.Cos(TrueSolarLongitude);

        /// <summary>
        /// The ecliptic rectangular y coordinate of the sun's position in the sky.
        /// </summary>
        private double EclipticRectangularYCoordinate => DistanceToSun * Math.Sin(TrueSolarLongitude);

        /// <summary>
        /// The equatorial rectangular x coordinate of the sun's position in the sky.
        /// This is the same as the <see cref="EclipticRectangularXCoordinate"/>.
        /// </summary>
        private double EquatorialXCoordinate => EclipticRectangularXCoordinate;

        /// <summary>
        /// The equatorial rectangular z coordinate of the sun's position in the sky.
        /// </summary>
        private double EquatorialZCoordinate => EclipticRectangularYCoordinate * Math.Sin(ObliquityOfEcliptic);

        /// <summary>
        /// The equatorial rectangular y coordinate of the sun's position in the sky.
        /// </summary>
        private double EquatorialYCoordinate => EclipticRectangularYCoordinate * Math.Cos(ObliquityOfEcliptic);

        /// <summary>
        /// The sun's apparent radius from Earth on the given day, in degrees.
        /// </summary>
        public double ApparentRadiusDegrees => SolarRadiusAt1AUDegrees / DistanceToSun;

        /// <summary>
        /// The sun's apparent radius from Earth on the given day, in radians.
        /// </summary>
        public double ApparentRadiusRadians => (SolarRadiusAt1AUDegrees * DegRad) / DistanceToSun;

        /// <summary>
        /// Gets the date for which this instance is calculated. Calculations should be accurate
        /// for dates between 1801 and 2099.
        /// </summary>
        public readonly DateTime Date;

        /// <summary>
        /// Gets the longitude (on the surface of Earth) for which this instance is calculated. If 
        /// accuracy is not important, this can be zero.
        /// </summary>
        public readonly double Longitude;

        /// <summary>
        /// The sun's right ascension, in radians.
        /// </summary>
        public double RightAscensionRadians => Math.Atan2(EquatorialYCoordinate, EquatorialXCoordinate);

        /// <summary>
        /// The sun's right ascension, in degrees.
        /// </summary>
        public double RightAscensionDegrees => RightAscensionRadians * RadDeg;

        /// <summary>
        /// The sun's declination, in radians.
        /// </summary>
        public double DeclinationRadians => Math.Atan2(EquatorialZCoordinate, Hypotenuse(EquatorialXCoordinate, EquatorialYCoordinate));

        /// <summary>
        /// The sun's declination, in degrees.
        /// </summary>
        public double DeclinationDegrees => DeclinationRadians * RadDeg;

        /// <summary>
        /// Returns the square root of the sum of the squares of the parameters.
        /// </summary>
        private static double Hypotenuse(double x, double y) => Math.Sqrt(Square(x) + Square(y));

        /// <summary>
        /// Given a value in radians, returns that value constrained to between 0 and 2*Pi.
        /// </summary>
        /// <param name="value">Any value in radians.</param>
        /// <returns>The value constrained to the 0 to 2*Pi radians range.</returns>
        private static double Rev2Pi(double value)
        {
            const double revolution = Math.PI * 2;
            double result = value % revolution;
            return result < 0 ? result + revolution : result;
        }

        /// <summary>
        /// Returns the square of the value.
        /// </summary>
        private static double Square(double value) => value * value;
    }
    public static class EpochHelper
    {
        private const double MaxLongitude = 180;

        /// <summary>
        /// The maximum year for which calculations are accurate.
        /// </summary>
        public const int MaxYear = 2099;

        /// <summary>
        /// The minimum year for which calculations are accurate.
        /// </summary>
        public const int MinYear = 1801;

        /// <summary>
        /// The start of the current astronomical epoch, at 00:00:00 on January 1, 2000.
        /// </summary>
        public static readonly DateTime J2000 = new DateTime(2000, 1, 1, 0, 0, 0);

        /// <summary>
        /// Returns the epoch day, or the days between the provided <see cref="DateTime"/> and <see cref="J2000"/>,
        /// the start of the current astronomical epoch.
        /// </summary>
        /// <param name="dateTime">The moment for which to calculate the epoch day.</param>
        /// <returns>The epoch day for the specified time.</returns>
        public static double DaysSinceJ2000(DateTime dateTime) => (dateTime - J2000).TotalDays;

        /// <summary>
        /// Returns the epoch day of local midday at the time and longitude specified.
        /// </summary>
        /// <param name="dateTime">A date for which to calculate the local midday. Hours, minutes, and seconds of this value are ignored.</param>
        /// <param name="longitude">The longitude at which local midday will be calculated.</param>
        /// <returns></returns>
        public static double EpochDayLocalMidday(DateTime dateTime, double longitude) => DaysSinceJ2000(dateTime.Date) + 0.5 - (longitude % MaxLongitude / 360.0);

        /// <summary>
        /// Converts an epoch day to a <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="epochDays">The epoch day. See <see cref="DaysSinceJ2000(DateTime)"/> for more information.</param>
        /// <returns></returns>
        public static DateTime EpochDayToDateTime(double epochDays) => J2000.AddDays(epochDays);

        /// <summary>
        /// Returns the local midday in UTC at the longitude specified.
        /// </summary>
        /// <param name="dateTime">A date for which to calculate the local midday. Hours, minutes, and seconds of this value are ignored.</param>
        /// <param name="longitude">The longitude at which local midday will be calculated.</param>
        /// <returns></returns>
        public static DateTime LocalMidday(DateTime dateTime, double longitude) => dateTime.Date.AddDays(0.5 - (longitude % MaxLongitude / 360.0));

        /// <summary>
        /// Returns the <see cref="DateTime"/> of midday for the provided day. The returned time
        /// represents midday in UTC, ignoring longitude.
        /// </summary>
        /// <param name="day">A date for which to calculate midday. Hours, minutes and seconds are ignored.</param>
        /// <returns>UTC midday on the provided day.</returns>
        public static DateTime UTCMidday(DateTime day) => day.Date.AddHours(12);

        /// <summary>
        /// Returns the epoch day of midday for the provided day. The returned time
        /// represents midday in UTC, ignoring longitude.
        /// </summary>
        /// <param name="epochDay">A date for which to calculate midday. Hours, minutes and seconds are ignored.</param>
        /// <returns>UTC midday on the provided day.</returns>
        public static double UTCMidday(double epochDay) => Math.Floor(epochDay) + 0.5;
    }
    /// <summary>
    /// Performs calculations for dawn and dusk times and related results for any position on 
    /// Earth, for any day from 1801 to 2099.
    /// </summary>
    public partial class SunriseCalc
    {
        /// <summary> Degrees to radians conversion factor. </summary>
        private const double DegRad = Math.PI / 180.0;

        private double latitude;
        private double longitude;
        private DateTime time;

        /// <summary>
        /// The maximum possible Latitude value. Latitudes above this do not exist.
        /// </summary>
        public const double MaxLatitude = 90.0;

        /// <summary>
        /// The maximum possible Longitude value. Longitudes above this wrap around to negative values.
        /// </summary>
        public const double MaxLongitude = 180.0;

        /// <summary>
        /// The minimum possible Latitude value. Latitudes below this do not exist.
        /// </summary>
        public const double MinLatitude = -90.0;

        /// <summary>
        /// The mininum possible Longitude value. Longitudes below this wrap around to positive values.
        /// </summary>
        public const double MinLongitude = -180.0;

        /// <summary>
        /// Creates a new instance of the sunrise calculator for a specified latitude, longitude,
        /// and optionally, day (default is today).
        /// </summary>
        /// <param name="latitude">The latitude, between -90.0 (the south pole,
        /// <see cref="MinLatitude"/>) and 90.0 (the north pole, <see cref="MaxLatitude"/>). Values
        /// outside this range will raise an exception.</param>
        /// <param name="longitude">The longitude, between -180.0 (the eastern side of the
        /// international dateline, <see cref="MinLongitude"/>) and and 180.0 (the western side of
        /// the international dateline, <see cref="MaxLongitude"/>). Values outside this range
        /// will be wrapped around.</param>
        /// <param name="day">Optionally specify any day for calculation, default is today. Results
        /// should be accurate for dates between 1801 and 2099.</param>
        /// <exception cref="ArgumentOutOfRangeException"><see cref="Latitude"/> must be in range <see cref="MinLatitude"/> (-90°) to <see cref="MaxLatitude"/> (90°).</exception>
        /// <exception cref="ArgumentOutOfRangeException"><see cref="Longitude"/> must be finite.</exception>
        public SunriseCalc(double latitude, double longitude, DateTime day = default)
        {
            Latitude = latitude;
            Longitude = longitude;
            Day = day;
        }

        /// <summary>
        /// The local sidereal time at the <see cref="Longitude"/>, in radians.
        /// </summary>
        /// <returns>The local sidereal time in radians, modulo 360.</returns>
        private double LocalSiderealTimeRadians => Rev2Pi(GMST0Radians(SolarPosition.LocalMeanSolarTimeEpoch) + Math.PI + Longitude * DegRad);

        /// <summary>
        /// The time (in UTC) at which the sun will be immediately above the <see cref="Longitude"/>
        /// (directly to the south in the northern hemisphere; to the north in the southern).
        /// </summary>
        private DateTime TimeSunAtLongitude => new DateTime(Day.Year, Day.Month, Day.Day, 0, 0, 0, DateTimeKind.Utc)
            .AddHours(12.0 - RadiansToHours(Rev1Pi(LocalSiderealTimeRadians - SolarPosition.RightAscensionRadians)));

        /// <summary>
        /// Sets and gets the day for which calculations are made. By default, the current date is used.
        /// </summary>
        public DateTime Day
        {
            get => time.Date; set
            {
                DateTime newTime = EpochHelper.LocalMidday(value == default ? DateTime.Today : value, Longitude);
                if (newTime != time)
                {
                    time = newTime;
                    SolarPosition = new SolarPosition(Day, Longitude);
                }
            }
        }

        /// <summary>
        /// The latitude of the geolocation to use for calculation, in degrees. North is positive,
        /// south is negative. Must be within <see cref="MinLatitude"/> (-90°) and <see cref="MaxLatitude"/> (90°).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><see cref="Latitude"/> must be in range <see cref="MinLatitude"/> (-90°) to <see cref="MaxLatitude"/> (90°).</exception>
        public double Latitude
        {
            get => latitude; set
            {
                if (double.IsNaN(value) || (value < MinLatitude) || (value > MaxLatitude))
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Latitude)} must be in range {MinLatitude}° to {MaxLatitude}°.");

                latitude = value;
            }
        }

        /// <summary>
        /// The longitude of the geolocation to use for calculation, in degrees. East is positive,
        /// west is negative. Values outside of <see cref="MinLongitude"/> (-180°) and
        /// <see cref="MaxLongitude"/> (180°) will be wrapped around.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><see cref="Longitude"/> must be finite.</exception>
        public double Longitude
        {
            get => longitude; set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Longitude)} must be finite.");

                // Since Windows.Devices.Geolocation.BasicGeoposition can return longitudes outside -180..180, we'll constrain.
                const double revolution = 360.0;
                while (value < MinLongitude)
                    value += revolution;
                while (value > MaxLongitude)
                    value -= revolution;

                longitude = value;
                if (time != default)
                    SolarPosition = new SolarPosition(Day, longitude);
            }
        }

        /// <summary>
        /// This object holds values for the position of the sun on the day of <see cref="Day"/>.
        /// </summary>
        public SolarPosition SolarPosition { get; private set; }

        /// <summary>
        /// Given a value in radians, returns that value constrained to between -Pi and Pi radians.
        /// </summary>
        /// <param name="value">Any value in radians.</param>
        /// <returns>The value constrained to the -Pi and Pi radians range.</returns>
        private static double Rev1Pi(double value) => value % Math.PI;

        /// <summary>
        /// Given a value in radians, returns that value constrained to between 0 and 2 Pi radians.
        /// </summary>
        /// <param name="value">Any value in radians.</param>
        /// <returns>The value constrained to the 0 to 360 degree range.</returns>
        private static double Rev2Pi(double value)
        {
            double result = value % (2 * Math.PI);
            return result < 0 ? result + (2 * Math.PI) : result;
        }

        /// <summary>
        /// Given a diurnal arc in radians, returns the corresponding time of day on the day of <see cref="Day"/>.
        /// </summary>
        /// <param name="radiansOfArc">An arc value in radians.</param>
        /// <returns>The corresponding time on the specified day.</returns>
        private TimeSpan ArcRadiansToTimeSpan(double radiansOfArc) => TimeSpan.FromHours(RadiansToHours(radiansOfArc));

        /// <summary>
        /// Computes the diurnal arc that the sun traverses to reach the specified altitude.
        /// Use <see cref="RadiansToHours(double)"/> to convert result to hours.
        /// </summary>
        /// <param name="altitude">The altitude threshold, in degrees. This is the 'horizon' for the calculation.</param>
        /// <param name="arcRadians">The diurnal arc, in radians.</param>
        /// <returns>A value indicating whether the sun rises (crosses the horizon) on the specified day.</returns>
        private DiurnalResult DiurnalArcRadians(double altitude, out double arcRadians)
        {
            double cosineOfArc = (Math.Sin(altitude * DegRad) - (Math.Sin(Latitude * DegRad) * Math.Sin(SolarPosition.DeclinationRadians))) / (Math.Cos(Latitude * DegRad) * Math.Cos(SolarPosition.DeclinationRadians));
            if (cosineOfArc >= 1.0)
            {
                arcRadians = 0.0;
                return DiurnalResult.SunAlwaysBelow;
            }
            else if (cosineOfArc <= -1.0)
            {
                arcRadians = Math.PI;
                return DiurnalResult.SunAlwaysAbove;
            }
            else
            {
                arcRadians = Math.Acos(cosineOfArc);
                return DiurnalResult.NormalDay;
            }
        }

        /// <summary>
        /// Returns the Greenwich Mean Sidereal Time at 0h UT (i.e. the sidereal time at the
        /// Greenwhich meridian at 0h UT) in radians.  GMST is then the sidereal time at Greenwich at any time
        /// of the day.
        /// </summary>
        /// <param name="epochDay">The days since the beginning of the J2000 epoch.</param>
        /// <remarks>For a full explanation of this value, refer to the original comments in Paul
        /// Schlyter's code, details in the <c>README.md</c> file.</remarks>
        private double GMST0Radians(double epochDay)
        {
            return Rev2Pi(Math.PI + 356.0470 * DegRad + 282.9404 * DegRad + ((0.9856002585 * DegRad + 4.70935E-5 * DegRad) * epochDay));
        }

        /// <summary>
        /// Selects the correct horizon value in degrees.
        /// </summary>
        private double HorizonDegrees(Horizon horizon)
        {
            const double AstronomicalHorizon = -18.0;
            const double CivilHorizon = -6.0;
            const double NauticalHorizon = -12.0;
            const double NominalHorizon = -35.0 / 60.0;

            switch (horizon)
            {
                case Horizon.Normal:
                    return NominalHorizon - SolarPosition.ApparentRadiusDegrees;

                case Horizon.Civil:
                    return CivilHorizon;

                case Horizon.Nautical:
                    return NauticalHorizon;

                case Horizon.Astronomical:
                    return AstronomicalHorizon;

                default:
                    throw new NotImplementedException($"No definition found for horizon {horizon}");
            }
        }

        /// <summary>
        /// Converts a right ascension or arc value in radians to a value in hours.
        /// </summary>
        private double RadiansToHours(double radians) => 12 / Math.PI * radians;

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> of the time the sun spends above the specified <see cref="Horizon"/>
        /// on the day of <see cref="Day"/>.
        /// </summary>
        /// <param name="horizon">The <see cref="Horizon"/> to use for day length calculation.</param>
        /// <returns>A <see cref="TimeSpan"/> for the specified day length.</returns>
        public TimeSpan GetDayLength(Horizon horizon = Horizon.Normal)
        {
            _ = DiurnalArcRadians(HorizonDegrees(horizon), out double arcRadians);
            TimeSpan halfDay = ArcRadiansToTimeSpan(arcRadians);


            return TimeSpan.FromTicks(2 * halfDay.Ticks);
        }

        /// <summary>
        /// Returns sunrise and sunset in UTC on the day specified in <see cref="Day"/>, and a
        /// <see cref="DiurnalResult"/> indicating whether the sun rises or not.
        /// </summary>
        /// <param name="sunrise">The calculated sunrise (in UTC) for the specified day.</param>
        /// <param name="sunset">The calculated sunset for the specified day.</param>
        /// <param name="timeZone">Optionally, convert the times to the provided time zone. In not specified, times are in UTC.</param>
        /// <param name="horizon">The horizon to use for the sunrise calculation.</param>
        /// <returns>A value indicating whether the sun rises (crosses the horizon) on the specified day.</returns>
        public DiurnalResult GetRiseAndSet(out DateTime sunrise, out DateTime sunset, TimeZoneInfo timeZone = null, Horizon horizon = Horizon.Normal)
        {
            DiurnalResult result = DiurnalArcRadians(HorizonDegrees(horizon), out double arcRadians);
            TimeSpan halfDay = ArcRadiansToTimeSpan(arcRadians);

            if (timeZone == null)
            {
                sunrise = TimeSunAtLongitude - halfDay;
                sunset = TimeSunAtLongitude + halfDay;
            }
            else
            {
                sunrise = TimeZoneInfo.ConvertTimeFromUtc(TimeSunAtLongitude - halfDay, timeZone);
                sunset = TimeZoneInfo.ConvertTimeFromUtc(TimeSunAtLongitude + halfDay, timeZone);
            }

            return result;
        }

        /// <summary>
        /// Returns sunrise in UTC on the day specified in <see cref="Day"/>, and a <see cref="DiurnalResult"/>
        /// indicating whether the sun rises or not.
        /// </summary>
        /// <param name="sunrise">The calculated sunrise (in UTC) for the specified day.</param>
        /// <param name="timeZone">Optionally, convert the times to the provided time zone. In not specified, times are in UTC.</param>
        /// <param name="horizon">The horizon to use for the sunrise calculation.</param>
        /// <returns>A value indicating whether the sun rises (crosses the horizon) on the specified day.</returns>
        public DiurnalResult GetSunrise(out DateTime sunrise, TimeZoneInfo timeZone = null, Horizon horizon = Horizon.Normal)
        {
            DiurnalResult result = DiurnalArcRadians(HorizonDegrees(horizon), out double arcRadians);
            TimeSpan halfDay = ArcRadiansToTimeSpan(arcRadians);

            if (timeZone == null)
                sunrise = TimeSunAtLongitude - halfDay;
            else
                sunrise = TimeZoneInfo.ConvertTimeFromUtc(TimeSunAtLongitude - halfDay, timeZone);

            return result;
        }

        /// <summary>
        /// Returns sunset in UTC on the day specified in <see cref="Day"/>, and a <see cref="DiurnalResult"/>
        /// indicating whether the sun sets or not.
        /// </summary>
        /// <param name="sunset">The calculated sunset for the specified day.</param>
        /// <param name="timeZone">Optionally, convert the times to the provided time zone. In not specified, times are in UTC.</param>
        /// <param name="horizon">The horizon to use for the sunset calculation.</param>
        /// <returns>A value indicating whether the sun sets (crosses the horizon) on the specified day.</returns>
        public DiurnalResult GetSunset(out DateTime sunset, TimeZoneInfo timeZone = null, Horizon horizon = Horizon.Normal)
        {
            DiurnalResult result = DiurnalArcRadians(HorizonDegrees(horizon), out double arcRadians);
            TimeSpan halfDay = ArcRadiansToTimeSpan(arcRadians);

            if (timeZone == null)
                sunset = TimeSunAtLongitude + halfDay;
            else
                sunset = TimeZoneInfo.ConvertTimeFromUtc(TimeSunAtLongitude + halfDay, timeZone);

            return result;
        }
    }
}