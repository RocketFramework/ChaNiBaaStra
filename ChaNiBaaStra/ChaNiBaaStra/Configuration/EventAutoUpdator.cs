using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChaNiBaaStra.Configuration
{
    
    public class EventAutoUpdator
    {
        public EventAutoUpdator() { }

        public List<AstroYogaConfigurationItem> CalculateAll()
        {
            List<AstroYogaConfigurationItem> allEvents = new List<AstroYogaConfigurationItem>();
            allEvents.AddRange(TransitLeadToAccident());
            allEvents.AddRange(TransitLeadToMarriage());
            return allEvents;
        }

        public List<AstroYogaConfigurationItem> TransitLeadToForeignTrips()
        {
            return null;
        }

        public List<AstroYogaConfigurationItem> TransitLeadToMarriage()
        {
            List<AstroYogaConfigurationItem> marriageLife = new List<AstroYogaConfigurationItem>();
            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            //Before analyzing the dasha system, we must read the transits of
            //Saturn and Jupiter carefully. The 2.5 years transit of Saturn and
            //1-year transit of Jupiter must affect or aspect the ascendant or
            //ascendant lord or seventh and seventh lord.
            foreach (EnumRasi lagnaRashi in langaRashies)
            {
                if ((int)lagnaRashi == 0) continue;
                AstroRasi lagna = new AstroRasi(lagnaRashi);
                EnumPlanet lagnaAdhipathy = lagna.AdhipathiEnumPlanets[0];
                EnumPlanet planet_7_Adhipathy = new AstroRasi(YogaAutoUpdator.GetIncrementRashi(lagnaRashi, 6)).AdhipathiEnumPlanets[0];
                // Saturn and Jupiter must be over house 1
                // Saturn and Jupiter must be with Lagnadhipathis
                // Saturn and Jupiter must be seen lagnadhipathis
                marriageLife.AddRange(MarriageCase1(lagnaAdhipathy, planet_7_Adhipathy));
                // Saturn and Jupiter must be over House 7
                // Saturn and Jupiter must be with 7th lord
                // Saturn and Jupiter must be seen 7th lord
                MarriageCase2(lagna, planet_7_Adhipathy);
            }
            return marriageLife;
        }

        public List<AstroYogaConfigurationItem> MarriageCase1(EnumPlanet lagnaAdhipathy, EnumPlanet planet_7_Adhipathy)
        {
            List<int> housesSet1 = new List<int>();
            List<int> housesSet2 = new List<int>();
            housesSet1.AddRange(AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet.Jupiter, 7));
            housesSet1.AddRange(AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet.Jupiter, 1));

            housesSet2.AddRange(AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet.Saturn, 7));
            housesSet2.AddRange(AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet.Saturn, 1));

            List<AstroYogaConfigurationItem> marriageLife = new List<AstroYogaConfigurationItem>();
            foreach (int houseJupiter in housesSet1)
            {
                AstroYogaConfigurationItem marriageEvent = new AstroYogaConfigurationItem();
                marriageEvent.YogaName = "Potential Marraige Time";
                marriageEvent.YogaDescription = "Jupiter Trasit at " + houseJupiter + " and seen 7th or Lagna";
                marriageEvent.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(houseJupiter, EnumPlanet.Jupiter));
                marriageLife.Add(marriageEvent);
            }
            foreach (int houseSaturn in housesSet2)
            {
                AstroYogaConfigurationItem marriageEvent = new AstroYogaConfigurationItem();
                marriageEvent.YogaName = "Potential Marraige Time";
                marriageEvent.YogaDescription = "Saturn Transit at " + houseSaturn + " and seen 7th or Lagna";
                marriageEvent.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(houseSaturn, EnumPlanet.Saturn));
                marriageLife.Add(marriageEvent);
            }
            /*
                for (int i = 1; i < 13; i++)
            {
                AstroYogaConfigurationItem marriageEvent1 = new AstroYogaConfigurationItem();
                AstroYogaConfigurationItem marriageEvent2 = new AstroYogaConfigurationItem();
                marriageEvent1.YogaName = "Potential Marraige Time";
                marriageEvent1.YogaDescription = "";
                marriageEvent1.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, lagnaAdhipathy));

                marriageEvent2.YogaName = "Potential Marraige Time";
                marriageEvent2.YogaDescription = "";
                marriageEvent2.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, planet_7_Adhipathy));

                List<int> housesSet3 = AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet.Saturn, i);
                List<int> housesSet4 = AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet.Jupiter, i);

                foreach (int house3 in housesSet3)
                {
                    foreach (int house4 in housesSet4)
                    {
                        marriageEvent2.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(house3, EnumPlanet.Saturn));
                        marriageEvent1.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(house3, EnumPlanet.Saturn));

                        marriageEvent2.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(house4, EnumPlanet.Jupiter));
                        marriageEvent1.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(house4, EnumPlanet.Jupiter));
                    }
                }
                marriageLife.Add(marriageEvent1);
                marriageLife.Add(marriageEvent2);
            }*/
            return marriageLife;
        }

        public void MarriageCase2(AstroRasi lagnaRashi, EnumPlanet planet_7_Adhipathy) { }

        public List<AstroYogaConfigurationItem> TransitLeadToAccident()
        {
            /*Position of Rahu and Mars in ascendant or in 2nd house, 
             * Mars or Saturn in ascendant, mars or Saturn in 3rd house, 
             * mars or Saturn in 5th house, Mars and Saturn in 2/12, 6/8 combinations, 
             * Saturn, Moon, Mars in 2nd, 4th , 10th , 12th Houses,
             * afflicted 4th house and 10th house.
             */
            List<AstroYogaConfigurationItem> eventAccidentLife = new List<AstroYogaConfigurationItem>();
            AstroYogaConfigurationItem rahuAscendant = new AstroYogaConfigurationItem();
            rahuAscendant.YogaName = "Potential to meet with accident";
            rahuAscendant.YogaDescription = "Rahu & Mars Ascendant";
            rahuAscendant.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Rahu));
            rahuAscendant.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Mars));
            eventAccidentLife.Add(rahuAscendant);

            AstroYogaConfigurationItem mars2House = new AstroYogaConfigurationItem();
            mars2House.YogaName = "Potential to meet with accident";
            mars2House.YogaDescription = "Mars & Rahu Second House";
            mars2House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(2, EnumPlanet.Rahu));
            mars2House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(2, EnumPlanet.Mars));
            eventAccidentLife.Add(mars2House);

            AstroYogaConfigurationItem saturnAscendant = new AstroYogaConfigurationItem();
            saturnAscendant.YogaName = "Potential to meet with accident";
            saturnAscendant.YogaDescription = "Mars & Saturn First House";
            saturnAscendant.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Saturn));
            saturnAscendant.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Mars));
            eventAccidentLife.Add(saturnAscendant);

            AstroYogaConfigurationItem saturn2House = new AstroYogaConfigurationItem();
            saturn2House.YogaName = "Potential to meet with accident";
            saturn2House.YogaDescription = "Mars & Saturn Second House";
            saturn2House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(2, EnumPlanet.Saturn));
            saturn2House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(2, EnumPlanet.Mars));
            eventAccidentLife.Add(saturn2House);

            AstroYogaConfigurationItem saturn3House = new AstroYogaConfigurationItem();
            saturn3House.YogaName = "Potential to meet with accident";
            saturn3House.YogaDescription = "Mars & Saturn Third House";
            saturn3House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(3, EnumPlanet.Saturn));
            saturn3House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(3, EnumPlanet.Mars));
            eventAccidentLife.Add(saturn3House);

            AstroYogaConfigurationItem saturn5House = new AstroYogaConfigurationItem();
            saturn5House.YogaName = "Potential to meet with accident";
            saturn5House.YogaDescription = "Mars & Saturn Fifth House";
            saturn5House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(5, EnumPlanet.Saturn));
            saturn5House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(5, EnumPlanet.Mars));
            eventAccidentLife.Add(saturn5House);

            AstroYogaConfigurationItem saturn212House = new AstroYogaConfigurationItem();
            saturn212House.YogaName = "Potential to meet with accident";
            saturn212House.YogaDescription = "Mars & Saturn 2 and 12 House";
            saturn212House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(2, EnumPlanet.Saturn));
            saturn212House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(12, EnumPlanet.Mars));
            eventAccidentLife.Add(saturn212House);

            AstroYogaConfigurationItem saturn12_2House = new AstroYogaConfigurationItem();
            saturn12_2House.YogaName = "Potential to meet with accident";
            saturn12_2House.YogaDescription = "Mars & Saturn 2 and 12 House";
            saturn12_2House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(12, EnumPlanet.Saturn));
            saturn12_2House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(2, EnumPlanet.Mars));
            eventAccidentLife.Add(saturn12_2House);

            AstroYogaConfigurationItem saturn68House = new AstroYogaConfigurationItem();
            saturn68House.YogaName = "Potential to meet with accident";
            saturn68House.YogaDescription = "Mars & Saturn 2 and 12 House";
            saturn68House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(6, EnumPlanet.Saturn));
            saturn68House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(8, EnumPlanet.Mars));
            eventAccidentLife.Add(saturn68House);

            AstroYogaConfigurationItem saturn86House = new AstroYogaConfigurationItem();
            saturn86House.YogaName = "Potential to meet with accident";
            saturn86House.YogaDescription = "Mars & Saturn 2 and 12 House";
            saturn86House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(8, EnumPlanet.Saturn));
            saturn86House.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(6, EnumPlanet.Mars));
            eventAccidentLife.Add(saturn86House);

            return eventAccidentLife;
        }
    }
}
