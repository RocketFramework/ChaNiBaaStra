using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.Utilities
{
    public class SinglePlanetYoga
    {
        public SinglePlanetYoga()
        {
            PlanetNames = new List<EnumPlanet>();
            PlanetPlacedHouses = new List<int>();
            PlacetPlacesRashis = new List<EnumRasi>();

            ExpectedRelationshipWithAnyGivenHouse = new List<EnumPlanetRasiRelationTypes>();
            ExpectedRelationshipWithAnyGivenRashi = new List<EnumPlanetRasiRelationTypes>();
        }
        public List<EnumPlanet> PlanetNames { get; set; }

        public int PlanetBaseRelativeHouse { get; set; }
        public string PlanetBaseRelativeRashi { get; set; }

        public List<int> PlanetPlacedHouses { get; set; }
        public List<EnumRasi> PlacetPlacesRashis { get; set; }

        public List<EnumPlanetRasiRelationTypes> ExpectedRelationshipWithAnyGivenHouse { get; set; }
        public List<EnumPlanetRasiRelationTypes> ExpectedRelationshipWithAnyGivenRashi { get; set; }

        public List<int> PlanetIsAdhipathiOfHouse { get; set; }
        public List<int> PlanetIsAdhipathiOfRashi { get; set; }

        public List<string> WhatPlanetIShouldSee { get; set; }
        public List<string> WhichPlanetShouldSeeMee { get; set; }

        public List<string> WhichPlanetIsNextToMe { get; set; }
        public List<string> WhichPlanetIsBeforeMe { get; set; }
    }

    public class RelationshipObject
    {
        public enum RelationshipTypes
        {
            Conjunction,
            NotConjunction,
            NotEitherSides
        }
    }

    public class TwoPlanetYoga
    {
        public TwoPlanetYoga()
        {
            Planet1 = new SinglePlanetYoga();
            Planet2 = new SinglePlanetYoga();
            Relation = new RelationshipObject();
        }

        public SinglePlanetYoga Planet1 { get; set; }
        public SinglePlanetYoga Planet2 { get; set; }
        public RelationshipObject Relation { get; set; }
    }

    public class ManyPlanetYoga
    {
        List<TwoPlanetYoga> PlanetYoga { get;set; }
    }

    public class YogaDefinition
    { }

    public class JobChangeOrLost : YogaDefinition
    {
        public JobChangeOrLost()
        {
            
        }
    }

    public class MahaYogaDefinition : YogaDefinition
    {
        public string Name { get; set; }
        public SinglePlanetYoga singlePlanetYoga = new SinglePlanetYoga();
        public MahaYogaDefinition()
        {
            singlePlanetYoga.PlanetNames
                .AddRange(new EnumPlanet[] { EnumPlanet.Jupiter, EnumPlanet.Mars
                , EnumPlanet.Venus, EnumPlanet.Mercury, EnumPlanet.Saturn });
            singlePlanetYoga.PlanetBaseRelativeHouse = 1;
            singlePlanetYoga.PlanetPlacedHouses.AddRange(new int[] { 1, 4, 7, 10 });
            singlePlanetYoga.ExpectedRelationshipWithAnyGivenHouse
                .AddRange(new EnumPlanetRasiRelationTypes[] { EnumPlanetRasiRelationTypes.Uchcha
                , EnumPlanetRasiRelationTypes.Swashesthra, EnumPlanetRasiRelationTypes.UchchaMulaThrikona
                , EnumPlanetRasiRelationTypes.SwashesthraMulaThrikona
                , EnumPlanetRasiRelationTypes.UchchaMulaThrikonaSwashesthra });
        }
    }

    public class KajaKesariYogaDefinition : YogaDefinition
    {
        public string Name { get; set; }

        public KajaKesariYogaDefinition(AstroPlanet moon, AstroPlanet jupiter)
        {
            if ((moon.HouseNumber == 6) || (moon.HouseNumber == 8) 
                || (moon.HouseNumber == 12))
                return;
            double dGab = (moon.Longitude - jupiter.Longitude) / 30;
            double decPart = (dGab - Math.Truncate(dGab))*30;
            if (decPart > 15)
                return;
            if (((int)dGab == 0) || ((int)dGab == 3) 
                || ((int)dGab == 6) || ((int)dGab == 9))
                Name = "Gaja Kesari Yoga Moon - " + moon.HouseNumber 
                    + " Jupiter - " + jupiter.HouseNumber;
        }
    }
}
