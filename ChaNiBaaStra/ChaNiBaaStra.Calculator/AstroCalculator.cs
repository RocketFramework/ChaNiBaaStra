using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.DataModels;
using SwissEphNet;

namespace ChaNiBaaStra.Calculator
{
    public class AstroCalculator : CalculationBase
    {
        // Just to test this is removed
        /*public AstroCalculator() : this(new DateTime(2016, 9, 26, 7, 31, 0), new AstroPlace())
        { }*/
        public AstroCalculator(AstroPlace place) : base(place, false)
        {
            WeekDay = new AstroWeekDay((EnumWeekDay)((int)place.AdjustedBirthDateTime.DayOfWeek + 1));
            Nakath = new AstroNakath(this.Moon.Longitude);
        }

        public Mod mod = new Mod();


        public class Rasi
        {
            public static double rasiLength = 30.0;

            public static string[] vals = new string[] { "Mesha", "Vrushabha", "Mithuna", "Kataka", "Sinha", "Kanya", "Thula", "Vrushchika", "Dhanu", "Makara", "Kumbha", "Meena" };
            public static string ofIndex(int index)
            {
                return vals[(vals.Length - index) % vals.Length];
            }

            public static string ofDeg(double deg)
            {
                return ofIndex((int)(deg / rasiLength));
            }
        }
        public class Bhava
        {
            string House;
            int BhavaNumber;
            double Start;
            double Mid;
            double End;
            double Length;
            public Mod mod = new Mod();
            public Bhava() { }
            public Bhava(int bhava, double start, double mid, double end)
            {
                BhavaNumber = bhava;
                Start = start;
                Mid = mid;
                End = end;
                Length = mod.sub(end, start);
                House = Rasi.ofDeg(mid);
            }
        }
        // Just to check this was renamed
        public void test22()
        {
            SwissEphNet.SwissEph t = new SwissEph();
            double[] house = new double[13];
            double[] ascmc = new double[10];
            double lt = 6.9;
            double lg = 79.8612;
            DateTime d = new DateTime(2012, 8, 1, 7, 31, 0).ToUniversalTime();
            double tjd_ut = ToJulianDate(d);
            t.swe_houses(tjd_ut, lt, lg, 'P', house, ascmc);
            double start = mod.add(house[12], (mod.sub(house[1], house[12]) / 2));
            double ascendant = house[1];
            double end = 0.0;
            Bhava[] housePositions = new Bhava[12];
            for (int i = 1; i < house.Length - 1; i++)
            {
                end = mod.add(house[i], (mod.sub(house[i + 1], house[i]) / 2));
                housePositions[i - 1] = new Bhava(i, start, house[i], end);
                start = end;
            }
            end = mod.add(house[12], (mod.sub(house[1], house[12]) / 2));
            housePositions[11] = new Bhava(12, start, house[12], end);

            t.swe_set_ephe_path("C:\\SWEPH\\EPHE");
            char sp;
            string sdate = DateTime.Now.ToString("dd/mm/yyyy");
            char[] snam = new char[40];
            string serr = "";
            int jday = 1, jmon = 1, jyear = 2000;
            double jut = 0.0;

            double te;
            double[] x2 = new double[6];
            int iflag, iflgret;
            int p;
            t.swe_set_ephe_path(null);

            iflag = SwissEphNet.SwissEph.SEFLG_SPEED;
            while (true)
            {
                string returnString = "\nDate (d.m.y) ?";

                /*
                 * we have day, month and year and convert to Julian day number
                 */
                //tjd_ut = t.swe_julday(jyear, jmon, jday, jut, SwissEphNet.SwissEph.SE_GREG_CAL);
                /*
                 * compute Ephemeris time from Universal time by adding delta_t
                 * not required for Swisseph versions smaller than 1.60
                 */
                /* te = tjd_ut + swe_deltat(tjd_ut); */
                SwissEphNet.C.sprintf("date: %02d.%02d.%d at 0:00 Universal time\n", jday, jmon, jyear);
                returnString += "planet     \tlongitude\tlatitude\tdistance\tspeed long.\n";
                /*
                 * a loop over all planets
                 */
                for (p = SwissEphNet.SwissEph.SE_SUN; p <= SwissEphNet.SwissEph.SE_CHIRON; p++)
                {
                    if (p == SwissEphNet.SwissEph.SE_EARTH) continue;
                    /*
                     * do the coordinate calculation for this planet p
                     */
                    iflgret = t.swe_calc_ut(tjd_ut, p, iflag, x2, ref serr);

                    //t.swe_set_sid_mode(SwissEphNet.SwissEph.SE_SIDM_LAHIRI, 0, 0);
                    // t.swe_set_topo(-2.35, 51.5, 0);
                    //t.swe_date_conversion(2016, 4, 20, 7.5 - 5.5, 'g', ref tjd_ut);

                    //t.swe_date_conversion(1975, 7, 2, (12 + (34.00 / 60.00)) - 5.5, 'g',ref tjd_ut);
                    //double ayana = t.swe_get_ayanamsa_ut(tjd_ut);
                    t.swe_houses(tjd_ut, lt, lg, 'P', house, ascmc);
                    double[] pPosition = new double[6];
                    t.swe_calc_ut(tjd_ut, p, SwissEphNet.SwissEph.SEFLG_SIDEREAL, pPosition, ref serr);
                    /* Swisseph versions older than 1.60 require the following
                     * statement instead */
                    /* iflgret = swe_calc(te, p, iflag, x2, serr); */
                    /*
                     * if there is a problem, a negative value is returned and an
                     * error message is in serr.
                     */
                    if (iflgret < 0)
                        returnString += "error: " + serr;
                    /*
                     * get the name of the planet p
                     */
                    t.swe_get_planet_name(p);
                    /*
                     * print the coordinates
                     */
                    /*printf("%10s\t%11.7f\t%10.7f\t%10.7f\t%10.7f\n",
                            snam, x2[0], x2[1], x2[2], x2[3]);*/
                }
            }
            return;
        }

        public double ToJulianDate(DateTime date)
        {
            return date.ToOADate() + 2415018.5;
        }
    }
}
