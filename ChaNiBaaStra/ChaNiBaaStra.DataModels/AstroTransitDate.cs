using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Utilities;
using SwissEphNet;

namespace ChaNiBaaStra.DataModels
{
    public class AstroTransitDate 
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
        public AstroDasas Dasas { get; set; }
        /// <summary>
        /// End time of the currently active Nakath
        /// </summary>
        public static DateTime? NakathEndDateTime { get; set; }
        public static DateTime? ThithiEndDateTime { get; set; }
        public static DateTime? KarnaEndDateTime { get; set; }
        public static DateTime? YogaEndDateTime { get; set; }
        public Horoscope Horoscope { get; set; }

        public DateTime SunRise { get; set; }
        public DateTime SunSet { get; set; }
        public int Second { get; set; }

        public AstroTransitDate()
        { }

        public AstroTransitDate(AstroPlace locationData, bool IsWithDetails) 
        {
        }
    }
}
