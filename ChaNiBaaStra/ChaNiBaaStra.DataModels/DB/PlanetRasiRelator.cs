using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels.DB
{
    public class PlanetToRasi
    {
        private AstroPlanet planet;
        private AstroRasi rasi;
        public PlanetToRasi(AstroPlanet planet, AstroRasi rasi)
        {
        }

        public AstroPlanet Planet
        {
            get
            {
                return planet;
            }

            set
            {
                planet = value;
            }
        }

        public AstroRasi Rasi
        {
            get
            {
                return rasi;
            }

            set
            {
                rasi = value;
            }
        }
    }
    public class PlanetRasiRelator 
    {
    }
}
