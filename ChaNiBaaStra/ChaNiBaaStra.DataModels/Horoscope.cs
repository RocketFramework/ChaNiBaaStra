using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.DataModels;

namespace ChaNiBaaStra.DataModels
{
    public class Horoscope
    {
        public Horoscope()
        {
            RasiPlanetList = new List<AstroPlanet>();
            BhavaPlanetList = new List<AstroPlanet>();
            RasiHouseList = new List<AstroRasi>();
            BhavaHouseList = new List<AstroBhava>();
        }
        public BirthRasiExtra ExtraDetails { get; set; }
        public AstroRasi NavamsaRasi { get; set; }
        public AstroRasi LagnaRasi { get; set; }
        public AstroNakath Nakath { get; set; }
        public List<AstroPlanet> RasiPlanetList { get; set; }
        public List<AstroPlanet> BhavaPlanetList { get; set; }
        public List<AstroRasi> RasiHouseList { get; set; }
        public List<AstroBhava> BhavaHouseList { get; set; }
    }
}
