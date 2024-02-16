using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public class RashiAdhipathiFinder
    {
        public RashiAdhipathiFinder()
        {

        }

        public List<AstroPlanet> UpdateRashiAdhipatiScore(List<AstroPlanet> planets, AstroRasi currentRashi)
        {
            List<AstroPlanet> newList = new List<AstroPlanet>();
            foreach (AstroPlanet planet in planets)
            {
                // sthana bala
                UpdateAdhipathiScore(planet, currentRashi);
                newList.Add(planet);
            }
            // Sthana bala

            // Adhimitra, Uchcha, Swakshethra, Mithra, 
            // 
            return newList.OrderBy(x => x.RashiAdhipathiScore).ToList();
        }

        private void UpdateAdhipathiScore(AstroPlanet planet, AstroRasi currentRashi)
        {
            MarkLocationalPower(planet, currentRashi);
            MarkDirectionalPower(planet, currentRashi);
            MarkChestaBalaPower(planet, currentRashi);
        }

        /// <summary>
        /// Sun amd Moon calculation is not accurate
        /// for sun we need to consider ayana bala
        /// for moon we need to consider sukla bala or something
        /// </summary>
        /// <param name="planet"></param>
        private static void MarkChestaBalaPower(AstroPlanet planet, AstroRasi currentRashi)
        {
            /*
             * Sun: Approximately 1 degree per day.
            Moon: Approximately 12 to 13 degrees per day.
            Mercury: Varies depending on its proximity to the Sun. On average, it moves roughly 1 to 2.5 degrees per day.
            Venus: Varies depending on its proximity to the Sun. On average, it moves roughly 0.5 to 1 degree per day.
            Mars: Varies depending on its proximity to the Sun. On average, it moves roughly 0.5 to 1 degree per day.
            Jupiter: Approximately 0.08 to 0.10 degrees per day.
            Saturn: Approximately 0.03 to 0.05 degrees per day.
            Uranus: Approximately 0.01 to 0.03 degrees per day.
            Neptune: Approximately 0.005 to 0.02 degrees per day.
            Pluto: Approximately 0.002 to 0.004 degrees per day.*/
            if (planet.IsReversing && planet.SpeedInLongitude < 0)
                planet.RashiAdhipathiScore += 4;
            else if ((planet.Current == EnumPlanet.Moon && planet.SpeedInLongitude > 13) ||
                (planet.Current == EnumPlanet.Sun && planet.SpeedInLongitude > 1) ||
                (planet.Current == EnumPlanet.Mercury && planet.SpeedInLongitude > 2.5) ||
                (planet.Current == EnumPlanet.Venus && planet.SpeedInLongitude > 1) ||
                (planet.Current == EnumPlanet.Mars && planet.SpeedInLongitude > 1) ||
                (planet.Current == EnumPlanet.Jupiter && planet.SpeedInLongitude > .1) ||
                (planet.Current == EnumPlanet.Saturn && planet.SpeedInLongitude > .05) ||
                (planet.Current == EnumPlanet.Uranus && planet.SpeedInLongitude > .03) ||
                (planet.Current == EnumPlanet.Neptune && planet.SpeedInLongitude > .02) ||
                (planet.Current == EnumPlanet.Pluto && planet.SpeedInLongitude > .004))
                planet.RashiAdhipathiScore += 8;
            else if ((planet.Current == EnumPlanet.Moon && planet.SpeedInLongitude < 13.1) ||
                (planet.Current == EnumPlanet.Sun && planet.SpeedInLongitude < 1.1) ||
                (planet.Current == EnumPlanet.Mercury && planet.SpeedInLongitude < 2.6) ||
                (planet.Current == EnumPlanet.Venus && planet.SpeedInLongitude < 1.1) ||
                (planet.Current == EnumPlanet.Mars && planet.SpeedInLongitude < 1.1) ||
                (planet.Current == EnumPlanet.Jupiter && planet.SpeedInLongitude < .19) ||
                (planet.Current == EnumPlanet.Saturn && planet.SpeedInLongitude < .059) ||
                (planet.Current == EnumPlanet.Uranus && planet.SpeedInLongitude < .039) ||
                (planet.Current == EnumPlanet.Neptune && planet.SpeedInLongitude < .029) ||
                (planet.Current == EnumPlanet.Pluto && planet.SpeedInLongitude < .0049))
                planet.RashiAdhipathiScore += 6;
        }

        private static void MarkDirectionalPower(AstroPlanet planet, AstroRasi currentRashi)
        {

            if ((planet.Current == EnumPlanet.Sun || planet.Current == EnumPlanet.Mars) && currentRashi.HouseNumber == 10)
                planet.RashiAdhipathiScore += 10;
            else if ((planet.Current == EnumPlanet.Moon || planet.Current == EnumPlanet.Venus) && currentRashi.HouseNumber == 4)
                planet.RashiAdhipathiScore += 10;
            if ((new List<int>() { 6, 8, 12 }).Contains(currentRashi.HouseNumber))
                planet.RashiAdhipathiScore += 2;
            else if ((new List<int>() { 3, 6, 9, 12 }).Contains(currentRashi.HouseNumber))
                planet.RashiAdhipathiScore += 4;
            else if ((new List<int>() { 2, 5, 8, 11 }).Contains(currentRashi.HouseNumber))
                planet.RashiAdhipathiScore += 6;
            else if ((new List<int>() { 1, 4, 7, 10 }).Contains(currentRashi.HouseNumber))
                planet.RashiAdhipathiScore += 8;
        }

        private void MarkLocationalPower(AstroPlanet planet, AstroRasi currentRashi)
        {

            if (planet.GetRelationToRasi(currentRashi.Current) <= EnumPlanetRasiRelationTypes.UchchaMulaThrikona)
                planet.RashiAdhipathiScore += 10;
            else if (planet.GetRelationToRasi(currentRashi.Current) >= EnumPlanetRasiRelationTypes.Mithra)
                planet.RashiAdhipathiScore += 8;
            else if (planet.GetRelationToRasi(currentRashi.Current) == EnumPlanetRasiRelationTypes.Sama || planet.GetRelationToRasi(currentRashi.Current) == EnumPlanetRasiRelationTypes.SamaMuta)
                planet.RashiAdhipathiScore += 5;
            else if (planet.GetRelationToRasi(currentRashi.Current) <= EnumPlanetRasiRelationTypes.SathuruMuta)
                planet.RashiAdhipathiScore += 4;
            else
                planet.RashiAdhipathiScore += 3;
        }
    }
}
