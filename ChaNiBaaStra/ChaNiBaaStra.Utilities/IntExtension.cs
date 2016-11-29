using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.Utilities
{
    public static class IntExtension
    {
        public static bool IsEven(this int value)
        {
            return ((value / 2 - (int)(value / 2)) == 0);
        }
    }
}
