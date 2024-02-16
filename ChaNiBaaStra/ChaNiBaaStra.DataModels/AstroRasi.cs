using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Handlers;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;
using Nido.Common.Extensions;

namespace ChaNiBaaStra.DataModels
{
    public enum EnumRasi
    {
        Any =0,
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
            if (WhoSeesMe == null)
                WhoSeesMe = new List<AstroPlanet>();
            ThathKalikaMythra = new List<AstroPlanet>();
            ThathKalikaSathuru = new List<AstroPlanet>();
            AdhipathiAstroPlanets = new List<AstroPlanet>();
        }

        public AstroRasi()
        { }

        public int HouseNumber { get; set; }

        public bool IsOddRashi { get { return (this.CurrentInt % 2 != 0); } }

        /// <summary>
        /// Aries (Mesh), Cancer (Kark), Libra (Tula) and Capricorn (Makara)
        /// </summary>
        public bool IsCharaRashi { get { return (this.CurrentInt % 3 == 1); } }

        /// <summary>
        /// Taurus (Rishaba), Leo (Simha), Scorpio (Vrishik), Aquarius (Kumbha)
        /// </summary>
        public bool IsThiraRashi { get { return (this.CurrentInt % 3 == 2); } }

        /// <summary>
        /// Gemini (Mithun), Virgo (Kanya), Sagittarius (Dhanus) and Pisces (Meen)
        /// </summary>
        public bool IsUbhayaRashi { get { return (this.CurrentInt % 3 == 0); } }

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
        public List<AstroPlanet> WhoSeesMe { get; set; }
        public List<AstroPlanet> ThathKalikaMythra { get; set; }
        public List<AstroPlanet> ThathKalikaSathuru { get; set; }
        public List<AstroPlanet> AdhipathiAstroPlanets { get; set; }
        public AstroPlanet Loard { get; set; }
        public AstroPlanet FirstDrosKanaAdhipathi { get; set; }
        public AstroPlanet SecondDrosKanaAdhipathi { get; set; }
        public AstroPlanet ThirdDrosKanaAdhipathi { get; set; }

        public List<EnumPlanet> AdhipathiEnumPlanets { 
            get
            {
                switch(this.Current)
                {
                    case EnumRasi.Mesha: { return new List<EnumPlanet>() { EnumPlanet.Mars, EnumPlanet.Sun, EnumPlanet.Pluto }; }
                    case EnumRasi.Vrishabha: { return new List<EnumPlanet>() { EnumPlanet.Venus, EnumPlanet.Moon, EnumPlanet.Rahu  }; }
                    case EnumRasi.Mithuna: { return new List<EnumPlanet>() { EnumPlanet.Mercury }; }
                    case EnumRasi.Kataka: { return new List<EnumPlanet>() { EnumPlanet.Moon, EnumPlanet.Jupiter, EnumPlanet.Neptune }; }
                    case EnumRasi.Simha: { return new List<EnumPlanet>() { EnumPlanet.Sun, EnumPlanet.Pluto }; }
                    case EnumRasi.Kanya: { return new List<EnumPlanet>() { EnumPlanet.Mercury, EnumPlanet.Rahu }; }
                    case EnumRasi.Thula: { return new List<EnumPlanet>() { EnumPlanet.Venus, EnumPlanet.Saturn }; }
                    case EnumRasi.Vrichika: { return new List<EnumPlanet>() { EnumPlanet.Mars, EnumPlanet.Kethu, EnumPlanet.Uranus }; }
                    case EnumRasi.Dhanus: { return new List<EnumPlanet>() { EnumPlanet.Jupiter}; }
                    case EnumRasi.Makara: { return new List<EnumPlanet>() { EnumPlanet.Saturn, EnumPlanet.Mars  }; }
                    case EnumRasi.Kumbha: { return new List<EnumPlanet>() { EnumPlanet.Saturn, EnumPlanet.Uranus }; }
                    case EnumRasi.Meena: { return new List<EnumPlanet>() { EnumPlanet.Jupiter, EnumPlanet.Venus, EnumPlanet.Kethu, EnumPlanet.Neptune }; }
                }
                return new List<EnumPlanet>();
            }
        }

        public int ofRasi(EnumRasi rasi)
        {
            IntCircle circle = new IntCircle(12, CurrentInt);
            return circle.Minus((int)rasi);
        }

        public int absoluteHouseFromRasi(EnumRasi rasi)
        {
            int rasiInt = (int)rasi;
            if (CurrentInt > rasiInt)
                return 13 - (CurrentInt - rasiInt);
            else
                return 1 + (rasiInt - CurrentInt);
        }

        public int absoluteGabOfRasi(EnumRasi rasi)
        {
            IntCircle circle = new IntCircle(12, CurrentInt);
            int addition = (int)rasi;
            if (addition < CurrentInt)
                addition = 13 - (CurrentInt - addition);
            else
                addition =  1+ (addition -CurrentInt);
            return circle.Add(addition);
        }

        public string GetPlanetOnRashiQuality(EnumPlanet planet)
        {
            return "";
        }

        public EnumPlanetRasiRelationTypes GetRelationToPlanet(EnumPlanet planet)
        {
            EnumRasi rasi = this.Current;
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

        public string GetRashiQuality()
        {
            switch (HouseNumber)
            {
                case 1:
                    return "First House, also known as ‘Lagna’ or ‘Ascendant’. It’s the house of self since it represents you and the way you look. Basically, your physical personality which includes physical appearance, temperament, nature, body frame, childhood, health, ego and their sense to self."
                                                + "\r\nIt affects your life choices, sense of knowing your strengths, weaknesses.Along with your likes, dislikes and the way you might wish others to perceive through your opinions, attitude and viewpoints."
                                                + "\r\nThe mains parts depicted by the 1st house are the head and the face. It includes complexion, forehead, hair, brain, etc.As per the Vedic horoscope, if your 1st house is weak, you may face problems like headache, acne, scars, etc. This house corresponds with Aries energy.";
                case 2:
                    return "The 2nd house in Vedic astrology is referred to as the house of possessions. It signifies Dhana or Income which includes the finances, the belongings that you own, possessions like car, furniture, investments etc. Using your possessions including your non-material things to the fullest also falls under the 2nd house’s realm. This house matches with Taurus."
                                                + "\r\nAn expert Vedic astrologer will tell you how the 2nd house rules body organs like tongue, teeth, eyes, mouth, nose and more. Also, the second house does not only limits the material holdings. It also comprises intangible things like one’s voice. For example, if a feminine planet like Venus sits in the second house of a person’s Kundali, his/her voice would be very appealing and melodious."
                                                + "\r\nPriyanka Chopra would be a great example of that. Our expert astrologers have checked her horoscope and found out that Mercury is there in its own house and is sitting with Venus which is the lord of Ascendant making her a great singer.";
                case 3:
                    return "The Third house relates to Gemini. It governs the mental inclination of a person and their ability to memorize. This house also relates to journeys, brothers, sisters, neighbours, interests, habits, mental intelligence and communication."
                                                + "\r\nThe 3rd house in Vedic astrology rules over different modes of communication, such as media, television, telephone, radio, writing, editing, etc. All sorts of professions related to communication are included in this dominion."
                                                + "\r\nThe body parts third house rules include legs, hands, arms, shoulders, collar bones, lungs, and nervous system. Imbalances in the nervous system, problems of the respiratory canal, shoulder pain, fracture in the collar bone and impartial deafness. Problems like these mainly arise out of a weak third house in your natal chart.";
                case 4:
                    return "The fourth house in Vedic astrology relates to Cancer. It rules your houses as well as your roots, land, real estate matters, vehicles and your relation with your mother. This house is also called Bandhu Bhava in Vedic astrology as it is quite associated with the domestic happiness of a person."
                                                + "\r\nThe body organs governed by the fourth house are the stomach breasts and digestive organs. And it may result in coronary problems, lung disorder, and physical ailment in breasts, chests and so on if the 4th house is weak in your horoscope.";
                case 5:
                    return "The fifth house in the Vedic horoscope, also known as Putra Bhava is the house of creativity, playfulness, joy, pleasure, and romance. It signifies your mental intelligence, your capability to create and innovate. The fifth house corresponds to Leo’s energy, the fifth sign in the Zodiac cycle. Since Jupiter signifies this house, which also relates to fortune, good luck, learning, and optimism."
                                                + "\r\nThe body parts that the fifth house rules over include the Heart, upper and middle back, stomach, pancreas, and spine. If the fifth house is weak in your horoscope, it may cause heart problems, spinal cord disorders, acidity, diarrhoea, stone in the gall bladder, etc."
                                                + "\r\nPlus if the house is oppressed by an air sign like Gemini or Aquarius, it may lead to mental illness or irrationality.";
                case 6:
                    return "This house corresponds mainly to your health, wellness, and your daily life routine. Surely the body you’re born with comes under the first house but the choices that you make on a daily basis, that affects your body are found in the 6th house in Vedic astrology."
                                                + "\r\n6th House is also known as Ari Bhava. Ari means ‘Enemy’ and hence this house also relates to debts, obstacles, enemies, and difficulties. However, a person having Rahu sat in the 6th house in his birth chart is nearly impossible to defeat. It corresponds with Libra Energy."
                                                + "\r\nThis house rules the body parts like waist, lower abdomen, kidney, navel, small intestine, the upper part of the large intestine, appendix, etc. A weak 6th house may cause sicknesses like constipation, appendicitis, hernia and even psychiatric problems.";
                case 7:
                    return "The 7th house in vedic astrology (descendent) sits directly across from the first house (Ascendant). This house is also known as Yuvati Bhava. It’s the house of your spouse/partner. It is also the house of all kinds of partnerships including business partnership and also deals with the darker side of your relationships, the partnerships you form. Planets moving through the Seventh House help you close deals, securing the bonds by signing contracts and making things official."
                                                + "\r\nAs this house is ruled by the Libra sign, the planet Venus is the natural significator of this house that also signifies love, romance, and sexuality."
                                                + "\r\nIt governs various body parts including Kidneys, ovaries and the lower half of the back.";
                case 8:
                    return "8th - In one way it is the death and re-brith of you while living in this life. It is the 8th house in Vedic astrology, also known as Randhra Bhava, rules over death, longevity and sudden events like Lottery such things that help you die and reborn. It is also related to wealth. Sudden losses, gains, the share of properties fall under the 8th house realm. If Saturn is sitting in the 8th house of one’s birth chart, the chances are that the person will inherit paternal property."
                                                + "\r\nThis house is also the house of mysteries and transformations. It can bring depression, chronic illness, miseries, lack of mental peace, imprisonment etc to the person affected. However, on a positive note, our Vedic astrologer claim that the native of the 8th house is ought to have strong intuitive skills and such people can also master the fields of psychology, astrology, mathematics, and paranormal activities. Several various body parts governed by this sign include pelvic bones and external sexual organs.";
                case 9:
                    return "Truth, principles, dreams, and intuitions all define the ninth house. Since this house is also known as Dharma Bhava in Vedic astrology, it deals with your religious instincts, immigration, good karma, dharma, ethics, higher learnings, one’s inclination towards good deeds and charity. The 9th house corresponds with Sagittarius energy which is signified by Jupiter that makes this house the house of luck, fortune, and favors."
                                                + "\r\nThe various parts of the body under control of this house are thighs, thigh bones, bone marrow, left leg, and arterial system."
                                                + "\r\nIf you have a strong 9th house in your birth charts, there are high chances of travel, higher learning, and foreign settlement.";
                case 10:
                    return "10th house, also known as Karma Bhava, deals with the kind of work you do, the profession you are in, your prestige, your reputation, etc. your area of occupation is defined by the planetary positions in this house. this house corresponds with the Capricorn energy and ruled by Saturn. if Saturn is in harmony with other planets in your natal chart, this planet can become the most powerful ally."
                                                + "\r\nDifferent body parts ruled by this house are knees, kneecaps, bones, and joints. A weakness of the 10th house in Vedic astrology may cause health-related problems like broken knees, inflammation of joints, weakness in the body and skin allergies, etc.";
                case 11:
                    return "Labha Bhava in Vedic astrology is the house of prosperity. ‘Labha’ means gains. It’s a strong indicator of wealth and income, gain in name, fame, and money, and also plays a role in determining what brings you profits. 11th House in Vedic astrology governs your social circle, your friends, acquaintances, your well-wishers and your relation with your elder brother."
                                                + "\r\n11th House in Vedic astrology relates to Aquarius and Sun is the natural significator of this House. Body parts that this house governs include ankle, right leg, shin bone, left ear, and left arm. A native with weak 11th house in their native chart may have to face problems of low productivity of blood, pain in legs, fracture in the lower part of the body, etc.";
                case 12:
                    return "Being the last house, the 12th house in Vedic astrology represents the ending of your life cycle and the beginning of your spiritual journeys. it is also called the house of unconscious, self- undoing, and imprisonment. A weak 12th house may give the native detachment from people like separation from their partner, parents, friends, and neighbors."
                                                + "\r\nThe detachment can also be in the form of death. Mostly it governs the intangible things. Things like intuitions, dreams, secrets, and emotions because this house corresponds with Pisces energy and is ruled by Neptune planet."
                                                + "\r\nThe twelfth house takes care of the body organs like the left eye, feet, and lymphatic system.";
            }
            return "";
        }

        public string GetPowerBasedOnViews()
        {
            string s = "";
            string tm = "\r\nThathkalika Mythra planets are ";
            string ts = "\r\nThathkalika Sathuru planets are ";
            foreach (AstroPlanet planet in this.WhoSeesMe)
            {
                if (planet.AdhipathiHouses.Contains(this.HouseNumber))
                    s += planet.Name + " - Rasi gives good results as adhipathi (" + planet.Name + ") of this House see it (+++)\r\n";
                s += planet.Name + ((planet.IsTransitPlanet) ? "- Transit Planet -" : "- Natal Planet -") + planet.Name + " (" + ((planet.IsGoodPlanet) ? "Good Planet" : "Bad Planet") + ")" + " at " + planet.HouseNumber;
                if (planet.IsAstha || planet.IsDebilitated || !planet.IsPowerful)
                    s += " sees the house while placed in a weaker rashi hence reduce result (-)\r\n";
                else
                    s += " sees the house while placed in a stronger rashi hence increase result (+)\r\n";

                if (((planet.HouseNumber == 6) || (planet.HouseNumber == 8) || (planet.HouseNumber == 12))
                    && planet.AdhipathiRasis.Contains(this.Current))
                    s += planet.Name + "Adhipathi of this rashi (" + planet.Name + ") placed on " + planet.HouseNumber + " House hence rashi reduce result (-)\r\n";
            }

            IEnumerable<string> mplanets = ThathKalikaMythra.Select(x => x.Name);
            foreach (string planet in mplanets)
                tm += planet + ", ";

            IEnumerable<string> splanets = ThathKalikaSathuru.Select(x => x.Name);
            foreach (string planet in splanets)
                ts += planet + ", ";

            s += tm;
            s += ts;
            if ((this.HouseNumber == 1) || (this.HouseNumber == 4) || (this.HouseNumber == 7) || (this.HouseNumber == 10))
                s += "\r\nThis Rashi is lagna rashi hence very powerful (++++)";
            else if ((this.HouseNumber == 2) || (this.HouseNumber == 5) || (this.HouseNumber == 8) || (this.HouseNumber == 11))
                s += "\r\nThis Rashi is Panapara rashi hence medium powerful (++)";
            else if ((this.HouseNumber == 3) || (this.HouseNumber == 6) || (this.HouseNumber == 9) || (this.HouseNumber == 12))
                s += "\r\nThis Rashi is Apoklima rashi hence low powerful (+)";

            s = s.TrimEnd(',');
            s += "\r\nRashi Adhipathies: " + this.AdhipathiAstroPlanets.ToAstroPlanetString();
            return s;
        }

        public static EnumRasi[] GetAllRashes()
        {
            return (EnumRasi[])Enum.GetValues(typeof(EnumRasi));
        }

        /// <summary>
        /// Increment has to be 1 less than the actual house
        /// </summary>
        /// <param name="increment"></param>
        /// <returns></returns>
        public EnumRasi GetIncrementRashi(int increment)
        {
            return (EnumRasi)AstroUtility.AstroCycleIncrease(this.CurrentInt, increment);
        }

        public void FinalActions()
        {
            RashiAdhipathiFinder finder = new RashiAdhipathiFinder();
            this.AdhipathiAstroPlanets = finder.UpdateRashiAdhipatiScore(this.AdhipathiAstroPlanets, this);
        }
        /// <summary>
        /// Neecha or Sathuru
        /// </summary>
        /// <param name="planet"></param>
        /// <returns></returns>
        public List<int> GetDebilitatedHouses(EnumPlanet planet)
        {            
            List<int> result = new List<int>();
            string t = new AstroRasi(this.Current).GetRelationToPlanet(planet).ToString();
            if (t.Contains("Neecha") || t.Contains("Sathuru"))
                result.Add(1);

            for (int i = 1; i <= 11; i++)
            {
                EnumRasi rasi = GetIncrementRashi(i);
                AstroRasi aRasi = new AstroRasi(rasi);
                string temp = aRasi.GetRelationToPlanet(planet).ToString();
                if (temp.Contains("Neecha") || temp.Contains("Sathuru"))
                    result.Add(i + 1);
            }
            return result;
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
