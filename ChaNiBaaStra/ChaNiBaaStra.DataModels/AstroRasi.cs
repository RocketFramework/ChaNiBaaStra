using System;
using System.Collections.Generic;
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

    public class AstroBhava
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
        public double LengthDegrees { get; set; }
        public List<AstroPlanet> Planets { get; set; }
    }
    public class AstroRasi : AstroBase<EnumRasi, Rashi>
    {
        public AstroRasi(EnumRasi rasi) : base(rasi, 12, AstroConsts.RasiLength)
        {
            Planets = new List<AstroPlanet>();
            this.DataModel = new RashiHandler().Include(x => x.MovemenType)
                .Include(x => x.PlanetRashiRelations).Include(x => x.RashiMonths)
                .Include(x => x.RashiThithis)
                .GetFirstGeneric(x => x.RashiId == this.CurrentInt).Result;

            SetAdhipathi();
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
        public List<string> Adhipathis { get; set; }
        public int ofRasi(EnumRasi rasi)
        {
            IntCircle circle = new IntCircle(12, (int)rasi);
            return circle.Minus(CurrentInt);
        }

        private void SetAdhipathi()
        {
            PlanetRashiRelationHandler relHandler = new PlanetRashiRelationHandler();
            var retData = relHandler.Include(x => x.Planet).GetAllGeneric(x => x.RashiId == CurrentInt
              && (x.RelationshipTypeId == (int)EnumRelationshipTypes.Swashesthra
              || x.RelationshipTypeId == (int)EnumRelationshipTypes.SwashesthraMulaThrikona));
            Adhipathis = new List<string>();
            foreach (PlanetRashiRelation pr in retData.Result)
                Adhipathis.Add(pr.Planet.Name);
        }
    }
}
