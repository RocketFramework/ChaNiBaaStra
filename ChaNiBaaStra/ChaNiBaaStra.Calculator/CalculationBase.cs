using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.DataModels;
using SwissEphNet;
using ChaNiBaaStra.Utilities;
using System.Windows;

namespace ChaNiBaaStra.Calculator
{
    public abstract class CalculationBase
    {
        public int Year { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Minute { get; set; }
        public int Hour { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public double tjd_ut { get; set; }
        public AstroPlace LocationData { get; set; }
        public SwissEph swissEph = new SwissEph();
        public AstroPlanet Sun { get; set; }
        public AstroPlanet Moon { get; set; }
        public AstroPlanet Mars { get; set; }
        public AstroPlanet Mercury { get; set; }
        public AstroPlanet Jupiter { get; set; }
        public AstroPlanet Venus { get; set; }
        public AstroPlanet Saturn { get; set; }
        public AstroPlanet Uranus { get; set; }
        public AstroPlanet Neptune { get; set; }
        public AstroPlanet Pluto { get; set; }

        public AstroPlanet Rahu { get; set; }
        public AstroPlanet Kethu { get; set; }
        public AstroNakath Nakath { get; set; }
        public AstroWeekDay WeekDay { get; set; }
        public AstroThithi Thithi { get; set; }
        public AstroYoga Yoga { get; set; }
        public AstroKarna Karna { get; set; }
        public AstroMuhurtha Muthurtha { get; set; }
        /// <summary>
        /// End time of the currently active Nakath
        /// </summary>
        public static DateTime? NakathEndDateTime { get; set; }
        public static DateTime? ThithiEndDateTime { get; set; }
        public static DateTime? KarnaEndDateTime { get; set; }
        public static DateTime? YogaEndDateTime { get; set; }
        public Horoscope Horoscope { get; set; }
        public CalculationBase(AstroPlace locationData, bool IsWithDetails) 
        {
            NakathEndDateTime = null;
            ThithiEndDateTime = null;
            KarnaEndDateTime = null;
            YogaEndDateTime = null;
            swissEph.swe_set_topo(locationData.Longitude, locationData.Latitude, 0.0);

            DateTime dateTime = locationData.BirthDateTime;
            LocationData = locationData;
            CurrentDateTime = dateTime;
            Year = dateTime.Year;
            Month = dateTime.Month;
            Day = dateTime.Day;
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
            Second = dateTime.Second;
            List<AstroPlanet> pList = (IsWithDetails)? CalculatePlanetPositionWithDetailsOptmized():CalculatePlanetPosition();
            Sun = pList.Find(x => x.Current == EnumPlanet.Sun);
            Moon = pList.Find(x => x.Current == EnumPlanet.Moon);
            Mars = pList.Find(x => x.Current == EnumPlanet.Mars);
            Mercury = pList.Find(x => x.Current == EnumPlanet.Mercury);
            Jupiter = pList.Find(x => x.Current == EnumPlanet.Jupiter);
            Venus = pList.Find(x => x.Current == EnumPlanet.Venus);
            Saturn = pList.Find(x => x.Current == EnumPlanet.Saturn);
            Uranus = pList.Find(x => x.Current == EnumPlanet.Uranus);
            Neptune = pList.Find(x => x.Current == EnumPlanet.Neptune);
            Pluto = pList.Find(x => x.Current == EnumPlanet.Pluto);
            Rahu = pList.Find(x => x.Current == EnumPlanet.Rahu);
            Kethu = pList.Find(x => x.Current == EnumPlanet.Kethu);

            Nakath = new AstroNakath(this.Moon.Longitude);
            Nakath.EndTime = NakathEndDateTime;
            WeekDay = new AstroWeekDay((EnumWeekDay)((int)dateTime.DayOfWeek + 1));
            Thithi = new AstroThithi(new AstroThithi(EnumThithi.Amavasya).ofDeg(this.Sun.Longitude, this.Moon.Longitude));
            Thithi.EndTime = ThithiEndDateTime;
            Yoga = new AstroYoga(new AstroYoga(EnumYoga.Shula).ofDeg(this.Sun.Longitude, this.Moon.Longitude));
            Yoga.EndTime = YogaEndDateTime;
            Karna = new AstroKarna(new AstroKarna(EnumKarana.Balava).ofDeg(this.Sun.Longitude, this.Moon.Longitude));
            Karna.EndTime = KarnaEndDateTime;

            Horoscope = CalculateHoroscope(pList);
            Horoscope.ExtraDetails = new BirthRasiExtra(Horoscope);
            Horoscope.ExtraDetails.ThithiNumber = Thithi.Current;
            Horoscope.ExtraDetails.IsPura = (Thithi.ThithiPaksha == EnumPaksha.Krishna);
            Horoscope.Nakath = Nakath;

            Init();
        }
        public void Init()
        {
            bool isSunrise = false;
            bool isSunset = false;
            DateTime sunrise = DateTime.Now;
            DateTime sunset = DateTime.Now;
            int ltD = (int)LocationData.Latitude;
            //DateTime = DateTime.AddDays(10);

            SunTimes.Instance.CalculateSunRiseSetTimes(new SunTimes.LatitudeCoords
                                   ((int)LocationData.Latitude, (int)((LocationData.Latitude - (int)LocationData.Latitude) * 60), 0, SunTimes.LatitudeCoords.Direction.North),
                                                new SunTimes.LongitudeCoords
                                   ((int)LocationData.Longitude, (int)((LocationData.Longitude - (int)LocationData.Longitude) * 60), 0, SunTimes.LongitudeCoords.Direction.East),
                                                CurrentDateTime, LocationData.TimeZone, ref sunrise, ref sunset,
                                 ref isSunrise, ref isSunset);

            if (CurrentDateTime > sunset)
            {
                DateTime sunrise2 = DateTime.Now;
                DateTime sunset2 = DateTime.Now;
                SunTimes.Instance.CalculateSunRiseSetTimes(new SunTimes.LatitudeCoords
                       ((int)LocationData.Latitude, (int)((LocationData.Latitude - (int)LocationData.Latitude) * 60), 0, SunTimes.LatitudeCoords.Direction.North),
                                    new SunTimes.LongitudeCoords
                       ((int)LocationData.Longitude, (int)((LocationData.Longitude - (int)LocationData.Longitude) * 60), 0, SunTimes.LongitudeCoords.Direction.East),
                                    CurrentDateTime.AddDays(1), LocationData.TimeZone, ref sunrise2, ref sunset2,
                     ref isSunrise, ref isSunset);
                sunrise = sunset;
                sunset = sunrise2;
            }
            SunRise = LocationData.GetStandardTime(sunrise);
            SunSet = LocationData.GetStandardTime(sunset);
            Muthurtha = new AstroMuhurtha(LocationData.OriginalDateTime, SunRise, SunSet);
        }
        public DateTime SunRise { get; set; }
        public DateTime SunSet { get; set; }
        public int Second { get; private set; }

        public List<AstroPlanet> CalculatePlanetPosition()
        {
            List<AstroPlanet> planets = new List<AstroPlanet>();
            NakathEndDateTime = null;
            double[] cusps = new double[6];
            string serr = "";
            long iflgret;
            int planet;

            swissEph.swe_set_ephe_path(null);

            DateTime dt = new DateTime(Year, Month, Day, Hour, Minute, Second);
            TimeData tData = new TimeData(AstroPlace.GetUniversalTime(dt, LocationData.Longitude));
            tjd_ut = tData.JulianDateTime;

            /*
             * a loop over all planets
             */
            for (planet = SwissEph.SE_SUN; planet <= SwissEph.SE_CHIRON; planet++)
            {
                tjd_ut = tData.JulianDateTime;
                cusps = new double[6];
                if (planet == SwissEph.SE_EARTH
                    || planet == SwissEph.SE_MEAN_NODE || planet == SwissEph.SE_MEAN_APOG
                    || planet == SwissEph.SE_OSCU_APOG || planet == SwissEph.SE_CHIRON) continue;
                /*
                 * do the coordinate calculation for this planet p
                 */
                swissEph.swe_set_sid_mode(SwissEphNet.SwissEph.SE_SIDM_LAHIRI, 0, 0);
                AstroPlanet pReturn = null;
                // Looping to find the next transit time/ reversing time of the planet body

                iflgret = swissEph.swe_calc_ut(tjd_ut, planet, AstroConsts.iflag, cusps, ref serr);
                // Longitude
                // Latitude
                // Distance in AU
                // Speed in longitude(deg / day)
                // Speed in latitude(deg / day)
                // Speed in distance(AU / day)

                pReturn = new AstroPlanet(planet, cusps, LocationData);
                /*
                 * if there is a problem, a negative value is returned and an
                 * error message is in serr.
                 */
                if (iflgret < 0)
                    pReturn.CalculationError = serr;
                /*
                 * get the name of the planet p
                 */
                pReturn.Name = swissEph.swe_get_planet_name(planet);
                planets.Add(pReturn);
                // Add Ketu
                if (planet == SwissEph.SE_TRUE_NODE)
                {
                    pReturn.Name = "Rahu";
                    cusps[0] = (cusps[0] + 180.00) % 360;
                    AstroPlanet ketu = new AstroPlanet(12, cusps, LocationData);
                    ketu.Name = "Kethu";
                    planets.Add(ketu);
                }
            }
            return planets;
        }
        public List<AstroPlanet> CalculatePlanetPositionWithDetailsOptmized()
        {
            List<AstroPlanet> planets = new List<AstroPlanet>();
            NakathEndDateTime = null;
            double[] cusps = new double[6];
            double moonOrbPeriod = 27.321661;
            string serr = "";
            long iflgret;
            int planet;
            swissEph.swe_set_ephe_path(null);

            DateTime dt = new DateTime(Year, Month, Day, Hour, Minute, Second);
            TimeData tData = new TimeData(AstroPlace.GetUniversalTime(dt, LocationData.Longitude));
            tjd_ut = tData.JulianDateTime;

            swissEph.swe_set_sid_mode(SwissEphNet.SwissEph.SE_SIDM_LAHIRI, 0, 0);

            cusps = new double[6];
            AstroPlanet ketu = null;

            bool IsPachangaCalculated = false;
            double orgSunLong = 0.0;
            double orgMoonLong = 0.0;
            while (true)
            {
                if (planets.Count > 11 && planets.All(a => a.NextTransitDateTime > dt))
                    return planets;
                AstroPlanet pReturn = null;
                AstroPlanet curSun = null;
                for (planet = SwissEph.SE_SUN; planet <= SwissEph.SE_CHIRON; planet++)
                {
                    pReturn = planets.FirstOrDefault(x => x.CurrentInt == planet);
                    if (LoopSkipLogic(planet, pReturn, IsPachangaCalculated, dt))
                        continue;

                    iflgret = swissEph.swe_calc_ut(tjd_ut, planet, AstroConsts.iflag, cusps, ref serr);
                    if (iflgret < 0)
                        pReturn.CalculationError = serr;
                    // Longitude
                    // Latitude
                    // Distance in AU
                    // Speed in longitude(deg / day)
                    // Speed in latitude(deg / day)
                    // Speed in distance(AU / day)
                    if (pReturn == null)
                    {
                        pReturn = Initialization(planets, cusps, planet, ref ketu, ref orgSunLong, ref orgMoonLong);
                    }

                    if (pReturn.RasiStart < cusps[0] && cusps[0] < pReturn.RasiEnd)
                    {
                        // Planet Reversing related Calculation 
                        if (pReturn.IsReversing && cusps[3] >= 0 && !pReturn.IsNode() && pReturn.ReversingEndAt == null)
                        {
                            pReturn.ReversingEndAt = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone);
                            pReturn.IsNivrutha = true;
                        }
                        else if (!pReturn.IsReversing && cusps[3] <= 0 && !pReturn.IsNode() && pReturn.ReversingStartingAt == null)
                        {
                            pReturn.ReversingStartingAt = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone);
                            pReturn.IsNivrutha = false;
                        }
                    }
                    else if ((pReturn != null) && !(pReturn.NextTransitDateTime > dt))
                    {
                        Mod mod360 = new Mod(360);
                        // TODO: One time sun speed was 0 and made the adjustment as I didn't have internet
                        // Need to check it again to find out whether the 1 is a viable alternative here

                        double rasiTimeDif = (((Math.Abs(mod360.sub(pReturn.RasiEnd, cusps[0])) < Math.Abs(mod360.sub(cusps[0], pReturn.RasiStart)))
                            ? mod360.sub(pReturn.RasiStart, cusps[0]) : mod360.sub(cusps[0], pReturn.RasiEnd))
                            / ((cusps[3] == 0) ? 1 : cusps[3])) * 1440 * -1;
                        pReturn.NextTransitDateTime = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone).AddMinutes(rasiTimeDif);
                        if ((pReturn.Current == EnumPlanet.Rahu) && (ketu != null))
                            ketu.NextTransitDateTime = pReturn.NextTransitDateTime;
                    }

                    if (pReturn.Current == EnumPlanet.Sun)
                        curSun = new AstroPlanet(pReturn.Current, pReturn.PlanetLocations, pReturn.Place);
                    // When Nakath ends before the rasi ends
                    else if (!IsPachangaCalculated && (pReturn.Current == EnumPlanet.Moon))
                        IsPachangaCalculated = PanchangaCalculation(cusps, pReturn, curSun, orgSunLong, orgMoonLong);
                }

                double daysToGo = 0.5;
                
                if (!IsPachangaCalculated)
                    daysToGo = 60.0 / 1440.0;
                else if (planets.Count(x => !(x.Current == EnumPlanet.Uranus || x.Current == EnumPlanet.Neptune || x.Current == EnumPlanet.Pluto) && (x.NextTransitDateTime < dt)) > 0)
                    daysToGo = 0.5;
                else
                    daysToGo = 3.0;

                tjd_ut += daysToGo;
            }
        }

        private AstroPlanet Initialization(List<AstroPlanet> planets, double[] cusps, int planet, ref AstroPlanet ketu
            , ref double orgSunLong, ref double orgMoonLong)
        {
            Mod mod360 = new Mod(360);
            AstroPlanet pReturn = new AstroPlanet(planet, cusps, LocationData);
            pReturn.Name = swissEph.swe_get_planet_name(planet);
            planets.Add(pReturn);
            if (pReturn.Current == EnumPlanet.Sun)
                orgSunLong = pReturn.Longitude;
            else if (pReturn.Current == EnumPlanet.Moon)
                orgMoonLong = pReturn.Longitude;
            // Add Ketu
            if (planet == SwissEph.SE_TRUE_NODE)
            {
                pReturn.Name = "Rahu";
                double[] kethuCusps = new double[6];
                cusps.CopyTo(kethuCusps, 0);
                kethuCusps[0] = mod360.add(kethuCusps[0], 180.00) % 360;
                ketu = new AstroPlanet(12, kethuCusps, LocationData);
                ketu.Name = "Kethu";
                planets.Add(ketu);
            }

            if (pReturn.RasiStart == 0.0)
                pReturn.RasiStart = Math.Truncate(cusps[0] / AstroConsts.RasiLength) * AstroConsts.RasiLength;
            if (pReturn.RasiEnd == 0.0)
                pReturn.RasiEnd = pReturn.RasiStart + AstroConsts.RasiLength;
            return pReturn;
        }

        private bool LoopSkipLogic(int planet, AstroPlanet pReturn, bool IsPachangaCalculated, DateTime birthDateTime)
        {
            if (planet == SwissEph.SE_EARTH
                    || planet == SwissEph.SE_MEAN_NODE || planet == SwissEph.SE_MEAN_APOG
                    || planet == SwissEph.SE_OSCU_APOG || planet == SwissEph.SE_CHIRON) return true;
            if (pReturn != null)
                if (pReturn.Current == EnumPlanet.Moon || pReturn.Current == EnumPlanet.Sun)
                {
                    if (pReturn.NextTransitDateTime > birthDateTime && IsPachangaCalculated)
                        return true;
                }
                else if (pReturn.NextTransitDateTime > birthDateTime)
                    return true;// transit is already captured for this planet, so no need to run this loop
            return false;
        }
        private bool PanchangaCalculation(double[] cusps, AstroPlanet pReturn, AstroPlanet curSun, double orgSunLong, double orgMoonLong)
        {
            Mod mod360 = new Mod(360);
            if (ThithiEndDateTime == null) ThithiEndTime(cusps, curSun, orgSunLong, orgMoonLong, mod360);
            if (YogaEndDateTime == null) YogaEndTime(cusps, curSun, orgSunLong, orgMoonLong, mod360);
            if (KarnaEndDateTime == null) KarnaEndTime(cusps, curSun, orgSunLong, orgMoonLong, mod360);
            if (NakathEndDateTime == null) NakathEndTime(cusps, orgMoonLong);

            return (NakathEndDateTime != null && KarnaEndDateTime != null && YogaEndDateTime != null && ThithiEndDateTime != null);
        }

        private void NakathEndTime(double[] cusps, double orgMoonLong)
        {
            double nakathEnd = Math.Truncate(orgMoonLong / AstroConsts.NakLength) * AstroConsts.NakLength + AstroConsts.NakLength;
            AstroNakath tempNak = new AstroNakath(cusps[0]);
            AstroNakath currentNak = new AstroNakath(orgMoonLong);
            if (currentNak.Current != tempNak.Current)
            {
                double nakTimeDif = ((cusps[0] - nakathEnd) / ((cusps[3] == 0) ? 1 : cusps[3])) * 1440 * -1;
                if (NakathEndDateTime == null)
                    NakathEndDateTime = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone).AddMinutes(nakTimeDif);
            }
        }

        private void KarnaEndTime(double[] cusps, AstroPlanet curSun, double orgSunLong, double orgMoonLong, Mod mod360)
        {
            double karnaEnd = Math.Truncate(mod360.sub(cusps[0], orgSunLong) / AstroConsts.KaranaLength) * AstroConsts.KaranaLength;
            AstroKarna tempKarna = new AstroKarna(new AstroKarna(EnumKarana.Balava).ofDeg(curSun.Longitude, cusps[0]));
            AstroKarna currentKarna = new AstroKarna(new AstroKarna(EnumKarana.Balava).ofDeg(orgSunLong, orgMoonLong));
            if (currentKarna.Current != tempKarna.Current)
            {
                double difSpeed = cusps[3] - curSun.SpeedInLongitude;
                double karTimeDif = ((mod360.sub(cusps[0], curSun.Longitude) - karnaEnd) / ((difSpeed == 0) ? 1 : difSpeed)) * 1440 * -1;
                if (KarnaEndDateTime == null)
                    KarnaEndDateTime = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone).AddMinutes(karTimeDif);
            }
        }
        private void YogaEndTime(double[] cusps, AstroPlanet curSun, double orgSunLong, double orgMoonLong, Mod mod360)
        {
            double yogaEnd = Math.Truncate(mod360.add(orgMoonLong, orgSunLong) / AstroConsts.YogaLength) * AstroConsts.YogaLength + AstroConsts.YogaLength;
            AstroYoga tempYoga = new AstroYoga(new AstroYoga(EnumYoga.Shula).ofDeg(curSun.Longitude, cusps[0]));
            AstroYoga currentYoga = new AstroYoga(new AstroYoga(EnumYoga.Shula).ofDeg(orgSunLong, orgMoonLong));
            if (currentYoga.Current != tempYoga.Current)
            {
                double totalSpeed = curSun.SpeedInLongitude + cusps[3];
                double yogaTimeDif = ((mod360.add(cusps[0], curSun.Longitude) - yogaEnd) / ((totalSpeed == 0) ? 1 : totalSpeed)) * 1440 * -1;
                if (YogaEndDateTime == null)
                    YogaEndDateTime = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone).AddMinutes(yogaTimeDif);
            }
        }

        private void ThithiEndTime(double[] cusps, AstroPlanet curSun, double orgSunLong, double orgMoonLong, Mod mod360)
        {
            double thithiEnd = Math.Truncate(mod360.sub(orgMoonLong, orgSunLong) / AstroConsts.ThithiLength) * AstroConsts.ThithiLength + AstroConsts.ThithiLength;
            AstroThithi tempThithi = new AstroThithi(new AstroThithi(EnumThithi.Amavasya).ofDeg(curSun.Longitude, cusps[0]));
            AstroThithi currentThithi = new AstroThithi(new AstroThithi(EnumThithi.Amavasya).ofDeg(orgSunLong, orgMoonLong));

            if (currentThithi.Current != tempThithi.Current)
            {
                double difSpeed = cusps[3] - curSun.SpeedInLongitude;
                double thithiTimeDif = ((mod360.sub(cusps[0], curSun.Longitude) - thithiEnd) / ((difSpeed == 0) ? 1 : difSpeed)) * 1440 * -1;
                if (ThithiEndDateTime == null)
                    ThithiEndDateTime = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone).AddMinutes(thithiTimeDif);
            }
        }

        public List<AstroPlanet> CalculatePlanetPositionWithDetails()
        {
            List<AstroPlanet> planets = new List<AstroPlanet>();
            NakathEndDateTime = null;
            double[] cusps = new double[6];
            string serr = "";
            long iflgret;
            int planet;
            swissEph.swe_set_ephe_path(null);
            DateTime dt = new DateTime(Year, Month, Day, Hour, Minute, Second);
            TimeData tData = new TimeData(AstroPlace.GetUniversalTime(dt, LocationData.Longitude));
            double planetAvgSpeed = 0.0;
            /*
             * a loop over all planets
             */
            for (planet = SwissEph.SE_SUN; planet <= SwissEph.SE_CHIRON; planet++)
            {
                tjd_ut = tData.JulianDateTime;
                cusps = new double[6];
                double x2RasiStart = 0.0;
                double x2RasiEnd = 0.0;
                double x2NakathEnd = 0.0;
                if (planet == SwissEph.SE_EARTH
                    || planet == SwissEph.SE_MEAN_NODE || planet == SwissEph.SE_MEAN_APOG
                    || planet == SwissEph.SE_OSCU_APOG || planet == SwissEph.SE_CHIRON) continue;
                /*
                 * do the coordinate calculation for this planet p
                 */
                swissEph.swe_set_sid_mode(SwissEphNet.SwissEph.SE_SIDM_LAHIRI, 0, 0);
                bool shouldAdd = true;
                bool transitIsCaptured = false;
                AstroPlanet pReturn = null;
                AstroPlanet ketu = null;
                // Looping to find the next transit time/ reversing time of the planet body
                while (true)
                {
                    /*DateTime nowDate = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone);
                    if (nowDate.Subtract(dt).TotalDays > 365)
                        break;*/ //Commented since we don't have to break;
                    iflgret = swissEph.swe_calc_ut(tjd_ut, planet, AstroConsts.iflag, cusps, ref serr);
               
                    // Longitude
                    // Latitude
                    // Distance in AU
                    // Speed in longitude(deg / day)
                    // Speed in latitude(deg / day)
                    // Speed in distance(AU / day)
                    if (shouldAdd)
                    {
                        shouldAdd = false;
                        planetAvgSpeed = cusps[3];
                        pReturn = new AstroPlanet(planet, cusps, LocationData);
                        /*
                         * if there is a problem, a negative value is returned and an
                         * error message is in serr.
                         */
                        if (iflgret < 0)
                            pReturn.CalculationError = serr;
                        /*
                         * get the name of the planet p
                         */
                        pReturn.Name = swissEph.swe_get_planet_name(planet);
                        planets.Add(pReturn);
                        // Add Ketu
                        if (planet == SwissEph.SE_TRUE_NODE)
                        {
                            pReturn.Name = "Rahu";
                            double[] kethuCusps = new double[6];
                            cusps.CopyTo(kethuCusps, 0);
                            kethuCusps[0] = (kethuCusps[0] + 180.00) % 360;
                            ketu = new AstroPlanet(12, kethuCusps, LocationData);
                            ketu.Name = "Kethu";
                            planets.Add(ketu);
                        }
                        x2RasiStart = Math.Truncate(cusps[0] / AstroConsts.RasiLength) * AstroConsts.RasiLength;
                        x2RasiEnd = x2RasiStart + AstroConsts.RasiLength;
                        // Adjust the loop ending logic to include Nakath end degree 
                        // This way we can find the NakathEndTime too
                        if (x2NakathEnd == 0.0 && pReturn.Current == EnumPlanet.Moon)
                            x2NakathEnd = Math.Truncate(cusps[0] / AstroConsts.NakLength) * AstroConsts.NakLength + AstroConsts.NakLength;
                    }
                    else if (x2RasiStart < cusps[0] && cusps[0] < x2RasiEnd)
                    {
                        // Planet Reversing related Calculation 
                        if (pReturn.IsReversing && cusps[3] >= 0 && !pReturn.IsNode() && pReturn.ReversingEndAt == null)
                        {
                            pReturn.ReversingEndAt = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone);
                            pReturn.IsNivrutha = true;
                        }
                        else if (!pReturn.IsReversing && cusps[3] <= 0 && !pReturn.IsNode() && pReturn.ReversingStartingAt == null)
                        {
                            pReturn.ReversingStartingAt = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone);
                            pReturn.IsNivrutha = false;
                        }

                        // When Nakath ends before the rasi ends
                        if (pReturn.Current == EnumPlanet.Moon && NakathEndDateTime == null)
                        {
                            // Adjustment for actual Nakath End Time
                            double nakTimeDif = ((cusps[0] - x2NakathEnd) / ((cusps[3] == 0) ? 1 : cusps[3])) * 1440 * -1;
                            NakathEndDateTime = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone).AddMinutes(nakTimeDif);
                        }

                        double degreeToGo = (!transitIsCaptured) ?
                           Math.Truncate(cusps[0] / AstroConsts.RasiLength) * AstroConsts.RasiLength + AstroConsts.RasiLength - cusps[0]
                           : x2RasiEnd - cusps[0];

                        double daysToGo = 0.5;                       
                        double hoursToGo = Math.Abs(degreeToGo * 24 / ((planetAvgSpeed == 0) ? 1 : planetAvgSpeed));

                        tjd_ut += (daysToGo == 0) ? hoursToGo : daysToGo;
                    }
                    else if (pReturn != null && !transitIsCaptured)
                    {
                        Mod mod360 = new Mod(360);
                        // TODO: One time sun speed was 0 and made the adjustment as I didn't have internet
                        // Need to check it again to find out whether the 1 is a viable alternative here
                        double rasiTimeDif = ((mod360.sub(cusps[0], x2RasiEnd)) / ((cusps[3] == 0) ? 1 : cusps[3])) * 1440 * -1;
                        pReturn.NextTransitDateTime = TimeData.JulianToDateTime(tjd_ut, TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalHours).AddMinutes(rasiTimeDif);
                        if ((pReturn.Current == EnumPlanet.Rahu) && (ketu != null))
                            ketu.NextTransitDateTime = pReturn.NextTransitDateTime;
                        transitIsCaptured = true;
                        if (pReturn.Current == EnumPlanet.Moon && x2RasiEnd < x2NakathEnd)
                            x2RasiEnd = x2NakathEnd + 0.001; // Adustment to get it hit the internal logic
                        else
                            break;
                    }
                    else
                        break;
                }
            }
            return planets;
        }
        public List<AstroPlanet> CalculatePlanetPositionWithDetailsForAsync()
        {
            List<AstroPlanet> planets = new List<AstroPlanet>();
            NakathEndDateTime = null;
            double[] cusps = new double[6];
            string serr = "";
            long iflgret;
            int planet;
            swissEph.swe_set_ephe_path(null);
            DateTime dt = new DateTime(Year, Month, Day, Hour, Minute, Second);
            TimeData tData = new TimeData(dt.ToUniversalTime());
            /*
             * a loop over all planets
             */
            for (planet = SwissEph.SE_SUN; planet <= SwissEph.SE_CHIRON; planet++)
            {
                tjd_ut = tData.JulianDateTime;
                cusps = new double[6];
                double x2RasiStart = 0.0;
                double x2RasiEnd = 0.0;
                double x2NakathEnd = 0.0;
                if (planet == SwissEph.SE_EARTH
                    || planet == SwissEph.SE_MEAN_NODE || planet == SwissEph.SE_MEAN_APOG
                    || planet == SwissEph.SE_OSCU_APOG || planet == SwissEph.SE_CHIRON) continue;
                /*
                 * do the coordinate calculation for this planet p
                 */
                swissEph.swe_set_sid_mode(SwissEphNet.SwissEph.SE_SIDM_LAHIRI, 0, 0);
                bool shouldAdd = true;
                bool transitIsCaptured = false;
                AstroPlanet pReturn = null;
                // Looping to find the next transit time/ reversing time of the planet body
                while (true)
                {
                    DateTime nowDate = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone);
                    if (nowDate.Subtract(dt).TotalDays > 365)
                        break;
                    iflgret = swissEph.swe_calc_ut(tjd_ut, planet, AstroConsts.iflag, cusps, ref serr);
                    // Longitude
                    // Latitude
                    // Distance in AU
                    // Speed in longitude(deg / day)
                    // Speed in latitude(deg / day)
                    // Speed in distance(AU / day)
                    if (shouldAdd)
                    {
                        shouldAdd = false;
                        pReturn = new AstroPlanet(planet, cusps, LocationData);
                        /*
                         * if there is a problem, a negative value is returned and an
                         * error message is in serr.
                         */
                        if (iflgret < 0)
                            pReturn.CalculationError = serr;
                        /*
                         * get the name of the planet p
                         */
                        pReturn.Name = swissEph.swe_get_planet_name(planet);
                        planets.Add(pReturn);
                        // Add Ketu
                        if (planet == SwissEph.SE_TRUE_NODE)
                        {
                            pReturn.Name = "Rahu";
                            cusps[0] = (cusps[0] + 180.00) % 360;
                            AstroPlanet ketu = new AstroPlanet(12, cusps, LocationData);
                            ketu.Name = "Kethu";
                            planets.Add(ketu);
                        }
                        x2RasiStart = Math.Truncate(cusps[0] / AstroConsts.RasiLength) * AstroConsts.RasiLength;
                        x2RasiEnd = x2RasiStart + AstroConsts.RasiLength;
                        // Adjust the loop ending logic to include Nakath end degree 
                        // This way we can find the NakathEndTime too
                        if (x2NakathEnd == 0.0 && pReturn.Current == EnumPlanet.Moon)
                            x2NakathEnd = Math.Truncate(cusps[0] / AstroConsts.NakLength) * AstroConsts.NakLength + AstroConsts.NakLength;
                    }
                    else if (x2RasiStart < cusps[0] && cusps[0] < x2RasiEnd)
                    {
                        // Planet Reversing related Calculation 
                        if (pReturn.IsReversing && cusps[3] >= 0 && !pReturn.IsNode() && pReturn.ReversingEndAt == null)
                        {
                            pReturn.ReversingEndAt = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone);
                            pReturn.IsNivrutha = true;
                        }
                        else if (!pReturn.IsReversing && cusps[3] <= 0 && !pReturn.IsNode() && pReturn.ReversingStartingAt == null)
                        {
                            pReturn.ReversingStartingAt = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone);
                            pReturn.IsNivrutha = false;
                        }

                        // When Nakath ends before the rasi ends
                        if (pReturn.Current == EnumPlanet.Moon && NakathEndDateTime == null && x2NakathEnd < cusps[0])
                        {
                            // Adjustment for actual Nakath End Time
                            double nakTimeDif = ((cusps[0] - x2NakathEnd) / ((cusps[3] == 0) ? 1 : cusps[3])) * 1440 * -1;
                            NakathEndDateTime = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone).AddMinutes(nakTimeDif);
                        }

                        // Optimization for NextTransitTime Calculation
                        double degreeToGo = (!transitIsCaptured) ?
                            Math.Truncate(cusps[0] / AstroConsts.RasiLength) * AstroConsts.RasiLength + AstroConsts.RasiLength - cusps[0]
                            : x2RasiEnd - cusps[0];
                        int daysToGo = (int)(degreeToGo / ((cusps[3] == 0) ? 1 : cusps[3]));
                        double hoursToGo = degreeToGo * 24 / ((cusps[3] == 0) ? 1 : cusps[3]);
                        if ((0.001 > cusps[3]) && (-0.001 < cusps[3]))
                            tjd_ut += 1.0 / 1440.0;
                        else if ((daysToGo > 2) || (daysToGo < -2))
                            tjd_ut += 1;
                        else if ((hoursToGo > 2) || (hoursToGo < -2))
                            tjd_ut += 60.0 / 1440.0;
                        else
                            tjd_ut += 1.0 / 1440.0;
                    }
                    else if (pReturn != null && !transitIsCaptured)
                    {
                        // TODO: One time sun speed was 0 and made the adjustment as I didn't have internet
                        // Need to check it again to find out whether the 1 is a viable alternative here
                        double rasiTimeDif = ((cusps[0] - x2RasiEnd) / ((cusps[3] == 0) ? 1 : cusps[3])) * 1440 * -1;
                        pReturn.NextTransitDateTime = TimeData.JulianToDateTime(tjd_ut, LocationData.TimeZone).AddMinutes(rasiTimeDif);
                        transitIsCaptured = true;
                        if (pReturn.Current == EnumPlanet.Moon && x2RasiEnd < x2NakathEnd)
                            x2RasiEnd = x2NakathEnd + 0.001; // Adustment to get it hit the internal logic
                        else
                            break;
                    }
                    else
                        break;
                }
            }
            return planets;
        }
        public Horoscope CalculateHoroscope(List<AstroPlanet> pList)
        {
            swissEph.swe_set_ephe_path("C:\\SWEPH\\EPHE");

            DateTime dt = new DateTime(Year, Month, Day, Hour, Minute, Second);
            TimeData tData = new TimeData(AstroPlace.GetUniversalTime(dt, LocationData.Longitude));
            tjd_ut = tData.JulianDateTime;

            double[] cusps = new double[13];
            double[] ascmc = new double[10];
            // cusps - the end point of a house
            swissEph.swe_houses_ex(tjd_ut, SwissEph.SEFLG_SIDEREAL, LocationData.Latitude, LocationData.Longitude, 'A', cusps, ascmc);
            Horoscope horoScope = new Horoscope();
            Mod mod = new Mod(360);

            int lagna = 0;
            // postion starts from 1
            for (int i = 1; i < cusps.Length; i++)
                if ((cusps[i] > 0) && (cusps[i] < 30)) lagna = i;
            if (lagna == 0)
                for (int i = 1; i < cusps.Length; i++)
                    if ((cusps[i] > 0) && (cusps[i] < 35)) lagna = i;

            int j = 0;
            
            horoScope.RasiHouseList = new List<AstroRasi>();
            horoScope.BhavaHouseList = new List<AstroBhava>();
            IntCircle intCycle = new IntCircle(12, lagna);
            double lagnaAscendant = cusps[lagna];
            double bIncrement = 30.0;
            while (j != 12)
            {
                // The 14 is used as the adjustment required to
                // get the right lagna integer from the lagna integer
                AstroRasi rasi = new AstroRasi((EnumRasi)intCycle.ValueMinusCurrent(14));
                rasi.AscendentDegrees = cusps[intCycle.Current];
                rasi.AscendentDegreesFromMesha = (intCycle.Current == 1) ? 0.0 : mod.sub(cusps[1], cusps[intCycle.Current]) + cusps[intCycle.Current];
                rasi.RasiEndDegreesFromMesha = (intCycle.Current == 1) ? 0.0 : mod.sub(cusps[1], cusps[intCycle.Current]);
                rasi.RasiEndDegreesFromHorizon = cusps[intCycle.Current];
                rasi.RasiStartDegreesFromMesha = (intCycle.Previous == 1) ? 360.0 : mod.sub(cusps[1], cusps[intCycle.Previous]);
                rasi.RasiStartDegreesFromHorizon = cusps[intCycle.Previous];
                rasi.RasiMidDegreesFromMesha = (rasi.RasiStartDegreesFromMesha + rasi.RasiEndDegreesFromMesha) / 2.0;
                rasi.LengthDegrees = mod.sub(rasi.RasiEndDegreesFromMesha, rasi.RasiStartDegreesFromMesha);
                rasi.Length = rasi.LengthDegrees;
                rasi.HouseNumber = j + 1;
                foreach (AstroPlanet planet in pList)
                    if (planet.Longitude >= rasi.RasiEndDegreesFromMesha
                        && planet.Longitude <= rasi.RasiStartDegreesFromMesha ||
                        ((rasi.RasiStartDegreesFromMesha < rasi.RasiEndDegreesFromMesha) &&
                        (((planet.Longitude <= rasi.RasiStartDegreesFromMesha) && (planet.Longitude >= 0)) ||
                        ((planet.Longitude >= rasi.RasiEndDegreesFromMesha) && (planet.Longitude <= 360)))))
                    {
                        planet.Rasi = rasi;
                        planet.AjustedLongitude = mod.sub(planet.Longitude, rasi.RasiEndDegreesFromMesha);
                        rasi.Planets.Add(planet);
                        horoScope.RasiPlanetList.Add(planet);
                    }
                horoScope.RasiHouseList.Add(rasi);

                AstroBhava bhava = new AstroBhava();

                Bhava30DegreeStartingFromHorizon(pList, cusps, horoScope, mod, j, bIncrement, bhava);

                if (lagna == intCycle.Current)
                {
                    horoScope.LagnaRasi = rasi;
                    horoScope.NavamsaRasi = new AstroRasi(AstroBase.GetNawamsaRasi(rasi.AscendentDegreesFromMesha));
                }
                intCycle.GoBackward();
                j++;
                bIncrement = mod.sub(bIncrement, 30.0);
                if (j == 12) break;
            }

            return horoScope;
        }

        private static void Bhava30DegreeStartingFromHorizon(List<AstroPlanet> pList, double[] cusps, Horoscope horoScope, Mod mod, int j, double bIncrement, AstroBhava bhava)
        {
            bhava.BhavaEndDegreesFromHorizon = mod.sub(bIncrement, 30);
            bhava.BhavaStartDegreesFromHorizon = bIncrement;
            bhava.BhavaEndDegreesFromMesha = mod.sub(cusps[1], bhava.BhavaEndDegreesFromHorizon);// Rasi start/ end degress were adjusted but I didn't touch this. Rasi ascendent value has to add to the end value
            bhava.BhavaStartDegreesFromMesha = mod.add(bhava.BhavaEndDegreesFromMesha, 30);
            bhava.BhavaMidDegreesFromHorizon = mod.add(bhava.BhavaStartDegreesFromHorizon, bhava.BhavaEndDegreesFromHorizon) / 2.0;
            bhava.LengthDegrees = mod.sub(bhava.BhavaStartDegreesFromHorizon, bhava.BhavaEndDegreesFromHorizon);
            bhava.BhavaNumber = j + 1;
            foreach (AstroPlanet planet in pList)
                if ((planet.Longitude >= bhava.BhavaEndDegreesFromMesha
                    && planet.Longitude <= bhava.BhavaStartDegreesFromMesha) ||
                    ((bhava.BhavaStartDegreesFromMesha < bhava.BhavaEndDegreesFromMesha) &&
                    (((planet.Longitude <= bhava.BhavaStartDegreesFromMesha) && (planet.Longitude >= 0)) ||
                    ((planet.Longitude >= bhava.BhavaEndDegreesFromMesha) && (planet.Longitude <= 360)))))
                {
                    planet.Bhava = bhava;
                    planet.AjustedBhavaLongitude = mod.sub(planet.Longitude, bhava.BhavaEndDegreesFromMesha);
                    planet.Bhava = bhava;
                    bhava.Planets.Add(planet);
                    horoScope.BhavaPlanetList.Add(planet);
                }
            horoScope.BhavaHouseList.Add(bhava);
        }

        private static void Bhava15DegreeEitherSideFromLagna(List<AstroPlanet> pList, double[] cusps, Horoscope horoScope, Mod mod, int j, double bIncrement, AstroBhava bhava)
        {
            bhava.BhavaEndDegreesFromHorizon = mod.sub(bIncrement, 30);
            bhava.BhavaStartDegreesFromHorizon = bIncrement;
            bhava.BhavaEndDegreesFromMesha = mod.sub(cusps[1], bhava.BhavaEndDegreesFromHorizon);
            bhava.BhavaStartDegreesFromMesha = mod.add(bhava.BhavaEndDegreesFromMesha, 30);
            bhava.BhavaMidDegreesFromHorizon = mod.add(bhava.BhavaStartDegreesFromHorizon, bhava.BhavaEndDegreesFromHorizon) / 2.0;
            bhava.LengthDegrees = mod.sub(bhava.BhavaStartDegreesFromHorizon, bhava.BhavaEndDegreesFromHorizon);
            bhava.BhavaNumber = j + 1;
            foreach (AstroPlanet planet in pList)
                if ((planet.Longitude >= bhava.BhavaEndDegreesFromMesha
                    && planet.Longitude <= bhava.BhavaStartDegreesFromMesha) ||
                    ((bhava.BhavaStartDegreesFromMesha < bhava.BhavaEndDegreesFromMesha) &&
                    (((planet.Longitude <= bhava.BhavaStartDegreesFromMesha) && (planet.Longitude >= 0)) ||
                    ((planet.Longitude >= bhava.BhavaEndDegreesFromMesha) && (planet.Longitude <= 360)))))
                {
                    planet.Bhava = bhava;
                    planet.AjustedBhavaLongitude = mod.sub(planet.Longitude, bhava.BhavaEndDegreesFromMesha);
                    planet.Bhava = bhava;
                    bhava.Planets.Add(planet);
                    horoScope.BhavaPlanetList.Add(planet);
                }
            horoScope.BhavaHouseList.Add(bhava);
        }

        public double GetTarnsit(EnumPlanet planet, AstroPlace place)
        {
            double[] geopos = new double[10];
            geopos[0] = place.Longitude;
            geopos[1] = place.Latitude;
            double atpress = 1013.25;
            double attemp = 0.0;
            double tret = 0.0;
            string serr = "";

            // one of SEFLG_SWIEPH, SEFLG_JPLEPH, SEFLG_MOSEPH
            int i = swissEph.swe_rise_trans_true_hor(tjd_ut, (int)planet, "", SwissEph.SEFLG_MOSEPH, SwissEph.SE_CALC_RISE, geopos, atpress, attemp, 0.0, ref tret, ref serr);
            return tret;
        }
    }
}
