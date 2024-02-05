using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace ChaNiBaaStra.Configuration
{
    public class YogaEventFinder
    {
        AstroYogaConfigurationItem horoscopeItem = new AstroYogaConfigurationItem();
        AstroYogaConfigurationItem trasitItem = new AstroYogaConfigurationItem();
        public YogaEventFinder(Horoscope horoscope, Horoscope transiteHoroscope)
        {
            horoscopeItem = SetData(horoscope);
            trasitItem = SetData(transiteHoroscope);
        }

        private AstroYogaConfigurationItem SetData(Horoscope horoscope)
        {
            AstroYogaConfigurationItem currentItem = new AstroYogaConfigurationItem();
            List<AstroPlanet> planets = horoscope.CompletePlanetList;
            currentItem.LagnaRashi = horoscope.LagnaRasi.CurrentInt;
            currentItem.IsMale = (horoscope.CurrentTransitDate.PlaceData.IsMale) ? 2 : 1;
            currentItem.IsBornInDayTime = (horoscope.CurrentTransitDate.IsDayTime) ? 2 : 1;
            currentItem.IsLagnaWargoththama = (horoscope.LagnaRasi.Current == horoscope.NavamsaRasi.Current) ? 2 : 1;
            currentItem.NawamsakaRashi = horoscope.NavamsaRasi.CurrentInt;

            foreach (var planet in planets)
            {
                currentItem.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(planet.HouseNumber, planet.Current));
                currentItem.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(planet.Rasi.Current, planet.Current));
            }

            for (int i = 1; i <= 12; i++)
                if (horoscope.RasiHouseList.Where(x => x.HouseNumber == i).Count() > 0)
                    currentItem.ListOfFilledHouseNumbers.Add(i);
                else
                    currentItem.ListOfEmptyHouseNumbers.Add(i);
            return currentItem;
        }

        public List<string> CalculateYoga()
        {
            List<string> all = new List<string>();

            YogaAutoUpdator yoga = new YogaAutoUpdator();
            List<AstroYogaConfigurationItem> yogaList = yoga.CalculateAll();
            bool allMatched = true;
            int c1 = yogaList.Count;
            List<int> horoscopeCompareItem = horoscopeItem.CompareValue;
            for (int i = 0; i < c1; i++)
            {
                AstroYogaConfigurationItem item = yogaList[i];
                List<int> copareItem1 = item.CompareValue;
                int c2 = copareItem1.Count;
                for (int j = 0; j < c2; j++)
                {
                    if ((copareItem1[j] != 0) && (copareItem1[j] != horoscopeCompareItem[j]))
                    {
                        allMatched = false;
                        break;
                    }
                }
                if (allMatched)
                    all.Add(item.YogaName + " " + item.YogaDescription);
                allMatched = true;
            }
            return all;
        }

        public List<string> CalculateEvents()
        {
            List<string> all = new List<string>();

            EventAutoUpdator events = new EventAutoUpdator();
            List<AstroYogaConfigurationItem> eventList = events.CalculateAll();
            bool allMatched = true;

            List<int> transitCompareItem = trasitItem.CompareValue;
            foreach (AstroYogaConfigurationItem item in eventList)
            {
                List<int> copareItem1 = item.CompareValue;
                int e2 = copareItem1.Count;
                for (int i = 0; i < e2; i++)
                {
                    if ((copareItem1[i] != 0) && (copareItem1[i] != transitCompareItem[i]))
                    {
                        allMatched = false;
                        break;
                    }
                }
                if (allMatched)
                    all.Add("T - " + item.YogaName + " " + item.YogaDescription);
                allMatched = true;
            }
            return all;
        }
    }
}
