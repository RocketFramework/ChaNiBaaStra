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
        public AstroTransitDate CurrentTransitDate { get; set; }

        public Horoscope()
        {
            RasiPlanetList = new List<AstroPlanet>();
            BhavaPlanetList = new List<AstroPlanet>();
            RasiHouseList = new List<AstroRasi>();
            BhavaHouseList = new List<AstroBhava>();
            CompletePlanetList = new List<AstroPlanet>();
        }
        public BirthRasiExtra ExtraDetails { get; set; }
        public AstroRasi NavamsaRasi { get; set; }
        public AstroRasi LagnaRasi { get; set; }

        public List<AstroPlanet> RasiPlanetList { get; set; }
        public List<AstroPlanet> BhavaPlanetList { get; set; }
        public List<AstroPlanet> CompletePlanetList { get; set; }

        public List<AstroRasi> RasiHouseList { get; set; }
        public List<AstroBhava> BhavaHouseList { get; set; }

        public AstroDasas AstroDasaDetails { get; set; }
        public AstroNakath Nakath { get { return this.CurrentTransitDate.Nakath; } }

        public int IsMaleHoroscope()
        {
            if ((LagnaRasi.IsMaleRashi)
                && (NavamsaRasi.IsMaleRashi)
                && (LagnaRasi.DoshKanaya != 2)
                && (CurrentTransitDate.Moon.Rasi.IsMaleRashi)
                && (CurrentTransitDate.Mars.Rasi.IsMaleRashi)
                && (CurrentTransitDate.Venus.Rasi.IsMaleRashi)
                && (CurrentTransitDate.Moon.NavamsaRasi.IsMaleRashi)
                && (CurrentTransitDate.Mars.NavamsaRasi.IsMaleRashi)
                && (CurrentTransitDate.Venus.NavamsaRasi.IsMaleRashi))
                return 100;
            else if ((LagnaRasi.IsMaleRashi)
                && (NavamsaRasi.IsMaleRashi))
                return 50;
            else if ((LagnaRasi.IsMaleRashi)
                && (NavamsaRasi.IsMaleRashi)
                && (LagnaRasi.DoshKanaya != 2))
                return 50;
            else if ((LagnaRasi.IsMaleRashi)
                && (NavamsaRasi.IsMaleRashi)
                && (LagnaRasi.DoshKanaya != 2)
                && (CurrentTransitDate.Mars.Rasi.IsMaleRashi)
                && (CurrentTransitDate.Mars.NavamsaRasi.IsMaleRashi))
                return 70;

            if ((NavamsaRasi.IsMaleRashi)
                || ((LagnaRasi.IsMaleRashi) && (LagnaRasi.DoshKanaya != 2))
                || ((!LagnaRasi.IsMaleRashi) && (LagnaRasi.DoshKanaya == 2))
                || ((CurrentTransitDate.Moon.Rasi.IsMaleRashi)
                && (CurrentTransitDate.Mars.Rasi.IsMaleRashi)
                && (CurrentTransitDate.Venus.Rasi.IsMaleRashi)
                && (CurrentTransitDate.Moon.NavamsaRasi.IsMaleRashi)
                && (CurrentTransitDate.Mars.NavamsaRasi.IsMaleRashi)
                && (CurrentTransitDate.Venus.NavamsaRasi.IsMaleRashi))) return 50;

            return 0;
        }
    }
}
