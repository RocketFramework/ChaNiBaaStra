using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Handlers;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;

namespace ChaNiBaaStra.DataModels
{
    public enum EnumRasi
    {
        Mesha = 1,
        Vrishabha = 2,
        Mithuna = 3,
        Kataka = 4,
        Simha = 5,
        Kanya = 6,
        Thula = 7,
        Vrichika = 8,
        Dhanus = 9,
        Makara = 10,
        Kumbha = 11,
        Meena = 12
    }

    public class AstroBhava : AstroRasi
    {
        public AstroBhava()
        { Planets = new List<AstroPlanet>(); }
        /// <summary>
        /// Starting from Mesha
        /// </summary>
        public double BhavaStartDegreesFromMesha { get; set; }
        /// <summary>
        /// Starting from Mesha
        /// </summary>
        public double BhavaEndDegreesFromMesha { get; set; }
        /// <summary>
        /// Starting from Mesha
        /// </summary>
        public double BhavaMidDegreesFromMesha { get; set; }
        /// <summary>
        /// Starting from Horizon
        /// </summary>
        public double BhavaStartDegreesFromHorizon { get; set; }
        /// <summary>
        /// Starting from Horizon
        /// </summary>
        public double BhavaEndDegreesFromHorizon { get; set; }
        /// <summary>
        /// Starting from Horizon
        /// </summary>
        public double BhavaMidDegreesFromHorizon { get; set; }
        public int BhavaNumber { get; set; }
        //public double LengthDegrees { get; set; }
        //public List<AstroPlanet> Planets { get; set; }
    }
    public class AstroRasi : AstroBase<EnumRasi, Rashi>
    {
        public AstroRasi(EnumRasi rasi) : base(rasi, 12, AstroConsts.RasiLength)
        {
            Planets = new List<AstroPlanet>();
            //SetAdhipathi();
        }
        public AstroRasi()
        {
        }
        public int HouseNumber { get; set; }

        /// <summary>
        /// Starting from Mesha
        /// </summary>
        public double RasiStartDegreesFromMesha { get; set; }
        /// <summary>
        /// Starting from Mesha
        /// </summary>
        public double RasiEndDegreesFromMesha { get; set; }
        /// <summary>
        /// Starting from Mesha
        /// </summary>
        public double RasiMidDegreesFromMesha { get; set; }
        /// <summary>
        /// Starting from Horizon
        /// </summary>
        public double RasiStartDegreesFromHorizon { get; set; }
        /// <summary>
        /// Starting from Horizon
        /// </summary>
        public double AscendentDegrees { get; set; }
        /// <summary>
        /// Starting from Horizon
        /// </summary>
        public double RasiEndDegreesFromHorizon { get; set; }
        /// <summary>
        /// Starting from Horizon
        /// </summary>
        public double RasiMidDegreesFromHorizon { get; set; }

        /// <summary>
        /// Actual Length of the rasi as per actual start and end
        /// </summary>
        public double LengthDegrees { get; set; }
        public List<AstroPlanet> Planets { get; set; }
        public double AscendentDegreesFromMesha { get; set; }
        public bool IsBadakaSthana { get; set; }

        public bool IsMaleRashi { get { return !this.CurrentInt.IsEven(); } }
        public int DoshKanaya { get { return (int)((this.AscendentDegrees % 30) / 10) % 3 + 1; } }
        public List<EnumPlanet> AdhipathiPlanets { 
            get
            {
                switch(this.Current)
                {
                    case EnumRasi.Mesha: { return new List<EnumPlanet>() { EnumPlanet.Mars, EnumPlanet.Sun, EnumPlanet.Pluto }; }
                    case EnumRasi.Vrishabha: { return new List<EnumPlanet>() { EnumPlanet.Venus, EnumPlanet.Moon  }; }
                    case EnumRasi.Mithuna: { return new List<EnumPlanet>() { EnumPlanet.Mercury }; }
                    case EnumRasi.Kataka: { return new List<EnumPlanet>() { EnumPlanet.Moon, EnumPlanet.Jupiter, EnumPlanet.Neptune }; }
                    case EnumRasi.Simha: { return new List<EnumPlanet>() { EnumPlanet.Sun, EnumPlanet.Pluto }; }
                    case EnumRasi.Kanya: { return new List<EnumPlanet>() { EnumPlanet.Mercury, EnumPlanet.Rahu }; }
                    case EnumRasi.Thula: { return new List<EnumPlanet>() { EnumPlanet.Venus, EnumPlanet.Saturn }; }
                    case EnumRasi.Vrichika: { return new List<EnumPlanet>() { EnumPlanet.Mars, EnumPlanet.Kethu, EnumPlanet.Uranus }; }
                    case EnumRasi.Dhanus: { return new List<EnumPlanet>() { EnumPlanet.Jupiter}; }
                    case EnumRasi.Makara: { return new List<EnumPlanet>() { EnumPlanet.Saturn, EnumPlanet.Mars  }; }
                    case EnumRasi.Kumbha: { return new List<EnumPlanet>() { EnumPlanet.Saturn, EnumPlanet.Uranus }; }
                    case EnumRasi.Meena: { return new List<EnumPlanet>() { EnumPlanet.Jupiter, EnumPlanet.Venus, EnumPlanet.Rahu, EnumPlanet.Neptune }; }
                }

                return new List<EnumPlanet>();
            }
        }
        public int ofRasi(EnumRasi rasi)
        {
            IntCircle circle = new IntCircle(12, CurrentInt);
            return circle.Minus((int)rasi);
        }

        public int absoluteGabOfRasi(EnumRasi rasi)
        {
            IntCircle circle = new IntCircle(12, CurrentInt);
            int addition = (int)rasi;
            if (addition < CurrentInt)
                addition = 13 - (CurrentInt - addition);
            else
                addition = 1+ (addition -CurrentInt);
            return circle.Add(addition);
        }

        /*private void SetAdhipathi()
        {
            // TODO - Manually set Adhipathi
            PlanetRashiRelationHandler relHandler = new PlanetRashiRelationHandler();
            var retData = relHandler.Include(x => x.Planet).GetAllGeneric(x => x.RashiId == CurrentInt
              && (x.RelationshipTypeId == (int)EnumRelationshipTypes.Swashesthra
              || x.RelationshipTypeId == (int)EnumRelationshipTypes.SwashesthraMulaThrikona));
            Adhipathis = new List<string>();
            foreach (PlanetRashiRelation pr in retData.Result)
                Adhipathis.Add(pr.Planet.Name);
        }*/
    }
}
