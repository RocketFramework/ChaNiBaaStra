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

        public bool IsBhavaView { get; set; }
        public AstroPlanet MostPowerfulPlanet { get; set; }

        public int IsMaleHoroscope()
        {
            int isMale = 0;

            if (LagnaRasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (NavamsaRasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;

            if (CurrentTransitDate.Sun.Rasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (CurrentTransitDate.Sun.NawamsaRasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (CurrentTransitDate.Sun.PlanetRasiRelation < EnumPlanetRasiRelationTypes.Mithra)
            {
                if (CurrentTransitDate.Sun.Rasi.IsMaleRashi) isMale += 1;
                else isMale -= 1;
                if (CurrentTransitDate.Sun.NawamsaRasi.IsMaleRashi) isMale += 1;
                else isMale -= 1;
            }

            if (CurrentTransitDate.Jupiter.Rasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (CurrentTransitDate.Jupiter.NawamsaRasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (CurrentTransitDate.Jupiter.PlanetRasiRelation < EnumPlanetRasiRelationTypes.Mithra)
            {
                if (CurrentTransitDate.Jupiter.Rasi.IsMaleRashi) isMale += 1;
                else isMale -= 1;
                if (CurrentTransitDate.Jupiter.NawamsaRasi.IsMaleRashi) isMale += 1;
                else isMale -= 1;
            }

            if (CurrentTransitDate.Moon.Rasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (CurrentTransitDate.Moon.NawamsaRasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (CurrentTransitDate.Moon.PlanetRasiRelation < EnumPlanetRasiRelationTypes.Mithra)
            {
                if (CurrentTransitDate.Moon.Rasi.IsMaleRashi) isMale += 1;
                else isMale -= 1;
                if (CurrentTransitDate.Moon.NawamsaRasi.IsMaleRashi) isMale += 1;
                else isMale -= 1;
            }

            if (CurrentTransitDate.Mars.Rasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (CurrentTransitDate.Mars.NawamsaRasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (CurrentTransitDate.Mars.PlanetRasiRelation < EnumPlanetRasiRelationTypes.Mithra)
            {
                if (CurrentTransitDate.Mars.Rasi.IsMaleRashi) isMale += 1;
                if (CurrentTransitDate.Mars.NawamsaRasi.IsMaleRashi) isMale += 1;
            }

            if (CurrentTransitDate.Venus.Rasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (CurrentTransitDate.Venus.NawamsaRasi.IsMaleRashi) isMale += 1;
            else isMale -= 1;
            if (CurrentTransitDate.Venus.PlanetRasiRelation < EnumPlanetRasiRelationTypes.Mithra)
            {
                if (!CurrentTransitDate.Venus.Rasi.IsMaleRashi) isMale -= 1;
                if (!CurrentTransitDate.Venus.NawamsaRasi.IsMaleRashi) isMale -= 1;
            }

            List<int> saturnList = new List<int>() { 3, 5, 7, 9, 11 };
            if (saturnList.Contains(CurrentTransitDate.Saturn.HouseNumber))
                isMale += 1;

            return (isMale > 0) ? 100 : 0;
            /*
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
            */
            //return 0;
        }

        public string GetSpecialMessages()
        {
            string message = "";
            List<AstroPlanet> eightAdhipathis = this.CompletePlanetList.Where(x => x.AdhipathiHouses.Contains(8)).ToList();
            foreach (AstroPlanet planet in eightAdhipathis)
                if (planet.Views.TheyCanSeeMee.Where(x => x.MelificOrBenific == PlanetTypes.Melific).Count() > 0)
                    message = "Accident Prone until - " + planet.NextTransitDateTime.ToShortDateString();
            return message;
        }

        public static int GetExtremeStateDegree(EnumPlanet enumPlanet)
        {
            switch (enumPlanet)
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

        public static EnumPlanetRasiRelationTypes GetPlanetRelationToRasi(EnumPlanet planet, EnumRasi rasi)
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

    }
}
