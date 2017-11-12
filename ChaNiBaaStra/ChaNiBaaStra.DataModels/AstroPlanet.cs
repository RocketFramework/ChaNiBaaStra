using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Handlers;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.Utilities;
using SwissEphNet;

namespace ChaNiBaaStra.DataModels
{

    public enum EnumPlanet
    {
        Sun = SwissEph.SE_SUN,
        Moon = SwissEph.SE_MOON,
        Mars = SwissEph.SE_MARS,
        Mercury = SwissEph.SE_MERCURY,
        Jupiter = SwissEph.SE_JUPITER,
        Venus = SwissEph.SE_VENUS,
        Saturn = SwissEph.SE_SATURN,
        Uranus = SwissEph.SE_URANUS,
        Neptune = SwissEph.SE_NEPTUNE,
        Pluto = SwissEph.SE_PLUTO,
        Rahu = SwissEph.SE_TRUE_NODE,
        Kethu = 12
    }
    public class AstroPlanet : AstroBase<EnumPlanet, Planet>
    {
        public AstroPlanet(EnumPlanet palnet, double[] planetLocations, AstroPlace place) : base(palnet, 9, AstroConsts.InvalidIntInput, place)
        {
            InitPlant(planetLocations);
            PlanetHandler handler = new PlanetHandler();
            int id = GetDbId();
            var rData = handler.Include(x => x.MovemenType)
                .Include(x => x.ButhaType).Include(x => x.FocusPlanetPlanetRelations)
                .Include(x => x.PlanetaryGenderType).Include(x => x.RelatedPlanetPlanetRelations)
                .GetFirstGeneric(x => x.PlanetId == id);
            if (rData.Successful)
                this.DataModel = rData.Result;
        }
        public AstroPlanet(int palnetInt, double[] planetLocations, AstroPlace place) : this((EnumPlanet)palnetInt, planetLocations, place)
        { }
        protected void InitPlant(double[] planetLocations)
        {
            RasiStart = 0.0;
            RasiEnd = 0.0;
            NextTransitDateTimes = new List<DateTime>();
            PlanetLocations = planetLocations;
            Longitude = planetLocations[0];
            AjustedLongitude = Longitude % AstroConsts.RasiLength;
            Rasi = new AstroRasi((EnumRasi)(1 + (int)(Longitude / AstroConsts.RasiLength)));
            IsReversing = ((planetLocations[3] < 0) && (!AstroPlanet.IsNode(Current)));
            Nakatha = new AstroNakath(Longitude);
            NavamsaRasi = new AstroRasi(AstroBase.GetNawamsaRasi(Longitude));
            /* target address for 6 position values: longitude, latitude, distance,
                                   long. speed, lat. speed, dist. speed */
            Latitude = planetLocations[1];
            Distance = planetLocations[2];
            SpeedInLongitude = planetLocations[3];
            SpeedInLatitude = planetLocations[4];
            SpeedInDistance = planetLocations[5];
        }
        public static bool IsNode(EnumPlanet p)
        {
            return (p == EnumPlanet.Rahu || p == EnumPlanet.Kethu);
        }
        public bool IsNode()
        {
            return (Current == EnumPlanet.Rahu || Current == EnumPlanet.Kethu);
        }
        public double[] PlanetLocations { get; set; }
        //  longitude, latitude, distance, speed in long., speed in lat., and speed in dist.
        /// <summary>
        /// Angle from Mesha Rasi
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// Longitude adjusted related to the current Rasi
        /// </summary>
        public double AjustedLongitude { get; set; }
        public double AjustedBhavaLongitude { get; set; }
        public AstroNakath Nakatha { get; set; }
        public int NakathPadaya { get { return Nakatha.Pada; } }
        public AstroRasi Rasi { get; set; }
        public AstroBhava Bhava { get; set; }
        public AstroRasi NavamsaRasi { get; set; }
        public double RasiStart { get; set; }
        public double RasiEnd { get; set; }
        public double Latitude { get; set; }
        /// <summary>
        /// Distance in AU
        /// </summary>
        public double Distance { get; set; }
        /// <summary>
        /// Speed in longitude(deg/day)
        /// </summary>
        public double SpeedInLongitude { get; set; }
        /// <summary>
        /// Speed in latitude(deg/day)
        /// </summary>
        public double SpeedInLatitude { get; set; }
        /// <summary>
        /// Speed in distance (AU/day)
        /// </summary>
        public double SpeedInDistance { get; set; }
        public bool IsReversing { get; set; }
        public bool IsNivrutha { get; set; }
        public bool IsAstha { get; set; }
        public bool IsVargoththama { get { return NavamsaRasi.Current == Rasi.Current; } }
        public DateTime NextTransitDateTime { get; set; }
        public List<DateTime> NextTransitDateTimes { get; set; }
        public DateTime? ReversingEndAt { get; set; }
        public DateTime? ReversingStartingAt { get; set; }
        public int HouseNumber { get { return Rasi.HouseNumber; } }
        public Planet PlanetData { get; set; }

        public int GetDbId()
        {
            return GetDbId(CurrentInt);
        }
        public static int GetDbId(int swissEphPlanetInt)
        {
            switch (swissEphPlanetInt)
            {
                case SwissEph.SE_SUN: return 1;
                case SwissEph.SE_MOON: return 2;
                case SwissEph.SE_MARS: return 3;
                case SwissEph.SE_MERCURY: return 4;
                case SwissEph.SE_JUPITER: return 5;
                case SwissEph.SE_VENUS: return 6;
                case SwissEph.SE_SATURN: return 7;
                case SwissEph.SE_URANUS: return 10;
                case SwissEph.SE_NEPTUNE: return 11;
                case SwissEph.SE_PLUTO: return 12;
                case SwissEph.SE_TRUE_NODE: return 8;
                case 12: return 9;
            }
            return 0;
        }
    }
}
