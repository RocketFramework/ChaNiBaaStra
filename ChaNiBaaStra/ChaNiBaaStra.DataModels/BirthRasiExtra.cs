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
            AstroPlanet vernus = birthHoroscope.RasiPlanetList.FirstOrDefault(x => x.Current == EnumPlanet.Venus);
            AstroPlanet saturn = birthHoroscope.RasiPlanetList.FirstOrDefault(x => x.Current == EnumPlanet.Saturn);

            switch (birthHoroscope.LagnaRasi.Current)
            {
                case EnumRasi.Mesha:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { sun, mars, moon };
                        List<AstroPlanet> asup = new List<AstroPlanet> { mercury, vernus, saturn };
                        List<AstroPlanet> yop = new List<AstroPlanet> { jupiter };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, vernus, saturn };

                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 11;
                    }
                    break;
                case EnumRasi.Vrishabha:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { sun, mars, mercury, vernus };
                        List<AstroPlanet> asup = new List<AstroPlanet> { moon, vernus, jupiter };
                        List<AstroPlanet> yop = new List<AstroPlanet> { saturn };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, vernus };

                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 9;
                    }
                    break;
                case EnumRasi.Mithuna:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { saturn, vernus };
                        List<AstroPlanet> asup = new List<AstroPlanet> { sun, mars, jupiter };
                        List<AstroPlanet> yop = new List<AstroPlanet> { vernus, mercury };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mars, jupiter };

                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 7;
                    }
                    break;
                case EnumRasi.Kataka:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { mars, jupiter };
                        List<AstroPlanet> asup = new List<AstroPlanet> { mercury, vernus };
                        List<AstroPlanet> yop = new List<AstroPlanet> { mars };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, vernus };

                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 11;
                    }
                    break;
                case EnumRasi.Simha:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { mars };
                        List<AstroPlanet> asup = new List<AstroPlanet> { mercury, jupiter, saturn };
                        List<AstroPlanet> yop = new List<AstroPlanet> { mars };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, vernus };

                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 9;
                    }
                    break;
                case EnumRasi.Kanya:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { vernus };
                        List<AstroPlanet> asup = new List<AstroPlanet> { moon, jupiter };
                        List<AstroPlanet> yop = new List<AstroPlanet> { mercury, vernus };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mars, jupiter };

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

                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 9;
                    }
                    break;
                case EnumRasi.Dhanus:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { sun, mars };
                        List<AstroPlanet> asup = new List<AstroPlanet> { vernus };
                        List<AstroPlanet> yop = new List<AstroPlanet> { sun, mercury };
                        List<AstroPlanet> marp = new List<AstroPlanet> { vernus };

                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 7;
                    }
                    break;
                case EnumRasi.Makara:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { vernus };
                        List<AstroPlanet> asup = new List<AstroPlanet> { moon, mars, jupiter };
                        List<AstroPlanet> yop = new List<AstroPlanet> { mars, jupiter };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mars };

                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 11;
                    }
                    break;
                case EnumRasi.Kumbha:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { moon, mars };
                        List<AstroPlanet> asup = new List<AstroPlanet> { sun, mercury, vernus };
                        List<AstroPlanet> yop = new List<AstroPlanet> { mars, jupiter };
                        List<AstroPlanet> marp = new List<AstroPlanet> { saturn };

                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 9;
                    }
                    break;
                case EnumRasi.Meena:
                    {
                        List<AstroPlanet> subp = new List<AstroPlanet> { moon, mars };
                        List<AstroPlanet> asup = new List<AstroPlanet> { sun, mercury, vernus, saturn };
                        List<AstroPlanet> yop = new List<AstroPlanet> { jupiter, mars };
                        List<AstroPlanet> marp = new List<AstroPlanet> { mercury, vernus, saturn };

                        SetPlanetVarieties(subp, asup, yop, marp);
                        BadakaHouseNumber = 7;
                    }
                    break;
            }
            LagnaAdhipathiPlanets = new List<AstroPlanet>();
            var retData = birthHoroscope.LagnaRasi.DataModel.PlanetRashiRelations.Where(x => x.RelationshipTypeId == (int)EnumRelationshipTypes.Swashesthra
                || x.RelationshipTypeId == (int)EnumRelationshipTypes.SwashesthraMulaThrikona);
            foreach (PlanetRashiRelation pr in retData)
                LagnaAdhipathiPlanets.Add(birthHoroscope.RasiPlanetList.FirstOrDefault(x => x.DataModel.PlanetId == pr.PlanetId));
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
