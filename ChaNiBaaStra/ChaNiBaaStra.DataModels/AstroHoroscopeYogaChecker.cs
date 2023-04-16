using ChaNiBaaStra.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public class AstroHoroscopeYogaChecker
    {
        public List<string> YogaNames { get; set; }
        public AstroHoroscopeYogaChecker(Horoscope horoscope, MahaYogaDefinition yogaDefinition)
        {
            YogaNames = new List<string>();
            if (yogaDefinition == null) throw new ArgumentNullException();
            foreach (AstroPlanet planet in horoscope.CompletePlanetList)
            {
                if (planet == null) throw new ArgumentNullException();

                if (yogaDefinition.singlePlanetYoga.PlanetNames.Contains(planet.Current))
                {
                    if ((yogaDefinition.singlePlanetYoga.PlanetPlacedHouses.Contains(planet.HouseNumber))
                    && (yogaDefinition.singlePlanetYoga.ExpectedRelationshipWithAnyGivenHouse.Contains(planet.PlanetRasiRelation)))
                        YogaNames.Add("Pancha Maha Purusha Yoga - " + planet.Name);
                }
            }


        }
    }
}
