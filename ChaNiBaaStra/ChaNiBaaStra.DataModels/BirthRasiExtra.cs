using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;

namespace ChaNiBaaStra.DataModels
{
    public class BirthRasiExtra
    {
        public BirthRasiExtra(Horoscope birthHoroscope)
        {
            SubhaPlanets = new List<AstroPlanet>();
            AsubhaPlanets = new List<AstroPlanet>();
            MarakaPlanets = new List<AstroPlanet>();
            YogakarakaPlanets = new List<AstroPlanet>();

            AstroPlanet sun = birthHoroscope.RasiPlanetList.FirstOrDefault(x => x.Current == EnumPlanet.Sun);
            AstroPlanet moon = birthHoroscope.RasiPlanetList.FirstOrDefault(x => x.Current == EnumPlanet.Moon);
            AstroPlanet mars = birthHoroscope.RasiPlanetList.FirstOrDefault(x => x.Current == EnumPlanet.Mars);
            AstroPlanet mercury = birthHoroscope.RasiPlanetList.FirstOrDefault(x => x.Current == EnumPlanet.Mercury);
            AstroPlanet jupiter = birthHoroscope.RasiPlanetList.FirstOrDefault(x => x.Current == EnumPlanet.Jupiter);
            AstroPlanet venus = birthHoroscope.RasiPlanetList.FirstOrDefault(x => x.Current == EnumPlanet.Venus);
            AstroPlanet saturn = birthHoroscope.RasiPlanetList.FirstOrDefault(x => x.Current == EnumPlanet.Saturn);
            LagnaAdhipathiPlanets = new List<AstroPlanet>();

            AstroPlanet[] filterer = new AstroPlanet[12];
            birthHoroscope.RasiPlanetList.CopyTo(filterer);
            List<AstroPlanet> filtered = new List<AstroPlanet>();
            filtered.AddRange(filterer);
            filtered.RemoveAll(x => x.Current == EnumPlanet.Uranus ||
            x.Current == EnumPlanet.Neptune ||
            x.Current == EnumPlanet.Pluto ||
            x.Current == EnumPlanet.Rahu ||
            x.Current == EnumPlanet.Kethu);

            this.AathmaKaraka = filtered.OrderByDescending(x => x.AjustedLongitude).FirstOrDefault();
            this.AathmaKaraka.KarakaState = PlanetKarakaStates.AathmaKaraka;
            this.AmathyaKaraka = filtered.OrderByDescending(x => x.AjustedLongitude).ElementAt(1);
            this.AmathyaKaraka.KarakaState = PlanetKarakaStates.AmathyaKaraka;
            BradhariKaraka = filtered.OrderByDescending(x => x.AjustedLongitude).ElementAt(2);
            this.BradhariKaraka.KarakaState = PlanetKarakaStates.BradhariKaraka; 
            MathruKaraka = filtered.OrderByDescending(x => x.AjustedLongitude).ElementAt(3);
            this.MathruKaraka.KarakaState = PlanetKarakaStates.MathruKaraka; 
            PithruKaraka = filtered.OrderByDescending(x => x.AjustedLongitude).ElementAt(4);
            this.PithruKaraka.KarakaState = PlanetKarakaStates.PithruKaraka; 
            GnathiKaraka = filtered.OrderByDescending(x => x.AjustedLongitude).ElementAt(5);
            this.GnathiKaraka.KarakaState = PlanetKarakaStates.GnathiKaraka; 
            DhaaraKaraka = filtered.OrderByDescending(x => x.AjustedLongitude).ElementAt(6);
            this.DhaaraKaraka.KarakaState = PlanetKarakaStates.DhaaraKaraka;
            switch (birthHoroscope.LagnaRasi.Current)
            {
                case EnumRasi.Mesha:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { jupiter, mars, sun, moon };
                        List<AstroPlanet> asup = new List<AstroPlanet> { mercury, venus, saturn };
                        List<AstroPlanet> yop = new List<AstroPlanet> { jupiter };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, venus, saturn };
                        LagnaAdhipathiPlanets.Add(mars);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 11;
                    }
                    break;
                case EnumRasi.Vrishabha:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { sun, mars, mercury, venus };
                        List<AstroPlanet> asup = new List<AstroPlanet> { moon, venus, jupiter };
                        List<AstroPlanet> yop = new List<AstroPlanet> { saturn };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, venus };
                        LagnaAdhipathiPlanets.Add(venus);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 9;
                    }
                    break;
                case EnumRasi.Mithuna:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { saturn, venus };
                        List<AstroPlanet> asup = new List<AstroPlanet> { sun, mars, jupiter };
                        List<AstroPlanet> yop = new List<AstroPlanet> { venus, mercury };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mars, jupiter };
                        LagnaAdhipathiPlanets.Add(mercury);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 7;
                    }
                    break;
                case EnumRasi.Kataka:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { mars, jupiter };
                        List<AstroPlanet> asup = new List<AstroPlanet> { mercury, venus };
                        List<AstroPlanet> yop = new List<AstroPlanet> { mars };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, venus };
                        LagnaAdhipathiPlanets.Add(moon);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 11;
                    }
                    break;
                case EnumRasi.Simha:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { mars };
                        List<AstroPlanet> asup = new List<AstroPlanet> { mercury, jupiter, saturn };
                        List<AstroPlanet> yop = new List<AstroPlanet> { mars };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, venus };
                        LagnaAdhipathiPlanets.Add(sun);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 9;
                    }
                    break;
                case EnumRasi.Kanya:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { venus };
                        List<AstroPlanet> asup = new List<AstroPlanet> { moon, jupiter };
                        List<AstroPlanet> yop = new List<AstroPlanet> { mercury, venus };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mars, jupiter };
                        LagnaAdhipathiPlanets.Add(mercury);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 7;
                    }
                    break;
                case EnumRasi.Thula:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { mercury };
                        List<AstroPlanet> asup = new List<AstroPlanet> { sun, mars, jupiter };
                        List<AstroPlanet> yop = new List<AstroPlanet> { moon, mercury, saturn };
                        List<AstroPlanet> marp = new List<AstroPlanet> { jupiter };
                        LagnaAdhipathiPlanets.Add(venus);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 11;
                    }
                    break;
                case EnumRasi.Vrichika:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { sun, jupiter, moon };
                        List<AstroPlanet> asup = new List<AstroPlanet> { mercury, mars, saturn };
                        List<AstroPlanet> yop = new List<AstroPlanet> { sun };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, saturn };
                        LagnaAdhipathiPlanets.Add(mars);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 9;
                    }
                    break;
                case EnumRasi.Dhanus:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { sun, mars };
                        List<AstroPlanet> asup = new List<AstroPlanet> { venus };
                        List<AstroPlanet> yop = new List<AstroPlanet> { sun, mercury };
                        List<AstroPlanet> marp = new List<AstroPlanet> { venus };
                        LagnaAdhipathiPlanets.Add(jupiter);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 7;
                    }
                    break;
                case EnumRasi.Makara:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { venus };
                        List<AstroPlanet> asup = new List<AstroPlanet> { moon, mars, jupiter };
                        List<AstroPlanet> yop = new List<AstroPlanet> { mars, jupiter };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mars };
                        LagnaAdhipathiPlanets.Add(saturn);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 11;
                    }
                    break;
                case EnumRasi.Kumbha:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { moon, mars };
                        List<AstroPlanet> asup = new List<AstroPlanet> { sun, mercury, venus };
                        List<AstroPlanet> yop = new List<AstroPlanet> { mars, jupiter };
                        List<AstroPlanet> marp = new List<AstroPlanet> { saturn };
                        LagnaAdhipathiPlanets.Add(saturn);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 9;
                    }
                    break;
                case EnumRasi.Meena:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { moon, mars };
                        List<AstroPlanet> asup = new List<AstroPlanet> { sun, mercury, venus, saturn };
                        List<AstroPlanet> yop = new List<AstroPlanet> { jupiter, mars };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, venus, saturn };
                        LagnaAdhipathiPlanets.Add(jupiter);
                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 7;
                    }
                    break;
            }
        }

        private void SetPlanetVarieties(List<AstroPlanet> subp, List<AstroPlanet> asup
            , List<AstroPlanet> yop, List<AstroPlanet> marp)
        {
            SubhaPlanets.AddRange(subp);
            foreach (AstroPlanet planet in SubhaPlanets)
                Subha += planet.Name + ", ";
            Subha.TrimEnd(' ', ',');

            AsubhaPlanets.AddRange(asup);
            foreach (AstroPlanet planet in AsubhaPlanets)
                Asubha += planet.Name + ", ";
            Asubha.TrimEnd(' ', ',');

            YogakarakaPlanets.AddRange(yop);
            foreach (AstroPlanet planet in YogakarakaPlanets)
                Yogakaraka += planet.Name + ", ";
            Yogakaraka.TrimEnd(' ', ',');

            MarakaPlanets.AddRange(marp);
            foreach (AstroPlanet planet in MarakaPlanets)
                Maraka += planet.Name + ", ";
            Maraka.TrimEnd(' ', ',');
        }

        public AstroPlanet AathmaKaraka { get; set; }
        public AstroPlanet AmathyaKaraka { get; set; }
        public AstroPlanet BradhariKaraka { get; set; }
        public AstroPlanet MathruKaraka { get; set; }
        public AstroPlanet PithruKaraka { get; set; }
        public AstroPlanet GnathiKaraka { get; set; }
        public AstroPlanet DhaaraKaraka { get; set; }

        public List<AstroPlanet> SubhaPlanets { get; set; }
        public string Subha { get; set; }
        public List<AstroPlanet> AsubhaPlanets { get; set; }
        public string Asubha { get; set; }
        public List<AstroPlanet> MarakaPlanets { get; set; }
        public string Maraka { get; set; }
        public List<AstroPlanet> YogakarakaPlanets { get; set; }
        public List<AstroPlanet> LagnaAdhipathiPlanets { get; set; }
        public string Yogakaraka { get; set; }
        public EnumThithi ThithiNumber { get; set; }
        public bool IsPura { get; set; }
        public int BadakaHouseNumber { get; set; }
    }
}
