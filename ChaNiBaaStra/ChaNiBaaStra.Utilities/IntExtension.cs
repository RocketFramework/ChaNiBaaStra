using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.Utilities
{
    public static class IntExtension
    {
        public static string ToCustomString(this List<int> list)
        {
            StringBuilder sb = new StringBuilder();

            // Append each integer in the list to the StringBuilder
            foreach (int num in list)
            {
                sb.Append(num);
                sb.Append(" "); // Add space between numbers for clarity, can be modified as needed
            }

            // Remove the last space if list is not empty
            if (sb.Length > 0)
                sb.Length--;

            return sb.ToString();
        }

        public static bool IsEven(this int value)
        {
            return ((value % 2) == 0);
        }

        public static string ToDegreeString(this double value)
        {
            string result;
            double coord = value;
            var ts = TimeSpan.FromHours(Math.Abs(coord));
            int degrees = Convert.ToInt32(Math.Sign(coord) * Math.Floor(ts.TotalHours));
            int minutes = ts.Minutes;
            int seconds = ts.Seconds;

            //gets the degree
            result = degrees + "°";
            result += minutes + "'";
            result += seconds + "\"";
            return result;
        }
    }
}
