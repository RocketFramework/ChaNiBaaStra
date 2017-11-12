using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Handlers;
using ChaNiBaaStra.Dal.Models;

namespace ChaNiBaaStra.DataModels
{
    public enum EnumThithi
    {
        Prathamai = 1,
        Dvithiyai = 2,
        Thrithiyai = 3,
        Chathruthi = 4,
        Panchami = 5,
        Sashti = 6,
        Sapthami = 7,
        Ashtami = 8,
        Navami = 9,
        Dasami = 10,
        Ekaadasi = 11,
        Dvaadasi = 12,
        Thrayodasi = 13,
        Chathurdasi = 14,
        Pournami = 15,
        Amavasya = 16
    }
    public enum EnumPaksha
    {
        Shukla,
        Krishna
    }
    public class AstroThithi : AstroBase<EnumThithi, Thithi>
    {
        public AstroThithi(EnumThithi thithi) : base(thithi, 16, AstroConsts.ThithiLength)
        {
            ThithiHandler handler = new ThithiHandler();
            this.DataModel = handler.GetFirstGeneric(x => x.ThithiId == CurrentInt).Result;
        }
        public AstroThithi(int thithiInt) : this((EnumThithi)thithiInt)
        { }

        public double FindThithiEnd(double sun, double moon, double sunSpeed, double moonSpeed)
        {
            double diff = getMoonSunDiff(sun, moon);
            double diffSpeed = moonSpeed - sunSpeed;
            double bal = AstroConsts.ThithiLength - (diff % AstroConsts.ThithiLength);
            double time = endTime(diffSpeed, bal);
            return (this.Place.TimeZone + time);
        }
        public EnumThithi ofDeg(double sun, double moon)
        {
            EnumThithi thithi;
            ThithiPaksha = EnumPaksha.Shukla;
            double diff;

            if (moon > sun)
                diff = moon - sun;
            else
                diff = (moon + 360) - sun;

            if (diff > 180.0)
            {
                ThithiPaksha = EnumPaksha.Krishna;
                diff = diff - 180;
            }

            thithi = ofIndex((int)Math.Ceiling(diff / AstroConsts.ThithiLength));

            //For Krishna Paksha 15th thithi is Ammavasya
            if ((thithi == EnumThithi.Pournami) && (ThithiPaksha == EnumPaksha.Krishna))
                thithi = EnumThithi.Amavasya;

            return thithi;
        }
        public EnumPaksha ThithiPaksha { get; set; }
        public bool IsGood { get { return DataModel.IsGood; } }
        public DateTime? EndTime { get; set; }
        public static double getMoonSunDiff(double sun, double moon)
        {
            double diff;
            if (moon > sun)
                diff = moon - sun;
            else
                diff = (moon + 360) - sun;

            if (diff > 180.0)
                diff = diff - 180;
            return diff;
        }

        public double endTime(double speed, double bal)
        {
            double time = (24.00 * (bal)) / speed;
            return time;
        }

        /*private double computeCorrection(double position, double expected, double caltime, double length, double diffSpeed)
        {
            double correction = 0.0;
            SwissHelper swissHelper = new SwissHelper(new SweDate(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH) + 1, cal.get(Calendar.DAY_OF_MONTH), caltime));
            EnumMap<Planet, Double> planetPosition = swissHelper.getPlanetaryPosition(EnumSet.of(Planet.Sun, Planet.Moon));

            double newmoon = planetPosition.get(Planet.Moon);
            double newsun = planetPosition.get(Planet.Sun);

            double newdiff = getMoonSunDiff(newsun, newmoon);

            double newbal = expected - newdiff;
            if ((expected % 180) == 0 && newbal > length)
            {
                newbal = newbal - 180;
            }

            correction = endTime(diffSpeed, newbal);

            if (Math.Abs(newbal) > PAN_APPROXIMATION)
            {

                correction = correction + computeCorrection(getMoonSunDiff(newsun, newmoon), expected, caltime + correction, length, diffSpeed);
            }
            return correction;

        }*/
    }
}
