using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public class AstroDasa
    {
        private EnumPlanet[] orderByDasa = new EnumPlanet[] { EnumPlanet.Sun, EnumPlanet.Moon
            , EnumPlanet.Mars, EnumPlanet.Rahu, EnumPlanet.Jupiter, EnumPlanet.Saturn
            , EnumPlanet.Mercury, EnumPlanet.Kethu, EnumPlanet.Venus };
        private double[] orderedDasaPeriod = new double[] { 6.0, 10.0, 7.0, 18.0, 16.0, 19.0, 17.0, 7.0, 20.0 };

        public EnumPlanet getDasaLord(double moonLon)
        {
            int i = 0;
            for (i = 0; i <= 26; i++)
                if (((i * (AstroConsts.NakLength)) <= moonLon)
                        && (moonLon < ((i + 1) * (AstroConsts.NakLength))))
                    break;
            int inum = ((int)(i + 7)) % 9;
            if (inum == 0) inum = 9;
            return orderByDasa[inum];
        }

        public double computeBalance(double moonLongitude, int dasaLoadIndex)
        {

            double balance = moonLongitude % AstroConsts.NakLength;
            if (balance == 0)
                balance = AstroConsts.NakLength;

            balance = AstroConsts.NakLength - balance;
            balance = balance * 60;

            return (balance * orderedDasaPeriod[dasaLoadIndex]) / 800;
        }
    }
}
