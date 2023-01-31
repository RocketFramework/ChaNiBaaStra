using ChaNiBaaStra.DataModels;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Documents;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.Calculator
{
    public struct TransitHouse
    {
        public TransitHouse(EnumPlanet planet, int house, string effect)
        {
            House = house;
            Effect = effect;
            Planet = planet;
        }
        public EnumPlanet Planet { get; private set; }
        public int House { get; private set; }
        public string Effect { get; private set; }
    }

    internal class PlanetTrasitOverHouse
    {
        public PlanetTrasitOverHouse()
        {
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 1, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 2, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 3, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 4, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 5, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 6, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 7, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 8, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 9, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 10, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 11, ""));
            TrasitOverHouse.Add(new TransitHouse(EnumPlanet.Jupiter, 12, ""));
        }

        public List<TransitHouse> TrasitOverHouse = new List<TransitHouse>();
        public string GetEffect(EnumPlanet planet, int houseNumber)
        {  
            switch (planet)
            {
                case EnumPlanet.Sun: return "";
                case EnumPlanet.Moon: return "";
                case EnumPlanet.Saturn: return "";
                case EnumPlanet.Jupiter: return "";
                case EnumPlanet.Mars: return "";
                case EnumPlanet.Venus: return "";
                case EnumPlanet.Mercury: return "";
                case EnumPlanet.Rahu: return "";
                case EnumPlanet.Kethu: return "";
            }
            return "";
        }
    }
}
