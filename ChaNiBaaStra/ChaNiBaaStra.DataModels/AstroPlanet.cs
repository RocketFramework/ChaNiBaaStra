using System;
using System.Collections.Generic;
using System.Linq;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.Utilities;
using SwissEphNet;
using System.Drawing;
using Nido.Common.Extensions;
using System.Data;
using System.Security.AccessControl;

namespace ChaNiBaaStra.DataModels
{
    public enum PlanetTypes
    {
        Melific,
        Benefic
    }

    public enum PlanetKarakaStates
    {
        NotDefined,
        AathmaKaraka,
        AmathyaKaraka,
        MathruKaraka,
        BradhariKaraka,
        PithruKaraka,
        GnathiKaraka,
        DhaaraKaraka,
    }

    public enum EnumPlanetStages
    {
        Toddler,
        Child,
        Young, 
        Old,
        Dead
    }

    public enum EnumPlanetRasiRelationTypes
    {
        Uchcha = 1,
        UchchaMulaThrikonaSwashesthra = 2,
        UchchaMulaThrikona = 3,
        Swashesthra = 4,
        SwashesthraMulaThrikona = 5,
        MulaThrikona = 6,
        Mithra = 7,
        Sama = 8,
        SamaMuta = 9,
        Muta = 10,
        SathuruMuta = 11,   
        Sathuru = 12,
        NeechaSamaMuta = 13,
        NeechaMutaSama = 14,
        NeechaSathuruMuta = 15,
        NeechaMuta = 16, 
        Neecha = 17
        /*Uchcha = 1,
        UchchaMulaThrikonaSwashesthra = 2,
        UchchaMulaThrikona = 15,
        Swashesthra = 3,
        SwashesthraMulaThrikona = 4,
        MulaThrikona = 12,   
        Mithra = 5,
        Sama = 6,  
        SamaMuta = 11,
        Muta = 13,
        NeechaSamaMuta = 17,
        Sathuru = 7,
        SathuruMuta = 8,
        NeechaMutaSama = 16, 
        NeechaMuta = 10,
        NeechaSathuruMuta = 14,      
        Neecha = 9*/
    }

    public enum EnumPlanetRelationTypes
    {
        Mithra = 5,
        Sama = 6,
        Sathuru = 7
    }

    public class PlanetIdentity 
    {
        public PlanetIdentity() { }

        public PlanetIdentity(string taste, string adhipathiOf, string bodyPart
            , string bodyType, string bodyCondition, string personality
            , List<string> bodyFeatures, List<string> talents)
        {
            this.BodyPartItLivesOn = bodyPart;
            this.BodyType = bodyType;
            this.BodyCondition = bodyCondition;
            this.Personality = personality;
            this.BodyFeatures = bodyFeatures;
            this.Talents = talents;
            this.AdhipathiOf = adhipathiOf;
            this.Taste = taste;
        }

        public string Taste { get; set; }
        public string AdhipathiOf { get; set; }
        public string BodyPartItLivesOn { get; set; }
        public string BodyType { get; set; }
        public string BodyCondition { get; set; }
        public string Personality { get; set; }
        public List<string> BodyFeatures { get; set; }
        public List<string> Talents { get; set; }

        public override string ToString()
        {
            return
                "Personality: " + Personality
                + "\r\nBody Condition: " + BodyCondition
                + "\r\nBody Type: " + BodyType
                + "\r\nBody Features: " + GetString(BodyFeatures)
                + "\r\nTalents: " + GetString(Talents)
                + "\r\nAdhipathi Of: " + AdhipathiOf
                + "\r\nTaste: " + Taste
                + "\r\nBody Part It Lives On: " + BodyPartItLivesOn;
        }

        private string GetString(List<string> list)
        {
            return string.Join(": ", list);
        }
    }

    public static class EnumPlanetRasiRelationTypesExtension
    {
        public static string ToEnumPlanetString(this List<EnumPlanet> me)
        {
            string s = "";
            foreach (EnumPlanet planet in me)
            {
                s += planet.ToString();
                s += ", ";
            }
            return s.Trim(new char[] { ' ', ','});
        } 

        public static string ToDetailString(this EnumPlanetStages me)
        {
            switch (me)
            {
                case EnumPlanetStages.Old: return "Old - Dushta Pala";
                case EnumPlanetStages.Toddler: return "Toddler - Swalpa Pala";
                case EnumPlanetStages.Dead: return "Dead - Give Death";
                case EnumPlanetStages.Young: return "Young - Purna Pala";
                case EnumPlanetStages.Child: return "Child - Ardha Pala";
            }
            return "";
        }

        public static string ToAstroPlanetString(this List<AstroPlanet> me)
        {
            string s = "";
            foreach (AstroPlanet planet in me)
            {
                s += "\tPlanet Name: " + planet.Name + " (" + planet.PlanetRasiRelation.ToString() + ")\r\n\t\tIts Nws Rashi Adhies: ";
                foreach (AstroPlanet nwPlanet in planet.NawamsaRasi.AdhipathiAstroPlanets)
                    s += nwPlanet.Name + " (" + nwPlanet.PlanetRasiRelation.ToString() + "), ";
                s += "\r\n";
            }
            return s.Trim(new char[] { ' ', ',' , '\r', '\n'});
        }

        public static string ToAstroPlanetShortString(this List<AstroPlanet> me)
        {
            if (me.Count == 0) return " Empty";
            string s = "";
            foreach (AstroPlanet planet in me)
            {
                s += planet.Name + ", ";
            }
            return s.Trim(new char[] { ' ', ',', '\r', '\n' });
        }

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

    public enum DasaEffectTypes
    {
        Sampurna,
        Purna,
        Riktha,
        Awarohini,
        Madyama,
        Adhama,
        Anishta,
        Mixed,
        None
    }

    public enum EnumBalaStatus
    {
        Full = 32,
        ThreeFourth = 24,
        Half = 16,
        OneFourth = 8,
        OneEigth = 4,
        OneSixteenth = 2,
        OneThirtySecond = 1,
        ZeroNeecha = 0
    }

    public class AstroPlanet : AstroBase<EnumPlanet, Planet>
    {

        public AstroPlanet(EnumPlanet palnet) : base()
        {

        }
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
        public AstroPlanet(int palnetInt, double[] planetLocations, AstroPlace place) : this((EnumPlanet)palnetInt, planetLocations, place) { }
        public string SpecialMessage { get; set; }
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
            NawamsaRasi = new AstroRasi(AstroBase.GetNawamsaRasi(Longitude));
            
            /* target address for 6 position values: longitude, latitude, distance,
                                   long. speed, lat. speed, dist. speed */
            Latitude = planetLocations[1];
            Distance = planetLocations[2];
            SpeedInLongitude = planetLocations[3];
            SpeedInLatitude = planetLocations[4];
            SpeedInDistance = planetLocations[5];
            AdhipathiHouses = new List<int>();
            MithraPlanets = new List<AstroPlanet>();
            SathuruPlanets = new List<AstroPlanet>();
            SamaPlanets = new List<AstroPlanet>();
            AdhiMithraPlanets = new List<AstroPlanet>();
            AdhiSathuruPlanets = new List<AstroPlanet>();
        }

        public void SetBala()
        {
            switch (PlanetRasiRelation)
            {
                case EnumPlanetRasiRelationTypes.Uchcha:
                    {
                        this.PlanetBala = EnumBalaStatus.Full;


                        foreach (AstroPlanet planet in this.Rasi.Planets)
                            if (this.Current != planet.Current)
                                if ((int)planet.PlanetBala < 16)
                                    planet.PlanetBala = EnumBalaStatus.Half;
                    } break;
                case EnumPlanetRasiRelationTypes.UchchaMulaThrikona:
                case EnumPlanetRasiRelationTypes.UchchaMulaThrikonaSwashesthra:
                case EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona:
                case EnumPlanetRasiRelationTypes.MulaThrikona:
                    this.PlanetBala = EnumBalaStatus.ThreeFourth; break;
                case EnumPlanetRasiRelationTypes.Swashesthra:
                    this.PlanetBala = EnumBalaStatus.Half; break;
                case EnumPlanetRasiRelationTypes.Mithra:
                    this.PlanetBala = EnumBalaStatus.OneFourth; break;
                case EnumPlanetRasiRelationTypes.Sathuru:
                case EnumPlanetRasiRelationTypes.SathuruMuta:
                case EnumPlanetRasiRelationTypes.NeechaSathuruMuta:
                    this.PlanetBala = EnumBalaStatus.OneSixteenth; break;
                case EnumPlanetRasiRelationTypes.Sama:
                case EnumPlanetRasiRelationTypes.SamaMuta:
                case EnumPlanetRasiRelationTypes.NeechaSamaMuta:
                    this.PlanetBala = EnumBalaStatus.OneEigth; break;
            }
            BalaFinalization();

        }

        /// <summary>
        /// TODO: KHARA NAWAMSA CALCULATION
        /// Khara Navamsa
        /// The 64th navamsa from Moon and Lagna which is the 4th sign from Moon and Lagna in the Navamsa chart 
        /// is called “Khara”. The lord of these houses may be problematic especially when Saturn transits over 
        /// them or during their antar dashas.Remedies are needed during such transits.
        /// </summary>
        /// <param name="moonDegreeOrLagnaDegree"></param>
        /// <returns></returns>


        /// <summary>
        /// Page 11 Uththara Kala Mruthaya
        /// </summary>
        private void BalaFinalization()
        {
            if (IsReversing)
            {
                this.PlanetBala = EnumBalaStatus.Full;

                foreach (AstroPlanet planet in this.Rasi.Planets)
                    if (this.Current != planet.Current)
                        if ((int)planet.PlanetBala < 16)
                            planet.PlanetBala = EnumBalaStatus.Half;

                if (this.PlanetRasiRelation == EnumPlanetRasiRelationTypes.Uchcha)
                    this.PlanetBala = EnumBalaStatus.ZeroNeecha;

                if (this.PlanetRasiRelation == EnumPlanetRasiRelationTypes.Neecha)
                    this.PlanetBala = EnumBalaStatus.Full;

            }

            foreach (AstroPlanet planet in this.Rasi.Planets)
                if ((this.GetPlanetRelation(planet.Current) == EnumPlanetRelationTypes.Mithra)
                    && (planet.MelificOrBenific == PlanetTypes.Melific))
                {
                    if ((int)planet.PlanetBala < 16)
                        this.PlanetBala = EnumBalaStatus.Half;
                }
                else if ((this.GetPlanetRelation(planet.Current) == EnumPlanetRelationTypes.Sathuru)
                    && (planet.MelificOrBenific == PlanetTypes.Benefic))
                {
                    if ((int)planet.PlanetBala < 16)
                        this.PlanetBala = EnumBalaStatus.Half;
                }
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
        /// <summary>
        /// Depending on the chart the CurrentlyActiveRashi
        /// varies. Example if Nawamsa is Kataka then active Rashi is 
        /// calculated relatively to the Kataka rashi
        /// </summary>
        public AstroRasi CurrentlyActiveRashi { get; set; }
        public int CurrentlyActiveHouseNumber { get; set; }
        public AstroBhava Bhava { get; set; }
        public EnumPlanet RashyardhaHora { get { return (((this.Rasi.IsOddRashi && this.AjustedLongitude < 15) || (!this.Rasi.IsOddRashi && this.AjustedLongitude > 15)) ? EnumPlanet.Sun : EnumPlanet.Moon); } }
        public AstroPlanet DroskanaAdhipathi { get; set; }//get { switch (DrosKanaya) { case 1: return Rasi.FirstDrosKanaAdhipathi; case 2: return Rasi.SecondDrosKanaAdhipathi; case 3: return Rasi.ThirdDrosKanaAdhipathi; } return null; } }
        public AstroPlanet SapthansaAdhipathi { get; set; }
        public AstroRasi NawamsaRasi { get; set; }
        public AstroPlanet NawamsaAdhipathi { get {
                return NawamsaRasi.AdhipathiAstroPlanets
                        .FirstOrDefault(x => x.Current == NawamsaRasi.AdhipathiEnumPlanets[0]);
            } }
        public AstroPlanet DwadasansaAdhipathi { get; set; }
        public AstroPlanet ThrishanshakaAdhipathi { get; set; }
        public int DrosKanaya { get { return (int)Math.Floor(this.AjustedLongitude / 10.0) + 1; } }
        public int Sapthanshaya { get { return (int)Math.Floor(this.AjustedLongitude / 4.28571428571429) + 1; } }
        public int Nawamsaya {  get {  return (int)Math.Floor(this.AjustedLongitude / 9.0) + 1; } }
        public int Dwadasanshaya { get { return (int)Math.Floor(this.AjustedLongitude / 2.5) + 1; } }
        public int Thrishanshaya { get { return (int)Math.Floor(this.AjustedLongitude) + 1; } }

        public AstroRasi DrosKanayaRasi { get; set; }
        public AstroRasi SapthanshayaRasi { get; set; } 
        public AstroRasi DwadasanshayaRasi{ get; set; }
        public AstroRasi ThrishanshayaRasi { get; set; }

        public double RasiStart { get; set; }
        public double RasiEnd { get; set; }
        public double Latitude { get; set; }
        public bool IsMarakaPlanet { get; set; }
        public bool IsRogaPlanet { get; set; }
        public bool IsSawmyaPlanet { get { return (this.Current == EnumPlanet.Jupiter || this.Current == EnumPlanet.Mercury || this.Current == EnumPlanet.Venus); } }
        public List<AstroPlanet> BirthPlanets { get; set; }
        public List<AstroPlanet> AdhiMithraPlanets { get; set; }
        public List<AstroPlanet> AdhiSathuruPlanets { get; set; }
        public List<AstroPlanet> MithraPlanets { get; set; }
        public List<AstroPlanet> SathuruPlanets { get; set; }
        public List<AstroPlanet> SamaPlanets { get; set; }
        public EnumBalaStatus PlanetBala { get; set; }

        /// <summary>
        /// Does the planet has sthana bala
        /// </summary>
        public bool HasSthanaBala
        {
            get {
                return (!this.Rasi.IsMaleRashi &&
                ((this.Current == EnumPlanet.Moon) ||
                (this.Current == EnumPlanet.Venus))) ?
                true : (this.Rasi.IsMaleRashi &&
                ((this.Current == EnumPlanet.Mars) ||
                (this.Current == EnumPlanet.Mercury) ||
                (this.Current == EnumPlanet.Jupiter) ||
                (this.Current == EnumPlanet.Saturn) ||
                (this.Current == EnumPlanet.Sun))) ? true : false; }
        }

        public EnumPlanetStages PlanetStage
        {
            get
            {
                int val = (int)Math.Floor(this.AjustedLongitude / 6);
                if (this.CurrentInt.IsEven())
                {   
                    switch (val)
                    {
                        case 0: return EnumPlanetStages.Toddler; 
                        case 1: return EnumPlanetStages.Child;
                        case 2: return EnumPlanetStages.Young;
                        case 3: return EnumPlanetStages.Old;
                        case 4: return EnumPlanetStages.Dead;
                    }
                }
                else
                {
                    switch (val)
                    {
                        case 0: return EnumPlanetStages.Dead;
                        case 1: return EnumPlanetStages.Old;
                        case 2: return EnumPlanetStages.Young;
                        case 3: return EnumPlanetStages.Child;
                        case 4: return EnumPlanetStages.Toddler;
                    }
                }
                return EnumPlanetStages.Young;
            }
        }

        public List<int> AdhipathiHouses { get; set; }
        public List<EnumRasi> AdhipathiRasis { get; set; }
        public PlanetTypes MelificOrBenific { get; set; }
        public PlanetKarakaStates KarakaState { get; set; }
        /// <summary>
        /// More closer than "Mithra" with the Rashi
        /// </summary>
        public bool IsPowerful
        {
            get
            {
                return this.PlanetRasiRelation < EnumPlanetRasiRelationTypes.Sama;
;
            }
        }

        /// <summary>
        /// Uchcha with Rashi
        /// </summary>
        public bool IsExalted
        {
            get
            {
                return this.PlanetRasiRelation == EnumPlanetRasiRelationTypes.Uchcha;
            }
        }

        public bool IsExaltedInRashi(EnumRasi rasi)
        {
            return this.GetRelationToRasi(rasi) == EnumPlanetRasiRelationTypes.Uchcha;
        }
        /// <summary>
        /// In most powerful angle with Rashi
        /// </summary>
        public bool IsExtremelyExalted
        {
            get
            {
                return ((this.PlanetRasiRelation == EnumPlanetRasiRelationTypes.Uchcha)
                    && (Horoscope.GetExtremeStateDegree(this.Current) <= (int)AjustedLongitude + 1)
                    && (Horoscope.GetExtremeStateDegree(this.Current) >= (int)AjustedLongitude - 1));
            }
        }

        public bool IsExtremelyExaltedInRashi(EnumRasi rasi)
        {
            return ((this.GetRelationToRasi(rasi) == EnumPlanetRasiRelationTypes.Uchcha)
                    && (Horoscope.GetExtremeStateDegree(this.Current) <= (int)AjustedLongitude + 1)
                    && (Horoscope.GetExtremeStateDegree(this.Current) >= (int)AjustedLongitude - 1));
        }

        public bool IsDebilitated
        {
            get
            {
                return (this.PlanetRasiRelation == EnumPlanetRasiRelationTypes.Neecha);
            }
        }

        public bool IsExtremelyDebilitated
        {
            get
            {
                return ((this.PlanetRasiRelation == EnumPlanetRasiRelationTypes.Neecha)
                    && (Horoscope.GetExtremeStateDegree(this.Current) <= (int)AjustedLongitude + 1)
                    && (Horoscope.GetExtremeStateDegree(this.Current) >= (int)AjustedLongitude - 1));
            }
        }

        public bool IsExtremelyDebilitatedInRashi(EnumRasi rasi)
        {
            return ((this.GetRelationToRasi(rasi) == EnumPlanetRasiRelationTypes.Neecha)
                && (Horoscope.GetExtremeStateDegree(this.Current) <= (int)AjustedLongitude + 1)
                && (Horoscope.GetExtremeStateDegree(this.Current) >= (int)AjustedLongitude - 1));
        }

        public EnumPlanetRasiRelationTypes PlanetRasiRelation
        {
            get
            {
                return Horoscope.GetPlanetRelationToRasi(this.Current, this.Rasi.Current);
            }
        }

        public DasaEffectTypes DasaBirthPlanetEffect
        {
            get
            {
                if ((IsExalted || IsExtremelyExalted))
                    return DasaEffectTypes.Sampurna;
                else if ((this.Rasi.GetRelationToPlanet(this.Current) <= EnumPlanetRasiRelationTypes.Mithra)
                    && (this.NawamsaRasi.GetRelationToPlanet(this.Current) <= EnumPlanetRasiRelationTypes.Mithra))
                    return DasaEffectTypes.Sampurna;
                else if (IsExalted)
                    return DasaEffectTypes.Purna;
                else if (this.Rasi.GetRelationToPlanet(this.Current) <= EnumPlanetRasiRelationTypes.Mithra)
                    return DasaEffectTypes.Purna;
                else if ((Horoscope.GetExtremeStateDegree(this.Current) < (int)AjustedLongitude)
                    && (this.NawamsaRasi.GetRelationToPlanet(this.Current) <= EnumPlanetRasiRelationTypes.Mithra))
                    return DasaEffectTypes.Madyama;
                else if ((Horoscope.GetExtremeStateDegree(this.Current) > (int)AjustedLongitude)
                    && (this.NawamsaRasi.GetRelationToPlanet(this.Current) <= EnumPlanetRasiRelationTypes.Mithra))
                    return DasaEffectTypes.Adhama;
                else if ((this.Rasi.GetRelationToPlanet(this.Current).ToString().Contains("Neecha")) || (this.NawamsaRasi.GetRelationToPlanet(this.Current) >= EnumPlanetRasiRelationTypes.Sathuru))
                    return DasaEffectTypes.Anishta;
                else if ((this.NawamsaRasi.GetRelationToPlanet(this.Current) >= EnumPlanetRasiRelationTypes.Sathuru)
                    && (this.GetRelationToRasi(this.Rasi.Current) < EnumPlanetRasiRelationTypes.Sama))
                    return DasaEffectTypes.Mixed;
                else if ((this.NawamsaRasi.GetRelationToPlanet(this.Current) < EnumPlanetRasiRelationTypes.Sama)
                    && (this.GetRelationToRasi(this.Rasi.Current) >= EnumPlanetRasiRelationTypes.Sathuru))
                    return DasaEffectTypes.Mixed;
                return DasaEffectTypes.None;
            }
        }

        public PlanetIdentity Identity
        {
            get
            {
                switch (this.Current)
                {
                    case EnumPlanet.Sun: { return new PlanetIdentity("Kulu Rasha", "Copper", "Borns", "Square Body", "Piththaadika Body", "King", new List<string>() { "Brown eyes", "Less hair" }, new List<string>() { "" }); }
                    case EnumPlanet.Moon: { return new PlanetIdentity("Lunu Rasha", "Gem", "Blood", "Thin Body", "Waatha/ Semadhika Body", "Queen", new List<string>() { "Use pleasant words", "Likeable" }, new List<string>() { "Sharp", "Brainy" }); }
                    case EnumPlanet.Mars: { return new PlanetIdentity("Thiththa Rasha", "Gold", "Born Marrow", "Young Body", "Piththaadika Body", "Warrior", new List<string>() { "Red/ cruel eyes", "No Big Belly" }, new List<string>() { "Ethical", "Quickly change" }); }
                    case EnumPlanet.Mercury: { return new PlanetIdentity("Mishra Rasha", "Brass", "Flem", "Child Like Body", "Waatha/ Pitha/ Sema Body", "Child", new List<string>() { "Gotha gasana voice" }, new List<string>() { "Like to smile" }); }
                    case EnumPlanet.Jupiter: { return new PlanetIdentity("Madhura Rasha", "Silver", "Fat", "Fat Body", "Semaadhika Body", "Advisor", new List<string>() { "Yellow/ brown eyes", "Brown hair" }, new List<string>() { "Live as per dharma", "Brainy" }); ; }
                    case EnumPlanet.Venus: { return new PlanetIdentity("Ambul Rasha", "Pearl", "Sperm", "Beautiful Body", "Sem/ Waathaadhika Body", "Princes", new List<string>() { "Beautiful eyes", "Black hair", "Curly hair" }, new List<string>() { "Sex", "Beauty" }); }
                    case EnumPlanet.Saturn: { return new PlanetIdentity("Kahata Rasha", "Led/ Iron", "Veins", "Thin tall Body", "Waathaadika Body", "Begger", new List<string>() { "Golden eyes", "Wide Teeth", "Thick hair all over" }, new List<string>() { "Lazy", "Use hard words" }); }
                    case EnumPlanet.Rahu: { return new PlanetIdentity("", "", "", "Square Body", "Piththaadika Body", "King", new List<string>() { "Brown eyes", "Less hair" }, new List<string>() { "" }); }
                    case EnumPlanet.Kethu: { return new PlanetIdentity("", "", "", "Square Body", "Piththaadika Body", "King", new List<string>() { "Brown eyes", "Less hair" }, new List<string>() { "" }); }
                    case EnumPlanet.Uranus: { return new PlanetIdentity("", "", "", "Square Body", "Piththaadika Body", "King", new List<string>() { "Brown eyes", "Less hair" }, new List<string>() { "" }); }
                    case EnumPlanet.Neptune: { return new PlanetIdentity("", "", "", "Square Body", "Piththaadika Body", "King", new List<string>() { "Brown eyes", "Less hair" }, new List<string>() { "" }); }
                    case EnumPlanet.Pluto: { return new PlanetIdentity("", "", "", "Square Body", "Piththaadika Body", "King", new List<string>() { "Brown eyes", "Less hair" }, new List<string>() { "" }); }
                }
                return new PlanetIdentity();

            }
        }

        public string GetEffectPlantOnRashi()
        {
            switch (this.Current)
            {
                case EnumPlanet.Sun: { return GetSunInRashies(this.Rasi.Current); }
                /*case EnumPlanet.Moon: { return GetSunInHouses(houseNumber); }
                case EnumPlanet.Mars: { return GetMarsInHouses(houseNumber); }
                case EnumPlanet.Mercury: { return GetSunInHouses(houseNumber); }
                case EnumPlanet.Jupiter: { return GetJupiterInHouses(houseNumber); }
                case EnumPlanet.Venus: { return GetVenusInHouses(houseNumber); }
                case EnumPlanet.Saturn: { return GetSaturnInHouses(houseNumber); }
                case EnumPlanet.Rahu: { return GetRahuInHouses(houseNumber); }
                case EnumPlanet.Kethu: { return GetKethuInHouses(houseNumber); }
                case EnumPlanet.Uranus: { return GetSunInHouses(houseNumber); }
                case EnumPlanet.Neptune: { return GetSunInHouses(houseNumber); }
                case EnumPlanet.Pluto: { return GetSunInHouses(houseNumber); }*/
            }
            return "";

        }

        private string GetSunInRashies(EnumRasi current)
        {
            switch (current)
            {
                case EnumRasi.Mesha: return "Get famous, become ";
            }
            return "";
        }

        public String GetEffectPlanetTransitOverHouse(int houseNumber)
        {
            return GetEffectPlanetTransitOverHouse(this.Current, houseNumber);
        }

        public String GetEffectPlanetTransitOverHouse(EnumPlanet planet, int houseNumber)
        {
            switch (this.Current)
            {
                case EnumPlanet.Sun: { return GetSunInHouses(houseNumber); } 
                case EnumPlanet.Moon: { return GetMoonInHouses(houseNumber); }
                case EnumPlanet.Mars: { return GetMarsInHouses(houseNumber); }
                case EnumPlanet.Mercury: { return GetMercuryInHouses(houseNumber); }
                case EnumPlanet.Jupiter: { return GetJupiterInHouses(houseNumber); }
                case EnumPlanet.Venus: { return GetVenusInHouses(houseNumber); }
                case EnumPlanet.Saturn: { return GetSaturnInHouses(houseNumber); }
                case EnumPlanet.Rahu: { return GetRahuInHouses(houseNumber); }
                case EnumPlanet.Kethu: { return GetKethuInHouses(houseNumber); }
                case EnumPlanet.Uranus: { return GetUranusInHouses(houseNumber); }
                case EnumPlanet.Neptune: { return GetNeptuneInHouses(houseNumber); }
                case EnumPlanet.Pluto: { return GetPlutoInHouses(houseNumber); }
            }
            return "";
        }

        /// <summary>
        /// https://cafeastrology.com/transitsofthemoon.html
        /// </summary>
        /// <param name="houseNumber"></param>
        /// <returns></returns>
        public string GetMoonInHouses(int houseNumber)
        {
            string message = "House Transit\r\n";

            switch (houseNumber)
            {
                case 1: message += "Your focus now is outward-oriented. You feel the need to express yourself–to manifest your inner world in the outer world in some manner. It’s a good time to focus on new beginnings and fresh starts. At this time, your skin is thin–you are more sensitive to the vibrations and energies around you, particularly in your immediate environment. You are inclined to act on impulse, or to react automatically based on your basic emotional orientation, rather than approaching the world objectively. It’s easy to be emotionally touched by something now, but also to feel hurt or disappointed. In the 2-3 days of this transit, you tend to take things very personally. Some restlessness is likely now, and could impel you to make some small personal changes, such as changing your “look” or your living environment in little ways. You might deal with the public in some manner. You could also be feeling emotional or sensitive about your appearance or manner."; break;
                case 2: message += "Your focus now is on emotional security. How much you have in terms of money and possessions can be an issue now, and tends to impact how you feel about yourself. This is not a time of emotional bravery. Rather, you tend to keep the status quo. You value predictability for the 2-3 days of this transit. You don’t look for new experiences as much as you put effort into managing your life in order to feel solid and secure. Material or tangible things have more importance to you right now. Feeling emotional about your financial position could figure now."; break;
                case 3: message += "This 2-3 day transit marks one of the busier periods in the lunar month. Activities may be centered around making errands, short trips, phone calls, and other communications. Your mind tends to be restless, easily bored, and in need of stimulation. You could find it hard to focus on any one particular task. Your curiosity is ignited. New friendships or contacts might be made. You might find yourself talking more than usual, perhaps about the past. Emotional communications could figure now."; break;
                case 4: message += "Your attention turns inward and towards your domestic affairs during this 2-3 day transit. You feel the need for more privacy than usual, and you tend to focus on building or solidifying your home base. You have a greater need for security and the feeling of being safe and comfortable during this period. This is a time for building your sense of security. Family and personal matters take precedence over worldly affairs just now. How you feel about your support system at this stage in your life will determine your mood."; break;
                case 5: message += "You are likely feeling decidedly more outgoing during this 2-3 day transit than you were feeling while the Moon transited your fourth house. This is an expressive few days—your energies are directed outwards as you feel more confident moving about in the world. You have an emotional need to be heard, seen, and noticed. An increased desire to create, and to display your talents, is often experienced during this phase. Recreation, hobbies, romance, and anything that gives you pleasure is now more important to you than usual. You are feeling especially amorous or at least more inclined to express your loving feelings now. Others tend to tune into you emotionally. You could get a sudden desire to see a movie, explore a creative urge, play a game, or take in a play, for example. Enjoy yourself and indulge your whims, within reason of course."; break;
                case 6: message += "After a somewhat naive and playful few days, while the Moon transited your fifth house, the current 2-3 day phase indicates a need and/or desire to perfect your craft. This is a time of dedication to work, health, and routine. This is a more introverted period when you might have your “nose to the grindstone”, so to speak. You might set your feelings aside in order to take care of details now, or you could be more emotionally sensitive about your work, health, and daily routine. Your senses are more acute and you could find minor aches and pains are now more noticeable. As well, you could find that little things that are out of order in your life become more apparent. Cleaning and re-organizing may be in order now. Your mood is likely to impact your health more than ever. Try not to stress over little things. Instead, work on improving and perfecting the smaller systems in your life so that you can move on without guilt."; break;
                case 7: message += "Close personal and business relationships are highlighted now. How you feel about your close relationships or partnerships will largely determine your mood during these 2-3 days. You might have emotional confrontations now or warm, nurturing relations, again depending on your current circumstances. Sometimes this transit correlates with the need for a consultation, and usually one-on-one relationships figure. An increased need to be with people, to socialize, and to compromise are featured during this transit. More attention to physical appearance and attractiveness, as well as graciousness, could also figure. You are in the position to learn much about yourself by listening to others. The need to create or maintain a harmonious environment dominates now, but getting to that point can entail some conflict! Feeling emotional about your relationships could also figure now."; break;
                case 8: message += "There can be a hunger now for deeper experiences and more powerful bonds. Emotional commitments come into focus during the 2-3 days of this transit. You are looking for more meaning in your life, and any activity that stirs your emotions attracts. On a more mundane level, money and possessions could be emotional issues now. Be aware that you could over-react to matters during this transit, finding it hard to detach yourself emotionally in order to look at life objectively. You are not as sociable during this brief trend, preferring to analyze and feel out your life’s circumstances than to put yourself “out there”."; break;
                case 9: message += "Freedom on all levels is the focus during this 2-3 day transit — not only physical freedom of movement and expression, but mental and spiritual freedom as well. The emotional need now is expansion and growth. You do not want to be limited by boundaries or barriers. This is a more gregarious placement of the Moon. Independence, new experiences, and intellectual growth are the major focus. You tend to take more trips or embark on adventures–however big or small–during this transit. Emotional boredom or restlessness could be at the root of this. Breaking the routine is in order. This is a good time to catch a break and get some perspective on your life. Feeling emotional about your opinions or beliefs could also figure now."; break;
                case 10: message += "Your attention now is on approval and recognition. The focus is on establishing some sort of order and control in your life. A stronger need for recognition and for concrete success is typical of this 2-3 day transit. Discontent with your position in life could be magnified now. Matters surrounding your profession or the authority figures in your life come to the foreground. Sensitivity to your reputation or how others view you can figure now. You are noticed for what you do (and don’t do), what you have done (or haven’t done). It’s time to be on your best behavior!"; break;
                case 11: message += "This is a more sociable and gregarious transit of the Moon. Stronger social awareness and a desire to belong to a group may figure now, although sometimes it’s more about expressing your own individuality and breaking the rules. Networking is the keyword for this 2-3 day period. It’s a good time to spend with friends or groups. However, you are more sensitive to the moods of those around you, and you could be feeling emotional about your sense of belonging (or lack of) with like-minded people."; break;
                case 12: message += "Heightened sensitivity and an emotional need to connect with your inner world is dominant during this 2-3 day transit. This is often a more introverted period in the lunar month when the focus is on your dreams and longings, personal creativity, and sensitivity. Time spent alone may be necessary, and some form of emotional retreat is natural. You could be more insecure than usual, and it’s best to hold back on starting new projects for the time being."; break;
            }
            if (!IsTransitPlanet)
                return message;

            message += "\r\nTransit over other planets";
            foreach (AstroPlanet planet in BirthPlanets)
            {
                    message += "\r\n";
                switch (planet.Current)
                {

                    case EnumPlanet.Sun:
                        {
                            if (((Math.Abs(planet.Longitude - this.Longitude) > 350) && (Math.Abs(planet.Longitude - this.Longitude) < 10)))
                                message += "0 Sun - Your personal New Moon is a time of new beginnings. Your needs are aligned with your wants right now, and it’s an opportune time to make a few resolutions. Things seem to play in your style, so you don’t have to stress or strain. The inner harmony you experience now is reflected in your outer experience and contributes to your personal success. You could experience some change or undergo inner changes that stimulate a new undertaking, relationship, or attitude change. You act with more confidence than usual. Without even trying, you are likely to draw attention to yourself or to receive support. This is an ideal time to establish inner peace and balance.";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 50) && (Math.Abs(planet.Longitude - this.Longitude) < 70))
                                message += "60 Sun - This transit offers you increased clarity derived from a feeling that what you want and what you need are in harmony. You are more willing to cooperate, and you naturally attract support from others and/or positive experiences that contribute to your success. Your gut instincts tend to serve you well now, as they are not undermined by fears or insecurities. Your intentions and actions harmonize, which improves your relationships with others and with your own body and spirit. This is a good time to heal, to clear your mind, and to “stop to smell the roses”. You could experience an improvement in your family affairs or domestic circumstances, as well as your business pursuits.";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 80) && (Math.Abs(planet.Longitude - this.Longitude) < 100))
                                message += "90 Sun - You may become aware of a conflict between what you want and what you need. Even if you are not aware of this inner imbalance, it could cause some tensions or feelings of being unsupported by others or by circumstances in your life. This can cause you to be provocative with others, or it can spur you into finding answers to problems–the choice is yours! You may feel slightly out of step or out of synch, which could make you edgy. There could be a noticeable discrepancy between the demands of your personal life and what is expected of you at work. Minor problems in relationships are more likely during this transit. Arriving at decisions is harder now because you feel torn between choices. If this transit occurs during the night, you could have a restless sleep. Examining bad dreams can help you understand what is bothering you. Use the dynamic energy of this transit to identify problems in order to find solutions to them, instead of harping on what is going wrong in your life or taking it out on others.";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 110) && (Math.Abs(planet.Longitude - this.Longitude) < 130))
                                message += "120 Sun - It’s easy to put your best face forward and to cooperate with others because you are not conflicted on the inside. What you do and what you feel are in harmony, and you benefit from this clarity. The harmony that you feel between your body and spirit allows you to act more holistically and purposefully. As well, decision-making is improved. If this transit occurs during the night, you sleep better. You are expressing yourself more genuinely, and you are received well as a result.";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 170) && (Math.Abs(planet.Longitude - this.Longitude) < 190))
                                message += "180 Sun - Decision - making can be challenging right now, as there is a basic conflict between your instincts and what you feel you should do.Inner imbalance between your body and your spirit can wreak a little havoc on your personal relationships.You may become aware of a conflict between the demands of your personal life and your professional life. It is harder to get support from others due to your own inner struggle. Try to avoid over-reacting, as it will get you nowhere fast.Use this dynamic energy to identify areas of your life that are not serving your greater purpose, and then work towards finding solutions.";
                        }
                        break;
                    case EnumPlanet.Moon:
                        {
                            if (((Math.Abs(planet.Longitude - this.Longitude) > 350) && (Math.Abs(planet.Longitude - this.Longitude) < 10)))
                                message += "0 Moon - This transit marks the start of your personal lunar month. You are emotionally charged now. You should be aware that your current state of mind can, in an indirect way, determine much about how you will be feeling in the month ahead. As such, make it as positive as you can. Honor your feelings, reach into your well, and pull out the feelings that support your larger goals. Familiarity, a sense of belonging, and emotional connections fuel your spirit now more than usual. You are more sensitive and responsive than you are typically. Relationships with significant women in your life may be especially prominent now.";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 50) && (Math.Abs(planet.Longitude - this.Longitude) < 70))
                                message += "60 Moon - It is easier for you to get in touch with your feelings and to recognize your inner resources now. A feeling of contentment and satisfaction can lead to inertia, or it can create opportunities for you to express yourself to others – the choice is yours. You are unlikely to break the routine for the time being, as a feeling of familiarity is a deep need. This is a good time for all things domestic–for bridging emotional gaps with family members, and for tending to domestic affairs with general success.";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 80) && (Math.Abs(planet.Longitude - this.Longitude) < 100))
                                message += "90 Moon - Minor forced changes to your routine or habits may upset you now. Friends and associates may burden you, and indecision keeps you from making good financial or business decisions. This can indicate a a brief period when you are not as popular as you normally are. Temperamentality is your worst enemy for the time being. You may be feeling stressed or unsupported, which can negatively influence your health. Feeling emotionally at odds with others will pass soon enough. For now, avoid taking little upsets to heart. It’s probably best to avoid new initiatives on the domestic front as well as business changes.";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 110) && (Math.Abs(planet.Longitude - this.Longitude) < 130))
                                message += "120 Moon - Your emotions are stable with this influence. Feelings of contentment and a generally good mood help you to deal with changes effortlessly. You are more receptive and are more able to rely on your instincts. Spontaneity is the key to success right now. New friends could be made. Occasionally, this influence brings you before the public in some manner. This can be a time of heightened yet manageable emotions. Family and financial affairs should run smoothly. Your personal popularity peaks. This is a good time for making business decisions, investing, and property deals, all things equal.";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 170) && (Math.Abs(planet.Longitude - this.Longitude) < 190))
                                message += "180 Moon - Emotional desire is strong, but could very well conflict with the demands of your personal life. Decisions made now, if you can come to any conclusions at all, may not be sound. Feeling emotionally out of step with others may get the better of your spirits for the time being. Your reactions are presently strongly emotional, and it is easy for events or for people to trigger resentments or buried emotions. You may take a trip down memory lane, but it might not be the most pleasant of journeys! Let the strong emotions pass rather than harp on them. Hold off on making business decisions or embarking on new projects on the domestic front.";
                        }
                        break;
                    case EnumPlanet.Mercury:
                        {
                            if (((Math.Abs(planet.Longitude - this.Longitude) > 350) && (Math.Abs(planet.Longitude - this.Longitude) < 10)))
                                message += "0 Mercury -	Imagination is brought to your communications and your mental pursuits, and your ideas and thoughts flow smoothly. You are more inclined towards personal communications, social discourse, and sharing. As well, you may easily get caught up in reminisce. Conversations or thoughts about the past are featured now. Your mind is more receptive and alert than usual, and you may find yourself especially busy and curious, but perhaps too scattered to concentrate for very long on any particular subject. Your memory is particularly sharp. Connections could be made or enhanced with younger people. You express your feelings in an honest way, and you are likely to be preoccupied with personal matters. Seeking advice could be a theme now, whether you are the one looking for it, or others are turning to you for answers.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 50) && (Math.Abs(planet.Longitude - this.Longitude) < 70))
                                message += "60 Mercury -	This influence brings imagination to your mental pursuits. In business terms, it’s a strong influence for negotiation, trading, and communications. A positive connection to a younger person may be made now, whether it’s a new connection or simply a boost to an existing relationship. You are at your most persuasive. With your heart and head cooperating with each other, you’re in the position to make wonderful connections. Conversations are warm and heart-to-hearts could be on the agenda; and common interests with your loved ones are the most likely topic. This is an especially favorable transit for public speaking and presenting your ideas with flair.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 80) && (Math.Abs(planet.Longitude - this.Longitude) < 100))
                                message += "90 Mercury -	What feels right clashes with logic right now. What you say may be a misrepresentation of your true feelings and emotions. Car and other transportation troubles, as well as computer glitches, miscommunications, and dealing with red tape, are more likely now than usual. You could encounter delays in business, and there might be some minor troubles with younger people or siblings. It takes extra effort for you to understand others, or they to understand you. You’re less likely to be objective and prone to changing your mind frequently, so it would be better to postpone important decision-making. Although you are in the mood to talk about personal matters, you could be communicating with an air of defensiveness. Avoid getting stressed out over the little things.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 110) && (Math.Abs(planet.Longitude - this.Longitude) < 130))
                                message += "120 Mercury -	Your head and your heart agree with one another now, so take advantage and open up the lines of communication with others. You are in a more sociable frame of mind. It’s easier than usual to flaunt your talents without even trying, and articulating your feelings without upsetting anyone comes easily. This is an excellent transit for taking tests, studying, writing, promoting, advertising, and public speaking. Your mind is especially alert and perceptive, and your memory retentive. Capture your ideas on paper so that you can use them to improve your personal affairs and business at a later date. If you need to, schedule negotiations, trades, and other communications now. Honesty will get you everywhere.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 170) && (Math.Abs(planet.Longitude - this.Longitude) < 190))
                                message += "180 Mercury -	Minor disagreements, especially over domestic matters, are more likely than usual now. You may be talkative, but not necessarily saying much! Little disturbances coming from the outside are likely more a reflection of your own nervousness and sensitivity to the emotional “weather” around you. It can be hard to stick to the facts and to remain clear-headed under this influence, so do what you can to avoid scheduling negotiations, test-taking, or contract-signing now. Also, because you are not received as well, public relations initiatives should be postponed. This is a time when things like the car breaking down, missing the bus, lost emails, and other minor mishaps involving getting from point A to point B and communicating effectively occur.		";
                        }
                        break;
                    case EnumPlanet.Venus:
                        {
                            if (((Math.Abs(planet.Longitude - this.Longitude) > 350) && (Math.Abs(planet.Longitude - this.Longitude) < 10)))
                                message += "0 Venus -	You are more approachable during this transit, and you could have the chance to improve your personal relationships. An invitation to a pleasurable event or activity is possible, and sometimes this can mark the start of a new friendship or love affair. This is an affectionate and friendly influence–not wild or exciting, but pleasing and perhaps a little self-indulgent. Your personal popularity moves up a notch. Being pampered and pampering are desires, and anything that brings more beauty and harmony to your life is favored.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 50) && (Math.Abs(planet.Longitude - this.Longitude) < 70))
                                message += "60 Venus -	Love and romantic matters are favorable for you now. You might enjoy a happy social event or other pleasurable activity. It’s a good influence for beauty treatments, redecorating, and the arts; and favorable for scheduling dates. This transit increases intimacy and improves relationships with others, particularly with women. It’s also a favorable time to ask for help from others if you need it. Increased sensitivity and warmth helps endear you to others.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 80) && (Math.Abs(planet.Longitude - this.Longitude) < 100))
                                message += "90 Venus -	You are a little more vulnerable than usual, likely because you don’t seem to know what you want for the time being. There could be clashes between your desire for familiarity and your need for pleasure right now. Social upsets are possible, or you may find that you are unable to do something pleasurable even though you would really like to. This sometimes triggers an attraction to someone who is simply not right for you, or minor problems in existing love affairs. On other occasions, this can signal a new love affair or friendship, particularly with a female. Domestic matters could annoy you. Avoid money transactions if you can.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 110) && (Math.Abs(planet.Longitude - this.Longitude) < 130))
                                message += "120 Venus -	This is a favorable influence for scheduling dates and for love in general. You are somewhat vulnerable, wearing your feelings on your sleeve. This can indicate happy social events, and is fortunate for beauty treatments, pleasurable outings, music, the arts, and holidays or gatherings. It’s good for money as well, but you might spend it as quickly as you earn it! You are especially warm and friendly with people you meet, and others sense your sincerity. You are more approachable than usual, and loving feelings influence–and enhance–your sex life. This is a favorable time for decorating your home (or your body!), throwing a party, or simply going out for a coffee with a buddy.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 170) && (Math.Abs(planet.Longitude - this.Longitude) < 190))
                                message += "180 Venus -	Interference that prevents you from doing something pleasurable may be in store for you now. For example, you might want to go out but your friends don’t want to, or can’t, accompany you. Domestic matters might burden you. Minor social upsets or problems with love affairs are possible now. An unusual attraction to someone perhaps unsuitable is possible. There could be minor problems with money, and some hypersensitivity that undermines your good humor or that disrupts cooperation with others.		";
                        }
                        break;
                    case EnumPlanet.Mars:
                        {
                            if (((Math.Abs(planet.Longitude - this.Longitude) > 350) && (Math.Abs(planet.Longitude - this.Longitude) < 10)))
                                message += "0 Mars - Your emotions intensify and you instinctively desire change and adventure. It would be wise to keep your cool and avoid confrontations. Excessive haste or rash behavior can leave you vulnerable to accidents or injuries, but healthy risk-taking might simply serve to enliven you. This sometimes points to a passionate time, or a new relationship with a man. This is a time when you are likely to feel irritable if you don’t have something adventurous, challenging, or physical to do. This is a good time to take a chance, say what you feel, or do something exciting outside of your normal routine. Taking the initiative is appropriate now. You are braver and more decisive. Your instinctive reactions are quick, your sexual appetite is voracious, and you naturally take the lead.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 50) && (Math.Abs(planet.Longitude - this.Longitude) < 70))
                                message += "60 Mars - This influence heightens your feelings, awakens your impulses, and stirs your passions, mostly in a positive way. This is sometimes an indication of connections made with men. As well, passionate liaisons occasionally begin under this transit. You are more in tune with your natural impulses, and less inclined to think things through before taking action. It’s an excellent period for taking the initiative. Expressing your feelings comes naturally now, and you make no apologies for doing so! This transit gives you self-confidence and backbone without backlash from others. You are more resourceful and independent, and less demanding of people around you, which tends to earn you respect.";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 80) && (Math.Abs(planet.Longitude - this.Longitude) < 100))
                                message += "90 Mars - This transit fires up your feelings and stirs up your need for action, activity, and challenges.You are more inclined to act on impulse now, and you could be quite temperamental.You may easily fly off the handle or simply jump into a situation without considering the consequences.There could be problems with men or masculine energy.It could also be a rather passionate time, simply because, for the time being, you tend to be ruled by your passions. Doing something rash is quite possible now, but it’s not always a bad thing.The dynamic energy of this transit could give you just the right kick in the pants to push you out of a bad situation, for example.Still, it would be wise to use some caution, and don’t push yourself too hard.Over - reacting to a situation could tick others off, although you don’t much care at this time!";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 110) && (Math.Abs(planet.Longitude - this.Longitude) < 130))
                                message += "120 Mars - This transit boosts your self - confidence and ability to assert yourself without ruffling the feathers of people around you.Your desire nature and your emotions are cooperating beautifully just now, which increases your resourcefulness and independence. Others allow you to be yourself, and you feel “in sync” with your environment.You can more confidently rely on your instincts now, and you react well to competition. This influence heightens your feelings, awakens your impulses, and stirs your passions, mostly in a positive way.This is sometimes an indication of connections made with men. As well, passionate liaisons sometimes begin under this transit. You’re a natural leader under this influence, so it’s an opportune time to take the initiative. Do something that breaks the routine or that you’ve always wanted to do but have been hesitating to do due to shyness or fear. You’ll pull it off with finesse now.";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 170) && (Math.Abs(planet.Longitude - this.Longitude) < 190))
                                message += "180 Mars -	Acting on impulse is what this transit tends to spur you to do. On the negative side, you could be very temperamental and touchy. Used positively, you could possess just the right amount of verve to do something you’ve never done before. Be aware that you are ruled by your passions now. A new connection with a man, or problems with males, may feature. You could get caught up in a domestic squabble. Although overly hasty or rash actions taken now could rebound on you, some healthy risk-taking could simply help you to break the routine and get you out of a rut. This transit excites your passions, and you are less in control of them than usual.";
                        }
                        break;
                    case EnumPlanet.Jupiter:
                        {
                            if (((Math.Abs(planet.Longitude - this.Longitude) > 350) && (Math.Abs(planet.Longitude - this.Longitude) < 10)))
                                message += "0 Jupiter -	This is a lucky, expansive, happy, and prosperous period. Some sort of emotional relief is likely, particularly with regards to your personal life. Domestic changes and legal affairs are favored, particularly dealings with property and renovations. It’s a good time to write, teach, learn, publish, promote, and take tests. You may enjoy opportunities to do any of these things now. Your personal popularity increases, in direct proportion to your own elevated, positive mood, and some kind of recognition or honor may come your way. It’s a better time of the month to buy a lottery ticket. Your desire for pleasure is strong. Occasionally, losses are required in order to see gains. Disagreements with others are rare during this period, generally because you are more likely to take the high road than to resort to pettiness.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 50) && (Math.Abs(planet.Longitude - this.Longitude) < 70))
                                message += "60 Jupiter -	This signals an emotionally upbeat period when you enjoy your family, friends, and social life. Legal and real estate matters proceed smoothly. Public relations and general good favor and approval are more likely now. You may stumble upon opportunities to expand your horizons through travel, higher education, or contact with those of a different background than your own. \r\nThis is a fortunate, albeit brief, period for achievement and recognition in business. This is a favorable influence for learning, teaching, taking exams, publishing, and promotion. Business opportunities may present themselves. Occasionally, a loss is necessary in order to achieve a gain. This sometimes indicates the beginning of a friendship, particularly with someone who expands your mind or your social circle.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 80) && (Math.Abs(planet.Longitude - this.Longitude) < 100))
                                message += "90 Jupiter -	You may be feeling less hopeful or optimistic during this brief transit. On the contrary, you could be feeling over-confident or enthusiastic to the point of over-excitement and potential letdown. The bottom line is that you are not especially realistic due to moodiness. Minor annoyances, such as unexpected bills coming your way or arguments with others over personal philosophies, may be part of the picture. \r\nThis is not an ideal time for publicity, promotion, or legal matters. You are more sensitive to injustices (or perceived injustices), but you should avoid behavior that is self-righteous or haughty. Don’t get your knickers in a knot over simple differences of opinion. Self-indulgence is more likely now. You’re not as inclined to consider the consequences of over-eating, over-drinking, or overdoing in general.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 110) && (Math.Abs(planet.Longitude - this.Longitude) < 130))
                                message += "120 Jupiter -	Happy feelings, the desire to do good and to honor your inner code, and faithfulness are characteristics of this period. Your positive state of mind can attract others, as well as favorable circumstances, to you. It’s a better time of the month to buy a lottery ticket or to engage in reasonable speculation. You are more tuned in to the big picture and less inclined to worry over details. Others might find you particularly wise right now, and you are more generous with your time, energy, and money.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 170) && (Math.Abs(planet.Longitude - this.Longitude) < 190))
                                message += "180 Jupiter -	You’re given to excesses just now, and it can be hard to think of the consequences of overdoing things when you’re in such an elevated mood. This is a borrow from the future energy. Try not to commit yourself to something that you don’t have the resources for. If you can, hold off on publicity or promotion activities. Don’t let differences of opinion get the best of you. Otherwise, this is a sociable and mostly pleasurable transit.		";
                        }
                        break;
                    case EnumPlanet.Saturn:
                        {
                            if (((Math.Abs(planet.Longitude - this.Longitude) > 350) && (Math.Abs(planet.Longitude - this.Longitude) < 10)))
                                message += "0 Saturn -	Situations that require you to keep a cool head will work out well under this transit. You are not easily swept away by your feelings now, enabling you to effectively tend to business. Authority figures or people who are older than you could figure prominently now. A heightened awareness of your responsibilities, or taking on new responsibilities, characterizes this influence. It’s easier for you to buckle down and work, organize, and plan. What you output now will benefit you down the road, as it’s likely to be solid and realistic. This is a good time to make plans and lists. Some of us feel lonely or unsupported under the influence of this transit. Others welcome the feeling of self-reliance that comes now. A domestic problem or a burden might drop into your lap now, but you are likely to handle it well.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 50) && (Math.Abs(planet.Longitude - this.Longitude) < 70))
                                message += "60 Saturn -	Although there isn’t much in the way of instant gratification for the work you do now, you will see real benefits from your efforts down the road. Connections with older people or authority figures can be made and are generally positive now. Because you are not easily swept away by your feelings at this time, you can take advantage by making clear-headed and realistic decisions. You are more reliable than usual, and more willing to go it alone. Others might find you a little distant emotionally, but they also view you as responsible and competent.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 80) && (Math.Abs(planet.Longitude - this.Longitude) < 100))
                                message += "90 Saturn -	You may need to work overtime, or you could feel a pinch with your finances. Some feelings of being blocked are possible now with Saturn, the great teacher, activated and urging you to slow down. There may be problems with older people or authority figures. The rewards for your hard work are unlikely to be obvious right now. Domestic affairs may be a little messy. A feeling of being unsupported, alone, or too independent might grab hold of you for the time being. Expressing your feelings or your need for others is hard to do at the moment. Treat this period as a time when you are learning to rely on yourself.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 110) && (Math.Abs(planet.Longitude - this.Longitude) < 130))
                                message += "120 Saturn -	New responsibilities may come your way now, or there can be a heightened awareness of existing ones. It’s relatively easy to discipline yourself and work hard now. The work you do now will have real benefits down the road, although it may not be immediately obvious. Others would be hard-pressed to sweep you off your feet or sway you from your path right now! Appeals to your emotions won’t work as much as appeals to your common sense, logic, and sense of responsibility.		";
                            if ((Math.Abs(planet.Longitude - this.Longitude) > 170) && (Math.Abs(planet.Longitude - this.Longitude) < 190))
                                message += "180 Saturn -	Feeling blocked from expressing yourself makes for a less than spontaneous period. Avoid clashes with authority figures or older people–you simply aren’t getting the recognition you deserve right now, but this influence will pass soon. Saturn often brings with it some blockage, hardship, or restriction. Your plans may hit a snag or two, or they simply don’t materialize as expected. You could feel misunderstood, your efforts could remain unrewarded, or you are not as physically energetic as usual, for example. You could also view situations (or people) with some mistrust for the time being. Because you may temporarily feel down or drained, this period is best used for rest.		";
                        }
                        break;
                }
            }
            return message;
        }

        public void FinalActions()
        {
        }

        private string GetMercuryInHouses(int houseNumber)
        {
            int moonHouse = this.BirthPlanets.FirstOrDefault(x => x.Current == EnumPlanet.Moon).HouseNumber;
            int countFromMoon = AstroUtility.HouseGab(moonHouse, houseNumber);

            switch (countFromMoon)
            {
                case 1: return "If Mercury transits into the first house from natal Moon, it increases one’s stress level. You might remain upset due to financial hiccups. Loss of confidence and courage is another unfavorable impact of Mercury transit in this house. You might find yourself involved in bad company during this time. This might not turn into your favor so better avoid any mischievous friends or lawsuits. Your expenditure could also shoot off so plan your finances wisely. It would also be good to postpone any travel plans for now.";
                case 2: return "If Mercury transits into the second house from natal Moon, it gives a nice lift to your income. You would get a lot of appreciation from your coworkers and friends during this time. Your learning objectives get fulfilled too and you gain a lot of essential knowledge. You remain in the company of inspiring people and communication becomes a source of profit for you. However, you should be careful concerning the health of your siblings.";
                case 3: return "When Mercury transits into third house from natal Moon, you might begin to suffer some sort of weakness and dip in health. Enemies might try to pose hurdles in your way so be prepared. This isn’t a favorable transit to take up travel. You may also run into disputes with your spouse. In fact, you might face issues in all relationships, whether coworkers or relatives. You should also avoid indulging in any arguments with seniors. Some financial turbulence may be there too due to high expenditure.";
                case 4: return "If Mercury transits into fourth house from natal Moon, it brings about new opportunities of income growth. This is a progressive time for education too. You would get to study new material and learn new skills. Sure-fire success in competitive exams is possible, though it draws heavily on your efforts. You could consider investing in real estate, as good returns are likely too. Some gains from spouse are possible as well. This is the period when you would enjoy peace of mind and success in your endeavors.";
                case 5: return "If Mercury transits into fifth house from natal Moon, you might feel low in terms of health. This transit could breed issues with children so be very careful in how you deal with them. You might also run into arguments with spouse during this time. It would be better to stay away from bad associations for now. Arguments with colleagues should also be dodged off for best. Students’ efforts may not materialize and studies may require more hard work and focus. This is not a good time to get lured into any investment plans either.";
                case 6: return "With Mercury’s transit into sixth house from natal Moon, success and victory follows in all endeavors. Business grows, knowledge flourishes, and you get a lot of benefits from many a sources. You would also observe progress in studies. Your lifestyle remains affluent, with regular comforts such as vehicle, wealth and luxuries life has to offer. Income also remains fair enough in keeping with your efforts. Health should be fine; however, you may want to flee away from situation involving arguments with seniors during this period.";
                case 7: return "When Mercury moves into seventh house from natal Moon, seniors begin to find faults with your work and get disappointed. You might face a lot of opposition during this time. Health seems to be a major area of concern, for you as well as your spouse and children. This might keep you stressed and drained. You should try to forge better communication with your spouse and children so they don’t feel ignored. Avoid any travel plans for now.";
                case 8: return "When Mercury transits into eighth house from natal Moon, your social status begins to rise. You enjoy a comfortable if not luxury lifestyle. Children matters remain smooth as well. If other planets support, you may also welcome a new member in your family. Mercury here affords you with a sudden intellect to take wiser decisions. Drawing on this improved wisdom, you may also progress on the career front and earn good income too. You would also enjoy a lot of mental peace and victory over opposition.";
                case 9: return "Mercury’s transit into ninth house from natal Moon marks the beginning of a relatively less fortunate period. You might run into some arguments with father during this time. Financial losses would also add to the mental burden you have been feeling lately. Some issues could also spoil your understanding with spouse. You should work hard during this while to maintain your position at work too. This is also a good period to think of cutting down expenditure and consider savings.";
                case 10: return "If Mercury transits into tenth house from natal Moon, you would feel more inclined towards spirituality. This is going to be an easygoing and cheerful period. You would enjoy a satisfactory income and growth in career as well. Your relationship with spouse would also remains sweet and smooth. You might get to spend time with someone new in your life. Your social status would also improve considerably as you topple opposition one by one. This would bring about a lot of mental peace.";
                case 11: return "Mercury’s move into eleventh house from natal Moon uplifts your will power. You are likely to enjoy a lot of material comforts and conveniences during this time. Your brothers and friends would specifically become your pillars of strength. You might discover and manifest a new hidden talent. You would fetch income from more than one source. Health should also remain satisfactory. You would also get to enjoy the company of opposite gender a lot.";
                case 12: return "When in twelfth house from the natal Moon, Mercury becomes weaker. There could be loss of wealth and health as well. Your expenditure would increase during this transit. You might go abroad during this period but don’t expect the desired outcome. Enemies may try to pose hurdles. You may also indulge in confrontations with spouse. All this might take a toll on your mental peace so try to maintain a cool and collected temperament in relationships.";
            }
            return "";
        }

        private string GetSunInHouses(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1: return "Rebirth of the self The Sun illuminates your first house for the next few weeks, bringing issues surrounding your personal identity, appearance, outward behavior, and self-expression to the forefront. This marks the height of your physical solar cycle, and you are in the position to make an impression on others, and to assert your personal influence beyond its normal boundaries. Spontaneity of expression is what this transit is about. You are ready to put your past behind you and to start a new personal cycle. You have presence and you project confidence. Increased energy and a renewed feeling of confidence is with you now, so take advantage. It’s a great month to do something entirely new and pioneeringto go solo in some area of your life. This particular season of the year smiles on your personal endeavors. This is a time when you more easily get in touch with a true sense of your identity and purpose. The most enterprising side of your nature pushes up and out, and it’s time to seize opportunities. Problems in your life may be overcome by bravery, self-assertion, and directness. There’s nothing wrong with a bit of self-centeredness during this cycle, but avoid taking it too far. It’s not the best time for team work and other cooperative endeavors. The spotlight is on you and your ability to lead, so make it a good one! Take steps to improve how you come across to others. It’s time to carve your own path in life. ";
                case 2: return "The Sun highlights your second house for the next few weeks, and your focus is on material affairs and comfort issues. Security is a driving force for you right now, and you might find that you are especially interested in accumulating possessions. What you have and what you don’t have come into focus–what makes you feel comfortable, your sense of security, and what you value. This is the time of year when personal finances and possessions receive maximum attention. Pour your energy into your work and your finances, and you might just be able to take your ideas to the bank. Extravagance with your pocketbook is something you may want to look out for, however. If you find yourself itching to make unnecessary purchases, know that at the root of this urge is the desire to pamper and comfort yourself. Nothing wrong with it, but there are inexpensive (and even free) ways to make yourself feel good. This is not the most eventful time of year for you. You are more inclined to dig your heels in and hang on to what makes you feel most secure than to take big risks. ";
                case 3: return "The Sun is illuminating your communications sector for the next few weeks, suggesting “busy-ness” and movement. You are exploring and searching now, making connections, and paying attention to your immediate environment. Social interaction is emphasized during this period, and is for the most part light-hearted. Give other people a little extra time and attention, notice their efforts on your behalf, and strengthen your connections. You are more curious and alert than usual, and you could be quite busy with errands, paperwork, phone calls, and light socializing. Much energy is expended in understanding and adapting to your immediate environment. Siblings, neighbors, close relatives, friends, and co-workers may play a more important role than usual in your life during this cycle. You are more interested in exploring your own neighborhood than you are a different country. This is not a time of big adventure-seeking. Rather, it’s a time of little adventures close to home. Neither is this a time when you are especially focused. In fact, you could have a finger in many pies right now. You are especially resourceful now, and you could find yourself enjoying (or seeking) attention for your intellectual know-how. The ability to express and communicate your ideas is extremely important to you at this time. You are eager to investigate new things, whether scientific or technical.   ";
                case 4: return "A time to “nest” The Sun is spotlighting your house of family and home for the next few weeks, and these areas are your instinctive focus during this period. Your family, home, property concerns, roots, and heritage come into focus and become a source of pride. You are likely quite preoccupied with feelings of security and your inner experiences. This is a time when you send down roots and seek a feeling of belonging. You could be thrust into a position of leadership on the home front. Ego confrontations with family members are possible now, but the best way to handle this energy is to do your best to strengthen your relationship to your family and your home base. This is a time to do what you can to build trust in your family life and a strong foundation within yourself, so that regardless of what you meet in the outside world over the next months, you have a secure place to return to. Besides spending more time tending to domestic affairs, the focus can be on cultivating and nourishing your inner foundations that support you and your growth. This is a time to collect yourself–to fill your well, so to speak. ";
                case 5: return "The Sun illuminates your fifth house for the next month or so. After a period of nesting, you are coming out of your shell, ready to perform and to express yourself creatively. This is a very playful period of the year, when you are inspired creatively and emotionally. After a period of self-protectiveness, you are now more spontaneous and more willing to take risks. You take more pride than usual in your creations, your love affairs, your children, and your hobbies. Pleasure and amusement play an important role in your search for freedom of self-expression now. Show off your best colors! You want others to take notice, and you are more sensitive to whether people appreciate you. More than any time of the year, this is the cycle in which you focus on having fun, enjoying romance, and expressing yourself creatively. Your hobbies, leisure time, moments spent with children, gaming time, and so forth, all come into focus at this time of year. This is a cycle in which you find joy in expressing who you are–when your “inner child” comes out to play. This is a time when you are more flirtatious than usual, and when you might take a few risks in life–not only gambling with games but with life itself. You might be a bit of a showman at this time. You are likely feeling good in general, and you tend to spread the joy. ";
                case 6: return "The Sun illuminates your sixth house for the next month or so. During this cycle, you take more pride in the work you do and in your health routines than any other time of the year. You are sorting through the experiences of the last several months, separating the worthwhile from the worthless. This is a good time to build your skills, to get organized, and to attend to your health and wellbeing. Its a great time to make improvements to your regular routines. Your self-esteem and your ego are tied up in the work you do and in the services you give. Details are more important to you now. It’s time to bring order to your life by focusing on the little things that make up the whole. This cycle presents an opportunity to get rid of what doesn’t work in your life, while also discovering what does. You could seek distinction and strive towards perfection in your work. Efficiency should be your goal now. Your physical health, as well as the relationship between your body and your mind, are in focus.   ";
                case 7: return "For the next month or so, the Sun illuminates your seventh house. At this time of year, you have a greater need than usual to be with a partner. Bouncing ideas off someone helps you to better understand yourself. A partner provides a mirror for your own self-discovery. Now is the time to realize your own potential through a significant other. During this cycle, you focus on balancing your personal interests and objectives with your social life, or with those of a partner. The emphasis is on “us” rather than “me”. You need the energies, companionship, and support of other people, and they may also seek out your support and companionship. It’s important to include others rather than to go solo for the time being. However, bending too much to the will of another is not advised either. Social interactions of a personal, one-on-one kind are emphasized. Circumstances are such that your diplomacy skills are required. Your popularity is increasing, and is reinforced by your own ability to cooperate and harmonize. Your ego and pride are tied up in how you relate to others now. This may be an especially busy time for people who consult or work with clients one-on-one.   ";
                case 8: return "For the next month or so, the Sun energizes your sector of  transformation, change, sexuality, personal growth, regeneration, others’ money and resources, addictions, and taxes. As a result, this is not the most gregarious of months for you. You take a step back, focus on intimacy with a partner, or simply retreat a little from the hectic pace of life. This is an excellent time to create a budget or financial plan, or to rid yourself of bad habits that undermine your sense of personal power and self-mastery. All that is deeply personal comes into focus now. Intimate matters are especially important to you during this cycle. Just how well you are handling your life comes up for inspection. Your self-mastery skills and psychological predisposition matter to you more than usual. This is the time of year when you are most desirous of change on a deep level. Clearing out psychic “junk” or ridding yourself of bad habits may be part of the picture now. You are more willing than usual to explore life’s secrets. This cycle brings greater in-depth understanding and an inclination to delve beneath the surface of matters to get to the bottom of them. Research uncovers new material that allows you to develop a better overall picture of the year’s events. This is an especially introspective cycle during which you have the chance to truly uncover your personal strengths and talents. On a more practical level, you may be dealing with joint finances and shared resources now more than usual.   ";
                case 9: return "For the next month or so, your focus turns outward, away from the more personal concerns that have occupied your thoughts in the last months. More than any other time during the year, you are feeling most adventurous and willing to take a leap of faith. This is a cycle in which you seek a higher meaning to your life, and/or seek out new experiences that take you beyond the here and now, and beyond the mundane details of day-to-day life. Anything that broadens your experiences attracts now. A lack of superficiality finds you straight to the point, interested in the truth of things. It would be wise for you to consider scheduling a vacation, adventure of sorts, or a course that expands your mind. These don’t have to happen now, but taking the time to recognize your needs for escaping the daily grind, taking a few risks, and feeding your spirit for self-expression through some form of adventure or higher learning, will help you to feel good about yourself. The only caution with this cycle is that you could lose touch with everyday affairs and important details.   ";
                case 10: return "For the next month or so, the Sun illuminates your career and reputation sector. More than any other time of the year, your focus is drawn to your “place” or standing in the outer world, and your reputation. This is the time when you are more interested in, and focused on, accomplishing something important. Your competency is something that you are especially sensitive to during this cycle. You want to shine. Your vision is practical right now, and you want to see tangible results for your efforts. More contact with authority figures is likely during this period. Recognition is likely to come your way whether you ask for it or not, and the responsibility that comes right along with it! Do what you feel is right, keeping in mind that you are at your most visible during this period in the year.   ";
                case 11: return "The Sun illuminates your sector of friends, groups, and dreams coming true for the next month or so. It’s a sociable sector of your chart, and that’s exactly how you are feeling–happy, lighthearted, and social. Group affiliations capture your attention. Connections can be made now and networking pays off. Being part of a community or circle of friends and building your social network is important to you at this time. This is a rather happy, goal-oriented cycle. A lively agenda is promised, you’re attracting quite a bit of interest, and your energy for making contact with others is high. A stronger sense of community is with you during this cycle. Relationships take on a fun, if impersonal, tone now. Activities with children increase. You are more stimulated by all that is unconventional during this cycle, and your ideas are original and progressive now. This is a time to follow your dreams and ideals, and to plant a seed in the form of a wish for the future.   ";
                case 12: return "For the next month or so, the Sun travels through your twelfth house, marking a time of retreat and regeneration. Think about the attachments you have–to things, people, and routines–and consider which ones are dragging you down. This is a time when competitive energies and the ego are on a bit of a break. It’s not the time to push ahead with brand new projects. Rather, it’s a time of reflection, dreaming, and recharging your batteries. Situations that have naturally outgrown their usefulness in your life can now be put behind you. Endings of natural cycles may be part of the picture at this time of year. Your energy is largely applied to personal and private affairs now. Your disposition is introspective. Rest and reflect, and prepare for a more outgoing cycle when the Sun moves into your first house. ";
            }
            return "";
        }

        private string GetJupiterInHouses(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1: { return "Jupiter is a symbol of knowledge, wealth and prosperity. The transit of Jupiter in the first house makes the native healthy, wealthy and wise. There is a marked increase in the financial position of the native. There are chances of promotion at the professional front or gains in business. The native is inclined towards religious activities. You may get married during this period. The health of the native improved considerably. This period opens new sources of income which benefits the native. The native possesses all the worldly comforts. There is a sudden turn of the events which will surpass all the problems. The transit makes the native physically and mentally fit. Overall, a very auspicious period."; }
                case 2: { return "Second house indicates wealth and personal possessions. During this transit, the native nourishes his talents and expands his horizons to increase his income. There are chances of purchasing valuable and materialistic things that add to your possessions. Promotion in the form of a rise in status and income comes very easily. Jupiter bestows its good effects on all the areas of life. If applied for loans, they get sanctioned from the higher authorities. The native enjoys social esteem and prestige. There is peace and harmony at home. There is a sense of satisfaction and fulfilment. The individual is more inclined towards religion and performs various rituals. The native should curb overspending as it may lead to financial crisis and mental agony. Overall, a very auspicious period."; }
                case 3: { return "Third house indicates communication and opportunities. The transit of Jupiter in third house highlights these areas. There is a noticeable improvement in the way the native communicates with the world. There are plenty of opportunities at the door. The native proceeds with full confidence and achieve success. The native is able to understand and explain complex subjects. You will meet new people and make friendly relations with them. They will enjoy your company. VIP’s will appreciate your work and would like to connect with you. There will be a rise in fame and recognition. Long distance travels are fruitful and yield handsome gains. There will be support from family members. The native’s health improves during this period. Overall, a very auspicious period."; }
                case 4: { return "The transit of Jupiter in the fourth house brings good luck in native’s life. Life gets filled with joy and happiness. There are gains from business and property. There is a sense of accomplishment and satisfaction. The native enjoys all the worldly comforts. All the pending works are completed during this period. The native enjoys cordial relations with his family members. The family will provide financial support. Some kind of legacy or inheritance may arrive during this transit. This transit of Jupiter brings fortunate changes and the native enjoys the entire phase to the fullest. In-laws are also supportive and provide helping hands at all times. Health improves considerably. There is an increase in the respect and fame of the individual. Overall, a good and lucky period for the native."; }
                case 5: { return "Fifth house depicts knowledge and progeny. The transit of Jupiter in the fifth house is fortunate for the native. There will be an increase in the knowledge and creativity of the native. New projects will yield appreciations and rewards. You get support from government authorities or persons in government jobs. You also get support from your children. There are chances of birth of a child. The native gets attracted towards opposite sex. There will be an increase in the financial status.You will get promotion in job or gains in business. You will find pleasure in implementing creative projects. Overall, this transit of Jupiter hasa positive impact on the native."; }
                case 6: { return "The transit of Jupiter in the sixth house highlights employment and work-related areas. The native gets promotion due to his hard work. Employees will remain cordial towards you. You will enjoy your working environment. Employers will get full cooperation from their employees. Financial status will improve. There are chances of increase in the expenditure of the native. Mental exertion increases during this period. Your health may deteriorate and becomes prone to many diseases. By the end of the transit, you will learn to handle your job efficiently and effectively. The native should curb overspending to avoid financial crisis. You will have a winning edge over your enemies and they will not be able to harm you. There may be an addition of a pet to your family. Overall, this transit gives mixed results."; }
                case 7: { return "The transit of Jupiter in the seventh house provides marital bliss to the native. The native enters into new partnerships. They are benefited through his spouse. His partner will be a source of happiness and the native will enjoy sharing and spending quality time with her. Peace and harmony prevail in married life. The native will shine in public and gain popularity due to his work. This transit marks the end of difficult partnerships and beginning of fruitful associations. There will be new sources of income. Economic conditions improve considerably and provide financial stability. Jobless are able to find jobs. Singles will be able to find the life partner of their choice. Success in the profession is assured during this transit. Expenditure increases during this period. Overall, a good period for the native."; }
                case 8: { return "Here Jupiter gives mixed results. You will be gained through partnerships. There will be an increase in the income of the spouse. You will be able to manage your resources very well. Financial status will improve but remain moderate. Enemies will not be able to harm you. The possibility of buying a new home or car prevails during this period. You will be rewarded for your work. Success is assured in your profession. You will get support from government authorities. At times, the native feels frustrated and lose peace of mind."; }
                case 9: { return "During Jupiter’s transit in the ninth house, the native enjoys good reputation in the society. There is marked increase in the wealth. All the pending tasks will be completed during this period. You will be inclined towards religion. New projects undertaken during this period will be fruitful and yield good results. You will get promotion in job or gains through business. You will learn while travelling. You will have opportunities to meet foreign people and exchange ideas with them. In-laws will be supportive during this period. Stress level decreases as Jupiter transits through this house. Litigations will settle in your favour. Overall, a lucky period for the native."; }
                case 10: { return "Jupiter gives good results in the tenth house. There will be peace and harmony in the family. The native is blessed with happy married life. The rise in perks and incentives are indicated during this period. There are chances of promotion in job. If in business, there will be gains from unexpected sources. Jupiter’s influence gives monetary gains to the native. Your productivity will be at an all-time high. VIP’s will look at you for your support. You will come into limelight and shine like a star at professional front. All your career ambitions will be fulfilled during this period. Overall, a very fortunate period for the native and should be utilized to the fullest."; }
                case 11: { return "Jupiter’s transit in the eleventh house signifies networking. The native indulges in connecting with new people. You will be benefited from your contacts and friends. During this period, all your wishes are fulfilled. Others will enjoy your company and look towards you for support and help. Financial status will improve. There will be a rise in the standard of living of the native. There are gains through business. You will enjoy sharing your ideas with others. You will be respected by Society. You will be able to accomplish your goals very easily and without any problems. A feeling of mental satisfaction will reign. Overall, a progressive period for the native."; }
                case 12: { return "Twelfth house indicates expenditure. This transit of Jupiter increases expenses considerably. As a result, the effluence of money is more during this period. There are chances that the native may visit foreign land. As a result, you will stay away from your native place and family. The business may suffer some obstacles. You will help others without expecting anything in return. You will be inclined towards spirituality and actively participate in religious activities. Peace of mind remains disturbed during this period. You will achieve success with hard work. At times, you may fall sick and suffer from chronic diseases. Overall, Jupiter gives mixed results in this house."; }
            }
            return "";
        }

        private string GetMarsInHouses(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1: return "You are able to stand your ground and assert yourself more than usual during this transit. You have energy at your disposal to move your plans forward, and you are more enterprising. You want to leave your mark on the world in some way–however big or small–and you are more able to make an impression than usual. If circumstances are such, you are able to easily fight back. In fact, you may be somewhat combative under this influence, and you may have a short temper. Avoid being pushy. Take charge of your life, but don’t bulldoze over others in the process! This is an excellent transit for assertiveness and physical vitality. Love affairs may also be stepped up during this period. On the rare occasion when an accident occurs, it is more likely to involve the head or face.	";
                case 2: return "You have more energy at your disposal to make money, but also to defend your values. This can be a very resourceful time, when you make the most of what you have. You have much energy for new money-making projects, or for stepping up existing ones. You may be over-identifying with what you have and own, and you could be trying to prove yourself (your worth) to others using money and possessions as the means to do so. If conflicts occur during this transit, they are likely to be over issues of ownership. This is a time when impulse buying is at a peak. You probably should avoid using credit right now, simply because your spending habits may be excessive and impulsive.	";
                case 3: return "You are likely to have many ideas and plans going during this transit, and you might be inclined to scatter your energies as a result. Channeled well, this is a good time to sell your ideas to others, or to present your case. You may be especially busy running errands and communicating with others. More articulate than usual, you may also have a more assertive, self-centered, or provocative communication style at this time. As such, discussions may become heated, or they may escalate into arguments, more easily. If this is the case, it’s likely because you are taking things very personally right now, or because you are over-identifying with your beliefs and ideas. A tendency to be impatient or impulsive while driving or while performing manual tasks, generally with the hands, may lead to accidents, so it’s wise to be careful on the road or while operating machinery or even using scissors! This is an excellent time to work on intellectual tasks with more vigor and passion.	";
                case 4: return "You have more energy at your disposal for domestic projects or activities. Because your actions are governed by your instincts during this period, you may be especially defensive and protective. You may work hard at making yourself feel more secure, and you may be called upon to take charge on the home and family front. You may have more energy to invest in homemaking, house repairs, re-decorating, or family activities. In fact, if you are feeling very restless, moody, or defensive during this period, it would be a good idea to do any of these things! You may have an increased desire to rule the roost, and if this transit stimulates conflict or disputes, it is likely to be family-related–you may have arguments with them, about them, or on their behalf. You may also encounter opposition from career-related matters or people. You may get worked up about old angers or regarding emotional issues from the past that are resurfacing now.	";
                case 5: return "This is a very self-expressive time when you have lots of energy, but not necessarily self-discipline to match. You have more energy at your disposal to express yourself creatively, through activities with children, romantic activities, hobbies, or sports. Your love life may step up a notch, and this could be an especially passionate time. You tend to put more energy into play and pleasure! Be careful not to burn the candle at both ends. Also, watch out for a tendency to want to gamble. You are more playful than usual, and especially magnetic.	";
                case 6: return "You have more energy for work and your daily routines tend to speed up during this transit. Perhaps you have a larger workload than usual. It’s a great time to take charge of your health. You have much energy at your disposal to pick up (or step up) a health and physical activity program. It might be hard for you to work with others in a harmonious manner during this transit, and disputes with co-workers are possible. If you are feeling especially angry, frustrated, or restless, it would be wise to find little projects and things to do so that you can channel excess energy constructively. If health is affected, fevers or infections are more likely.	";
                case 7: return "Partnerships may suffer from ego conflicts, or adversaries may be challenging. Use this energy to work cooperatively on relationship problems. You may even find that you seem to need someone’s help in order to do what you want to do during this cycle. Relationships are vivacious and dynamic during this period. When a difference arises, you are quick to settle it, and have little patience for sweeping matters under the rug. Your close personal relationships are lively during this cycle–full of conflicts and resolutions or reconciliations.	";
                case 8: return "Sexuality and intimacy are stimulated under this transit. Negative expression of this energy is the tendency towards ego conflicts concerning jointly held property or money. Conflicts with partners over values or possessions are possible. Occasionally, this transit could bring a crisis or ending of some kind. Something you hear about now might disturb or touch you deeply. You are likely to be more strategic in your actions during this period, as you become aware of the subtleties of human interaction. This is a time when your best course of action is to recognize that you need, or rely on, others for support.	";
                case 9: return "During this period, you are especially enthusiastic and more bold than usual. Some restlessness and hunger for adventure is experienced now. Essentially, you are looking to expand your activities, and you may find that you have a lot of energy for higher studies, travel, or simply new subjects. Negative potentials include being excessively opinionated or getting easily fired up over differences in points of view, or legal fights.	";
                case 10: return "This transit stimulates your ambition and/or your desire to be recognized for your accomplishments. Whether it’s professional or personal, you are likely to have an increased desire for others to notice you. This can be a good time to become self-employed or start a business if other factors (and Mars itself) are favorable. Conflicts with those in authority are possible now. You may pour more energy into self-promotion or business/career activities.	";
                case 11: return "Group activities and cooperative efforts are the best way to achieve your goals right now. In fact, you have all sorts of ideas about what you want to do. Avoid allowing the ego to attempt to dominate others. You prefer to lead a group rather than follow during this period, and there are certainly ways to do so without stepping on others’ toes. As well, the best way to achieve your goals during this period is to work as a team, or to at least to do some networking. You may have more energy than usual to want to organize projects. Your humanitarian impulse may be stimulated. The role you play for other people in your life becomes the focus. You may feel that your schedule gets overloaded at this time with things to do (usually for others).	";
                case 12: return "This is the time to research and reflect upon your goals. It can be a time when past actions catch up with you–and this is not necessarily a bad thing! It could also be a time when much of your energy is channeled into private matters, or when you prefer that others not observe what you are doing. This is natural–you may just as well do your best work alone for now. Unconscious behavior patterns could influence the way you assert yourself. Some may experience insomnia during this phase, especially if they are not allowing themselves the chance to recoup and if they are not letting their intuition serve them. Others may enjoy a more active dreaming life (this includes day-dreaming), and, if allowed to run free, the imagination can serve them very well, especially with regards to goals and new concepts.	";

            }
            return "";
        }

        private string GetVenusInHouses(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1: return "You could find it hard to deny yourself anything during this cycle! This is a time when you naturally let loose your softer, receptive side. Romantic matters, as well as pleasure-seeking activities, come to the fore now. You are more likely to pay closer attention to your physical appearance and mannerisms, aiming to improve and enhance your attractiveness. Others find you agreeable and cooperative.	";
                case 2: return "As the natural ruler of this sector of the chart, Venus feels right “at home” here. This is a rather content position for Venus, although there can be some restlessness when it comes to money and spending it–you are more inclined to want more things around you! Financial security and enjoyment of the good things in life are important to you, although you also value simple pleasures. The ability to relate well with others might enhance your own personal finances during this period. You may find yourself in a position in which there is a blending of financial matters with social or public affairs. This is a stable position for love matters and close relationships. You value those who make you feel comfortable, and familiarity is more important to you than someone new during this cycle.";
                case 3: return "You are mostly cheerful in your approach to others, and perhaps somewhat intellectual, during this transit. Essentially, you are quite companionable now. You enjoy talking about what interests you, and you find great value in the exchange of ideas. Sometimes this transit brings benefit through siblings, communications, or short trips. During this period, you are most attracted to wit, cheerfulness, and verbal rapport. You are especially good at mediating conflicts. Smoothing over differences using your diplomacy skills figures now.";
                case 4: return "During this cycle, you are especially fond of the life of the home and family. You are more receptive and gentle on a romantic level, and tend to be sentimental or nostalgic now. You may particularly value the aesthetics in and around your home during this period. If things are out of whack on the home front, you will do whatever you can to create a peaceful and stable atmosphere. Loyalty and sensitivity in your relationships are more important to you than typically. You might focus on ways to earn money in or from your home. This is a calming influence–a time when simple pleasures most appeal.";
                case 5: return "This is an expressive period for the goddess of love! It’s natural for you to turn on the charm without even lifting a finger. You are especially attracted to aesthetic forms of recreation. You feel a little more playful now, and love matters tend to be laced with a touch of drama. That shouldn’t be a problem–in fact, you kind of like it that way for the time being. More loving and appreciative relationships with your children may also figure now. Your powers of attraction skyrocket during this cycle. Yet, you are not aggressive in your approach to love. Instead, you attract more if you allow yourself to be pursued during this cycle. Creative self-expression of any kind is favored at this time. At this time, you instinctively know how to place yourself in the best light in order to make a good impression on others. Any love affair begun now will be characterized by good cheer, having fun, and a fair share of emotional drama!";
                case 6: return "Establishing a happy and harmonious work environment through friendly relations with co-workers or tidying up your work area comes into focus no. Romantic and social activities may revolve around your working environment. You are generally well liked and respected socially on the job right now. Some laziness is possible now, as you tend to associate pleasure with work! Perhaps you are socializing more than usual on the job. You have good team spirit during this cycle, and you are more tactful and obliging with your co-workers. You are less inclined to fall in love for the sake of love itself during this cycle. Your tendency is to consider whether it is clever to do so! You’re most successful doing tasks that involve cooperation and team harmony. You could find that your talents or skills are especially appreciated. Romantic and social activities may revolve around your working environment.";
                case 7: return "Special attention to and from a partner is in focus, and flattery will get you everywhere if you use it wisely. One-to-one relating appeals to you more than group activities or more casual connections. Smoothing out your close personal relationships is what makes you happy during this cycle. If single, you are more willing than normal to enter into a committed relationship. In general, you are adaptable when it comes to your affections–very willing to compromise, negotiate, and make peace.";
                case 8: return "During this cycle, a financial boost is possible, or you may gain financially through your partner. A deep and intimate connection made now could be revitalizing and even healing. You are more inclined to want to smooth over differences in a partnership concerning the sharing of power, intimacy matters, finances, and other emotionally-charged topics. Intimate relationships are intensified now. Either you or your partner want a deeper union.";
                case 9: return "A taste for the exotic takes hold during this cycle. Routine affairs simply don’t seem to satisfy. You receive pleasure from anything that expands your horizons, both physically and mentally. Foreign people and places may particularly appeal now. You tend to be expansive and generous when it comes to love. A love interest who attracts you during this cycle may be somebody who you previously wouldn’t consider attractive, or someone whose cultural background is very different than yours. You have a taste for the exotic and the spirit to match. Public relations work, promotion, and other such endeavors are favored now. It is more about how you express yourself than the specifics of what you are saying that helps sway others to your position. There could be especial rapport with foreigners and with women if you are traveling during this period. You are all the more attractive and charming with this position, which increases your popularity. If a romance were to begin now, it is more likely to be with someone of a different background or educational level, or someone you meet through travel. You have a taste for the exotic now that can show up in many areas of your life–who you are attracted to, what you buy, the kind of art or entertainment you enjoy, and so forth.	";
                case 10: return "During this cycle, you are most charming and well-received on the job. Your responsibility and authority are likeable qualities now, making this a favorable period overall for schmoozing with those in a higher position than you, as well as for negotiations or social activities related to business. Venus is charming, friendly, and affectionate, and her presence in your career and reputation sector brings social opportunities to your career. You are coming across well at work now, and romantic opportunities, or simply more chances to socialize and network, are likely. You are socially ambitious right now, and success may come though your good managerial qualities or some form of artistic talent, or, indirectly through your marriage partner. People who turn your head during this cycle are those who come across as especially competent.";
                case 11: return "Forming harmonious, warm social friendships, possibly related to group activities within a club, can figure now. You may meet someone through such group activities; consequently, your interests will be shared. Whether or not you do, the bottom line is that sharing interests with someone is what makes you happy during this cycle. Venus here enlivens your friendships and group associations with charm and grace. You are more peace-loving than usual and slightly detached on a personal level. If a romance were to begin during this time frame, it would be characterized by a strong feeling of camaraderie, but it could also be rather impersonal and perhaps lacking in depth and intimacy.	";
                case 12: return "Venus is spending some time in “hibernation” in your privacy sector. Now, this doesn’t necessarily mean that your love life is stagnant, but that your affection is expressed behind closed doors. Attraction to secrets and whispers characterize this period, although for some, it can also be a time of endings, relationship concerns, and wistfulness. Personal and social contacts may be secretive, and there can be secret love affairs, or at least very private love feelings and longings. Shyness can lead to some loneliness or romantic frustration.	";
            }
            return "";
        }

        private string GetRahuInHouses(int houseNumber)
        {
            int moonHouse = this.BirthPlanets.FirstOrDefault(x => x.Current == EnumPlanet.Moon).HouseNumber;
            int countFromMoon = AstroUtility.HouseGab(moonHouse, houseNumber);
            switch (countFromMoon)
            {
                case 1: { return "When Rahu moves into the first house from natal Moon in a birth chart, it brings a lot of challenges for the native. It boosts one’s tendency to squander money. Possibility of financial loss also exists during this period. Some health issues may keep you disturbed mentally. Also, lack of peace of mind persists in life until Rahu is in this position. A sense of restlessness remains. Native should refrain from any shady activities too."; }
                case 2: { return "If Rahu transits to the second house from natal Moon, financial issues increase in your life. Some disputes in married life also take place. Expenditure also shoots up during this time. Something or the other keeps you disturbed. You should keep your dietary habits in check during this period to maintain good health. Eyes also become vulnerable during this time. It would also be better to avoid any arguments during this period."; }
                case 3: { return "When Rahu transits to the third house from natal Moon, it brings positive vibes back into life. You begin to enjoy your work life and work harder. Chances of promotion also exist. Native gets a lot of financial gains and prosperity during this time. Any prolonged litigation matters also get resolved in your favor. Your relationship with siblings also improves during this time. Your will power becomes stronger. You get fame and name in society with your own efforts. For salaried individuals, this period brings good chances of increment too."; }
                case 4: { return "Rahu’s transit into 4th house from where natal Moon is positioned is an alarming time. You should be extra cautious in matters involving land or property. This period may be full of troubles, which can affect your mental peace too. Your mother’s health could fall during this time. You should also be careful while driving as some trouble or accident from vehicle is possible during this period. A relocation could occur for some."; }
                case 5: { return "If Rahu transits to the fifth house from natal Moon, it brings a lot of mental stress and grief to the native. Something or the other related to children keeps you disturbed. This is a very promising period for growth in income and business though. But at the same time, some issues prevail in love life of the native. Due to increasing confusion, you may remain mentally distressed during this time."; }
                case 6: { return "When Rahu transits to the sixth house from natal Moon, it increases your sources of wealth accumulation. You may also get profit in business matters. Property deals turn out well for the native. You get a lot of respect and recognition in your social circle. Any pending court cases wind up in your favor too. You may also benefit from your maternal uncle in some way or the other."; }
                case 7: { return "If Rahu is moving into your 7th house from natal Moon, expect a lot of financial turbulence. There could be some loss of wealth too. You should be very cautious in matters involving money. Married life also remains disturbed during this time due to recurrent disputes. Moreover, health of spouse may also become a matter of concern. Your relationship with coworkers also suffers a setback while Rahu is in this position. You own health may also dip a bit during this time. You might bump into someone of other religion or caste and make a strong association."; }
                case 8: { return "Rahu’s transit in 8th house from natal Moon is not that positive. It can create some hurdles for the native such as physical ailments. You should be very careful and alert in health matters. A sexual disease is also possible so exercise caution. A lot of mental distress would be there along with unnecessary fears. You might have to face humiliation so better not indulge in any shady activities. Someone at work may try to drag you down so be watchful of any conspiracies against you. On a positive note, you could land some unexpected gain or hidden treasure during this transit."; }
                case 9: { return "Rahu’s move into the 9th house from natal Moon is also positive for a native. You might go abroad during this period. This is also a promising time concerning higher education. You might feel yourself driven towards spirituality. However, this transit may not augur well for your parents. Loss of money is also possible and you might get involved in shady activities. It would be best to avoid any arguments with coworkers to maintain better work relationships. Refrain from unnecessary discussions too."; }
                case 10: { return "Having Rahu in your 10th house from natal Moon means you are likely to experience growth in career. Your status and professional image improves during this period. You may also get some financial gains. Your relationship with seniors and coworkers also remains cordial and mutually beneficial. However, you may feel mentally distressed due to some reason. Sleeplessness is also another upsetting result of this transit. Your mother’s health may also suffer during this time so take care."; }
                case 11: { return "When Rahu moves into the 11th house from natal Moon, it brings a better phase in your life. You could land some monetary gains too. Your social standing and image at work improves considerably. This is a favorable period for income growth. You might get a chance to go abroad as well. Your domestic life also become peaceful. Your children might get married during this time. Your interest in religion also increases. Overall, you enjoy a good status during this transit."; }
                case 12: { return "The period after Rahu moves into 12th house from natal Moon is very positive for going abroad. However, this transit may not augur well for money matters. Native may suffer from losses in business and hurdles in career. Over-confidence can lead to significant wrong moves in life. Despite the challenges, you should try to avoid any mental stress. Health of spouse could also downhill during this time."; }
            }
            return "";
        }

        private string GetKethuInHouses(int houseNumber)
        {
            int moonHouse = this.BirthPlanets.FirstOrDefault(x => x.Current == EnumPlanet.Moon).HouseNumber;
            int countFromMoon = AstroUtility.HouseGab(moonHouse, houseNumber);
            switch (countFromMoon)
            {
                case 1: { return "When Ketu transits to the first house from natal Moon, native begins to experience some mental tensions and health goes downhill to some extent. This is a period when your expenditure increases and savings decrease. You should avoid taking a loan during this period. This transit specifically affects your mind. Some confusion persists in life along with misunderstandings in married life. Your social reputation also suffers during this period."; }
                case 2: { return "If ketu transits into the 2nd house from natal Moon, it affects one’s financial prospects. Financial state remains vulnerable due to possibility of loss. Expenses are also likely to shoot up during this time. You should be very careful from theft and keep your house and belongings secure. Some mental ailments could possibly strike due to the placement of Ketu. It would be better to not ignore any eye related issues. During this time, you might develop a tendency to indulge in useless conversations. You should avoid becoming harsh as it could engender conflicts with spouse."; }
                case 3: { return "When Ketu moves into the 3rd house from where natal Moon is positioned, a relatively easy period begins. Native might enjoy some financial gains as well. Chances of progress on the work front increase. Native might get a lot of acclaim and fame in society. Frequent travels take place as well. This is a good period to perform well in education and land your dream job too."; }
                case 4: { return "Ketu transit to 4th house from natal Moon is not considered positive in Vedic Astrology. You should be careful while driving. Health of mother also becomes vulnerable during this period. Some financial fluctuations persist, causing unnecessary mental stress during this time. It isn’t the best period to travel either. You should also try to avoid any property related disputes."; }
                case 5: { return "If Ketu moves into 5th house from natal Moon, it increases one’s expenditure. Native also experiences a lot of issues with children during this period. Some mental stress remains throughout. It is not an opportune time to make new investments and you should exercise utmost caution in money matters too. Overall, this period brings lots of ups and downs in life."; }
                case 6: { return "When Ketu transits to 6th house from natal Moon, your work life begins to improve. This is a good period to get success in competitions. Career progresses and you get victory over opponents. Financial position also improves during this period. It is also an opportune time for business growth. You might begin to take interest in spiritual pursuits. However, health needs attention during this transit."; }
                case 7: { return "When Ketu moves into 7th house from natal Moon, the native tends to develop many health issues. Native also feels distressed and pressured mentally. A lot of misunderstandings and confusion prevails in your married life too. You should work towards curtailing expenses to keep finances balanced."; }
                case 8: { return "Ketu transit in 8th house from natal Moon doesn’t augur that well for a native. You should be extra careful in terms of health. Chances of frequent fever and body aches could be there. Lack of peace of mind and mental distress also persists until Ketu moves ahead. This transit can also lead to defame in society. You feel more inclined towards spirituality, which is good to mitigate the negativity during this transit. Some wealth loss is also possible during this period."; }
                case 9: { return "When Ketu moves into 9th house from natal Moon, native might travel abroad or go for a religious trip. This position of Ketu is not favorable for one’s finances. Some mental and physical distress also persists during this time. You should try to avoid any arguments with your children and siblings to maintain peaceful and cordial relationship."; }
                case 10: { return "Ketu’s transit into 10th house from natal Moon could affect one’s wealth related possibilities. You may also encounter some mental distress due to recurrent issues in life. Business progress could also come to a halt if you don’t put in serious efforts. Nonetheless, those in fieldwork might experience some growth during this time. This is a satisfactory period for salaried individuals too. You should however be alert and cautious in your social life."; }
                case 11: { return "When Ketu transits to 11th house from natal Moon, it brings profits and gains in business. Any land and property deals also prove lucrative during this period. You can also start your own business. Income remains satisfactory throughout the transit. Your children are likely to get married during this period. Overall, this is a positive transit. You also feel more interested in meditation."; }
                case 12: { return "Ketu in 12th house from natal Moon is not a positive placement for married life. You might encounter some issues with spouse during this time. Expenditure also increases. However, this transit proves good for spiritual development. There is however a possibility of humiliation and defame too. You might get to travel abroad during this period but you should not spend excessively or take a loan while the transit lasts.\r\n\r\n"; }
            }
            return "";
        }

        private string GetUranusInHouses(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1: { return ""; }
                case 2: { return ""; }
                case 3: { return ""; }
                case 4: { return ""; }
                case 5: { return ""; }
                case 6: { return ""; }
                case 7: { return ""; }
                case 8: { return ""; }
                case 9: { return ""; }
                case 10: { return ""; }
                case 11: { return ""; }
                case 12: { return ""; }
            }
            return "";
        }

        private string GetNeptuneInHouses(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1: { return ""; }
                case 2: { return ""; }
                case 3: { return ""; }
                case 4: { return ""; }
                case 5: { return ""; }
                case 6: { return ""; }
                case 7: { return ""; }
                case 8: { return ""; }
                case 9: { return ""; }
                case 10: { return ""; }
                case 11: { return ""; }
                case 12: { return ""; }
            }
            return "";
        }

        private string GetPlutoInHouses(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1: { return ""; }
                case 2: { return ""; }
                case 3: { return ""; }
                case 4: { return ""; }
                case 5: { return ""; }
                case 6: { return ""; }
                case 7: { return ""; }
                case 8: { return ""; }
                case 9: { return ""; }
                case 10: { return ""; }
                case 11: { return ""; }
                case 12: { return ""; }
            }
            return "";
        }

        private string GetSaturnInHouses(int houseNumber)
        {
            switch (houseNumber)
            {
                case 1: { return "First house represents the personality of an individual. The transit of Saturn in the first house of the chart highlights all the areas associated with the individual identity. This is the best time to start various health-related regimens to improve your health. At the initial stages of the transit, you will lose your self-confidence. You may land in troubles due to the ill effects of the Saturn in this house. You will look at others for support to regain strength and confidence in life. The results of the ventures undertaken during this period will get delayed causing frustration to the native. The native may land up in mental depression. The native should maintain patience during this period. By the end of the transit, with your sheer dedication and hard work, you will be a changed person with improved confidence and self-respect. The ventures undertaken during the early stages of the transit may become the source of your income and will start yielding handsome gains."; }
                case 2: { return "Second house represents family and the relations of the native with family members. The transit of Saturn in the second house of the chart highlights all the areas associated with the individual’s finances and relatives. This is the time where you utilize your abilities and capabilities attained during the transit of Saturn in the first house to achieve success and financial stability in this period. Though the gains are minimal they are steady and the chances of losses are less during this transit. The individual leaves no stone unturned to make financial progress. As a result, the native is least interested in worldly comforts and possessions. Second house also indicates separation. The native may end up in separation with the family members especially with mother. By the end of the transit, the native regains hope and confidence to move ahead in the financial field effectively and positively."; }
                case 3: { return "The transit of Saturn in the third house gives positive results to all the aspects of the individuals associated with this house if the Saturn is powerful in the Lagna chart. Individual gains through his mental ability. The native is interested in networking which yields results and discards the unnecessary networking as he finds it a sheer wastage of time. Relations with father and Son get strained. You may become more effective in your communication and the way with which you communicate with the world. If the Saturn is debilitated in the Lagna chart, the native suffers from delays in the education and foreign trips."; }
                case 4: { return "The transit of Saturn in the fourth house gives bad results and is referred to as Kantaka Shani. Fourth house represents home and family. Due to arrow-like effects of Saturn in this house, the native is unable to maintain good relations with the family members and decide to break ties with a view that the relationship can’t be reclaimed. The native is flooded with obstacles and problems in every area of life which make the native very serious and least interested in entertainment. Even with the utmost efforts, the native remains devoid from all the worldly comforts and become troublesome. If the Saturn is powerful in the Lagna chart, then the native has good mental capabilities and solve all the problems strongly and boldly. But if the Saturn is debilitated, then the native has poor mental capabilities and unable to come out of the problems. Due to this, the native may land up in mental depression and lose self-confidence. The native suffers from many diseases. Since fourth house indicates native`s mother, the health of mother is also adversely affected during this period. By the end of this transit, the native masters over his inner strengths and look forward towards life with hope and optimism."; }
                case 5: { return "The transit of Saturn in the fifth house give bad results and is inauspicious for the individual. Fifth house indicates higher education and love matters. The native suffers from hurdles and delays in the proceedings of higher education. Progeny or the birth of a child is delayed or badly affected. The native lacks creativity and unable to create new ideas. The native feels sterile and limp over issues to complete them. The native feels neglected from others and fails to receive the due attention from them. If Saturn is favorably placed in the fifth house, then the effects are positive. There is usually delay in marriage and in matters of love affairs. It may give gains through speculation and gambling. If Saturn is debilitated, then the native suffers from diseases related to stomach and pancreas. By the end of this period, the native learns to love himself."; }
                case 6: { return "Sixth house indicates Work, Debt, Disease and Disputes. The transit of Saturn in sixth house highlights all these areas. The native is forced to change his diet plans and habits to overcome health problems. There is a marked increase in the responsibilities and the native feels pressurized and more accountable for the jobs. If the Saturn is exalted, the native succeeds his enemies and overcome any obstacles caused by them. The native travels to foreign land due to his hard work and dedication towards work. During this period, the native also gets support from younger siblings. If the Saturn is debilitated, then the individual suffers from health problems related to bones and unable to recover from them. By the end of the transit, Saturn teaches you work and time management so that you may be more productive and healthier for overall success in life."; }
                case 7: { return "Seventh house indicates marriage and partnerships. The transit of Saturn in the seventh house generally delays marriage. The native becomes more inclined towards his parents and respects them whole heartedly. During this period, the native becomes religious and often offers prayers. The relationship with the spouse gets strained and it becomes difficult to maintain peace and harmony at home. New relationships or partnerships are blocked or delayed. If the Saturn is debilitated in the Lagna chart, then the native suffers from diseases related to reproductive organs. By the end of this period, Saturn teaches you to be more responsible towards your partner and strengthens the relations to make it long lasting."; }
                case 8: { return "The transit of Saturn in eighth house gives bad results and is referred to as Ashtama Shani. Eighth house depicts death, legacy and inheritance. The tenth aspect of Saturn on fifth house delays progeny. The native is engulfed with problems in every area of life. The native finds difficulty in overcoming the problems which lead to disappointments. This house is also associated with Research and during this period, the native is inclined towards occult sciences. If the Saturn is well placed in the Lagna chart, then the native is fortunate and inherit a legacy from his forefathers. If the Saturn is debilitated, then the native is unfortunate and unable to inherit any legacy from his forefathers. The native suffers from a prolonged illness which may ultimately lead to death."; }
                case 9: { return "Ninth house indicates fortune and relation with the father. The transit of Saturn in the ninth house gives bad results and considered inauspicious for the native. The native is involved in sinful activities which lead to imprisonment and separation from family especially Father. The native suffers from financial crises. In order to improve the economic conditions, the individual should curb the expenses. Ninth house also depicts faith. During this period, there is temporary depletion of faith and the native should perform religious rituals to regain confidence. During this transit, the travels are delayed and fruitless; the native achieves victory over enemies. If the Saturn is debilitated, then the native suffers from diseases related to parts of the lower body. By the end of the transit, native is full of enthusiasm and look towards life with optimism."; }
                case 10: { return "Tenth house indicates occupation, profession and status. The Saturn’s transit highlights these areas and causes delays in professional success. There is a loss of status in the society and the native suffers from a financial crunch. The native suffers from mental agony and pain. There is a marked increase in the expenses as against native’s income. The tenth aspect of Saturn on seventh house creates differences with the spouse. There is lack of peace and harmony at home front. The native is surrounded by troubles and remained dissatisfied with life. Change of profession is indicated by this transit. Due to the financial mess, the native gets indulged in sinful activities which may lead to imprisonment and separation from family. There is lack of entertainment and worldly comforts. The transit of Saturn in tenth house is inauspicious for the native and he should maintain patience during this period."; }
                case 11: { return "The native enjoys life with full enthusiasm. There is a marked increase in the respect of the native. He gets promotion in his job. The relations with family members and spouse are very cordial. The native enjoys all the perks of his hard work. Long distance travels are fruitful and bear good rewards. The native cherishes relations with relatives and is benefitted through them. Peace and harmony prevail at home. The native gets support from his elder brother and sister. There is a windfall of money from various sources of income. The native enjoys all the comforts of life. His aspirations are fulfilled. Birth of a female child is indicated during this period. Overall, a very auspicious period for the native and is blessed in every sphere of life."; }
                case 12: { return "Twelfth house indicates imprisonment and hospitalization. There is a loss of position and status. There is a marked increase in the expenditure as against native’s income. The native will land up in financial crises. The native is flooded with troubles and obstacles in every sphere of life. The native gets disappointments in all his plans. Long distance travels are fruitless. All his dreams are shattered and the native suffers from mental pain and depression. Depending upon the strength of the Saturn in Lagna chart, there are chances of imprisonment or hospitalization. If the Saturn is debilitated, then the native suffers from diseases related to left feet, left eye, left ear, etc. Overall, a very inauspicious period for the native."; }
            }
            return "";
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

        public string GetPlanetQuality()
        {
            switch (this.Current)
            {
                case EnumPlanet.Sun: { return "Sun is the Atma (soul) of all planets and the person as well. It possesses various positive traits such as being a fatherly figure, having immense strength, holds self-respect and authority. It is Sun to show how a person projects himself onto the world. If a strong Sun represents energy and authority, a weak Sun can make a person ego-centric/over-confident. You may need a strong Sun when it comes to your career and profession, but not when you deal with personal relationships. Self Identify, Things that all about you, soul , vitality,  father, eyes  health, east direction and dawn : Karaka of the 1st house ( Lagna), 10th (Career), 9th, and 5th houses.";   }
                case EnumPlanet.Moon: { return "Moon represents the mind, acts as the mother of all, imparts love, peace of mind, positivity, and emotions. A strong Moon helps a person in all stages of life, but a weak Moon can bring troubles like flickering mind or even depression. Mother, compassion, feelings, mind & emotions, milk and ghee , divine medicine, herbs, water,   pearls, the evening: Karaka of the 4th, 1st and 11th houses, and the NW direction."; }
                case EnumPlanet.Mars: { return "Mars denotes courage, passion, bravely, strength and confidence. But in many aspects of life, you don’t need all this equally. A strong Mars can help you in your career and profession but can adversely affect your married life. Mangala – Courage, never give up when working on something, younger siblings, strength or stamina, blood, war, defense, enemies: Karaka of the 3rd, 6th, 4th, 5th houses. The south direction"; }
                case EnumPlanet.Mercury: { return "Mercury represents speech, Intelligence, grasping power, alertness, and logic.\r\nThough Mercury plays a significant role throughout life, it assumes more importance during the early stage of education. speech, learning, memory, intellect, analytical power, friends, business, and literature, mathematics: Karaka of the 2nd, 4th, 5th, 10th and 11th houses and owner of the North direction."; }
                case EnumPlanet.Jupiter: { return "Jupiter represents knowledge. It helps a person more when it reaches the stage of education and career, so may not have that significant in the early age of the person or, say, initial childhood. Give optimism but along your religious belief, Family, wealth matters, expansion, happiness, finances,  children, guru-teachers, religion, fortune, elder brothers: Karakaka of the 2nd , 5th, 9th, and 11th houses. The Nortth East direction"; }
                case EnumPlanet.Venus: { return "Venus represents love, relationship, romance, beauty, sex life, relationships, be it with the spouse/business associates. Many may not know, but a good Venus is an essence for your professional life. So at what stage you need support from Venus is to be decided by you. pouse, partner,  martial relationships, vehicles, sexual pleasures, fluids, perfumes, dance , music, song,  : Karaka of the 7th house, 4th house, 12 house . The SE direction."; }
                case EnumPlanet.Saturn: { return "Saturn is the Karmic planet that practically holds a person’s life throughout with the type of Karmas one does. You step out, become extra ambitious, or commit wrong deeds; Saturn will punish you. Saturn plays the dual role of a teacher and a cop. It depends on what you want Saturn to do to you. Saturn as a planet has such a comprehensive explanation that I cannot summarize it here. Read me separately to know about Saturn's effects on our life. \r\nHaving explained it all, now I will come to another important aspect regarding the role of different planets in horoscope. Hold on to something, Don't let things go that easy, longevity, delay, grief, losses, ailments, limps, humiliations, hard labor, imprisonment, renunciation, lower class. Karaka of the 8th, 6th, 5th and 12th and the  west direction."; }
                case EnumPlanet.Rahu: { return "Rahu brings name and fame, but spoiled Rahu brings humiliation. Rahu is the planet for worldly desires, manipulation apart from many other significations attached to him. The heavy impact of Rahu in the initial age of life can make a person too much involved in mobile phones/internet-related activities and the result we know. Rahu is a shadowy and mysterious plant which, if it acts negative, tends to make a person over-ambitious, over-confident, and I don’t care type of attitude. It makes a person know no limit or cross all limits and the result we know when we hear about Top Babas, Businessmen, Bureaucrats and Politicians in the worst phase of their life. So how you make use of it depends on you. You stay under control, Rahu will play a good role, you brag or over-step, Rahu will devastate. So results of Rahu are in your hands. accidents, occult knowledge, life in a foreign land, poisons, skin diseases, arguments, darkness. Karaka of the 7th, 9th and 6th houses.  It indicates  SW direction."; }
                case EnumPlanet.Kethu: { return "Ketu shows spirituality but detachment also. This is again a shadowy and planet of no physical existence. Ketu is known to be malefic to worldly desires and spiritually benefic. So an adverse effect of Ketu can turn a person away from mundane and worldly desires, including Love and romance, at the age when you need them most. occult knowledge, moksha, detachment, isolation,  imprisonment. Karka of the 12th, 9th and 8th houses. It indicates NW direction."; }
                case EnumPlanet.Uranus: { return "Uranus symbolises technology, rebellion and innovation. This revolutionary planet hates the rules and is always eager to facilitate groundbreaking and dynamic change. "; }
                case EnumPlanet.Neptune: { return "Neptune is considered as a planet of inspiration, dreams, illusion and confusion. It rules our spiritual world. This planet is connected with rituals, magic, fairy tales, and experiences that are far beyond this materialistic world."; }
                case EnumPlanet.Pluto: { return "Intence diging and researching, this planet help you get beneath the serface. Help you spend more time researching"; }
            }
            return "";
        }

        public void UpdateAdhipathis()
        {
            AdhipathiHouses = new List<int>();
            switch (this.Current)
            {
                case EnumPlanet.Sun: { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Mesha, EnumRasi.Simha };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Mesha));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Simha));
                    } break;
                case EnumPlanet.Moon: { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Vrishabha, EnumRasi.Kataka };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Vrishabha));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Kataka));
                    } break;
                case EnumPlanet.Mars: 
                    { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Mesha, EnumRasi.Vrichika, EnumRasi.Makara };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Mesha));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Vrichika));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Makara));
                    } break;
                case EnumPlanet.Mercury:
                    { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Mithuna, EnumRasi.Kanya };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Mithuna));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Kanya));
                    } break;
                case EnumPlanet.Jupiter: 
                    { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Kataka, EnumRasi.Dhanus, EnumRasi.Meena };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Kataka));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Dhanus));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Meena));
                    } break;
                case EnumPlanet.Venus: 
                    { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Vrishabha, EnumRasi.Thula, EnumRasi.Meena };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Vrishabha)); 
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Thula)); 
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Meena));
                    } break;
                case EnumPlanet.Saturn:
                    { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Thula, EnumRasi.Makara, EnumRasi.Kumbha };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Thula));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Makara));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Kumbha));
                    } break;
                case EnumPlanet.Rahu: 
                    { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Vrishabha, EnumRasi.Kanya };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Vrishabha));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Kanya));
                    } break;
                case EnumPlanet.Kethu: 
                    { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Vrichika, EnumRasi.Meena };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Vrichika));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Meena));
                    } break;
                case EnumPlanet.Uranus: 
                    { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Vrichika, EnumRasi.Kumbha };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Vrichika));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Kumbha));
                    } break;
                case EnumPlanet.Neptune: 
                    { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Kataka, EnumRasi.Meena };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Kataka));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Meena));
                    } break;
                case EnumPlanet.Pluto: 
                    { 
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Simha, EnumRasi.Mesha };
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Simha));
                        AdhipathiHouses.Add(this.LagnaRasi.absoluteHouseFromRasi(EnumRasi.Mesha));
                    } break;
            }
            AdhipathiHouses = AdhipathiHouses.OrderBy(x => x).ToList();
        }

        public void GenericUpdateAdhipathis()
        {
            AdhipathiHouses = new List<int>();
            switch (this.Current)
            {
                case EnumPlanet.Sun:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Mesha, EnumRasi.Simha };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Mesha));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Simha));
                    }
                    break;
                case EnumPlanet.Moon:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Vrishabha, EnumRasi.Kataka };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Vrishabha));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Kataka));
                    }
                    break;
                case EnumPlanet.Mars:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Mesha, EnumRasi.Vrichika, EnumRasi.Makara };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Mesha));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Vrichika));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Makara));
                    }
                    break;
                case EnumPlanet.Mercury:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Mithuna, EnumRasi.Kanya };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Mithuna));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Kanya));
                    }
                    break;
                case EnumPlanet.Jupiter:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Kataka, EnumRasi.Dhanus, EnumRasi.Meena };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Kataka));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Dhanus));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Meena));
                    }
                    break;
                case EnumPlanet.Venus:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Vrishabha, EnumRasi.Thula, EnumRasi.Meena };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Vrishabha));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Thula));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Meena));
                    }
                    break;
                case EnumPlanet.Saturn:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Thula, EnumRasi.Makara, EnumRasi.Kumbha };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Thula));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Makara));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Kumbha));
                    }
                    break;
                case EnumPlanet.Rahu:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Vrishabha, EnumRasi.Kanya };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Vrishabha));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Kanya));
                    }
                    break;
                case EnumPlanet.Kethu:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Vrichika, EnumRasi.Meena };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Vrichika));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Meena));
                    }
                    break;
                case EnumPlanet.Uranus:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Vrichika, EnumRasi.Kumbha };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Vrichika));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Kumbha));
                    }
                    break;
                case EnumPlanet.Neptune:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Kataka, EnumRasi.Meena };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Kataka));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Meena));
                    }
                    break;
                case EnumPlanet.Pluto:
                    {
                        AdhipathiRasis = new List<EnumRasi>() { EnumRasi.Simha, EnumRasi.Mesha };
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Simha));
                        AdhipathiHouses.Add(this.OriginalNawamsaRasi.absoluteHouseFromRasi(EnumRasi.Mesha));
                    }
                    break;
            }
            AdhipathiHouses = AdhipathiHouses.OrderBy(x => x).ToList();
        }

        /*public string GetPlanetQualityOnRashi()
        {
            switch (this.Current)
            {
                case EnumPlanet.Sun:
                    {
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
                        switch (this.Rasi.Current)
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
            return "";
        }*/

        public string GetPlanetQualityOnHouse()
        {
            if (IsTransitPlanet)
                return this.GetEffectPlanetTransitOverHouse(this.Current, this.HouseNumber);
            else
            {
                switch (this.Current)
                {
                    case EnumPlanet.Sun:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "If the sun is posited in the 1st house of the horoscope, it grants the native with a spark and vibrancy.\r\nThe native is filled with passion and positive energy. This is a good placement and confers decent health if there aren’t any diminishing factors.\r\nThe native may have a charming personality and people would look up to him. The native will be on good terms with the people in power and will be a respectful person, obedient to his father.\r\nThey are reckless with a raging temperament, and a little bit lazy at the same time, quite like a lion.\r\nThis position of sun grants the native with leadership qualities which sometimes may result in an aggression and superiority complex.\r\nHowever, the presence of sun in the ascendant can also make the native self-centred.";
                                case 2: return "When the sun is to be found in the second house in a horoscope, the chart-holder usually has a generous and warm nature.\r\nMoreover, the native earns good money and spend most of it on costly materialistic things.\r\nA pattern frequently observed is that a second house Sun person has a very melodious and heavy voice.\r\nThey make great singers. Individuals having such placement in their horoscope have an intense desire for power and a deep sense of self-worth.\r\nThey are always driven towards acquiring power in the form of possessions, bank balance and talent.\r\nThese people tend to be way too straight-forward.";
                                case 3: return "Placement of Sun in the third house suggests that the native is fond of talking and is mostly a conventional speaker. He’ll have achievements in the field of editing and publishing.\r\nThis positioning, however, makes the connection with younger brother/sister along with other relatives. The younger brother, sisters, neighbours or co-workers may attain high positions in their life.\r\nThe native will be fortunate, great looking, well educated, successful in litigation, smart, brave and in an authoritative position.\r\nThey love travelling and might travel a lot as a part of their business.\r\nThe native devotes a lot of value to wisdom and cognition and believes in sharing it with others.";
                                case 4: return "The fourth house is the house of family, possessions, properties and so on. Placement of Sun in 4th house means that the native takes a lot of interests in matters concerning the domestic side of his or her life.\r\nIt’s about homeland, it’s about mother’s nourishment that you get in the home. They take good care of the family and family’s welfare and social status.\r\nThe native identifies himself by what he loves and feels like Home is where the heart is.\r\nThey are more of introverted personalities and love being inside the home.\r\nSun in the fourth house also gives the native increased energy and strength in the latter half of life.\r\nThese people usually find success later on in their life because Sun is the vitality of your soul, the engine that fuels you and it’s not there when you were born. But Sun rises and when it rises it brightens up your life.";
                                case 5: return "5th house is the natural house of Sun because of the fifth sign i.e., Leo. This house represents creativity, academic education, the creation, joyfulness, speculation business like broking, cinema, being on stage, performing, artistic talent, learning cultural education.\r\nSo when comes into the fifth house it magnifies, it illuminates everything. The native loves talking about politics, creativity, philosophy, ancient texts and would want to be involved in these creative aspects of life, to be able to perform them.\r\nSun here makes a person very bold when it comes to education, they want to be a centre of attention in their academic field.\r\nThis is where their ego lies, in learning and expressing themselves.\r\nThey love to express their knowledge, their creativity, their business ability. Also, they share a great bond with their father.";
                                case 6: return "6th house is the house of conflicts, wars, diseases, enemies. Sun tries to take a centre stage in whatever house that it’s placed in, in your birth chart.\r\nSun, in the 6th house, would like to solve conflicts, win litigation, win over their enemies and basically creatively win over things in life.\r\nAs sun also represents bones and let’s say, if the sun is badly placed or debilitated, you might suffer bone defragmentation or fractures.\r\nIt represents politics as well because war and conflicts are a part of politics and even in everyday work life, you might have enemies or friends who are very competitive.\r\nA lot of litigation attorneys are seen from the 6th house and as it’s also the house of diseases and sun is even though a malefic planet still wants to do good and provide life and solve others problems.\r\nSo physicians, advocates, people in the medical business or in safety divisions are usually seen from this house.";
                                case 7: return "When Sun goes down, things go down in the seventh house. 7th house is the house of legal bindings like marriage, business partnership, sexual relationship, laws.\r\nIt also represents other people, like your public life. This house, the house of Libra which is the sign of justice, balance and harmony debilitates the Sun. That further results as a lack of confidence and self-esteem in the native.\r\nIn case, Sun is exalted in this house, the native is of very authoritative and fearful nature and tries to instil so much authority on the other people because he wants to be heard, he wants to be respected.\r\nPeople with Sun in the seventh house in their birth chart may even end up with more than one marriage.\r\nHowever, an excelled Sun would make a good manager in any creative field, it could be a lawyer or judge and even a good politician because they’ll have that leadership quality and authority to gather people, to make people work around them. ";
                                case 8: return "8th house represents occult knowledge, knowledge of the deep, secretive things, confidential information, major ups and downs, drastic changes.\r\nIt also signifies assets, joint assets from your partner, your in-laws family.\r\nSo, what happens when the sun is in 8th house, It signifies and illuminates the qualities of the 8th house.\r\nSun and Saturn are the only two planets that actually works really well and strong in 6th, 8th and 12th house. In here, Sun feels welcomed here as it’s in the house of his actual friend, Mars (lord of Scorpio).\r\nNative usually doesn’t need to express their ego, they just recognize themselves as better than others.\r\nPeople are naturally drawn to their aura as they have magnificent personality. They are always curious about the darkness, things behind the curtain, mysteries and occult.";
                                case 9: return "Sun is your soul, your ego, self-esteem, the vitality in you, father figure and authoritative. And, 9th house is the house of religion, spirituality, house of your teachers, law and the house of your father.\r\nIt also signifies long journeys like pilgrimage, fortune and luck. So, when Sun comes into the 9th house, Sun’s ego heightens.\r\nThis is where the native’s father and his teachings have a great influence on him. And your ego and self-esteem will solely depend on what your father has taught you, what your teacher has taught you.\r\nSo this person is constrained by what he has learned in his life.\r\nLawyer, judges, Professors, religious priests are seen from this house. They love to make people follow certain rules.\r\nIt is really hard to break this person’s ego and because of which, they might get into ego battles with their fathers.\r\nThese are the people when they travel they want to have an end meaning to their journey, they want to get some wisdom out of it.";
                                case 10: return "The 10th house represents government work, authority, career, executive work, the way you present yourself to the outer world, the way you want others to perceive you as.\r\nIt’s the house of your father. So when Sun comes into this house, it’s the brightest and the hottest in the house.\r\nNative is usually in an authoritative position either in the government or in an executive position.\r\nSun feels much better when there’s nobody to point the finger against them or question them which is the reason why these people can not stand a managerial or supervisory position.\r\nThis is the house of Presidency, Athletes and fighters. Soldiers and CEOs are seen from this house.\r\nAnd no matter how hard situations they had to go through early on in their lives, Sun still has enough power to bring himself up, why? Because Sun! Duh! It rises and bring himself up and overshadows everybody.\r\nThis is one place where no matter how much opposition you face, you will come out of it.";
                                case 11: return "11th house is the most important house when it comes to Wealth. It’s the house of Gains and is a strong indicator of income, sudden profits and prosperity.\r\nThis house includes your professional networks including your friends.\r\nSo, when the sun comes into this house, it’s not very comfortable as it’s the original house of Saturn. They don’t get along very well because they both are kinda opposite energies.\r\nSun in Eleventh House\r\nHowever, This position gives strong inclination towards positions of being a representative and group leader.\r\nNatives with this placement in their horoscope also have strong recognition tendencies.\r\nIf the sun is excelled in this house, that’s when the things with father go chaotic. Native’s relation with his father may get unsteady and bitter but gets better towards the end, especially in case of women with the sun in 11th house.\r\nIt is also said that the sun in the 11th house blesses the native with long life and a lot of wealth.";
                                case 12: return "It’s the house that represents Hospitals, Permanent foreign settlement, Foreign relations, Relations across the sea, Asylum, Jails.\r\nIt corresponds to charity, hidden talents, hidden enemy, hidden treasure, spirituality, connection to the divine. When Sun comes here, it illuminates the12thhouse meaning, the native’s ability to see their hidden enemies, hidden talents.\r\nThis position is, nonetheless very good for imagination, like for an artist to make Art as imagination is a dark place but Sun lights it so much that the art just flows and words just come out.\r\nDirectors, Scriptwriters, Spiritual leader are seen from this house. This house helps the native make political international relations with other countries or business in foreign lands.\r\nSo, if you go to the foreign lands your image, your personality would be far better than what it is in the homeland.";
                            }
                            break;
                        }
                    case EnumPlanet.Moon:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "First house or ascendant is your physical self. it shows your physical personality, your vitality, your health and sets out the map of your entire life. Moon, however, is your emotional connection or emotional response to your surroundings.\r\nSo, when the moon is in the first house, it makes to native a really health-conscious person. Moon gives a beautiful appearance and fair complexion to people, these people have a very youthful appearance throughout their life. The face would be round and a little chubby.\r\nThese people have motherly and feminine qualities like they are very much caretaker of their spouses and people around them. They are nurses type of people. They like to take the emotional burden of people.\r\nDebilitated moon in the ascendant makes the person very very emotional, they take things to the heart just like that. Mother for these people becomes the driving force in their life.\r\nSomebody who leads you, who guides you, has a big influence in your life. You can’t get away with your mother’s influence whether its positive influence or negative.";
                                case 2: return "The second house is related to family, your accumulated wealth, and basically the material possessions with the native. The second house is feelings, emotions and younger siblings.\r\nMoon is like the tides of the sea which represents fluctuations meaning this placement indicates ups and downs in the financial conditions. However, the native will belong to a good and wealthy family.\r\nThe native will be very much attached to his money and possessions. He would like to safeguard his belongings all his life. Such people are also mild, delicate and emotional regarding their family’s well being.\r\nNonetheless, they always love the creative side of life because they express their creativity through what they have learned through their family. Moon in the second house is also related to the vocal talent of the native.\r\nThey make great songwriters and singers. This position, however, could give the native some issues related to the eyes.";
                                case 3: return "It represents sibling, friends, neighbours, close relative. It’s the house of your courage, writing, skills of your hands, communication, media.\r\nWhen the Moon is in the 3rd house, it represents that the native share a deep emotional bond with their siblings and close neighbours.\r\nOne needs an eccentric mind in order to communicate one’s ideas, to articulate the thoughts, to be a writer, which the native is blessed with.\r\nNatives build for media, sales and advertising. why? Because they are curious to learn, to lead, to gather the crowd. They always want to know what’s going around them. These people look for somebody who they can learn from, somebody who can provide them with wisdom, knowledge and philosophy.\r\nThey are the people who love to travel around the world and expand their mind.";
                                case 4: return "4th house represents the mother’s nourishment, mother’s love, family, domestic life, real estate, lands, vehicles, childhood, childhood memories and your homeland. This is actually moon’s original house.\r\nHere moon’s quite emotionally balanced and comfortable. Moon in this house indicates that the native’s very attached to his mother, and their entire life’s principles and beliefs are based on their mother’s teachings.\r\nTheir ties with their native place or the homeland are quite strong. They are always trying to improve the conditions of their home both physically and emotionally.\r\nNative is very calm and subtle in nature and they show their true emotions for example if they are helping somebody, they genuinely help them and forget everything else than helping that person and nourishing that person.";
                                case 5: return "5th house signifies creativity, playfulness, joy, romance and pleasure. Gains, love, lovers, income and investments are also represented by this house. Moon in this house intensifies the emotions and it’s the most favourable position for love matters.\r\nThis placement often produces creative individuals, creative in the different fields like, in art, writing poetry, scripts, acting, painting, entertainment and sports because the emotional balance in the native comes through creativity here.\r\nYour emotional balance happens through creativity when you’re learning something, as in academic learning or educating with the knowledge of something hidden or some sort of art. They also have a special interest in speculations and occult.\r\nYour attachment tends to be very emotional with your children and their kids would be a great source of happiness and satisfaction for them.";
                                case 6: return "The sixth house is simply obstacles, conflicts, illness, long term diseases, debt, legal battles, enemies. It also represents small animals, professions like medicine, military or laws.\r\nThis is one of the most difficult places for the moon. This placement generally causes an unpleasant relationship with your mother, as the mindset of you and your mother doesn’t get along very well.\r\nHowever, it’s an excellent positioning for the advocates because their mind all throughout life is forced to deal with the conflicts and after a while, they get used to of it.\r\nAlthough this is a difficult position for the moon, Moon can provide great service through those hardships that it has learned.\r\nCareers that suit the native the most are Services like healing ( in medicine fields), protective service (through military) or resolving conflicts as Lawyer.";
                                case 7: return "7th house denotes legal partnerships, both in business and in life. It also represents travel, sexual relationships and the other people in one’s life.\r\nThe feminine energy of the Moon makes the native drawn to relationships . They always seek the emotional support and fulfillment in their life from their other half. Your emotional balance happens when you are in a harmonious relationship with your partner.\r\nMoon in this house indicates that you will get a devoted and beautiful spouse (as Moon brings beauty into life), who would be a master in handling domestic and family-related matters.\r\nHowever, in case of afflicted Moon, you may have to face issues regarding your marriage and other legal partnerships. As far as your career is concerned, you want to involve in partnership and prefer to work in teams than alone.";
                                case 8: return "8th house represents longevity, sudden events, dramatic events. The occult, things hidden underneath the ground, deaths, government secrets, taxes, surgeries and accidents, spouse’s assets, in-laws family and things like lotteries etc.\r\nWhen Moon comes into this house, they attract other peoples money through inheritance, it shows somebody who goes through lots of ups and downs in their life because here moon experiences sudden swings through their mind and it really has an impact on them.\r\nThese people love taking others emotional burden upon them which can lead them towards the healing field such as being occultist, nurses, doctors, mystics. These people usually after sudden emotional turmoils, surround themselves with spirituality.\r\nMoon’s placement in the eighth house also suggests sudden and unexpected gains in wealth or income. However, If Moon is debilitated your joint assets can suffer sudden ups and downs.";
                                case 9: return "9th house is the house of your beliefs, rituals, cultural deeds. Its the house of long journeys like a pilgrimage for spiritual reasons. It represents the teachings of your guru and your father.\r\nWhen the moon is in the 9th house, the native develops high spiritual and moral values.\r\nThey are steady learners and no matter how much they discover, there’s always a feeling of being consummated. This placement gifts the native with a highly sensitive and acceptive mind.\r\nHowever, because of the fluctuating nature moon provides, the native might frequently change his mind and philosophies or have plenty of hobbies which they switch oftentimes.";
                                case 10: return "This house deals with the kind of work you do, the profession you are in, your prestige, reputation, position, status, karma and aspiration etc. This placement suggests that the native holds a crucial position in dealing with public, fame and change.\r\nSince Moon is related to mother, your mother was a very career oriented woman, she was quite a professional person and you share a good bond with your mother but you knew that your mother has that authority in the house.\r\nNonetheless, a debilitated moon can bring hardships related to one’s career. Native may find difficulty in getting promotions in his regular job. Moon in this house gives the native with an unspoken kind of understanding and relation with his father. In addition to that, it’s a good placement and can bring fame and good public image in the life of the native.";
                                case 11: return "The 11th house is the house of your network circle, it represents gains of all kind, wealth, this is the strongest house regarding your hopes and wishes as in, how much of it will come true or not. Along with that, it is also the house of your elder siblings.\r\nMoon in this house brings balance in the native’s life when surrounded by people of their network. The Moon feels balanced when the gains are coming in smoothly. Hence this is a very good spot for the moon to be in.\r\nAs it also represents elder siblings, the native gains through elder siblings and have a great attachment with them.\r\nBut, in case of the debilitated moon, the native may have to face emotional hardships from the elder siblings or emotional imbalance due to lack of gains, emotional instability due to social networks.";
                                case 12: return "The 12th house represents all foreign things, foreign travel, foreign settlement, isolated places, jails, hospitals, asylums. It also represents losses.\r\nThis is the house of your imagination. Your subconscious mind, talents or secrets that are hidden from you that you must discover.\r\nNatives may make success in the field of writing as the imagination is in favor. It represents a strong envision of the other dimension.\r\nWhen Moon comes into this house, it shows somebody who’s mind is always into some other realm, some other universe away from where they live. These people are always trying to run away from reality which also represents a very introverted and isolated personality. \r\nVery secluded and private people belong to this house. Natives are likely to choose any career or work-related field that requires them to be away from public life. They feel balanced when they go to some foreign land away from their troubles when they’re in isolation.\r\nAs far as isolation and spirituality are concerned, Moon in this house is always inclined towards the mystical side of life. Natives from this house are driven towards the psychic world.";
                            }
                            break;
                        }
                    case EnumPlanet.Mars:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "First house is your physical appearance, your personality. Its a map of your whole life. Its how every single section of your house will behave depends upon the first house.\r\nSo, when Mars is in the house, it suggests that the native has a highly energetic and dynamic personality. The native is likely to be strong. They yearn for Independence and are quite straightforward in nature.\r\nThis is a great position for Mars to reside in irrespective of the fact that it might make the native aggressive and troublesome.\r\nThe first house also rules over face and head, there’s a possibility of having scars of cuts or burns on the native’s face. So its usually easy to distinguish that person because of those scars.\r\nEven though mars in the first house people are prone to get injured, their curative powers are really sound and they tend to heal quickly.";
                                case 2: return "The second house is related to your speech, wealth, family, family assets, possessions, food that you eat (because it controls your throat), early education. It’s the house of values that you learn from your family.\r\nSo, mars here is a very energetic and dynamic speaker. These people make the most dominative and authoritative speakers out there.\r\nHowever, mars in the second house can give somebody a bad mouth. People can curse a lot.\r\nMars has a mentality of a soldier, they like to have a lot of control over things, over their family and over their possessions. They love to control.\r\nOn the other hand, with these people, money comes and goes. They accumulate wealth through lots of exertion and risks as they earn well through investments and gambling but because mars make the native foolhardy and careless, they are equally impulsive in spending their money.";
                                case 3: return "It’s the house that represents your courage, communication, media, short distance travels, younger siblings. Mars, on the other hand, represents your aggression, your energy and where you put in your energy.\r\nWhen Mars comes into this house, it elevates the native’s desire to travel and also increases the chances of accidents and casualty in one’s life.\r\nThis person wants to always lead and be the one to always in-charge of things. This is why Mars in the third house can produce very rude and selfish leaders.\r\nHowever, third house mars personify professional athletes, soldiers and in case of debilitated Mars gangsters, thugs, looters, and pickpockets.\r\nSince this house rules over communication, these people love to argue and debate and take pride in defeating people verbally.";
                                case 4: return "The fourth house is the original house of the moon and the sign of cancer, of motherly love and nourishment. Mars here kind of loses its direction, it’s self of being.\r\nHowever, mars is friendly with the moon, it still doesn’t feel comfortable here. They both share entirely different energies. So, this placement of Mars in the fourth house is not considered favourable in Vedic astrology.\r\nIt can create ill health towards the mother because it’s the house of mother and make the native too strict and rigorous, at times.\r\nMars needs a medium to release its excess energy in order to achieve a balanced life.\r\nOne of the good effects of mars and that this placement offers to the native, is very active and healthy old age.\r\nThese people are extremely close to their families and are very protective of them.";
                                case 5: return "Fifth house rules over creativity, sex, romance, gambling, arts, entertainment, passions, dating, talents and affairs. Self- employment, education, intelligence, attitude towards gurus and elders is also represented by the fifth house.\r\nStrong and positive mars in the 5th house will make the native very active and energetic and they lead a sturdy and vigorous lifestyle.\r\nPeople with this placement considers romance as a creative and artistic expression. Mars needs freedom and does not accept a life captured in four walls, it needs to go out.\r\nLeading a lively and energetic lifestyle is very important to these people and they are often involved in the outdoor activities which also proves to be beneficial for the native.\r\nDespite all of that, gambling and speculation is something that could cause a lot of problems in life.\r\nIf Mars is retrograde here, the native might also face problems in expressing himself creatively.";
                                case 6: return "The sixth house in Vedic astrology is mostly associated with your job and service, challenges, shortcomings, debts, fears, health, litigation, enemies and losses.\r\nWhen mars is placed in sixth house, it represents that the native is vulnerable to losses by fire and is prone to wounds and burns.\r\nThe native is also likely to meet accidents at workplace because of his own restlessness and recklessness.\r\nAn exalted Mars in this house blesses the native with good results in profession, marriage, authority, status and reputation. On the other hand, a malefic debilitated Mars here can trouble the native in the same matters because the things go vice- versa in that case.\r\nIt can also provide criminal inclination to the native under its influence due to which some native even enter into a life of crime.";
                                case 7: return "Mars is a planet of courage, strength, energy and bravery And seventh house is the house of your partner. So, when Mars comes into this house it brings a lot of energy and aggression in the native.\r\nOne of the adverse effects of Mars even is delays and restrictions in the marriage. It is also considered as an inauspicious placement for marriage perspective as it can bring strong disagreements in beliefs.\r\nThe native and his partner are likely to face differences of opinions and they might get into several arguments quite frequently. These issues may increase with time, consequently ending in even more serious arguments and fights.\r\nMars is a planet of courage, strength, energy and bravery And seventh house is the house of your partner. So, when Mars comes into this house it brings a lot of energy and aggression in the native.\r\nMars even causes delays and restrictions in the marriage. It is also considered as an inauspicious placement for marriage perspective as it can bring strong disagreements in beliefs.\r\nThe native and his partner are likely to face differences of opinions and they might get into several arguments quite frequently. These issues may increase with time, consequently ending in even more serious arguments and fights.\r\nIt is always advised that a Manglik person should marry another Manglik in order to get rid of the ill effects and destruction caused by Mars.\r\nThis position, nonetheless, will make the native quite an independent and courageous personality. And you’ll be able to fight all kinds of oppositions.\r\nIf there is no affliction, the native will be an honest and protective person.";
                                case 8: return "The eighth house is the house of wealth, sudden events, accidents, in-laws, assets with your wife/husband after marriage. This house also represents death and rebirths. it’s also the house of occult, mysticism and secrecy.\r\nWhen Mars comes into this house, it can cause quite a few accidents or injuries in the native’s life. Like cuts, burns or car accidents. Mars here feels quite in a difficult position.\r\nThis person can be a good detective who is good in understanding issues itentify root causes and getting in to actual cause underneath, get into arguments with the in-laws considering he has a dominant nature like when he comes in he expects the in-laws to respect him.\r\nMars’s placement in this house might even give disturbed relations with the spouse.\r\nThis placement also shows the gains after marriage, gains through secretive means. If you have combined effects of benefic exalted Mars in the eighth house, then you are likely to earn a good amount of money, success and recognition with the occult as a profession.";
                                case 9: return "Ninth House is the house of your higher learning, spirituality, pilgrimage, long-distance journeys, teachings of fatherly figures, it is also called as the house of your luck, fortune and treasure.\r\nA person with the effects of Mars in the ninth house of his horoscope is quite fond of travelling and adventures but with it comes the danger of reckless risks. Moreover, this positioning represents that the native has to be very careful in legal matters.\r\nMars in 9th house creates lots of disagreement with your teachers and especially your father because here Mars doesn’t really like to be told what to do, they don’t like to take orders.\r\nHe will have his own viewpoints and does not require others’ guidance. It’s like a blessing to him. Native from this house are more inclined towards study and research on various topics related to the spiritual growth of the soul and he might also go beyond this if there are some other supportive influences in his horoscope.";
                                case 10: return "The tenth house represents and rules over professional life, karma, nature of the person, reputation in work area, karma, next birth, weaknesses, ambitions etc. So, when Mars comes into this house, it makes the native earn a good amount of wealth.\r\nHe will be very hardworking and his only goal of life will be to reach the heights of his profession. these people like to lead the crowd.\r\nHowever, to achieve such heights, the native has to work extremely hard and he doesn’t get anything without actually earning it. Due to the dominating nature of the native, most of his colleagues and subordinates would not like him.\r\nAt the same time, many successful politicians are seen from this house with mars in it, for the exact reason. These people tend to bring something new to the table.\r\nAlong with that, the raw energy of mars enforces the native to have an enthusiastic and active nature.";
                                case 11: return "The 11th house is the house of your network circle, it represents gains of all kind, wealth. This is the strongest house regarding your hopes and wishes as in, how much of it will come true or not.\r\nAlong with that, it is also the house of your elder siblings. Mars in this house assures one’s effort towards earning an income or livelihood for self and the family.\r\nThis house s also a strong indicator of sudden income through lotteries, sudden wealth and profits, and prosperity, etc. So, the native belonging to this house with mars will be very competitive in making money.\r\nWhen it comes to competition, the person with Mars in the 11th house may go at an extreme level to achieve their targets.\r\nOn the negative side, the native is always concerned about making money and for that he will not hesitate to go in an illegal way.";
                                case 12: return "12thhouse in Vedic astrology represents detachments, solitude, isolation, and separation. Foreign lands, foreign travel, isolated places, hospitals, jails, asylums, and losses are also defined by this house. This is the house of letting things go and moving towards liberation.\r\nMars here could be a rather disturbing placement as a bad Mars could cause false accusations to the native which might result in imprisonment as well.\r\nThe presence of mars in this house even indicate difficulties in expressing one’s anger and aggressive emotions. The native will try to remain reserved.\r\nHowever, on the other hand, if placed favorably, it can provide the native with frequent foreign travels and the native might even settle abroad for good.\r\nSome people under the effects of exalted benefic mars in this house gets involved in the fields of spirituality as the beneficial effects of mars blesses them with a special understanding in such matters.";
                            }
                            break;
                        }
                    case EnumPlanet.Mercury:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "Mercury is a Planet that rules over intelligence and your ability to memorize things and first house represents the native from the outside, their outer behaviour, persona, and outer appearance.\r\nWhen mercury comes into the first house that means it’s impacting your entire life because the ascendant becomes that triggering point of your life. So your entire life becomes about communication.\r\nMercury in the first house makes the person highly intelligent. It makes them want to know more.\r\nExpressing themselves is a big part of their lives. They have a natural curiosity of knowing things in deep, in detail. These people love uncovering mysteries, solving puzzles and riddles of life.\r\nThis placement gives the native a straight petite body with small eyes and an expressive face. Native may have a long nose and a beautiful high forehead.\r\nAs Planet Mercury influences your head, these people can become philosophic intellectual artists.\r\nNative is usually way ahead of others in thinking because they are quick and consistent learners. However, this ability might be used for the wrong reasons if Mercury is afflicted.";
                                case 2: return "Second House concerns the wealth of the native, meaning if he is going to be rich or not. It represents the native’s personal possessions and financial position.\r\nMercury here influences native’s approach to money. They are naturally blessed with the talent to think of different ways to make money.\r\nIf mercury is badly aspected they might use their intelligence in acquiring wealth through illegal ways like stealing, smuggling etc. and even if it’s badly aspected, with much hard work, the native’s still able to make good money.\r\nHaving a way with words, these people have the ability to achieve financial success through their communication skills. Money is always in their mind as their thoughts are usually wondering towards the financial aspects of life.\r\nThese are the people who suffer the least from unemployment. Their bright mind always finds a way to earn adequate wealth and create a safety net. They are great with numbers. So, professions like a mathematician, financial advisors or money management are quite apt for them.";
                                case 3: return "The third house in Vedic astrology is concerned with siblings, neighbours, relatives, communication and so on. It also signifies short trips, possibly for education or business purposes.\r\nThis is the placement where mercury feels at home. It grants the native with a lofty degree of intelligence and an excellent way of communication through speech and writing.\r\nThese natives are mentally quite alert and clever, with plenty of reasoning and sharp intellect of logic, such a placement creates exceptional public speakers and writers.\r\nHowever, if Planet Mercury is afflicted, they might use their speech and influencing skills in spreading wrong ideas and false information. They can easily convince people and win over them irrespective of the mercury being afflicted or not.\r\nThe natives feel their best when they’re moving even if its a short distance like going on road-trips and visiting parks and cafeterias, despite sitting at home.\r\nProfessions that suits the best for these natives are writing, telecommunications, transportation, web design, publishing, speaking, journalism and travel etc.";
                                case 4: return "4th house is the house of mother, motherhood, love and emotions and is ruled by Moon. Emotions are something that doesn’t go along with logical and analytical thinking and this is the reason why Mercury doesn’t feel comfortable in the 4th house.\r\nThis house represents not only the native’s childhood and relationships with parents but also how they are likely to treat their family too. It relates to domestic comforts.\r\nThere is a possibility that the native would work from home. They are likely to research their roots, customs of their country, details of their ancestors, either for professional purpose or just out of curiosity.\r\nNative’s parents are very intelligent and lots of ideas are usually discussed at home which is why the native’s interest grows in discussions, solving riddles and reading in general.\r\nSerious bust-ups might take place at home during debates and arguments in case the Mercury is afflicted.";
                                case 5: return "5th house is mostly associated with progeny, love affairs, pleasure, amusements, artistic talents, higher education and speculation etc. It shows what the native’s understanding of having a good time is, how they like to have fun and how much they are able to enjoy their life.\r\nPresence of Planet Mercury in the 5th house influences the natives to communicate in an artistic manner. They are blessed with the natural endowment to express themselves in a way that affects people emotionally.\r\nNative is likely to have a very intellectual first child with a strong Virgo or Gemini in their birth chart.\r\nThey excel at careers like advertising or politics and since the native is utterly proficient in communication, it matters for them to have a good bond with their children. They also make excellent teachers.\r\nA combination of benefic exalted Mercury and Sun blesses the native with good results in education and the native may further get selected for some of the most prestigious types of jobs, by acing in competitive exams.";
                                case 6: return "The sixth house relates to debts, obstacles, difficulties, enemies and the native’s ability to overcome and sweep over the opponent.\r\nWhen mercury comes into this house, the intelligence of a person all throughout their life goes into resolving conflicts, whether it’s their personal life or lives of other people.\r\nPlacement of Mercury in this house can also give the mind uneasiness and impatience. The native is at risk of getting health issues like stress and anxiety. A constant effort should be made to keep up the peace of mind.\r\nThis natal placement will bring the native’s inclination towards social services, the social well being of other people, of lower-class people, people who are unprivileged, people in poverty, people in abused relations. native’s logical intelligence goes into resolving these things in an analytical manner.\r\nAnd accordingly, they may occupy themselves in such profession, depending on their overall horoscopes. Professions like Lawyer, doctor, police officer, administrative officer, politicians, social workers etc.";
                                case 7: return "This house is the house of all sort of partnerships, including business partnerships and marriage. It describes what kind of a wife/husband the native wants. This house also shows if you are likely to be successful in business or any other sort of partnerships.\r\nPlacement of mercury in this house represents that the native will spend a lot of his time thinking about his other half and the idea of marriage.\r\nIt blesses the native with an intellectually superior and sharp-minded partner. The native anyway falls for people who are perceptive, humorous and knowledgeable.\r\nAfflicted mercury might cause problems and misunderstandings in marriage or business partnerships. In that case, native should avoid anything to do with the legal matters.\r\nThe spouse of the native might be a writer, poet, journalist or in any other profession or career mentioned under Mercury’s attributes. These people strongly long for the need to communicate their feelings towards their partner and that’s what they expect in return.";
                                case 8: return "Eighth house in Vedic astrology rules over sudden events, longevity and death. This house is also the house of joint sources or inherited money and property from the in-laws. Besides, it indicates if the native is driven by fear or other emotion.\r\nThis placement blesses the native with good results related to health, profession, marriage, finances and spiritual growth.\r\nThe native may choose to dig deeper into the field of astrology as the naturally have the ability to understand the things behind the curtain easily.\r\nWhile the native love uncovering secrets of other people, they keep their own very well hidden.\r\nNatives are brilliant with influential speech even though they might not be fully educated about the subject. So they can easily make themselves seen as an authority figure. They have a fascination to use this great natural ability for the manipulation of the public.\r\nThe native might be ambitious to work in areas like taxes, managing other people’s resources, insurances and so on.";
                                case 9: return "9th house in Vedic astrology is concerned with group thoughts and self-expression. It’s about long journeys, higher learnings, religious & spiritual inclination, good karma, ethics and values.\r\nIt represents the journeys towards the unknown to find what is beyond and in a higher place than all of us.\r\nNative’s mind is quick and easily understands abstract concepts. They enjoy having intellectual conversations with people about education, travel and social trends.\r\nPlacement of Planet Mercury shows one’s great inclination towards spiritual learnings. The person can actually become a spiritual speaker due to the effect of mercury in this house.\r\nThere is a significant chance that the native may have to travel and settle abroad for his higher studies or business purposes.\r\nThe natives have a strong inclination towards matters like religion, spirituality, travelling, higher studies, philosophies, litigation, foreign affairs and so on. So, professions like a lecturer, spiritual leader, foreign diplomat or dignitary.";
                                case 10: return "10th house is concerned with career, social reputation, political concerns, ambitions and the public image of the native. It deals with what kind of service the native provides to the public.\r\nNatives with this placement usually choose a career related to speaking and writing. In fact, they might have more than one career at the same time as it’s easy for them to get along with different kind of people because of their superior communication skills.\r\nIt is likely that the native is versatile and they know exactly when and how to manipulate their speech in order to influence a different kind of people.\r\nThis position is fairly favourable for the people belonging to the fields of politics, writing, media, publishing and so on.\r\nThe native gets to travel a lot mostly because of the profession they are in. they use their knowledge wisely to stay ahead in anything they do, be it their career or anything else in general.";
                                case 11: return "The 11th house is a strong indicator of incomes and gains, of prosperity and sudden profits. It represents the native’s social sphere. This house also rules over native’s interests, hopes and wishes.\r\nWith Planet mercury in 11th house, the native likes to take qualities of their friends and social circle. They love to exchange ideas with people and are always open to learning. Moreover, they are always ready for interesting discussions. Something that would challenge their mind.\r\nThese people excel in careers related to information technology, especially in case of exalted Mercury, a career in the scientific field would be the best for them.\r\nWith the effect of afflicted Mercury, native’s ideas might be impractical but they may use their intelligence in order to influence people for their selfish reasons.\r\nThey might accidentally attain great wealth through some communication activity, like writing or speaking.\r\nIf the mercury is retrograde, the native feels a sense of detachment from the worldly desires and seeks solitude which eventually might take their inclination towards spirituality.";
                                case 12: return "Being the last house, 12th house represents endings. It’s the house of secrets, mysterious places, fears, hidden enemies, subconscious mind. Moreover, this house also includes seclusion, detachments, withdrawal and isolation. Detachments, mostly from the materialistic aspects of life.\r\nThis is a great placement for the native to explore his subconscious, but it’s important to not lose the balance. It gives the native ability to establish subconscious connections with other mysterious realms of life.\r\nThe native is highly imaginative and representative. They understand the power of speech and use their words and excellent communicative skills quite carefully.\r\nAfflicted mercury may give the native mental instability as a result of which they even might get hospitalised or jailed for committing some criminal offence out of such mental state.\r\nThey are likely to master higher learnings in the subjects regarding astrology, occult, religion and spirituality.";
                            }
                            break;
                        }
                    case EnumPlanet.Jupiter:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "The first house or Ascendant is mainly concerned with the native’s outer appearance, health and how in general they appear to the world. It’s the most important part of one’s birth chart as it defines in which houses the rest of the signs and planets will be located.\r\nJupiter is the planet of expansion. Its placement in this house increases native’s inclination towards travelling, reading, and basically exploring.\r\nEducation is a big part of their lives. They inspire people with their ability to stand out in the crowd because of their knowledge and wisdom. Hence, this effect of Jupiter should definitely be used to the fullest to become an independent and self-reliant person.\r\nSince Jupiter is the planet of higher learnings, religions and spirituality, the native might take a keen interest in these subjects.\r\nIt gives the native a body that’s more on a chubby side, a beautiful complexion with long or oval face, large eyes and high forehead also a tendency of baldness in middle age.";
                                case 2: return "The second house concerns the possessions and wealth of the native. The native was probably born in a rather wealthy family and from a young age accustomed to a life without financial troubles.\r\nAlthough any fluctuations are natural in everyone’s life, this position assures the native lifetime financial security.\r\nJupiter in the second house signifies that the native is a highly influential person in society. They enjoy wide social circles which grants them authoritative and leadership qualities.\r\nSince the 2nd house also rules over the throat area of the body, the native with Jupiter in this house is blessed with a beautiful sweet voice and has prominent chances of becoming a singer.\r\nJupiter is the planet of expansion, so if it is badly aspected it may turn the native into a spendthrift. But this planet is so lucky that the native is still likely to regain the financial condition despite that.";
                                case 3: return "The 3rd house mostly associates with communication and self-expression. It also signifies short trips, and if the native tends to remain to move a lot or remain at one place. This house also represents siblings, relatives and neighbours.\r\nThis position indicates that the native has a keen interest in gaining all sorts of knowledge and visiting different places.\r\nNative’s life is full of short trips and happy events. They love to explore and are happy when they evolve intellectually. They are likely to maintain a good relationship with their relatives and neighbours.\r\nStrong Jupiter in the third house indicates a good command of the native over communication and they are most likely to involve themselves in professions like writing, publishing, media, journalism, broadcasting, railways, tourism and so on.\r\nThis position also enhances native’s mental capabilities which provide them with a strong intuitive skill. Jupiter expands one’s mental strength so they tend to grasp information quickly.";
                                case 4: return "The 4th house is the house of mother, motherly love, nourishment, happiness, basic education and domestic peace. It represents family, home and childhood. It also describes the inherited properties like land or vehicle etc from mother or father.\r\nPlacement of Jupiter in the fourth house, the native gets good results in matters related to family relation, in their desire of learning and childhood. Native’s parents instil good ethics and values in the native.\r\nThis placement suggests that the native is most likely to flourish at their domestic or native places and they should not move away from their native place.\r\nNative with this placement in their natal chart likes to collect immovable properties. Apart from that, this placement also gives huge benefits in terms of starting a family. Parenting, to be specific, is fairly beneficial for the native.";
                                case 5: return "5th house has connection with what the native’s understanding of good time is, how they like to express them creatively, and what their idea of free time is. It is mainly concerned with progeny, creativity and love affairs. In addition to that, it can also indicate the wealth of the native’s father.\r\nJupiter itself is the planet of expansion and luck brings about good fortune into the life of the native. They are likely to achieve heights in the careers they choose.\r\nThis placement provides the native with great creative knowledge, a proclivity for philosophy and religions. Native likes to express himself through creativity, entertainment, arts, education or gets involved with activities to do with children.\r\nThe native’s children will bring happiness to him. These people love their kids and kids, in general. His children are likely to take fair interest in spirituality, religions and philosophy.\r\nIt also indicates many love affairs, and that the native enjoys getting involved with people who give them a great time. Hence, intimate relationships are usually based on the amount of fun that could be exchanged.";
                                case 6: return "This house relates to debts, obstacles, difficulties, enemies and the native’s ability to overcome. It also shows the kind of service that Native is going to provide to society. Moreover, it represents the people who work under the native. For example, native’s rantee or tenant.\r\nLord of 6th house is Mercury and Jupiter is not considered to have a friendly bond with Mercury. Hence, this is not regarded as a favourable placement for the native. However, the planet of luck definitely brings great chances of earning good money from the work.\r\nSince Jupiter is a benefic planet, it provides the native with great vitality and they generally get lucky in health-related matters.\r\nIn case, Jupiter is afflicted, Native doesn’t get along with his coworkers, in whatsoever work they do. It may prove to an unpleasant placement in such matters.\r\nThe native will usually render his free time to serve for humanity. They are also involved in healing activities, be it in the medical field or spiritual field of healing.";
                                case 7: return "7th house is the house of all sort of partnerships and legal bondage. It includes both business partnerships and marriages. This house represents what kind of a partner the native is looking for and if they are likely to be successful in business or partnerships or not.\r\nWith Jupiter in this house, the native gets lucky in partnership-related matters and are blessed with a well educated, loyal and sensible person. Usually, the spouse is from a wealthy and noble family.\r\nThis placement provides good wealth accumulating opportunities through matrimony or partnership. The native has a strong need for a partner who they could share their religious, philosophical views in order to empower them and increase their growth opportunities.\r\nIf Jupiter is afflicted, the partner could face issues regarding obesity and most likely to be lethargic and arrogant.\r\nJupiter in the seventh house of horoscope makes the native intellect and successful. They tend to be an eloquent speaker and gets benefits in foreign lands.";
                                case 8: return "The eighth house is mostly concerned with hidden matters like taxes and insurance, sudden events, longevity and death. Its also known as the house of joint resources. It’s about the deals regarding the inherited money and property.\r\nPlanet Jupiter being the house of fortunes shows good luck in above-stated subjects. Others like to give money and wealth to these people, they manage other peoples money and wealth.  In most of the cases of afflicted Jupiter, the native has extreme sexual temptation which might end up in extra sexual affairs. If Jupiter is badly aspected, it might even turn into an obsession if one’s not careful.\r\nThe native takes great interest in professions that involve finance related matters like tax accounting, insurance or occupations to do with death, like providing funeral services etc.\r\nNative is most likely to get benefits from joint resources and other matters ruled by this house, like other people’s money and inheritances.\r\nThis placement gives the native high intuition and psychic abilities. It blesses them with a great understanding of the occult and mystical subjects.";
                                case 9: return "The house of travels, spirituality and higher learnings. It’s related to long-distance travel like a pilgrimage or foreign trips and the philosophical and geographical knowledge obtained during it.\r\nPresence of Jupiter in the ninth house depicts that the native would base their entire life on their religious and philosophical learnings. They love to travel and stand great chances of foreign trips or abroad settlement.\r\nThey have a thing for learning even if Jupiter is afflicted, they want to explore more and more. However, they may not have many opportunities to do it.\r\nThey learn by focusing on main areas rather than getting into the deets. They prefer studying on their own on the things that interest them, things like spirituality, travel and philosophy.\r\nNative remains a student and a learner all their life. They are likely to taste success quite early in life and continues throughout life.";
                                case 10: return "This house is concerned with the career, profession, reputation, political concerns, life ambitions and the overall public image of the native.\r\nJupiter’s presence shows that the native will achieve his desired success and wealth, and also fame in his career, in most of the cases, later in their life as a lot of obstacles and delays would come in the way.\r\nThe native likes to involve himself in professions related to education, spirituality or travels. These people like to be known and recognised for what they do and feel their best when people know them.\r\nThis position also represents that the father would be a positive influential figure in the native’s life and contributes a lot to what this person is today.\r\nNative loves to expand his cognition and be the most knowledgeable person in the sphere, in order to do that they study and research a lot.";
                                case 11: return "The 11th house is a strong indicator of incomes and gains, of prosperity and sudden profits. It represents the native’s social sphere. This house also rules over one’s interests, hopes and wishes.\r\nPlacement of Jupiter in the 11th house proves to be beneficial in the matters of friendship. These people get bright and loyal friends who help the native expand their mind spiritually and intellectually.\r\nNative achieve good results in group activities and they form quick connections with people who are of higher understanding, sensible and possibly of foreign descent.\r\nNative with this placement enjoys remarkable achievements in life mostly because of the fiscal and psychological assistance from their allies who tend to enjoy influential positions in society.\r\nThey are likely to spend most of their time with their friends and in social activities in order to neglect their work and studies in case of debilitated Jupiter.";
                                case 12: return "The 12th house deals with mysterious things, things hidden behind the curtain, solitude, subconscious mind, isolated places, one’s fears and insecurities.\r\nPresence of Jupiter in this house represents that the native might take great interest in spirituality, occult and mysticism. They might be practising such spiritual ways like meditation or prayer in order to attain relief.\r\nThe native might be working in some places of isolation such as hospitals, jails, rehabs etc. They love to help people in defending their troubles.\r\nIn case of afflicted Jupiter, the native might be too delusional and tend to create their own fantasy world in order to save themselves from the harsh reality.\r\nNatives are likely to detach themselves from the materialistic aspects of life and they are more inclined towards spirituality and religious beliefs.";
                            }
                            break;
                        }
                    case EnumPlanet.Venus:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "The first house is concerned with the native’s outer appearance, their health, character, temperament, their strength and weaknesses. It mostly relates to one’s public appearance.\r\nVenus’s presence in the First House depicts that the native has an artistic persona with a hint of sensuality. The native enjoys music and poetry and music and all other forms of art along with beautiful surroundings and has a great sense of aesthetics.\r\nPlanet Venus grants the native a playful personality, appealing physique with beautiful and dazzling eyes plus curly hair. They gain a lot of friends because of their calm, polite and sensitive nature towards others.\r\nRelationships, specifically love and sexual relationships are very important to the native, they can’t be single for a long time.\r\nAn afflicted Venus can make to native very conscious and insecure of their appearance or they want everybody to like them and suffers deeply if someone dislikes them.";
                                case 2: return "The second house is associated with the possessions and the wealth of the native. This position suggests the native’s earning capacity along with the ability to handle money.\r\nVenus being the feminine planet attracts, it attracts the money and finances. Undeniably, the cash flow of the native grows and they spend an extravagant amount of money on arts, beauty and entertainment.\r\nA good Venus here makes the native balanced, soft-spoken and a peace-loving person. These people know when to speak what, they choose their words wisely that leaves an impact on people’s lives.\r\nThere’s a great possibility of earning money or addition to the wealth because of beauty or some creative activity. The native loves to be admired and pampered with gifts.";
                                case 3: return "The third house is mainly concerned with native’s siblings, relatives, and neighbors. Apart from that, it is also the house of communication, short distance travels and moving from one place to another.\r\nPlacement of Venus in the third house suggests that the natives will feel their best when they’re with their siblings or relatives and when they’re moving. They love visiting beautiful places like cafes, parks, and gardens.\r\nNative with the placement of Planet Venus in 3rd house often wants to make their career in poetry and literature as it is something that highly stimulates them.\r\nThere’s a possibility that the natives might use their excellent speech and communication skills for some selfish reason, specifically when the Venus is afflicted.\r\nIt is extremely important for the natives to have a partner who’d listen to them, but their true feelings in front and is communicative in the relationship.";
                                case 4: return "This is the house that represents home, childhood, mother, the kind of relationship the native shares with his mother, one’s early childhood and the way native’s likely to treat his family.\r\nWhen Venus is in the 4th house, it makes the native extra sensitive and emotionally attached to his parents. They have a childhood full of beautiful beautiful memories and fondness.\r\nThe native likes to be a wonderful host. They naturally have a sense of aesthetics which is evidently visible in their homes. It provides them with a sense of fruitfulness and inner pleasure. In addition to that, such a person is likely to gain financially from their family affairs.\r\nIn the case of afflicted Venus, the native’s family doesn’t really appreciate all the efforts they put into creating a pleasant aura in the family.";
                                case 5: return "The fifth house is about pleasure. It shows how the native expresses himself creatively. What the native considers fun and what they like to spend their free time. It also indicates the father’s wealth.\r\nThe planet of love in the house of love itself, what could be better than that? This placement proves to be very beneficial and the native is lucky to have this placement in their natal chart because Venus feels very comfortable in this house. \r\nIt gives the native joyful and exciting romantic relationship. This placement makes the native have popularity among friends and a strong love for kids.\r\nHaving Venus in the 5th house gives the natives a tendency to have a female first child and they may have a very beautiful female child.";
                                case 6: return "6th house indicates the kind of services one provides for humanity, it describes the way the native is going to be fruitful for the society.\r\nVenus in the 6th house grants the native with a strong inclination to be of service at work. Their co-workers admire them for their easygoing and humble personality.\r\nThere is a strong tendency that the native will be drawn towards the subject of beauty, art, and creativity. They are likely to do well in such occupations.\r\nThese people have a beautiful and ever-evolving personal style. Besides, they pay good attention to their diet as they like to stay healthy and look great.\r\nThe native is always connected to art and creative fields even if he/she is not directly connected to it. They might be floral designers, interior designers, photographers, editor or makeup artists.\r\nThis placement creates good hairdressers, fitness trainers, beauty or cosmetics specialists, dance trainers and so on.";
                                case 7: return "The seventh house is one of the most important houses of all. it’s the house of partnerships, be it in business-related matters or in life.\r\nThe presence of Venus in this house gives good results in marriage. It blesses the native with a beautiful, wealthy and an attractive spouse someone with whom they can possess and enjoy the comforts of life.\r\nThe native is also likely to flourish in business partnerships. They usually are blessed with someone who is not just their business partner by also their friend which makes the business atmosphere quite pleasant.\r\nIn the case of debilitated Venus, the partner of the native might be lazy and someone with bad behavior.\r\nNevertheless, the native completely understands the value of companionship in their life and they are very close to their partner and maintains a balance and harmony in the partnership.";
                                case 8: return "The 8th house in Vedic astrology represents marriage, corporate resources and the property or money inherited. It’s also the house of hidden matters, occult, mysticism, death, and rebirth.\r\nWill marry a wealthy partner. Others like to give money and wealth to these people, they manage other peoples money and wealth.This placement indicates that the native will have a partner who is well informed of money matters and would be someone who will provide richness and comforts in life.\r\nHowever, in the case of afflicted Venus, it could make the native lazy and careless. The native might even experience disappointments in their love life.\r\nThe presence of Planet Venus in this house draws the native to people who have darkness in them. They are always attracted to the mysterious and dark energy that people possess.\r\nNative is likely to get into a relationship with someone who is mysterious, sexual and wealthy. On the other hand, others find the native charming and enchanting without being able to identify the reason why.";
                                case 9: return "This house is concerned with the long-distance travels like a pilgrimage or foreign travel etc. and the knowledge obtained during it. it’s also related to the religious and philosophical ideas, together with the higher learnings of the native.\r\nWhen Venus is position in this house, it makes the native very fond of traveling, they are always excited about discovering new places, culture, music, and art.\r\nThere are chances that the natives might get married to some foreigner or someone who’s settled in foreign lands. The native tends to live far from his/her native land.\r\nA badly aspected Venus may give the tendency to escapism, especially at a younger age or the native might cut his studies short either by their own choice or due to some obstacles.\r\nThese people take great interest in religious and philosophical discussions and are tend to be fair-minded.";
                                case 10: return "In Vedic astrology, the 10th house is considered as the house that represents a career or profession. It shows if the person will achieve fame and grandness in his life. It is also the house fathers.\r\nWhen Venus is positioned in this house, it gives the native a cheerful and friendly behavior with a harmonious and compelling personality which makes them gain a lot of attention in their workplace.\r\nThe native tends to be an easygoing and sociable person and have a positive outlook on life. This quality of theirs helps them a lot in their life. The native shares a good relation with his father.\r\nWith this placement in the native’s horoscope, they tend to be more enticed towards making a career in music, speaking or even politics.\r\nIf badly aspected, this position might affect the native’s public image. They might even use their talent and abilities selfishly to gain money.";
                                case 11: return "The 11th house is a strong indicator of sudden wealth and gains. It represents prosperity, sudden income and good wealth. This is also the house that depicts one’s social circle.\r\nPlacement of Planet Venus in the 11th house grants the native with a gracious personality. It further helps them in making friends easily. The native might attract many friends from the opposite sex. He will be worried about future and Masturbate much, he will have excessive lust. He must learn to respect females.\r\nNative is naturally blessed with a persona that he is easily able to financially gain from their social activities.\r\nNative with this placement has a strong desire of being surrounded by their friends. They attract financially sound people who can further give them financial assistance when needed.\r\nIn the case of afflicted Venus, the native should not overindulge in social groups and with hanging with friends, as it might affect them unfavorably.";
                                case 12: return "It’s the house of secrets, fears, the subconscious mind and isolated places. It also represents liberation and detachments from the materialistic desires of life and indicates one’s inclination towards spirituality.\r\nWhen Planet Venus is placed in the 12th house, it depicts that the native would love to spend time alone. Moreover, they may have hidden love affairs as they like to keep things hidden from people.\r\nThe native is likely to be shy and introvert. They enjoy mystical and artistic things. Being themselves very creative and artistic, they are usually unaware of their artistic talents or keep that hidden from the world.\r\nThe presence of Venus in the 12th house makes the native unaware of his personal charm. So, these people are likely to be more attractive and charismatic then what they think. ";
                            }
                            break;
                        }
                    case EnumPlanet.Saturn:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "The first house is associated with the outer personality and health of the person. It represents the character, temperament, strengths, and weaknesses of the person. In general, how a person appears in the world.\r\nWith Saturn in the first house, it makes the native look reserved and serious. These people like to be organized and don’t mind exerting all their energy into their work.\r\nNative is likely to be highly sincere and strong-minded. These people as kids tend to be far more disciplined and mature than their other childhood friends. They are very serious-minded.\r\nEarly years of their lives could be difficult and melancholic, especially when Saturn is debilitated.\r\nPeople with this placement are very law-abiding as well as fair. They make the most fierce and respected lawyers and judge out there.";
                                case 2: return "The second house in Vedic astrology is mostly concerned with family, accumulated wealth and possessions held by the native. Along with the native’s earning skills and capacity. Speech and intake of food are also seen from this house as it represents the throat.\r\nThe presence of Saturn in the second house of a horoscope indicates delays the ability to save money for the native until the age of 35. Between 32 and 35, it starts the process of taking its negative side out and the natives can start saving money.\r\nSaturn is a planet that might restrict childhood nourishment. The native may not have born with a silver spoon in their mouth and not have all the luxuries that a child might need because of their very conservative and disciplined family.\r\nOnce the Saturn releases its Karmic backlogs, the native might end up making far more money than anybody else because they become very disciplined and hard workers.";
                                case 3: return "The third house is associated with self-expression, siblings, relative, neighbors and native’s immediate environment. Plus, it also signifies Native’s courage, short trips or running errands, etc.\r\nWhen Saturn comes here, it tends to restrict native’s relationship with his siblings, especially at an early age until mid-life. They do not have good communication with their siblings unless there’s Venus and Jupiter’s aspect in the third house.\r\nSaturn is a planet that can make the mental concentration of the native very slow but steady. These people become life-long learners of knowledge and philosophy.\r\nPeople with this placement tend to be a little ignorant but very mature at a young age. They are likely to express their creativity through discipline and persistence.\r\nThe presence of Planet Saturn in the 3rd house makes the natives quite sharp and intelligent but they might face difficulty in expressing themselves in words. Hence, Native has to work hard in order to ace the art of communicating.";
                                case 4: return "The Fourth house represents Native’s childhood, mother, motherly love and nourishment, home, real estate, early childhood and the way they’re likely to treat their family.\r\nThe presence of this dull and dark planet-Saturn in the 4th house might affect adversely in the emotional areas connected with native’s family, home and childhood.\r\nIt is not supposed to be a very benefic placement for the natives as it indicates difficulty in the early age and constraints by the parents.\r\nThe native might have a hard time expressing his emotions and true feelings towards his family. The family might be rather disciplined and conservative towards expressing their love and emotions.\r\nThere is a possibility that the native might be raised by his grandparents as the parents were absent from native’s life and burdened with other responsibilities.";
                                case 5: return "It’s the house of pleasures. This house represents how the native likes to express himself creatively and what they consider as fun. It is also associated with the father’s wealth.\r\nThe presence of a well-aspected Saturn in the fifth house indicates that the native will be disciplined and hardworking with a structured approach to creativity.\r\nNative is usually of shy nature which is why he takes his life way too seriously and barely allows himself to enjoy any pleasures of life.\r\nThey are likely to follow well- defined patterns and rules in life instead of being spontaneous and having fun.\r\nNative could face difficulty in giving birth or have low infertility especially if the Saturn is debilitated. It could even indicate miscarriages.";
                                case 6: return "This is the house of conflicts, wars, diseases, enemies. It also indicates the kind of services the native provides for humanity, it describes the way the native is going to be fruitful for the society.\r\nPlanet Saturn in the 6th house indicates that the native takes his job quite seriously and believes in working hard. These people are well organized and structured in whatever they do.\r\nThe native tends to be good with what work that requires close attention to details and need logic. They are likely to be respected for what they do.\r\nIn case of debilitated Saturn, native doesn’t really enjoy conversations with his colleagues and might face minor health problems due to overworking habit of the native.\r\nThey are not likely to be very creative with their work and mostly rely on tested and proved methods.";
                                case 7: return "7th house is the house of legal bindings like marriage, business partnership, sexual relationship, laws. It also represents other people, like your public life.\r\nPlacement of Planet Saturn in the seventh house makes the native responsible and are reliable people.\r\nAn afflicted Saturn can make the native strict and hardcore even in the most sensitive of matters like marriage. They like to boss around people and this quality of theirs can help them do well in business management and law-related fields.\r\nWith this placement in one’s chart, one should be very careful if they get married before thirty, as it might bring negative and malefic effects in life to make it unbearable.\r\nWhen it comes to a well-aspected Saturn in the native’s natal chart, it blesses the native with good results and provides stability in marriage and business unions.";
                                case 8: return "The 8th house in Vedic astrology represents marriage, corporate resources and the property or money inherited. It’s also the house of hidden matters, occult, mysticism, death, and rebirth.\r\nWith this placement in the native’s chart, it shows a heavy burden of responsibilities like joint finances, taxes and other people’s resources on the native’s shoulders.\r\nThe native might face a lot of obstacles and problems in subjects like insurance and taxes. There is a possibility that the native’s spouse may lack money if Saturn is debilitated.\r\nThis position disturbs the Native’s health and causes illness. Whatever illness they may face, Saturn elongates it and makes it chronic. That illness could be the cause of death or the native might even die at a young age.\r\nIf Saturn is well-aspected, it shows a long life and with much effort and hard work, wealth will come later on in native’s life.";
                                case 9: return "9th house id the house of religion, spirituality, house of your teachers, law and the house of your father. It also signifies long journeys like a pilgrimage, fortune, and luck.\r\nSaturn in the ninth house makes the native Spiritual and religious person. These people are well educated but in an orthodox manner.\r\nPeople with this placement are more inclined towards making a career where they could grow more on a spiritual and philosophical level. They like to get employed in traditional and well-established institutions.\r\nNative gets to travel a lot and mostly for business purposes and career progress. he considers travelling a way of learning.\r\nThe native tends to have a narrow mind and would be egoistic and very strict if Saturn is afflicted. It could even create difficulty in native’s higher education.";
                                case 10: return "In Vedic astrology, career or profession falls under the 10th house. It shows if the person will achieve fame and grandness in his life. It is also the house father.\r\nSaturn in the 10th house is considered a fruitful placement for the native. They fit well in their work environment and get to taste success but after putting good efforts and a lot of hard work.\r\nThey are likely to be very ambitious in their career which drives them to achieve greatness in their occupation. Provided that it’s also the house of the father, Native might not share a good relationship with their father.\r\nSaturn might bring obstacles and lack of opportunities but in those cases, it’s disciplined and patient nature takes over and the native plans things out about his future. They are likely to achieve great heights in their careers and earn good wealth.";
                                case 11: return "The 11th house is a strong indicator of sudden wealth and gains. It represents prosperity, sudden income and good wealth. This is also the house that depicts one’s social circle.\r\nHaving Saturn in the 11th house would indicate that either the native have more than one source of income or both husband and wife are diligently earning.\r\nProvided that fact that the eleventh house is also the house of friends and social circle, the native generally gets support from his social circle and friends unless Saturn is debilitated or badly placed in the chart.\r\nIn case of a badly aspected Saturn, the native might struggle in building friendships due to their shy and introverted nature. Most of the time, they are concerned if they even fit in any social group and don’t like to contribute to gossips and chit chats.";
                                case 12: return "It’s the house of secrets, fears, the subconscious mind, and isolated places. It also represents liberation and detachments from the materialistic desires of life and indicates one’s inclination towards spirituality.\r\nPeople with this placement in their birth charts like to spend a lot of their time alone. They might be working in some secluded place like a hospital, jail, asylum or ashrams, etc.\r\nNative understands the value of spirituality and seeks that path. However, in the case of debilitated Saturn, they might find themselves lazy for that and Saturn might even give them a feeling of depression as well.\r\nThis placement, however, provides good results in foreign lands. The native is likely to get success if he’s connected with fields like petroleum, coal, or mines, etc.";
                            }
                            break;
                        }
                    case EnumPlanet.Uranus:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "You may become very short-tempered and broody.";
                                case 2: return "You may face eye-related problems and unstable financial life.";
                                case 3: return "You may develop a strong personality, and sharp memory power but may have issues with siblings.";
                                case 4: return "You may have unhappy domestic life and property issues.";
                                case 5: return "Native associated with the stock market may suffer from loss.You may have children’s issues.";
                                case 6: return "You may become a self - centred person and have problems due to others’ mistakes.";
                                case 7: return "You may find problems in married life and extramarital affairs.";
                                case 8: return "You may have legal issues and losses in court cases, accidental death and cheating by friends.";
                                case 9: return "You may get positive results if you are associated with the journalism and research field.";
                                case 10: return "This is a good position in regards to your career and social status, but age from 42 to 45 problems may arise.";
                                case 11: return "You may find Problems due to friends, but it’s a good placement for business.";
                                case 12: return "You may deal with financial troubles and poor health issues. You may have frequent visits to hospitals.";
                            }
                            break;
                        }
                    case EnumPlanet.Neptune:
                        {
                            switch (this.Rasi.Current)
                            {
                                case EnumRasi.Mesha: return "Neptune in Aries natives ride the line between intensity and impulse and their legacies are often marked by serious and even violent struggles. When Neptune was last in Aries, America was entrenched in the Civil War, a conflict of ideals and humanitarian principles that gave rise to a new, fledgling nation. Fittingly, this era coincided with the development of war photography, marrying the horror of combat with the ephemera of the captured image. "; 
                                case EnumRasi.Vrishabha: return "The combination of Neptune in Taurus makes the natives inspirational, creative, and meticulous. There would be increased materialistic trends and you may spend a lot of time collecting different resources.\r\n\r\nThese natives are very practical and they give a lot of importance to aesthetics. They are goal-oriented people who do not let go of things easily. Nothing is impossible for them.";
                                case EnumRasi.Mithuna: return "People having the combination of Neptune in Gemini are very curious, intelligent, knowledgeable, and interesting. The ability to engage with people will help you discover your preferences and makes you a versatile communicator. They excel in logical reasoning. This combination blesses the natives with interpersonal skills.\r\n\r\nGreat writers and speakers have this placement of Neptune in their Birth Chart. They are blessed with the power of attracting people like a magnet. They have a huge social circle indeed. They make complex ideas easy to understand for everyone. That apart, these people are inclined to occult science, and they love talking about paranormal activities. They are driven by impulse and are often fickle-minded and could change their stance, without warning.";
                                case EnumRasi.Kataka: return "Natives having Neptune in their Cancer sign are highly emotional and sensitive towards their family members, especially their mothers. They are born nurturers and helpers. Their empathetic nature gives them an ability to understand and share the feelings of others. The secret to their happiness is helping and supporting their family members.\r\n\r\nThey have intuitive abilities and are well aware of their surroundings. For these people, their home is their happy place where they feel the most comfortable and peaceful. If they feel stressed out, they take a few moments and spend time with their family members.\r\n\r\nThey are the most industrious and diligent people among the zodiacs. However, if they feel they cannot achieve a particular goal, they will start running away from the situation. There is no denying that they hate challenges. They go into their shell and try to dodge difficult situations as far as they can. Since they believe that true enlightenment can only be achieved through perfection, they get depressed when things do not work out as per their plans.";
                                case EnumRasi.Simha: return "This combination of Neptune in Leo makes the natives charming, passionate, energetic, and imaginative. The charisma of these natives is amazing. Leo, the natural-born leader, is fearless in leading and inspiring others. They are blessed with a lot of admirers when makes them even more bossy and egotistic.\r\n\r\nOne of the most unique qualities of these people is they make their dreams come true at any cost. Also, they always find a way for getting impossible things done. They are very dramatic and have a heightened sense of creativity in them. They not only love being in the limelight but also know the ways of getting there. Their magnetic personality gives them a lot of followers. Their ideas are unique but these people are quite dominant.\r\n\r\nWhile Leos can accomplish a lot, they still need help to learn a lot about their spiritual journey, and it is better if they learn it soon.";
                                case EnumRasi.Kanya: return "This combination of Neptune in Virgo makes the natives detail-oriented and highly observant to a level that they can notice minor changes that others often overlook. These people want to get into the nitty-gritty of things. However, in this process, they sometimes overlook the bigger picture. They are willing to put in extra time but they want things to be perfect. Once they visualize something, they lay down a plan and then make a strategy to achieve their goals.\r\n\r\nThey also have an affinity for healing, which may make them a good physician. They are very critical and analyze almost everything with different perspectives. These natives are also very responsible and take their duties seriously.\r\n\r\nFor them, their spiritual enlightenment is to let go of their perfectionist attitude and accept things as they come.";
                                case EnumRasi.Thula: return "This combination of Neptune in Libra helps the natives strike a perfect balance in life. This help them reach a logical conclusion. These people tend to be very accommodating and can act as the mediator. One of the best listeners, they are mature, practical, and realistic in the matters of life. They are good conversationalists and believe in fighting against injustice.\r\n\r\nThis position of Neptune also makes them inclined to charity and social work. This works as spiritual enlightenment for these people. However, they need to understand that they cannot change somebody’s mind. Therefore, they should focus on things that are under their control. These people find true happiness in helping others. During this process, they tend to forget about their own needs, which may lead to depression. They must remember that it is their spiritual duty to make their mind peaceful.";
                                case EnumRasi.Vrichika: return "The natives having this combination of Neptune in Scorpio are mysterious and secretive. They are pessimistic about things and life in general. However, at the same time, they are very intuitive, impeccable, spiritual, and protective. But they can be revengeful, possessive, and jealous at times. Their obsessive behavior causes a lot of problems in life.\r\n\r\nBeing an intense and spiritual sign, the placement of Neptune in Scorpio will increase their intuitive powers. Often, their psychic abilities are reflected in their day-to-day activities. The most peculiar thing about these natives is that they get spiritual enlightenment through sensual pleasures. The bedroom is the place where they can express themselves truly. They connect with people through sexual intimacy. Their magnetic attraction is mysteriously intense. Even after having lots of emotions and sentiments, Scorpions will hardly show them. Most of their sentiments are wrapped inside themselves. These natives are also very much susceptible to addiction. The amount of passion in these natives is too high, and if it is not utilized properly, their energy is channelized in a way that might be very destructive. The best advice for these people is to build strong communication channels. Discover new hobbies that excite you and help you achieve your spiritual goals.";
                                case EnumRasi.Dhanus: return "The natives having this combination of Neptune in the Sagittarius sign are adventurous and fun-loving people who love exploring new places and learning new things. This attitude would help them achieve their spiritual goals.\r\n\r\nThey are fiercely independent and do not believe in setting boundaries. These natives are very spontaneous and can make their adventure and travel plans almost instantly. They are not much interested in daily routine activities. They see challenges as opportunities. They are good learners and keep acquiring new skills and capabilities well past their formal education years. However, it may make them somewhat opinionated.\r\n\r\nTheir passion and enthusiasm are boundless. Whatever these natives do, they do it with pure intentions. They live life selflessly in the service of others.\r\n\r\nThe perfect advice for them is to plan their task and go accordingly to achieve their spiritual goals.";
                                case EnumRasi.Makara: return "The natives having this combination of Neptune in Capricorn are very logical, practical, and ambitious. However, they may be controlling and stubborn. People who are practical and realistic inspire them. Their ideas are usually based on reality. They always do a strategy study before reaching any conclusion.\r\n\r\nEven though these natives are not very creative, yet they always make wise and mature decisions. You may not see them discussing their plans with others as they live in their own bubble. Their ideas are very innovative and original. These natives are very hardworking and disciplined, especially in their workplace. However, on the other hand, they are not very empathetic and compassionate towards people and may hurt someone intentionally.\r\n\r\nThey are also very conservative and traditional. Since these people lack empathy, they fail to understand other people’s feelings and emotions. Their planning is immaculate and they follow it religiously. They love to be in control and when they lose that control, they might get depressed. They believe that their purpose is to keep things in order and to gain more authority. However, when things do not go as per their expectations, they feel stressed and disturbed.\r\n\r\nIf they understand that challenges come to make them better and not bitter, they will be able to achieve their spiritual goals.";
                                case EnumRasi.Kumbha: return "Unconventional and extraordinary are the most suitable words for the natives having Neptune in their Aquarius sign. They have a creative mental outlook. They want to change or modify the social and cultural norms of society. They are easy-going people with a casual sort of attitude towards things.\r\n\r\nBeing a humanitarian, they try to protect human dignity without expecting anything in return. However, their way of helping people might be unique and different. They believe in transforming the world and making it a better place.\r\n\r\nThis combination of Neptune in Aquarius may make you a rebellious person who likes to break the rules for the wellbeing of the masses. They are highly intelligent beings and do not follow anything blindly.\r\n\r\nLogic-driven in everything they do, they never follow the path chosen by any society. However, it does not mean that they do not have a large friends circle. They do not believe in doing deep research and make their own decisions based on their thought process. Creating something new and unique, makes them feel enlightened. They spend most of their time and energy only on things, which they consider are important. They hardly believe in the social norms and regulations. Being independent and working for a social cause is their way of fulfilling their purpose on this planet.\r\n\r\nIf they learn not to discard everything that seems conventional to them and become slightly more empathetic towards people, then they will have a friction-free spiritual journey.";
                                case EnumRasi.Meena: return "This is the most selfless position of Neptune. Pisces natives having Neptune in their chart are the real givers of the society. They can sacrifice their comfort for others' happiness. Independence is their key to spiritual growth. They become addicted to things quite easily. They are naturally gifted with mystic and occult knowledge. They can be a great healer in this psychic world. They are highly imaginative, intuitive, spiritual in real terms, empathetic, and caring towards people. However, these people daydream a lot, and they are much disorganized.\r\n\r\nThey are far from being practical and find their happiness in making sacrifices for others. They have strong imagination power and fantasize too much. Despite having numerous thoughts running through their mind, they are unable to take practical action in life. One of the biggest problems they face is the lack of discipline. However, on the other hand, their intuition helps them understand the needs of others. This is why they always put themselves in other person's shoes before making the final call. Being empathetic is good but, it gives allows others to take advantage of you.";
                            }
                            break;
                        }
                    case EnumPlanet.Pluto:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "You radiate intensity, and others’ first impressions of you tend to be strong, one way or the other! In fact, you might often intimidate others with your manner, whether it’s your intention or not. You can be very protective of your privacy, yet you generate much intrigue and interest with your strong presence.\r\nYou might struggle with fears of being overpowered, rejected, or minimized, yet few are able to guess that you could be anything less than confident. Your first instinct in new situations is gutsy and determined, defensive and intense. You rarely accept the obvious or the surface of matters — instead you look through situations in order to read any information on hidden levels. Your challenge is to strive to avoid getting your back up more than is necessary and viewing life as a battleground.";
                                case 2: return "When it comes to building your resources, your instincts are powerful. It’s not very easy for you to let go of things, as you attach much sentimental value to your possessions. Or, you might hold on to things because you fear poverty or because you fear the feeling of helplessness and wanting. Some with this placement feel a powerful need for control over their money and possessions. You could be driven to make money.\r\nOthers taking something from you without asking, even right in front of you, could be especially irritating to you. It’s not about being stingy–you simply have a strong sense of ownership and prefer that you are asked. You may experience some form of loss in your life that leads to lessons of change–you learn that strength, worth, value, and wealth come from within.\r\nWith finances, you are excellent at strategy and planning. You can spot a good deal or objects of value instinctively. Your advice on these matters can be invaluable to others.";
                                case 3: return "You rarely accept what you hear or what you read as truths. Your mind is very analytical and you instinctively search for hidden meanings. You can be exceptionally persuasive in your self-expression, whether through the spoken or written word, simply because you communicate with authority, conviction, strength, and decisiveness.\r\nYou tend to learn through observation rather than by asking questions. In fact, you may be somewhat resistant to learning directly from others, preferring to self-teach. You might fear the loss of self through self-expression, and thus you might choose your words carefully as to avoid letting others know too much about you.";
                                case 4: return "Early experiences may have led you to feel self-protective or to be secretive about yourself. A parent might have been secretive or ashamed, for example, and this pattern is deeply ingrained in your psyche. You might feel a sense of guilt about where you came from, even if you mostly feel proud of your roots.\r\nA parent or parent figure might have encouraged you to look beyond the surface of matters, and might have encouraged in you a love for psychology. That person may have been very protective of you, attempting to shield you from negative experiences, and you subsequently grew to fear change. Or, your early experiences might have included a shocking, intense, or scary event that lives within you. Alternatively, you might have absorbed the strong fears or obsessions of a parent/parental figure.\r\n";
                                case 5: return "You possess powerful creative impulses, and you can invest much energy and passion into the creative arts, romance, or child-rearing. You take great pride in– and invest much of your ego into–whatever it is you produce or create.\r\nRomance for you needs to be intense, passionate, and deeply intimate–nothing superficial or light attracts. You have an “all or nothing” attitude in love.\r\nIf you are not “owning” this attitude/energy, then you may be meeting Pluto energies through your lovers, and thus attracting intense, controlling, or passionate romantic partners. A deep-seated fear of loss or betrayal can be behind any jealous, obsessive, or controlling behavior in fifth house areas, including romantic involvements, child-rearing, and creative endeavors.";
                                case 6: return "You are a hard worker and can be quite protective or private when it comes to your work output. While you’re excellent at analysis,  you can also easily become obsessed with finding an answer to problems, perhaps even finding problems that others overlook.\r\nYou “come alive” when presented with a problem that requires research and analysis. Work can become an obsession for you, and you are able to work almost tirelessly.\r\nYou might be private or insular when it comes to your work, and you might also feel overly attached to what you do even to the point of paranoia. Fear of criticism can run high with your work. Directing your own work or working for yourself may be the best route for you, as you can easily resent others controlling your schedule and the work that you do.";
                                case 7: return "With Pluto in the seventh house of the horoscope, power struggles in close personal relationships are themes. This can play out in a variety of ways. You might simultaneously fear and desire complete absorption in a close one-to-one relationship. You can find yourself both drawn to and resistant of close partnerships, fearing loss of control over your own life. People who are intense, jealous, possessive, obsessive, or seem powerful tend to draw you in.\r\nOn the other hand, your resistance can bring out control issues in a partner, who fears the loss of you or your betrayal. In fact, you might bring out the “worst” in others by your relationship behavior — you tend to be the catalyst for others to discover their more primal instincts and fears. Never underestimate your role in this interplay.";
                                case 8: return "You have a natural attraction to all that is hidden, taboo, or “dark.” This fascination can lead you to experience more unusual events than others. A natural psychologist, you are expert at cutting through appearances and getting to the heart of matters.\r\nYou are endlessly interested in motivations and sources. Hypnosis, healing therapies, occult sciences, as well as great mysteries and the darker side of life can be fascinating to you.\r\nSexual relationships are very intense and perhaps complicated. You are both fascinated with and fearful of deep intimacy, and crave unusually deep, passionate, and intense experiences with others. This fascination can bring you intense experiences with others, and attraction to nontraditional sexual experiences, particularly those that involve domination and submission, control, and possession.";
                                case 9: return "You are extremely attached to your opinions and belief system. Due to this attachment, debates might too easily turn into arguments if you are not careful. You are persuasive and intelligent with a probing and incisive mind. Your opinions are strong and well-researched. You are able to back up your arguments, and enjoy doing so! At your worst, you can be obsessed with “converting” others to your beliefs.\r\nNaturally suspicious of new ideas until you’ve given them deeper thought, you can also have some disdain for hypocrisy and blind followers of belief systems.\r\nOthers can consider you to be deep or profound, and you are likely to come up with some unusual and unique ideas that impress others. Your sense of adventure runs deep and can lead you to unusual experiences. You are likely to make an involved, captivating, and inspiring teacher, speaker, or lecturer.";
                                case 10: return "There is something very unique about you that makes you stand out from the crowd. Your ambition is well-developed, or you pursue your goals with great focus and determination. You can have a strong interest in research, making improvements, understanding how things work, and transformation. These are qualities that you use most notably in your career or in your dealings with the public. Some of you could have a parent or parental figure who was quite driven or worked in healing or research professions.\r\nYour personal presence is strong, and you may find that you inspire love-hate reactions as a result, particularly in your professional experiences. Nevertheless, you can be very persuasive when you choose to be.";
                                case 11: return "You can have an “all or nothing” approach to your friendships or group associations, and power or control issues can frequently surface. As well, your social life may go through rather drastic changes. Friendships might often begin with intensity. Loyalty is most important to you in even a casual relationship.\r\nYou believe in the power of the group to effect necessary changes, and you could make an influential leader if it interests you, but you don’t take an association lightly. Easily moved by the plights of humankind, you may feel compelled to make a difference, particularly later in life. You refuse to be a follower!\r\n*You may have a deep aversion to groups, associations, clubs, or organizations of any kind. Any such group you become involved in is likely to be either for intense personal growth, change, and healing, or centered around social change and revising society in some manner.";
                                case 12: return "You are inclined to go deep, explore the meaning of your dreams, and analyze your personal psychology. You’re also quite adept at comprehending others’ motives. It’s possible you discover that you have healing powers and that you tune in quite quickly to others’ struggles and vulnerabilities, understanding more than most.\r\nIt can be easy for you to become deeply involved when helping others, perhaps even at your own risk at times. You consider others’ backstories and have strong empathy as a result, with a sense that we’re all quite capable of good and evil.\r\nYou may, however, keep very many things to yourself, which could eventually impact your health. Ask yourself if some of your secrets are truly necessary, as your first instinct may be to keep things to yourself when a more direct approach would be less complicated.";
                                    return "";
                            }
                            break;
                        }
                    case EnumPlanet.Rahu:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "The first house or Ascendant is the house of self. It is associated with the overall personality of the native, both in the inner and the outer shell. Basically the head of the person, physical appearance, character, temperament, strengths and weaknesses are represented by this house.\r\nPresence of Rahu in the first house generally provides good results to the native. The native might even give sudden wealth.\r\nRahu represents shrewdness and wit, so the native with this placement is blessed with this quality of Rahu. Although, they might be quick-tempered but very sharp-minded and intelligent and are able to achieve a higher position in their work.\r\nIf badly aspected, Native could be very conscious about the way they look and as Rahu likes all the glitter and shimmer, they could be easily manipulated and cheated by the fake razzle-dazzle.";
                                case 2: return "The second house in Vedic astrology is mainly concerned with the immediate family and possessions with the native. Along with the native’s earning skills and capacity. Speech and intake of food are also seen from this house as it represents the throat.\r\nNative with this planetary position in their charts yearns to possess things. They have a strong desire to own money, food, valuables, knowledge, treasures and so on.\r\nRahu\r\nIn case of debilitated Rahu in the chart, it might create problems with acquiring and saving the money, as the native is hardly able to save before the age of 30-32.\r\nIt also gives the native a tendency to move out and stay away from the family because of the unnecessary arguments with relatives and the members of the family.\r\nThe native might also acquire comprehensive knowledge about different languages, mostly in order to stay connected to high-ranking lineage and historic values.";
                                case 3: return "The third house is associated with self-expression, siblings, relative, neighbours and native’s immediate environment. Plus, it also signifies Native’s courage, short trips or running errands etc.\r\nThe third house also signifies Gemini sign which is a friendly sign of Rahu which also denotes communication, computer related and technical fields. If Planet Rahu is well aspected here, the native gets benefits through fields related to communication and media.\r\nA lot of renowned politicians and actors have this position in their natal chart. Presence of Rahu in this house makes the native clever and they know exactly how to use their position in order to make solid earnings.\r\nNatives are likely to possess solid intuition and psychic abilities. Knowing exactly how to exercise those skills in order to understand the thought process of the other person makes it even better.";
                                case 4: return "The Fourth house represents Native’s childhood, mother, motherly love and nourishment, home, real estate, early childhood and the way they’re likely to treat their family.\r\nPeople with this placement are said to be firmly embedded in their family and home culture. They have a strong desire to own home, land and properties.\r\nSince Rahu represents foreign things, it makes the native move around a lot in their life. It can take the person to even foreign lands because, Rahu aspects the 12th house from here, the house of foreign lands and abroad settlements.\r\nHowever, the presence of Rahu in the 4th house may disturb native’s concentration. Native’s peace of mind is mostly lost for one reason or the other.\r\nNative likes to pay a lot of attention to his home decoration, furnishing and styling and would like to be recognized for that.";
                                case 5: return "It’s the house of pleasures. This house represents how the native likes to express himself creatively and what they consider as fun. It is also associated with the children, intelligence of a person, the knowledge of politics.\r\nPresence of planet Rahu in the 5th house wants to achieve creativity, social status and the celebrity realm but mostly in the political sphere. Native loves to take centre stage and are big on things that involve creativity, art and gambling.\r\nThis positioning might disturb native’s relation with his children or father. Nevertheless, it favours adoption.\r\nWith malefic exalted Rahu placed in the fifth house of the native’s horoscope can disturb the native with problems related to his marriage, carrier, finances, reputation, children, health and many other types of problems.";
                                case 6: return "This is the house of conflicts, wars, diseases, enemies. It also indicates the kind of services the native provides for humanity, it describes the way the native is going to be fruitful for the society.\r\n6th house is considered as a positive location for Rahu. In here, the native likes to take benefit of the privileges associated with dominance. These people are experts in handling conflicts sensibly, fairly and efficiently.\r\nNatives with Rahu in their 6th house might have to go through lots of hardships in their life but eventually, get success by providing services to others. However, the enemies might not be able to harm him.\r\nIf Rahu is well aspected here, an abundance of wealth or gains through inheritance is also observed with this placement in one’s birth chart. The native would be quite a courageous and bold person.";
                                case 7: return "7th house is the house of legal bindings like marriage, business partnership, sexual relationship, laws. It also represents other people, like your public life.\r\nPresence of Rahu in this house is not considered very auspicious. It makes the native to be surrounded with people who appear to be friendly but aren’t actually trustworthy.\r\nNative may face trouble in marriage and other partnerships which might result in creating enemies around. These people remain dissatisfied in relationships.\r\nHowever, this position might even bring sudden gains to the natives. They might even have profits or losses by being involved in litigation, loans, bankruptcy or divorce.\r\nThe inherent taboo-breaking nature of Rahu makes the native challenge the mainstream ways and methods of partnership and conflict management in society.";
                                case 8: return "The 8th house in Vedic astrology represents marriage, corporate resources and the property or money inherited. It’s also the house of hidden matters like taxes, occult, mysticism, death and rebirth.\r\nIn this house, Rahu deals with secrecy. Its a beneficial placement for the people involved in fields that involve high risk like native working as a detective, intelligence officer, secret investigator etc.\r\nKnowledge and wealth are the major factors that the native looks for in his/her other half. That’s what attracts them the most. These people also love to deal with the matters that are hidden behind the curtains, risky secrets and confidential information.\r\nRahu in the 8th house also brings about a lot of unexpected changes in the native’s life. These changes sometimes affect them negatively.";
                                case 9: return "9th house is the house of religion, spirituality, house of your teachers, law and the house of the father. It also signifies long journeys like pilgrimage, fortune and luck.\r\nRahu in 9th house makes the native an extremist. It indicates native’s inclination towards religious and higher learnings and the presence of Rahu creates an obsession with the things. So, the native is likely to be obsessed with the idea of developing higher wisdom in life.\r\nNative gets happiness by devoting himself and his energy into mystical and enlightening aspects of life. They are likely to travel foreign lands and pilgrimages as Rahu itself represents foreign things.\r\nThe father of the native may also use their spiritual heights as a source of empowerment and advantage. A badly aspected Rahu in 9th house gives wisdom that is, in some cases faked than earned genuinely.";
                                case 10: return "In Vedic astrology, 10th house is considered as the house that represents career or profession. It shows if the person will achieve fame and grandness in his life. It is also the house father.\r\nPlacement of Planet Rahu in the 10th house of a natal chart is considered quite favourable for the native as it mostly provides good results and makes the native a workaholic personality.\r\nThe native tends to be very hardworking and intelligent with the capability of reaching heights of their career through their strong will and pure dedication. He will be a well- respected and has a prominent personality in his career and society.\r\nAn afflicted Rahu, on the other hand, may give adverse effects to the native with his professional life as it might develop laziness and irregularity at work.";
                                case 11: return "The 11th house is a strong indicator of sudden wealth and gains. It represents prosperity, sudden income and good wealth. This is also the house that depicts one’s social circle.\r\nFrom the material point of view, Rahu in the 11th house is an excellent placement. As it gives heavy emphasis on connecting the native with people who share similar interests in social groups and friends.\r\nNative is blessed with influential, wealthy and powerful friends, he gets great happiness and support from his social connections both materially and emotionally.\r\nAlong with that, the native should have to be cautious and beware of his enemies in the form of friends as there are chances of betrayal and backstabbing through them. Nevertheless, this is a marvellous position for multi-level or network marketers.";
                                case 12: return "It’s the house of secrets, fears, the subconscious mind and isolated places. It also represents liberation and detachments from the materialistic desires of life and indicates native’s strong inclination towards spirituality.\r\nUnder the benefic influence of Planet Rahu in the 12th house, it is likely to provide the native with the benefits from hospital, jail or isolated places like some foreign land.\r\nHowever, this positioning mostly gives malefic effects to the native. Expenses are likely to be more than earning an abundance of health-related issues might trouble him.\r\nThis tough placement can encourage the native to choose a religious and spiritual path in order to get free from the harsh reality and it will also incline the native to spend more and more money towards social works and charity.";
                            }
                            break;
                        }
                    case EnumPlanet.Kethu:
                        {
                            switch (this.HouseNumber)
                            {
                                case 1: return "The first house or Ascendant is the house of self. It is associated with the overall personality of the native, both in the inner and the outer shell. Basically the head of the person, physical appearance, character, temperament, strengths and weaknesses are represented by this house.\r\nKetu in ascendant gives the native a dynamic and magnetic personality. These people like to travel a lot to fulfil their sense of adventure in life.\r\nIf Ketu is well-aspected in this house, it makes the native hard working, wealthy and blessed. But he is always concerned and anxious because of his children.\r\nThe native should keep himself away from the bad company. There’s also tendency that the native might become self- centred and greedy at times. An afflicted Ketu in the 1st house might also affect native’s health and stamina.";
                                case 2: return "The second house in Vedic astrology is mainly concerned with the immediate family and possessions with the native. Along with the native’s earning skills and capacity. Speech and intake of food are also seen from this house as it represents the throat.\r\nIf Ketu is well aspected in this house of native’s Kundali, it makes the native a well-informed and knowledgeable person. These are the people who tend to have a way with word and are quite expressive.\r\nHowever, in the case of afflicted Ketu in this position, it might bring about problem in learning things and speech disorders like stammering etc.\r\nKetu itself is the planet of detachments. Its presence in the second house might make the native detach from its immediate family. These people are likely to struggle to have a good relationship with their family.";
                                case 3: return "The third house is associated with self-expression, siblings, relative, neighbours and native’s immediate environment. Plus, it also signifies Native’s courage, short trips or running errands etc.\r\nKetu usually shows favourable results to the native when positioned in the 3rd house. The native tends to be renowned, wealthy and successful in his life.\r\nTravelling for the native proves to be fruitful and productive. Hence, they get to travel a lot and are likely to have good earnings from it. The native also likes to take part in spiritual and religious activities so that he could attain fame and name in those fields.\r\nAlthough, when in case of afflicted Ketu in this house, it complicates the native’s bond with its siblings. There’s also a tendency that the native might have to spend on a legal complication with his siblings.\r\nIt can also make native’s relationship with his colleagues and associates a little hostile he should give a proper attention in order to preserve a good relationship with the people around.";
                                case 4: return "The Fourth house represents Native’s childhood, mother, motherly love and nourishment, home, real estate, early childhood and the way they’re likely to treat their family.\r\nWith Ketu in the 4th house, there’s a possibility that the native will move away from his native place to a foreign land as Ketu represents detachments and 4th house is the house of home and native places ruled by the moon. And Moon doesn’t share a friendly bond with Ketu.\r\nBecause 4th house also represents mother and motherly love, Health of native’s mother tends to be a matter of concern in native’s life. In some cases, the relation with the mother may also not be very pleasant and warm.\r\nOther aspects of the 4th house like peace of mind, happiness and matters related to family and property also tend to be a matter of worry in native’s life and should be properly taken care of.";
                                case 5: return "It’s the house of pleasures. This house represents how the native likes to express himself creatively and what they consider as fun. It is also associated with the children, intelligence of a person, the knowledge of politics.\r\nThe native usually has a special inclination towards philosophical learnings. These people have a bent towards matters concerning religions and spirituality. These people might even get involved in research of such subjects.\r\nPresence of Ketu in the house of mysticism and occult render the native a tendency to bend towards matters concerning occult sciences and in some cases, black magic too.\r\nProgeny might become one of the concerning issues in the native’s life as it might cause delays in the childbirth or might lead to miscarriages or abortions.";
                                case 6: return "This is the house of conflicts, wars, diseases, enemies. It also indicates the kind of services the native provides for humanity, it describes the way the native is going to be fruitful for the society.\r\nPlacement of Ketu in the 6th house may make the native prone to accidents and injuries. This position might cause lots of obstructions and obstacles in the native’s life.\r\nNevertheless, these people have the ability to rise above all the difficulties and attain success through their hard work and sweat.\r\nIf Ketu is badly afflicted in this position, the native might possess an intense attitude too. Such a person can also get involved in any criminal or fishy activity. This is also an inauspicious placement of Ketu for maternal relatives as it might cause a lack of peace and happiness in the family.";
                                case 7: return "7th house is the house of legal bindings like marriage, business partnership, sexual relationship, laws. It also represents other people, like your public life.\r\nKetu’s placement in the 7th house is not considered very auspicious in the Vedic astrology. It can bring about some chances of hardship in the native’s life regarding marriage and partnership.\r\nThe native might have a non-communicative and secretive partner. The marital life of the native might suffer because of certain health issues affecting one’s sexual life.\r\nThere could be frequent conflicts, misunderstandings and arguments between native and his partner which could further lead to separation as Ketu depicts detachments. Besides, there’s also a chance of more than one marriage.\r\nThis placement is as unfavourable to the business partnership as well. There could be conflicts between business partners or the partnership may not flourish and produce profits.";
                                case 8: return "The 8th house in Vedic astrology represents marriage, corporate resources and the property or money inherited. It’s also the house of hidden matters like taxes, occult, mysticism, death and rebirth.\r\nPlacement of Ketu in the eighth house shows a lack of auspiciousness and happiness. Native may face hurdles in earnings and financial matters. However, it shows good results regarding the mystical side of life.\r\nThese people are strongly inclined towards unearthly realms and there is a good likeliness that the native will opt Astrology or occultism as a profession.\r\nThis position also makes the native vulnerable to injuries due to weapons, heat, animals or insects. This person might even undergo some sort of surgeries too. However, they can expect some sudden wealth gains.";
                                case 9: return "9th house is the house of religion, spirituality, house of your teachers, law and the house of your father. It also signifies long journeys like pilgrimage, fortune and luck.\r\nKetu represents inclination towards liberty and freedom. Its placement here in the house of pilgrimages, luck, fortune, spirituality and higher learnings accents that nature of Ketu and the native travel more and more in order to amplify his spiritual and philosophical learnings.\r\nThe native tends to be a very religious person who is dedicated and likes to take their dedication seriously towards their religious beliefs and values.\r\nThis placement, however, Is not considered very favourable for the native’s father as they could face difficulties in their health. The native also might not share a very friendly and warm bond with his father.";
                                case 10: return "In Vedic astrology, 10th house is considered as the house that represents career or profession. It shows if the person will achieve fame and grandness in his life. It is also the house father.\r\nPresence of Ketu in the house of career, wealth and intelligence makes the native have a deep approach towards his family as well as his life.\r\nNative has a very strong personality and tend to gain power, good status, and wealth in his life with the well-aspected Ketu in the Kundli. These people have the propensity of acquiring knowledge and they tend to earn a lot of fame throughout their life.\r\nHaving great influence on people can give them an upper hand even to their enemies which help them lead the business. Their temperament nevertheless kind of lack positivity and pessimism.";
                                case 11: return "The 11th house is a strong indicator of sudden wealth and gains. It represents prosperity, sudden income and good wealth. This is also the house that depicts one’s social circle.\r\nWhen Ketu is placed in the 11th house, it mostly gives positive and favourable outcomes in the native’s life. It provides the native many sources of income flow and such a person never loses hope in the hardest times.\r\nThe native is likely to be a religious person and with the help of his spirituality and his faith, he has the ability to come out stronger out of difficult times. The person tends to be kind and charitable and most likely to be famous because of his nature and devotion towards his work.\r\nThe native is perfectly suitable for an administration job as they can easily handle any odd situation and may lead the organization strongly.";
                                case 12: return "This is the house of secrets, fears, the subconscious mind and isolated places. It also represents liberation and detachments from the materialistic desires of life and indicates native’s strong inclination towards spirituality.\r\nThis position may bring positive results in a native’s life. Because Ketu is also considered as the natural significator of the 12th house. The person tends to have an introverted personality with a spiritual bent of mind.\r\nNative is driven towards enlightenment and erudition as their ultimate goal in life. There’s also a tendency that the native might incline towards seclusion as they enjoy isolation and use aloofness at work to maintain focus and avoid drama.\r\nPresence of Ketu in this house also indicates the tendency of native to develop an interest in the subjects like occult and mystical science. Plus, these people also tend to grow in such fields and become one of the greatest occultists and astrologers with the well aspected Ketu.";
                            }
                            break;
                        }
                }
            }
            return "";
        }

        public EnumPlanetRasiRelationTypes GetRelationToRasi(EnumRasi rasi)
        {
            switch (this.Current)
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

        public int GetExtremeStateDegree()
        {
            switch (this.Current)
            {
                case EnumPlanet.Sun: return 10;
                case EnumPlanet.Moon: return 3;
                case EnumPlanet.Mars: return 28;
                case EnumPlanet.Mercury: return 15;
                case EnumPlanet.Jupiter: return 5;
                case EnumPlanet.Venus: return 27;
                case EnumPlanet.Saturn: return 20;
                case EnumPlanet.Rahu: return 3;
                case EnumPlanet.Kethu: return 3;
            }
            return 0;
        }

        public static string GetModeofEarnings(EnumPlanet planet)
        {
            switch (planet)
            {
                case EnumPlanet.Sun: return "From Father";
                case EnumPlanet.Moon: return "From Mother";
                case EnumPlanet.Mars: return "From Enemies";
                case EnumPlanet.Mercury: return "From Friends";
                case EnumPlanet.Jupiter: return "From Brothers";
                case EnumPlanet.Venus: return "From Ladies";
                case EnumPlanet.Saturn: return "From Workers/ Labours";
                case EnumPlanet.Rahu: return "";
                case EnumPlanet.Kethu: return "";
            }
            return "";
        }

        public bool IsWellPlaced()
        {
            return false;
        }

        public void UpdateViewDetails(List<AstroPlanet> completePlanetList)
        {
            this.ViewDetails = new AstroViewDetails(this, completePlanetList);
        }

        public string GetSpecialMessages()
        {
            SpecialMessage = "***";
            switch (this.Current)
            {
                case EnumPlanet.Sun: if (this.HouseNumber == 12) SpecialMessage += "12th - The Planet is in Place of Its Death."; break;
                case EnumPlanet.Moon:
                    {
                        if (this.HouseNumber == 8) SpecialMessage += "8th - The Planet is in Place of Its Death.";
                        if (this.Rasi.Current == EnumRasi.Meena 
                            || this.Rasi.Current == EnumRasi.Vrichika 
                            || this.Rasi.Current == EnumRasi.Mithuna) SpecialMessage += "High Intelligence.";
                       
                    }
                    break;
                case EnumPlanet.Mars: if (this.HouseNumber == 7) SpecialMessage += "7th - Mars if Celibate, here you ask to Marry. The Planet is in Place of Its Death."; break;
                case EnumPlanet.Jupiter: if (this.HouseNumber == 3) SpecialMessage += "3rd - Guru is told 'you don't meditate'. The Planet is in Place of Its Death."; break;
                case EnumPlanet.Kethu: if (this.HouseNumber == 4) SpecialMessage += "4th - Ketu is Nomads, here you ask him to build and live in a house. The Planet is in Place of Its Death."; break;
                case EnumPlanet.Venus: if (this.HouseNumber == 6) SpecialMessage += "6th - Venus goddess of marriage, here on 6th it become a celibate. The Planet is in Place of Its Death."; break;
                case EnumPlanet.Mercury: if ((this.HouseNumber == 4) || (this.HouseNumber == 7)) SpecialMessage += this.HouseNumber + "th - Mercury is ask to go to school (4th) or marry (7th). The Planet is in Place of Its Death."; break;
                case EnumPlanet.Saturn: if (this.HouseNumber == 1) SpecialMessage += "1st - Saturn is darkness, meet the light of 1st house. The Planet is in Place of Its Death."; break;
                case EnumPlanet.Rahu: if (this.HouseNumber == 9) SpecialMessage += "9th - Rahu is Devil, and he is asked to repeat the name of God of Dharma sthana. The Planet is in Place of Its Death."; break;
            }

            SpecialMessage += "\r\nCurrent Rashi: " + this.Rasi.Current.ToString();
            SpecialMessage += "\r\nThe planet bala is " + this.PlanetBala;
            SpecialMessage += "\r\nHora Adhipathi is \t\t\t " + this.RashyardhaHora.ToString() + "-" + ((this.Rasi.IsOddRashi && !this.IsGoodPlanet && this.RashyardhaHora == EnumPlanet.Sun) ? "Famous, Couregeous, Powerful" : (!this.Rasi.IsOddRashi && this.IsGoodPlanet && this.RashyardhaHora == EnumPlanet.Moon) ? "Mrudu, Nice Body, Attractive, Genius, Attractive Speach" : "");
            SpecialMessage += "\r\nLoard of the House is \t\t" + this.Rasi.Loard.Name;

            if (this.DroskanaAdhipathi != null)
                SpecialMessage += "\r\nThe DrosKana Adhipath is \t\t" + this.DroskanaAdhipathi.Current;
            if (this.SapthansaAdhipathi != null)
                SpecialMessage += "\r\nThe Sapthansa Adhipath is \t\t" + this.SapthansaAdhipathi.Current;
            if (this.NawamsaAdhipathi != null)
                SpecialMessage += "\r\nThe Nawamsa Adhipath is \t\t" + this.NawamsaAdhipathi.Current;
            if (this.DwadasansaAdhipathi != null)
                SpecialMessage += "\r\nThe Dwadasansha Adhipath is \t" + this.DwadasansaAdhipathi.Current;
            if (this.ThrishanshakaAdhipathi != null)
                SpecialMessage += "\r\nThe Thrishansa Adhipath is \t" + this.ThrishanshakaAdhipathi.Current;

            if (this.IsDigbala)
                SpecialMessage += "\r\nThe planet is in Digbala State.";
            if (this.HasSthanaBala)
                SpecialMessage += "\r\nThe planet has Sthanabala.";
            SpecialMessage += "\r\nPlanet Stage: " + this.PlanetStage.ToDetailString();
            if (this.IsMarakaPlanet)
                SpecialMessage += "\r\nThe planet is the Maraka Planet.";
            if (this.IsVargoththama)
                SpecialMessage += "\r\nThe planet is the Vargoththama State.";
            SpecialMessage += "\r\nRashi Adhipathies: \r\n" + this.Rasi.AdhipathiAstroPlanets.ToAstroPlanetString();
            SpecialMessage += "\r\nNawamsa Athipathies: \r\n" + this.NawamsaRasi.AdhipathiAstroPlanets.ToAstroPlanetString();
            if (this.IsExtremelyExalted)
                SpecialMessage += "\r\nExtreme: Planet is Extremely Extremely Exalted";
            if (this.IsExtremelyDebilitated)
                SpecialMessage += "\r\nExtreme: Planet is Extremely Extremely Debilitated";
            SpecialMessage += "\r\nKaraka: " + this.KarakaState.ToString();
            SpecialMessage += "\r\nAdhipathi Houses: " + this.AdhipathiHouses.ToJSON();
            SpecialMessage += "\r\nI See: " + AstroView.GetAllHousesPlanetSee(this.Current, this.HouseNumber).ToJSON();
            SpecialMessage += "\r\nNext Transit Date: " + this.NextTransitDateTime.ToShortDateString();

            if (this.IsTransitPlanet)
            {
                if (this.IsReversing && this.ReversingEndAt != null)
                    SpecialMessage += "\r\nReversing End Date: " + this.ReversingEndAt.GetValueOrDefault().ToShortDateString();
                else if (this.ReversingStartingAt.HasValue)
                    SpecialMessage += "\r\nReversing Start Date: " + this.ReversingStartingAt.GetValueOrDefault().ToShortDateString();
            }

            return SpecialMessage.Trim(new char[] { '\r', '\n' }) + "***";
        }

        public AstroRasi LagnaRasi { get; set; }
        public AstroRasi OriginalNawamsaRasi { get; set; }

        public AstroView Views { get; set; }

        public AstroViewDetails ViewDetails { get; set; }
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
        public bool IsVargoththama { get { return NawamsaRasi.Current == Rasi.Current; } }
        public bool IsDigbala { get; set; }
        public bool IsTransitPlanet { get; set; }
        public DateTime NextTransitDateTime { get; set; }
        public DateTime PreviousTransitDateTime { get; set; }
        public List<DateTime> NextTransitDateTimes { get; set; }
        public DateTime? ReversingEndAt { get; set; }
        public DateTime? ReversingStartingAt { get; set; }
        public int HouseNumber { get { return Rasi.HouseNumber; } }
        public Planet PlanetData { get; set; }
        public bool IsGoodPlanet { get { return AstroGoodBad.GetGoodPlanet().Contains(this.Current); } }

        public bool IsLord { get { return (Rasi.Loard.Name == this.Name); } }

        public int RashiAdhipathiScore { get; set; }

        public static EnumPlanet[] GetAllPlanets()
        {
            return (EnumPlanet[])Enum.GetValues(typeof(EnumPlanet));
        }

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
