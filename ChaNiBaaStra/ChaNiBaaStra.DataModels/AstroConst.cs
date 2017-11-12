using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Models;
using SwissEphNet;

namespace ChaNiBaaStra.DataModels
{
    public class AstroConsts
    {
        public static double NakLength = (double)(360.00 / 27.0);

        public static double PadaLength = (double)(360.00 / 108.0);

        public static double ThithiLength = 12.0;

        public static double KaranaLength = 6.0;

        public static double YogaLength = NakLength;

        public static double RasiLength = 30.0;

        public static double MILLIS_IN_DAY = 24 * 60 * 60 * 1000;

        public static long MILLIS_IN_HR = (1000 * 60 * 60);

        public static int iflag = SwissEph.SEFLG_SWIEPH | SwissEph.SEFLG_SPEED | SwissEph.SEFLG_SIDEREAL; // SwissEph.SEFLG_SIDEREAL | SwissEph.SEFLG_SPEED | SwissEph.SEFLG_SWIEPH;

        public static int InvalidIntInput = -1;

        public static double CHATHURDASI_SECOND_HALF = 342.00;

        public static double PAN_APPROXIMATION = 0.01;

        public static int AUS_TIME_ROW = 9;

        //public static int HOUSE_SYSTEM = (int)'P';

        public static int HOUSE_FLAG = SwissEph.SEFLG_SIDEREAL;
        public static List<int> PowerfulHouses = new List<int> { 1, 4, 7, 10, 5, 9 };
        public static List<int> GoodPlanetRashiRelationShips = new List<int> { (int)EnumRelationshipTypes.Uchcha, (int)EnumRelationshipTypes.UchchaMulaThrikona, (int)EnumRelationshipTypes.Swashesthra, (int)EnumRelationshipTypes.SwashesthraMulaThrikona, (int)EnumRelationshipTypes.MulaThrikona, (int)EnumRelationshipTypes.Mithra };

    }
}