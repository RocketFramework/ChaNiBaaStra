using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.Utilities
{
    public class AstroUtility
    {
        public static int[] GetDegreeMinuteSeconds(double value)
        {
            int deg = (int)value;
            double mindob = (value - deg) * 60;
            int min = Math.Abs((int)(mindob));
            int sec = Math.Abs((int)((mindob + min) * 60));
            return new int[] { deg, min, sec };
        }
        public double ToAstroDecimal(int deg, int min, int sec)
        {
            double temp = (((deg * 60) + min) * 60) + sec;
            double res = (double)(temp / 3600);
            return res;
        }
        private double ToAstroDecimal(string deg, string min, string sec)
        {
            return ToAstroDecimal(Convert.ToInt32(deg)
                , Convert.ToInt32(min)
                , Convert.ToInt32(sec));
        }

        public static double ConvertDegreeAngleToDouble(string degreeAngle)
        {
            string[] data = degreeAngle.Split(new char[] { '°', '\'', ' ', '\"' }, StringSplitOptions.RemoveEmptyEntries);
            double minutes = Convert.ToDouble(data[1]);
            double degrees = Convert.ToDouble(data[0]);
            double seconds = (data.Length > 2) ? Convert.ToDouble(data[2]) : 0.0;
            //Decimal degrees = 
            //   whole number of degrees, 
            //   plus minutes divided by 60, 
            //   plus seconds divided by 3600

            return degrees + (minutes / 60) + (seconds / 3600);
        }
    }
}
