using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            string[] data = degreeAngle.Split(new char[] { '°', '\'', ' '
                , '\"' }, StringSplitOptions.RemoveEmptyEntries);
            double minutes = Convert.ToDouble(data[1]);
            double degrees = Convert.ToDouble(data[0]);
            double seconds = (data.Length > 2) ? Convert.ToDouble(data[2]) : 0.0;
            //Decimal degrees = 
            //   whole number of degrees, 
            //   plus minutes divided by 60, 
            //   plus seconds divided by 3600
            return degrees + (minutes / 60) + (seconds / 3600);
        }

        public static int AstroCycleIncrease(int house, int increment)
        {
            IntCircle circle = new IntCircle(12, house);
            return circle.Add(increment);
        }

        public static int HouseGab(int house1, int house2)
        {
            if (house1 < house2)
                return 1 + house2 - house1;
            else if (house1 == house2)
                return 1;
            else
                return 13 - (house1 - house2);
        }

        public static int AstroCycleDecrease(int house, int decrease)
        {
            IntCircle circle = new IntCircle(12, house);
            return circle.Minus(decrease);
        }

        public static void TimeSpanToDateParts(DateTime d1
            , DateTime d2, out int years, out int months
            , out int days, out int hours, out int minutes)
        {
            if (d1 < d2)
            {
                var d3 = d2;
                d2 = d1;
                d1 = d3;
            }

            var span = d1 - d2;
            months = 12 * (d1.Year - d2.Year) + (d1.Month - d2.Month);
            //month may need to be decremented because the above calculates
            //the ceiling of the months, not the floor.
            //to do so we increase d2 by the same number of months and compare.
            //(500ms fudge factor because datetimes are not precise enough
            //to compare exactly)
            if (d1.CompareTo(d2.AddMonths(months).AddMilliseconds(-500)) <= 0)
                --months;
            years = months / 12;
            months -= years * 12;
            if (months == 0 && years == 0)
                days = span.Days;
            else
            {
                var md1 = new DateTime(d1.Year, d1.Month, d1.Day);
                // Fixed to use d2.Day instead of d1.Day
                var md2 = new DateTime(d2.Year, d2.Month, d2.Day);
                var mDays = (int)(md1 - md2).TotalDays;

                if (mDays > span.Days)
                    mDays = (int)(md1.AddMonths(-1) - md2).TotalDays;

                days = span.Days - mDays;
            }
            hours = span.Hours;
            minutes = span.Minutes;
        }

        public static void DateDiff(DateTime dt1, DateTime dt2, out int years, out int months
            , out int days)
        {
            if (dt1 > dt2)
            {
                var dt3 = dt2;
                dt2 = dt1;
                dt1 = dt3;
            }

            DateTime zeroTime = new DateTime(1, 1, 1);

            int leapDaysInBetween = CountLeapDays(dt1, dt2);

            TimeSpan span = dt2 - dt1;

            years = (zeroTime + span).Year - 1;
            months = (zeroTime + span).Month - 1;
            days = (zeroTime + span).Day - (leapDaysInBetween % 2 == 1 ? 1 : 0);
        }

        private static int CountLeapDays(DateTime dt1, DateTime dt2)
        {
            int leapDaysInBetween = 0;
            int year1 = dt1.Year, year2 = dt2.Year;
            DateTime dateValue;

            for (int i = year1; i <= year2; i++)
            {
                if (DateTime.TryParse("02/29/" + i.ToString(), out dateValue))
                {
                    if (dateValue >= dt1 && dateValue <= dt2)
                        leapDaysInBetween++;
                }
            }

            return leapDaysInBetween;
        }
    }
}
