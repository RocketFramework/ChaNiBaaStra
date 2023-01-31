using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Handlers;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.Utilities;
using SwissEphNet;
using System.Drawing;
using System.Net;

namespace ChaNiBaaStra.DataModels
{
    public enum EnumPlanetRasiRelationTypes
    {
        Uchcha = 1,
        UchchaMulaThrikonaSwashesthra = 2,
        Swashesthra = 3,
        SwashesthraMulaThrikona = 4,
        Mithra = 5,
        Sama = 6,
        Sathuru = 7,
        SathuruMuta = 8,
        Neecha = 9,
        NeechaMuta = 10,
        SamaMuta = 11,
        MulaThrikona = 12,
        Muta = 13,
        NeechaSathuruMuta = 14,
        UchchaMulaThrikona = 15,
        NeechaMutaSama = 16,
        NeechaSamaMuta = 17
    }

    public enum EnumPlanetRelationTypes
    {
        Mithra = 5,
        Sama = 6,
        Sathuru = 7
    }

    public static class EnumPlanetRasiRelationTypesExtension
    {
        public static string ToShortString(this EnumPlanetRasiRelationTypes me)
        {
            switch (me)
            {
                case EnumPlanetRasiRelationTypes.Uchcha: return "Uch";
                case EnumPlanetRasiRelationTypes.UchchaMulaThrikonaSwashesthra: return "UMulTrSw";
                case EnumPlanetRasiRelationTypes.Swashesthra: return "Swa";
                case EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona: return "SwMulTri";
                case EnumPlanetRasiRelationTypes.Mithra: return "Mith";
                case EnumPlanetRasiRelationTypes.Sama: return "Sama";
                case EnumPlanetRasiRelationTypes.Sathuru: return "Sathu";
                case EnumPlanetRasiRelationTypes.SathuruMuta: return "SaMut";
                case EnumPlanetRasiRelationTypes.Neecha: return "Necha";
                case EnumPlanetRasiRelationTypes.NeechaMuta: return "NeMut";
                case EnumPlanetRasiRelationTypes.SamaMuta: return "SamMut";
                case EnumPlanetRasiRelationTypes.MulaThrikona: return "MuTri";
                case EnumPlanetRasiRelationTypes.Muta: return "Mut";
                case EnumPlanetRasiRelationTypes.NeechaSathuruMuta: return "NeSatMut";
                case EnumPlanetRasiRelationTypes.UchchaMulaThrikona: return "UMulTri";
                case EnumPlanetRasiRelationTypes.NeechaMutaSama: return "NeMutSam";
                case EnumPlanetRasiRelationTypes.NeechaSamaMuta: return "NeSamMut";
            }
            return "";
        }
        public static string ToLongString(this EnumPlanetRasiRelationTypes me)
        {
            switch (me)
            {
                case EnumPlanetRasiRelationTypes.Uchcha: return "The planet is in " + "Uchcha state" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.UchchaMulaThrikonaSwashesthra: return "The planet is in " + "Uchcha Mula Thrikona Swesshethra" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.Swashesthra: return "The planet is in " + "Swashesthra" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona: return "The planet is in " + "Swashesthra Mula Thrikona" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.Mithra: return "The planet is in " + "Mithra" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.Sama: return "The planet is in " + "Sama" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.Sathuru: return "The planet is in " + "Sathuru" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.SathuruMuta: return "The planet is in " + "Sathuru Muddha" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.Neecha: return "The planet is in " + "Neecha" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.NeechaMuta: return "The planet is in " + "Neecha Muddha" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.SamaMuta: return "The planet is in " + "Sama Muddha" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.MulaThrikona: return "The planet is in " + "Mula Thrikona" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.Muta: return "The planet is in " + "Muddha" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.NeechaSathuruMuta: return "The planet is in " + "Neecha Sathuru Muddha" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.UchchaMulaThrikona: return "The planet is in " + "Uchcha Mula Thrikona" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.NeechaMutaSama: return "The planet is in " + "Neecha Muddha Sama" + " State with Rashi";
                case EnumPlanetRasiRelationTypes.NeechaSamaMuta: return "The planet is in " + "Neecha Sama Muddha" + " State with Rashi";
            }
            return "";
        }

        public static string ToLongString(this EnumPlanetRelationTypes me, string planetName)
        {
            switch (me)
            {
                case EnumPlanetRelationTypes.Mithra: return "The planet is in " + "Mithra" + " State with Planet " + planetName;
                case EnumPlanetRelationTypes.Sama: return "The planet is in " + "Sama" + " State with Planet " + planetName;
                case EnumPlanetRelationTypes.Sathuru: return "The planet is in " + "Sathuru" + " State with Planet " + planetName;
            }
            return "";
        }

        public static System.Drawing.Color ToColor(this EnumPlanetRelationTypes me)
        {
            switch (me)
            {
                case EnumPlanetRelationTypes.Mithra: return Color.Yellow;
                case EnumPlanetRelationTypes.Sama: return Color.White;
                case EnumPlanetRelationTypes.Sathuru: return Color.Red;
            }
            return Color.Purple;
        }

        public static System.Drawing.Color ToColor(this EnumPlanetRasiRelationTypes me)
        {
            switch (me)
            {
                case EnumPlanetRasiRelationTypes.Uchcha: return Color.Yellow;
                case EnumPlanetRasiRelationTypes.UchchaMulaThrikonaSwashesthra: return Color.Yellow;
                case EnumPlanetRasiRelationTypes.Swashesthra: return Color.Yellow;
                case EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona: return Color.Yellow;
                case EnumPlanetRasiRelationTypes.Mithra: return Color.Green;
                case EnumPlanetRasiRelationTypes.Sama: return Color.Gray;
                case EnumPlanetRasiRelationTypes.Sathuru: return Color.Red;
                case EnumPlanetRasiRelationTypes.SathuruMuta: return Color.Red;
                case EnumPlanetRasiRelationTypes.Neecha: return Color.Black;
                case EnumPlanetRasiRelationTypes.NeechaMuta: return Color.Black;
                case EnumPlanetRasiRelationTypes.SamaMuta: return Color.Gray;
                case EnumPlanetRasiRelationTypes.MulaThrikona: return Color.Gray;
                case EnumPlanetRasiRelationTypes.Muta: return Color.Red;
                case EnumPlanetRasiRelationTypes.NeechaSathuruMuta: return Color.Red;
                case EnumPlanetRasiRelationTypes.UchchaMulaThrikona: return Color.Yellow;
                case EnumPlanetRasiRelationTypes.NeechaMutaSama: return Color.Gray;
                case EnumPlanetRasiRelationTypes.NeechaSamaMuta: return Color.Gray;
            }
            return Color.Purple;
        }
    }

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="palnet"></param>
        /// <param name="planetLocations"></param>
        /// <param name="place"></param>
        public AstroPlanet(EnumPlanet palnet, double[] planetLocations, AstroPlace place) : base(palnet, 9, AstroConsts.InvalidIntInput, place)
        {
            InitPlant(planetLocations);
            int id = GetDbId();

            // CHECK - Just wanted to see if this has any relation to the important calculations
            /*PlanetHandler handler = new PlanetHandler();   
            var rData = handler.Include(x => x.MovemenType)
                .Include(x => x.ButhaType).Include(x => x.FocusPlanetPlanetRelations)
                .Include(x => x.PlanetaryGenderType).Include(x => x.RelatedPlanetPlanetRelations)
                .GetFirstGeneric(x => x.PlanetId == id);
            if (rData.Successful)
                this.DataModel = rData.Result;*/
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
        public bool IsMarakaPlanet { get; set; }
        public bool IsRogaPlanet { get; set; }

        public List<EnumRasi> AdhipathiRasis
        {
            get
            {
                switch (this.Current)
                {
                    case EnumPlanet.Sun: { return new List<EnumRasi>() { EnumRasi.Mesha, EnumRasi.Simha }; }
                    case EnumPlanet.Moon: { return new List<EnumRasi>() { EnumRasi.Vrishabha, EnumRasi.Kataka }; }
                    case EnumPlanet.Mars: { return new List<EnumRasi>() { EnumRasi.Mesha, EnumRasi.Vrichika, EnumRasi.Makara }; }
                    case EnumPlanet.Mercury: { return new List<EnumRasi>() { EnumRasi.Mithuna, EnumRasi.Kanya }; }
                    case EnumPlanet.Jupiter: { return new List<EnumRasi>() { EnumRasi.Kataka, EnumRasi.Dhanus, EnumRasi.Meena }; }
                    case EnumPlanet.Venus: { return new List<EnumRasi>() { EnumRasi.Vrishabha, EnumRasi.Thula, EnumRasi.Meena }; }
                    case EnumPlanet.Saturn: { return new List<EnumRasi>() { EnumRasi.Thula, EnumRasi.Makara, EnumRasi.Kumbha }; }
                    case EnumPlanet.Rahu: { return new List<EnumRasi>() { EnumRasi.Vrishabha, EnumRasi.Kanya }; }
                    case EnumPlanet.Kethu: { return new List<EnumRasi>() { EnumRasi.Vrichika, EnumRasi.Meena }; }
                    case EnumPlanet.Uranus: { return new List<EnumRasi>() { EnumRasi.Vrichika, EnumRasi.Kumbha }; }
                    case EnumPlanet.Neptune: { return new List<EnumRasi>() { EnumRasi.Kataka, EnumRasi.Meena }; }
                    case EnumPlanet.Pluto: { return new List<EnumRasi>() { EnumRasi.Simha, EnumRasi.Mesha }; }

                }
                return new List<EnumRasi>();
            }
        }

        public EnumPlanetRasiRelationTypes PlanetRasiRelation
        {
            get
            {
                return GetPlanetRelationToRasi(this.Current, this.Rasi.Current);
            }
        }

        public EnumPlanetRelationTypes GetPlanetRelation(EnumPlanet planet)
        {
            switch (planet)
            {
                case EnumPlanet.Sun:
                    {
                        switch(this.Current)
                        {
                            case EnumPlanet.Mars:
                            case EnumPlanet.Moon:
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Neptune:
                            case EnumPlanet.Pluto:
                            case EnumPlanet.Kethu:
                                    return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Mercury:
                            case EnumPlanet.Rahu:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Venus:
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Uranus:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
                case EnumPlanet.Moon:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Sun:
                            case EnumPlanet.Mercury:
                            case EnumPlanet.Rahu:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Venus:
                            case EnumPlanet.Mars:
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Uranus:
                            case EnumPlanet.Neptune:
                            case EnumPlanet.Pluto:
                            case EnumPlanet.Kethu:
                                return EnumPlanetRelationTypes.Sama;
                        }
                        break;
                    }
                case EnumPlanet.Mars:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Sun:
                            case EnumPlanet.Moon:
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Neptune:
                            case EnumPlanet.Pluto:
                            case EnumPlanet.Kethu:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Venus:
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Uranus:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Mercury:
                            case EnumPlanet.Rahu:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
                case EnumPlanet.Mercury:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Venus:
                            case EnumPlanet.Sun:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Mars:
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Uranus:
                            case EnumPlanet.Neptune:
                            case EnumPlanet.Pluto:
                            case EnumPlanet.Kethu:
                            case EnumPlanet.Rahu:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Moon:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
                case EnumPlanet.Jupiter:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Sun:
                            case EnumPlanet.Moon:
                            case EnumPlanet.Mars:
                            case EnumPlanet.Neptune:
                            case EnumPlanet.Pluto:
                            case EnumPlanet.Kethu:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Uranus:
                            case EnumPlanet.Rahu:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Venus:
                            case EnumPlanet.Mercury:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
                case EnumPlanet.Venus:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Uranus:
                            case EnumPlanet.Mercury:
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Rahu:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Mars:
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Neptune:
                            case EnumPlanet.Pluto:
                            case EnumPlanet.Kethu:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Sun:
                            case EnumPlanet.Moon:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
                case EnumPlanet.Saturn:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Mercury:
                            case EnumPlanet.Venus:
                            case EnumPlanet.Uranus:
                            case EnumPlanet.Rahu:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Kethu:
                            case EnumPlanet.Neptune:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Sun:
                            case EnumPlanet.Moon:
                            case EnumPlanet.Mars:
                            case EnumPlanet.Pluto:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
                case EnumPlanet.Rahu:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Mercury:
                            case EnumPlanet.Venus:
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Uranus:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Neptune:
                            case EnumPlanet.Kethu:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Sun:
                            case EnumPlanet.Moon:
                            case EnumPlanet.Mars:
                            case EnumPlanet.Pluto:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
                case EnumPlanet.Kethu:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Moon:
                            case EnumPlanet.Mars:
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Neptune:
                            case EnumPlanet.Pluto:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Sun:
                            case EnumPlanet.Mercury:
                            case EnumPlanet.Rahu:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Venus:
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Uranus:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
                case EnumPlanet.Uranus:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Moon:
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Neptune:
                            case EnumPlanet.Kethu:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Mercury:
                            case EnumPlanet.Venus:
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Pluto:
                            case EnumPlanet.Rahu:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Sun:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
                case EnumPlanet.Neptune:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Moon:
                            case EnumPlanet.Mars:
                            case EnumPlanet.Pluto:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Mercury:
                            case EnumPlanet.Venus:
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Uranus:
                            case EnumPlanet.Rahu:
                            case EnumPlanet.Kethu:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Sun:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
                case EnumPlanet.Pluto:
                    {
                        switch (this.Current)
                        {
                            case EnumPlanet.Sun:
                            case EnumPlanet.Moon:
                            case EnumPlanet.Mars:
                            case EnumPlanet.Jupiter:
                            case EnumPlanet.Neptune:
                            case EnumPlanet.Kethu:
                                return EnumPlanetRelationTypes.Mithra;
                            case EnumPlanet.Venus:
                                return EnumPlanetRelationTypes.Sama;
                            case EnumPlanet.Mercury:
                            case EnumPlanet.Saturn:
                            case EnumPlanet.Uranus:
                            case EnumPlanet.Rahu:
                                return EnumPlanetRelationTypes.Sathuru;
                        }
                        break;
                    }
            }
            return EnumPlanetRelationTypes.Sama;
        }

        public EnumPlanetRasiRelationTypes GetPlanetRelationToRasi(EnumPlanet planet, EnumRasi rasi)
        {
            switch (planet)
            {
                case EnumPlanet.Sun:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.Uchcha;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.Neecha;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.SathuruMuta;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.Mithra;
                        }
                        break;
                    }
                case EnumPlanet.Moon:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.UchchaMulaThrikona;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Swashesthra;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.NeechaMutaSama;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.Sama;
                        }
                        break;
                    }
                case EnumPlanet.Mars:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Neecha;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.SamaMuta;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.Swashesthra;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Uchcha;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.Mithra;
                        }
                        break;
                    }
                case EnumPlanet.Mercury:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Swashesthra;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.UchchaMulaThrikonaSwashesthra;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.NeechaSamaMuta;
                        }
                        break;
                    }
                case EnumPlanet.Jupiter:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.SathuruMuta;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Uchcha;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Neecha;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.Swashesthra;
                        }
                        break;
                    }
                case EnumPlanet.Venus:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.SamaMuta;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.Swashesthra;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.Neecha;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.Uchcha;
                        }
                        break;
                    }
                case EnumPlanet.Saturn:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.Neecha;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.SathuruMuta;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.Uchcha;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Swashesthra;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.Sama;
                        }
                        break;
                    }
                case EnumPlanet.Uranus:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.SamaMuta;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.NeechaSathuruMuta;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.UchchaMulaThrikona;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.Swashesthra;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.Mithra;
                        }
                        break;
                    }
                case EnumPlanet.Neptune:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Uchcha;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.SamaMuta;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Neecha;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona;
                        }
                        break;
                    }
                case EnumPlanet.Pluto:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.Uchcha;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.SamaMuta;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.Neecha;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.Mithra;
                        }
                        break;
                    }
                case EnumPlanet.Rahu:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.Uchcha;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.SathuruMuta;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.Swashesthra;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.Neecha;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.MulaThrikona;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.Muta;
                        }
                        break;
                    }
                case EnumPlanet.Kethu:
                    {
                        switch (rasi)
                        {
                            case EnumRasi.Mesha: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Vrishabha: return EnumPlanetRasiRelationTypes.Neecha;
                            case EnumRasi.Mithuna: return EnumPlanetRasiRelationTypes.Sama;
                            case EnumRasi.Kataka: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Simha: return EnumPlanetRasiRelationTypes.MulaThrikona;
                            case EnumRasi.Kanya: return EnumPlanetRasiRelationTypes.Muta;
                            case EnumRasi.Thula: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Vrichika: return EnumPlanetRasiRelationTypes.Uchcha;
                            case EnumRasi.Dhanus: return EnumPlanetRasiRelationTypes.Mithra;
                            case EnumRasi.Makara: return EnumPlanetRasiRelationTypes.Sathuru;
                            case EnumRasi.Kumbha: return EnumPlanetRasiRelationTypes.SathuruMuta;
                            case EnumRasi.Meena: return EnumPlanetRasiRelationTypes.Swashesthra;
                        }
                        break;
                    }
            }
            return EnumPlanetRasiRelationTypes.Sama;
        }

        public string GetPlanetQuality()
        {
            switch (this.Current)
            {
                case EnumPlanet.Sun: { return "It is Sun to show how a person projects himself onto the world. "+
                            "\r\nIf a strong Sun represents energy and authority, " +
                            "\r\na weak Sun can make a person ego-centric/ over-confident. "+
                            "\r\nYou may need a strong Sun when it comes to your career and profession,"+
                            "\r\n but not when you deal with personal relationships.";   }
                case EnumPlanet.Moon: { return "Moon represents the mind, acts as the mother of all, imparts love,"+
                            "\r\n peace of mind, positivity, and emotions. A strong Moon helps a person in all stages of life,"+
                            "\r\n  but a weak Moon can bring troubles like flickering mind or even depression."; }
                case EnumPlanet.Mars: { return "Mars denotes courage, passion, bravely, strength and confidence."+
                            "\r\n  But in many aspects of life, you don’t need all this equally."+
                            "\r\n  A strong Mars can help you in your career and profession "+
                            "\r\n but can adversely affect your married life."; }
                case EnumPlanet.Mercury: { return "Mercury represents speech, Intelligence, grasping power, alertness, and logic."+
                            "\r\nThough Mercury plays a significant role throughout life, "+
                            "\r\nit assumes more importance during the early stage of education."; }
                case EnumPlanet.Jupiter: { return "Jupiter represents knowledge. It helps a person more "+
                            "\r\nwhen it reaches the stage of education and career, so may not have that significant "+
                            "\r\nin the early age of the person or, say, initial childhood."; }
                case EnumPlanet.Venus: { return "Venus represents love, relationship, romance, beauty, "+
                            "\r\nsex life, relationships, be it with the spouse/business associates. "+
                            "\r\nMany may not know, but a good Venus is an essence for your professional life. "+
                            "\r\nSo at what stage you need support from Venus is to be decided by you."; }
                case EnumPlanet.Saturn: { return ""; }
                case EnumPlanet.Rahu: { return ""; }
                case EnumPlanet.Kethu: { return "Ketu shows spirituality but detachment also. "+
                            "\r\nThis is again a shadowy and planet of no physical existence. "+
                            "\r\nKetu is known to be malefic to worldly desires and spiritually benefic. "+
                            "\r\nSo an adverse effect of Ketu can turn a person away from mundane and worldly desires, "+
                            "\r\nincluding Love and romance, at the age when you need them most."; }
                case EnumPlanet.Uranus: { return ""; }
                case EnumPlanet.Neptune: { return ""; }
                case EnumPlanet.Pluto: { return ""; }
            }
            return "";
        }
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
        public bool IsDigbala { get; set; }
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
