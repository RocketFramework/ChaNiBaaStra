using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels.Varga
{
    public abstract class AshtakaVargayaBase
    {
        public int[] AshtakaVargaList = new int[12];
        protected abstract List<int> sunList { get; }
        protected abstract List<int> moonList { get; }
        protected abstract List<int> marsList { get; }
        protected abstract List<int> mercuryList { get; }
        protected abstract List<int> jupiterList { get; }
        protected abstract List<int> venusList { get; }
        protected abstract List<int> saturnList { get; }
        protected abstract List<int> lagnaList { get; }
        protected List<int> SunList { get { return sunList; } }
        protected List<int> MoonList { get { return moonList; } }
        protected List<int> MarsList { get { return marsList; } }
        protected List<int> MercuryList { get { return mercuryList; } }
        protected List<int> JupiterList { get { return jupiterList; } }
        protected List<int> VenusList { get { return venusList; } }
        protected List<int> SaturnList { get { return saturnList; } }
        protected List<int> LagnaList { get { return lagnaList; } }

        protected void FillPlanetStrengths(int houseNumber, List<int> list)
        {
            for (int i = 0; i < 12; i++)
                if (list.Contains(i + 1))
                    AshtakaVargaList[AstroUtility.AstroCycleIncreaseNew(houseNumber, i + 1) - 1] += 1;
                else
                    AshtakaVargaList[AstroUtility.AstroCycleIncreaseNew(houseNumber, i + 1) - 1] += -0;
        }

        protected void SetVargaya(List<AstroPlanet> birthPlanetList)
        {
            FillPlanetStrengths(1, LagnaList);
            foreach (AstroPlanet planet in birthPlanetList)
            {
                if (planet.Current == EnumPlanet.Uranus
                    || planet.Current == EnumPlanet.Neptune
                    || planet.Current == EnumPlanet.Pluto
                    || planet.Current == EnumPlanet.Rahu
                    || planet.Current == EnumPlanet.Kethu)
                    continue;
                switch (planet.Current)
                {
                    case EnumPlanet.Sun:
                        {
                            FillPlanetStrengths(planet.HouseNumber, SunList);
                        }
                        break;
                    case EnumPlanet.Moon:
                        {
                            FillPlanetStrengths(planet.HouseNumber, MoonList);
                        }
                        break;
                    case EnumPlanet.Mars:
                        {
                            FillPlanetStrengths(planet.HouseNumber, MarsList);
                        }
                        break;
                    case EnumPlanet.Jupiter:
                        {
                            FillPlanetStrengths(planet.HouseNumber, JupiterList);
                        }
                        break;
                    case EnumPlanet.Mercury:
                        {
                            FillPlanetStrengths(planet.HouseNumber, MercuryList);
                        }
                        break;
                    case EnumPlanet.Venus:
                        {
                            FillPlanetStrengths(planet.HouseNumber, VenusList);
                        }
                        break;
                    case EnumPlanet.Saturn:
                        {
                            FillPlanetStrengths(planet.HouseNumber, SaturnList);
                        }
                        break;
                }
            }
        }
        public AshtakaVargayaBase() { }
    }

    public class SunAsktakaVargaya : AshtakaVargayaBase
    {
        protected override List<int> sunList { get { return new List<int> { 1, 2, 4, 7, 8, 9, 10, 11 }; } }
        protected override List<int> moonList { get { return new List<int> { 3, 6, 10, 11 }; } }
        protected override List<int> marsList { get { return new List<int> { 1, 2, 4, 7, 8, 9, 10, 11 }; } }
        protected override List<int> mercuryList { get { return new List<int> { 3, 5, 6, 9, 10, 11, 12 }; } }
        protected override List<int> jupiterList { get { return new List<int> { 5, 6, 9, 11 }; } }
        protected override List<int> venusList { get { return new List<int> { 6, 7, 12 }; } }
        protected override List<int> saturnList { get { return new List<int> { 1, 2, 4, 7, 8, 9, 10, 11 }; } }
        protected override List<int> lagnaList { get { return new List<int> { 3, 4, 6, 10, 11, 12 }; } }
        public void SetAsktakaVargaya(List<AstroPlanet> birthPlanetList)
        {
            base.SetVargaya(birthPlanetList);
        }
    }

    public class MoonAsktakaVargaya : AshtakaVargayaBase
    {
        protected override List<int> sunList { get { return new List<int> { 3, 6, 7, 8, 10, 11 }; } }
        protected override List<int> moonList { get { return new List<int> { 1, 3, 6, 7, 9, 10, 11 }; } }
        protected override List<int> marsList { get { return new List<int> { 2, 3, 5, 6, 10, 11 }; } }
        protected override List<int> mercuryList { get { return new List<int> { 1, 3, 4, 5, 7, 8, 10, 11 }; } }
        protected override List<int> jupiterList { get { return new List<int> { 1, 2, 4, 7, 8, 10, 11 }; } }
        protected override List<int> venusList { get { return new List<int> { 3, 4, 5, 7, 9, 10, 11 }; } }
        protected override List<int> saturnList { get { return new List<int> { 3, 5, 6, 11 }; } }
        protected override List<int> lagnaList { get { return new List<int> { 3, 6, 10, 11 }; } }
        public void SetAsktakaVargaya(List<AstroPlanet> birthPlanetList)
        {
            base.SetVargaya(birthPlanetList);
        }
    }

    public class MarsAsktakaVargaya : AshtakaVargayaBase
    {
        protected override List<int> sunList { get { return new List<int> { 3, 5, 6, 10, 11 }; } }
        protected override List<int> moonList { get { return new List<int> { 3, 6, 11 }; } }
        protected override List<int> marsList { get { return new List<int> { 1, 2, 4, 7, 8, 10, 11 }; } }
        protected override List<int> mercuryList { get { return new List<int> { 3, 5, 6, 11 }; } }
        protected override List<int> jupiterList { get { return new List<int> { 6, 10, 11, 12 }; } }
        protected override List<int> venusList { get { return new List<int> { 6, 8, 11, 12 }; } }
        protected override List<int> saturnList { get { return new List<int> { 1, 4, 7, 8, 9, 10, 11 }; } }
        protected override List<int> lagnaList { get { return new List<int> { 1, 3, 6, 10, 11 }; } }
        public void SetAsktakaVargaya(List<AstroPlanet> birthPlanetList)
        {
            base.SetVargaya(birthPlanetList);
        }
    }

    public class MercuryAsktakaVargaya : AshtakaVargayaBase
    {
        protected override List<int> sunList { get { return new List<int> { 5, 6, 9, 11, 12 }; } }
        protected override List<int> moonList { get { return new List<int> { 2, 4, 6, 8, 10, 11 }; } }
        protected override List<int> marsList { get { return new List<int> { 1, 2, 4, 7, 8, 9, 10, 11 }; } }
        protected override List<int> mercuryList { get { return new List<int> { 1, 3, 5, 6, 9, 10, 11, 12 }; } }
        protected override List<int> jupiterList { get { return new List<int> { 6, 8, 11, 12 }; } }
        protected override List<int> venusList { get { return new List<int> { 1, 2, 3, 4, 5, 8, 9, 11 }; } }
        protected override List<int> saturnList { get { return new List<int> { 1, 2, 4, 7, 8, 9, 10, 11 }; } }
        protected override List<int> lagnaList { get { return new List<int> { 1, 2, 4, 6, 8, 10, 11 }; } }
        public void SetAsktakaVargaya(List<AstroPlanet> birthPlanetList)
        {
            base.SetVargaya(birthPlanetList);
        }
    }

    public class JupiterAsktakaVargaya : AshtakaVargayaBase
    {
        protected override List<int> sunList { get { return new List<int> { 1, 2, 3, 4, 7, 8, 9, 10, 11 }; } }
        protected override List<int> moonList { get { return new List<int> { 2, 5, 7, 9, 11 }; } }
        protected override List<int> marsList { get { return new List<int> { 1, 2, 4, 7, 8, 10, 11 }; } }
        protected override List<int> mercuryList { get { return new List<int> { 1, 2, 4, 5, 6, 9, 10, 11 }; } }
        protected override List<int> jupiterList { get { return new List<int> { 1, 2, 3, 4, 7, 8, 10, 11 }; } }
        protected override List<int> venusList { get { return new List<int> { 2, 5, 6, 9, 10, 11 }; } }
        protected override List<int> saturnList { get { return new List<int> { 3, 5, 6, 12 }; } }
        protected override List<int> lagnaList { get { return new List<int> { 1, 2, 4, 5, 6, 7, 9, 10, 11 }; } }

        public void SetAsktakaVargaya(List<AstroPlanet> birthPlanetList)
        {
            base.SetVargaya(birthPlanetList);
        }
    }

    //TODO
    public class VenusAsktakaVargaya : AshtakaVargayaBase
    {
        protected override List<int> sunList { get { return new List<int> { 8, 11, 12 }; } }
        protected override List<int> moonList { get { return new List<int> { 1, 2, 3, 4, 5, 8, 9, 11, 12 }; } }
        protected override List<int> marsList { get { return new List<int> { 3, 4, 6, 9, 11, 12 }; } }
        protected override List<int> mercuryList { get { return new List<int> { 3, 5, 6, 9, 11 }; } }
        protected override List<int> jupiterList { get { return new List<int> { 5, 8, 9, 10, 11 }; } }
        protected override List<int> venusList { get { return new List<int> { 1, 2, 3, 4, 5, 8, 9, 10, 11 }; } }
        protected override List<int> saturnList { get { return new List<int> { 3, 4, 5, 8, 9, 10, 11 }; } }
        protected override List<int> lagnaList { get { return new List<int> { 1, 2, 3, 4, 5, 8, 9, 11 }; } }
        public void SetAsktakaVargaya(List<AstroPlanet> birthPlanetList)
        {
            base.SetVargaya(birthPlanetList);
        }
    }

    public class SaturnAsktakaVargaya : AshtakaVargayaBase
    {
        protected override List<int> sunList { get { return new List<int> { 1, 2, 4, 7, 8, 10, 11 }; } }
        protected override List<int> moonList { get { return new List<int> { 3, 6, 11 }; } }
        protected override List<int> marsList { get { return new List<int> { 3, 5, 6, 10, 11, 12 }; } }
        protected override List<int> mercuryList { get { return new List<int> { 6, 8, 9, 10, 11, 12 }; } }
        protected override List<int> jupiterList { get { return new List<int> { 5, 6, 11, 12 }; } }
        protected override List<int> venusList { get { return new List<int> { 6, 11, 12 }; } }
        protected override List<int> saturnList { get { return new List<int> { 3, 5, 6, 11 }; } }
        protected override List<int> lagnaList { get { return new List<int> { 1, 3, 4, 6, 10, 11 }; } }
        public void SetAsktakaVargaya(List<AstroPlanet> birthPlanetList)
        {
            base.SetVargaya(birthPlanetList);
        }
    }

    public class AscendantAsktakaVargaya : AshtakaVargayaBase
    {
        protected override List<int> sunList { get { return new List<int> { 3, 4, 6, 10, 11, 12 }; } }
        protected override List<int> moonList { get { return new List<int> { 3, 6, 10, 11, 12 }; } }
        protected override List<int> marsList { get { return new List<int> { 1, 3, 6, 10, 11 }; } }
        protected override List<int> mercuryList { get { return new List<int> { 1, 2, 4, 6, 8, 10, 11 }; } }
        protected override List<int> jupiterList { get { return new List<int> { 1, 2, 4, 5, 6, 7, 9, 10, 11 }; } }
        protected override List<int> venusList { get { return new List<int> { 1, 2, 3, 4, 5, 8, 9 }; } }
        protected override List<int> saturnList { get { return new List<int> { 1, 3, 4, 6, 10, 11 }; } }
        protected override List<int> lagnaList { get { return new List<int> { 3, 6, 10, 11 }; } }

        public void SetAsktakaVargaya(List<AstroPlanet> birthPlanetList)
        {
            base.SetVargaya(birthPlanetList);
        }
    }

    public static class IntArrayExtensions
    {
        public static void Add(this int[] array, int[] otherArray)
        {
            if (array.Length != otherArray.Length)
                throw new ArgumentException("Arrays must be of the same length");

            for (int i = 0; i < array.Length; i++)
                array[i] += otherArray[i];
        }
    }

    public sealed class Ascendant2AsktakaVargaya
    {
        public int[] AscAshtakaVargaList { get; set; }
        private Ascendant2AsktakaVargaya() { }
        private static Ascendant2AsktakaVargaya instance = null;
        public static Ascendant2AsktakaVargaya Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Ascendant2AsktakaVargaya();
                    Ascendant2AsktakaVargaya.Instance.AscAshtakaVargaList = new int[12];
                }
                return instance;
            }
        }

        public void Init()
        {
            Ascendant2AsktakaVargaya.Instance.AscAshtakaVargaList = new int[12];
        }
    }

    public class AstakaVargaMaster
    {
        public MoonAsktakaVargaya MoonVarga { get;set; }
        public SunAsktakaVargaya SunVarga { get; set; }
        public MarsAsktakaVargaya MarVarga { get; set; }
        public MercuryAsktakaVargaya MercuryVarga { get; set; }
        public JupiterAsktakaVargaya JupiterVarga { get; set; }
        public VenusAsktakaVargaya VenusVarga { get; set; }
        public SaturnAsktakaVargaya SaturnVarga { get; set; }
        public AscendantAsktakaVargaya AscVarga { get; set; }
        public int[] SavAsktakaVarga { get; set; }
        
        public AstakaVargaMaster(Horoscope horoscope)
        {
            SavAsktakaVarga = new int[12];
            List<AstroPlanet> birthPlanets = horoscope.CompletePlanetList;

            MoonVarga = new MoonAsktakaVargaya();
            MoonVarga.SetAsktakaVargaya(birthPlanets);
            SavAsktakaVarga.Add(MoonVarga.AshtakaVargaList);
            SunVarga = new SunAsktakaVargaya();
            SunVarga.SetAsktakaVargaya(birthPlanets);
            SavAsktakaVarga.Add(SunVarga.AshtakaVargaList);
            MarVarga = new MarsAsktakaVargaya();
            MarVarga.SetAsktakaVargaya(birthPlanets);
            SavAsktakaVarga.Add(MarVarga.AshtakaVargaList);
            MercuryVarga = new MercuryAsktakaVargaya();
            MercuryVarga.SetAsktakaVargaya(birthPlanets);
            SavAsktakaVarga.Add(MercuryVarga.AshtakaVargaList);
            JupiterVarga = new JupiterAsktakaVargaya();
            JupiterVarga.SetAsktakaVargaya(birthPlanets);
            SavAsktakaVarga.Add(JupiterVarga.AshtakaVargaList);
            VenusVarga = new VenusAsktakaVargaya();
            VenusVarga.SetAsktakaVargaya(birthPlanets);
            SavAsktakaVarga.Add(VenusVarga.AshtakaVargaList);
            SaturnVarga = new SaturnAsktakaVargaya();
            SaturnVarga.SetAsktakaVargaya(birthPlanets);
            SavAsktakaVarga.Add(SaturnVarga.AshtakaVargaList);
            AscVarga = new AscendantAsktakaVargaya();
            AscVarga.SetAsktakaVargaya(birthPlanets);
        }
    }
}
