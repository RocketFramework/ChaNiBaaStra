using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public class AstroGoodBad
    {
        /// <summary>
        /// benefic planets
        /// </summary>
        /// <returns></returns>
        public static List<EnumPlanet> GetGoodPlanet()
        {
            return new List<EnumPlanet>() { EnumPlanet.Moon, EnumPlanet.Mercury, EnumPlanet.Jupiter, EnumPlanet.Venus, EnumPlanet.Neptune };
        }

        /// <summary>
        /// malefic
        /// </summary>
        /// <returns></returns>
        public static List<EnumPlanet> GetBadPlanet()
        {
            return new List<EnumPlanet>() { EnumPlanet.Sun, EnumPlanet.Mars, EnumPlanet.Saturn, EnumPlanet.Rahu, EnumPlanet.Kethu };
        }

        public static List<int> GetGoodHouses()
        {
            return new List<int>() { 5, 9, 1, 4, 7, 10 };
        }

        public static List<int> GetHousesThatGivesGoodOrBad()
        {
            return new List<int>() { 3, 6, 10, 11 };
        }

        public static List<int> GetBadHouses()
        {
            return new List<int>() { 6, 8, 12 };
        }

        public static List<int> GetAllGoodHouseForLagnaAndPlanet(EnumRasi lagnaRashi, EnumPlanet planet)
        {
            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            List<int> houses = new List<int>();
            List<int> goodHouses = AstroGoodBad.GetGoodHouses();
            foreach (EnumRasi currentRashi in langaRashies)
            {
                if ((int)currentRashi == 0) continue;

                AstroRasi rasi = new AstroRasi(lagnaRashi);
                int houseNumberOfTheRashi = rasi.absoluteHouseFromRasi(currentRashi);

                AstroRasi current = new AstroRasi(currentRashi);
                if (current.GetRelationToPlanet(planet) < EnumPlanetRasiRelationTypes.Sathuru)
                    if (goodHouses.Contains(houseNumberOfTheRashi))
                        houses.Add(houseNumberOfTheRashi);
            }
            return houses;
        }

        public static List<int> GetAllUchchaHouseForLagnaAndPlanet(EnumRasi lagnaRashi, EnumPlanet planet)
        {
            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            List<int> houses = new List<int>();
            List<int> goodHouses = AstroGoodBad.GetGoodHouses();
            foreach (EnumRasi currentRashi in langaRashies)
            {
                if ((int)currentRashi == 0) continue;

                AstroRasi rasi = new AstroRasi(lagnaRashi);
                int houseNumberOfTheRashi = rasi.absoluteHouseFromRasi(currentRashi);

                AstroRasi current = new AstroRasi(currentRashi);
                if (current.GetRelationToPlanet(planet) < EnumPlanetRasiRelationTypes.Mithra)
                    if (goodHouses.Contains(houseNumberOfTheRashi))
                        houses.Add(houseNumberOfTheRashi);
            }
            return houses;
        }

        public static List<int> GetAllBadHouseForLagnaAndPlanet(EnumRasi lagnaRashi, EnumPlanet planet)
        {
            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            List<int> houses = new List<int>();
            List<int> badHouses = AstroGoodBad.GetBadHouses();
            foreach (EnumRasi currentRashi in langaRashies)
            {
                if ((int)currentRashi == 0) continue;

                AstroRasi rasi = new AstroRasi(lagnaRashi);
                int houseNumberOfTheRashi = rasi.absoluteHouseFromRasi(currentRashi);

                AstroRasi current = new AstroRasi(currentRashi);
                if (current.GetRelationToPlanet(planet) >= EnumPlanetRasiRelationTypes.Sathuru)
                    if (badHouses.Contains(houseNumberOfTheRashi))
                        houses.Add(houseNumberOfTheRashi);
            }
            return houses;
        }

        public static List<int> GetAllNeechaHouseForLagnaAndPlanet(EnumRasi lagnaRashi, EnumPlanet planet)
        {
            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            List<int> houses = new List<int>();
            foreach (EnumRasi currentRashi in langaRashies)
            {
                if ((int)currentRashi == 0) continue;

                AstroRasi rasi = new AstroRasi(lagnaRashi);
                int houseNumberOfTheRashi = rasi.absoluteHouseFromRasi(currentRashi);

                AstroRasi current = new AstroRasi(currentRashi);
                if (current.GetRelationToPlanet(planet).ToString().Contains("Neecha"))
                    houses.Add(houseNumberOfTheRashi);
            }
            return houses;
        }

        public static string GetDasaQualityBasedOnDasaPlanet(EnumPlanet dasaPlanet, bool? isGood)
        {
            switch (dasaPlanet)
            {
                case EnumPlanet.Sun: return (isGood == true) ? "Wealth gain from cruelty, traveling, kings, or war. promoted by never giveup" : "Various destruction, donations, get addicted to sin, fight with your own workers, HEART or STOMATCH deceases";
                case EnumPlanet.Moon: return (isGood == true) ? "Manthra or Clergies helping you. Milk related, Clothes, Flower, Sport, Food related business can bring you wealth" : "Slpeepiness, lazyness, get attracted to God or Clergies, Birth of a Girl";
                case EnumPlanet.Mars: return (isGood == true) ? "Win over enemies, brothers, kings or land related wealth" : "Angry with your friends, wife, brothers and children. Reputed people and teachers going to hate you. Deceases like Thirsty, Blood, Fever, Pitha, and Brocken Borns. Troubled by an extra marital activity. Get satisfied doing bad deeds, use of Valgur words";
                case EnumPlanet.Kethu: return (isGood == true) ? "" : "";
                case EnumPlanet.Venus: return (isGood == true) ? "Get devoted to hapiness, and lot of ladies one after another, satisfying sex life, get talented, rarely get treasures" : "Get sad and get attacked by very low level (ungodly) people or kings";
                case EnumPlanet.Mercury: return (isGood == true) ? "Wealth gain in Brockering, Friends, Teachers, or clergies. Reputed people, and all others praise you. Become visibly very talended. Perform good deeds." : "Get prisioned, use of valgur words, sadness over rule you, deceases related to thri-dosa";
                case EnumPlanet.Jupiter: return (isGood == true) ? "Get famous for knowledge and talent, receive wealth, fame, childrens" : "Greedy for small things, lots of useless thoughts, sadness, decease in the ear, get hated by bad people";
                case EnumPlanet.Saturn: return (isGood == true) ? "Get wealth and money from Animal or Old women. Reputed people start respecting or devoting you. Get lots or small seeds (like rice)" : "Sadeness, deceases and destruction. Labours, Sons, or your wife get sick or they get damage/ hospitalized";
                case EnumPlanet.Rahu: return (isGood == true) ? "" : "";
            }
            return "";

        }
        public static string GetDasaQualityBasedOnMoonPlacement(EnumRasi moonRashi)
        {
            switch (moonRashi)
            {
                case EnumRasi.Mesha: return "Women get raped";
                case EnumRasi.Vrishabha: return "No food shortage";
                case EnumRasi.Mithuna: return "Get Knowledge/ Education, Friends and wealth";
                case EnumRasi.Kataka: return "Get wealth, happiness, and recognition";
                case EnumRasi.Simha: return "Happen to have hard work at distance places, in forest, in road or near house";
                case EnumRasi.Kanya: return "Get Knowledge/ Education, Friends and wealth";
                case EnumRasi.Thula: return "No food shortage";
                case EnumRasi.Vrichika: return "Women get raped";
                case EnumRasi.Dhanus: return "Wealth, Hapiness and devotion come after you"; ;
                case EnumRasi.Makara: return "Get a bad woman";
                case EnumRasi.Kumbha: return "Get a bad woman";
                case EnumRasi.Meena: return "Wealth, Hapiness and devotion come after you";
            }
            return "";
        }

        public static List<EnumPlanet> GetAllNeechaPlanetsForRashi(EnumRasi rashi)
        {
            EnumPlanet[] planets = AstroPlanet.GetAllPlanets();
            List<EnumPlanet> returnPlanets = new List<EnumPlanet>();

            AstroRasi rasi = new AstroRasi(rashi);

            foreach (EnumPlanet currentPlanet in planets)
            {
                if ((currentPlanet == EnumPlanet.Uranus)
                    || (currentPlanet == EnumPlanet.Neptune)
                    || (currentPlanet == EnumPlanet.Pluto)) continue;

                if (rasi.GetRelationToPlanet(currentPlanet).ToString().Contains("Neecha"))
                    returnPlanets.Add(currentPlanet);
            }
            return returnPlanets;
        }
    }
}
