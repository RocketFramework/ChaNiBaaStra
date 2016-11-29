using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public class Mod
    {
        int _mod;
        int _min;
        public Mod()
        {
            _mod = 360;
            _min = 0;
        }
        public Mod(int mod)
        {
            _mod = mod;
        }

        public Mod(int mod, int min)
        {
            _mod = mod;
            _min = min;
        }
        public double add(double n1, double n2)
        {
            double a = ((n1 + n2) % _mod);
            if (a < _min)
                a = (a % _mod) + _mod;
            return (a == _min) ? _mod : a;
        }

        public double sub(double n1, double n2)
        {
            double res = n1 - n2;
            if (res == _min) return _min;

            if (res < _min)
                res = (res % _mod) + _mod;

            if (res == _min)
                return _mod;

            return (res % _mod);
        }

        public int add(int n1, int n2)
        {
            int a = (n1 + n2) % _mod;
            if (a < _min)
                a = (a % _mod) + _mod;
            return (a == _min) ? _mod : a;
        }

        public int sub(int n1, int n2)
        {
            int res = n1 - n2;

            if (res < _min)
                res = (res % _mod) + _mod;

            if (res == _mod)
                return _mod;
            return (res % _mod);
        }
    }
}
