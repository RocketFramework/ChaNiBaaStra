using ChaNiBaaStra.DataModels;

namespace ChaNiBaaStra.Calculator
{
    public class NakathFinderInput
    {
        public EnumRasi[] LangnaToConsider { get; set; }
        public EnumNakath[] NakathToConsider { get; set; }
        public int[] NakathNumberFromRaviNakath { get; set; }
        public EnumThithi[] ThithiToConsider { get; set; }
        public int[] MaleficPlanetPosition { get; set; }
        public int[] BeneficPlanetPosition { get; set; }
        public int[] EmptyHousesToConsider { get; set; }
        public bool DoCheckYoga { get; set; }
        public bool DoCheckNakathWithMine { get; set; }
        public bool DoCheckOtherConditions { get; set; }
        public bool DoCheckPanchanga { get; set; }
        public bool DoCheckMoonStength { get; set; }

    }
}