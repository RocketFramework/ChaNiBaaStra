using ChaNiBaaStra.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public class AstroView
    {
        public enum EnumViewStrengths
        {
            VeryGood,
            Good,
            Bad,
            VeryBad
        }
        private AstroUtility utility = new AstroUtility();  

        public List<int> ICanSeeThem { get; set; }
        public List<AstroPlanet> TheyCanSeeMee { get; set; }

        public List<int> SeeRashiHouses { get; set; }
        public List<AstroPlanet> PlanetRashiSeeMee { get; set; }

        public List<int> SeeBhavaHouses { get; set; }
        public List<AstroPlanet> PlanetBhavaSeeMee { get; set; }

        public AstroView(AstroPlanet planet)
        {
            ICanSeeThem = new List<int>();
            TheyCanSeeMee = new List<AstroPlanet>();
            SeeBhavaHouses = new List<int>();
            PlanetBhavaSeeMee = new List<AstroPlanet>();

            UpdateForViews(planet);
        }
        
        public static bool CanPlanetSeeThisRashiHouse(EnumPlanet planet, int planetInHouse, int toSeeHouse)
        {
            return GetHouses_ForPlanetBe_ToSeeThisHouse(planet, toSeeHouse).Contains(planetInHouse);
        }

        public static List<int> GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet planet, int toSeeHouse)
        {
            int i, j, k, l;
            switch (planet)
            {
                case EnumPlanet.Sun:
                case EnumPlanet.Saturn:
                case EnumPlanet.Moon:
                    {
                        i = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 3);
                        j = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 9);
                        k = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7);

                        return new List<int> { i, j, k };
                    }
                case EnumPlanet.Mars:
                case EnumPlanet.Mercury:
                    {
                        i = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 4);
                        j = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 8);
                        k = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7);

                        return new List<int> { i, j, k };
                    }
                case EnumPlanet.Jupiter:
                case EnumPlanet.Venus:
                    {
                        i = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 5);
                        j = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 9);
                        k = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7);

                        return new List<int> { i, j, k };
                    }
                case EnumPlanet.Rahu:
                case EnumPlanet.Kethu:
                    {
                        i = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 5);
                        j = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 9);
                        k = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7);
                        l = AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 12);

                        return new List<int> { i, j, k, l };
                    }
                case EnumPlanet.Pluto:
                case EnumPlanet.Neptune:
                case EnumPlanet.Uranus:
                    return new List<int> { AstroUtility.AstroCycleDecreaseNew(toSeeHouse, 7) };
            }
            return new List<int>();
        }
        
        public static List<int> GetAllHousesPlanetSee(EnumPlanet planet, int planetHouse)
        {
            int i, j, k, l;
            switch (planet)
            {
                case EnumPlanet.Sun:
                case EnumPlanet.Saturn:
                case EnumPlanet.Moon:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planetHouse, 3);
                        j = AstroUtility.AstroCycleIncreaseNew(planetHouse, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planetHouse, 7);

                        return new List<int> { i, j, k }.OrderBy(x => x).ToList();
                    }
                case EnumPlanet.Mars:
                case EnumPlanet.Mercury:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planetHouse, 4);
                        j = AstroUtility.AstroCycleIncreaseNew(planetHouse, 8);
                        k = AstroUtility.AstroCycleIncreaseNew(planetHouse, 7);

                        return new List<int> { i, j, k }.OrderBy(x => x).ToList();
                    }
                case EnumPlanet.Jupiter:
                case EnumPlanet.Venus:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planetHouse, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planetHouse, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planetHouse, 7);

                        return new List<int> { i, j, k }.OrderBy(x => x).ToList();
                    }
                case EnumPlanet.Rahu:
                case EnumPlanet.Kethu:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planetHouse, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planetHouse, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planetHouse, 7);
                        l = AstroUtility.AstroCycleIncreaseNew(planetHouse, 12);

                        return new List<int> { i, j, k, l }.OrderBy(x => x).ToList();
                    }
                case EnumPlanet.Pluto:
                case EnumPlanet.Neptune:
                case EnumPlanet.Uranus:
                    return  new List<int> { AstroUtility.AstroCycleIncreaseNew(planetHouse, 7) };
            }
            return new List<int>();
        }

        private void UpdateForViews(AstroPlanet planet)
        {
            int i, j, k, l;
            switch (planet.Current)
            {
                case EnumPlanet.Sun:
                case EnumPlanet.Saturn:
                case EnumPlanet.Moon:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 3);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7);

                        ICanSeeThem = new List<int> { i, j, k };

                        i = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 3);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 7);

                        SeeBhavaHouses = new List<int> { i, j, k };
                        break;
                    }
                case EnumPlanet.Mars:
                case EnumPlanet.Mercury:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 4);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 8);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7);

                        ICanSeeThem = new List<int> { i, j, k };

                        i = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 4);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 8);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 7);

                        SeeBhavaHouses = new List<int> { i, j, k };
                        break;
                    }
                case EnumPlanet.Jupiter:
                case EnumPlanet.Venus:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7);

                        ICanSeeThem = new List<int> { i, j, k };

                        i = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 7);

                        SeeBhavaHouses = new List<int> { i, j, k };
                        break;
                    }
                case EnumPlanet.Rahu:
                case EnumPlanet.Kethu:
                    {
                        i = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7);
                        l = AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 12);

                        ICanSeeThem = new List<int> { i, j, k, l };

                        i = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 5);
                        j = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 9);
                        k = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 7);
                        l = AstroUtility.AstroCycleIncreaseNew(planet.Bhava.BhavaNumber, 12);

                        SeeBhavaHouses = new List<int> { i, j, k, l };
                        break;
                    }
                case EnumPlanet.Pluto:
                case EnumPlanet.Neptune:
                case EnumPlanet.Uranus:
                    ICanSeeThem = new List<int> { AstroUtility.AstroCycleIncreaseNew(planet.HouseNumber, 7) };
                    break;
            }
        }
    }
}
