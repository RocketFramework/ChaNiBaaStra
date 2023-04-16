using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Reflection;
using ChaNiBaaStra.Dal.Models;
using System.Runtime.InteropServices;

namespace ChaNiBaaStra.Configuration
{
    public class PlanetInHouse
    {
        public PlanetInHouse(int house, EnumPlanet planet)
        {
            this.HouseNumber = house;
            this.PlanetName = planet;
        }
        public int HouseNumber { get; set; }
        public EnumPlanet PlanetName { get; set; }
    }

    public class PlanetsInHouse
    {
        public PlanetsInHouse(int house, List<EnumPlanet> planets)
        {
            this.HouseNumber = house;
            this.PlanetNames = planets;
        }
        public int HouseNumber { get; set; }
        public List<EnumPlanet> PlanetNames { get; set; }
    }

    public class PlanetInRashi
    {
        public PlanetInRashi(EnumRasi rashi, EnumPlanet planet)
        {
            this.PlanetName = planet;
            this.RashiName = rashi;
        }
        public EnumPlanet PlanetName { get; set; }
        public EnumRasi RashiName { get; set; }
    }

    public class PlanetsInRashi
    {
        public PlanetsInRashi(EnumRasi rashi, List<EnumPlanet> planets)
        {
            this.PlanetNames = planets;
            this.RashiName = rashi;
        }
        public List<EnumPlanet> PlanetNames { get; set; }
        public EnumRasi RashiName { get; set; }
    }

    public class AstroYogaConfigurationItem
    {
        public AstroYogaConfigurationItem()
        {
            ListOfPlanetPlacedInHouse = new List<PlanetInHouse>();
            ListofPlanetsPlacedInHouse = new List<PlanetsInHouse>();
            ListOfPlanetPlacedInRashi = new List<PlanetInRashi>();
            ListOfPlanetsPlacedInRashi = new List<PlanetsInRashi>();

            ListOfEmptyHouseNumbers = new List<int>();
            ListOfFilledHouseNumbers = new List<int>();

            YogaId = DateTime.Now.Ticks;
        }

        private List<int> value = new List<int>();
        private bool isOrdered = false;
        public List<int> CompareValue
        {
            get
            {
                if (value.Count != 0)
                    return value;
                if (!isOrdered)
                {
                    isOrdered = true;
                    ListOfPlanetPlacedInHouse = ListOfPlanetPlacedInHouse.OrderBy(x => x.PlanetName).ToList();
                    ListOfPlanetPlacedInRashi = ListOfPlanetPlacedInRashi.OrderBy(x => x.RashiName).ToList();
                }
                List<int> numbers = new List<int>();

                numbers.Add(LagnaRashi);
                numbers.Add(IsMale);
                numbers.Add(IsBornInDayTime);
                numbers.Add(IsLagnaWargoththama);
                numbers.Add(NawamsakaRashi);

                numbers.Add(House_1_Empty);
                numbers.Add(House_2_Empty);
                numbers.Add(House_3_Empty);
                numbers.Add(House_4_Empty);
                numbers.Add(House_5_Empty);
                numbers.Add(House_6_Empty);
                numbers.Add(House_7_Empty);
                numbers.Add(House_8_Empty);
                numbers.Add(House_9_Empty);
                numbers.Add(House_10_Empty);
                numbers.Add(House_11_Empty);
                numbers.Add(House_12_Empty);

                numbers.Add(House_1_NotEmpty);
                numbers.Add(House_2_NotEmpty);
                numbers.Add(House_3_NotEmpty);
                numbers.Add(House_4_NotEmpty);
                numbers.Add(House_5_NotEmpty);
                numbers.Add(House_6_NotEmpty);
                numbers.Add(House_7_NotEmpty);
                numbers.Add(House_8_NotEmpty);
                numbers.Add(House_9_NotEmpty);
                numbers.Add(House_10_NotEmpty);
                numbers.Add(House_11_NotEmpty);
                numbers.Add(House_12_NotEmpty);

                numbers.Add(Sun_1_House);
                numbers.Add(Sun_2_House);
                numbers.Add(Sun_3_House);
                numbers.Add(Sun_4_House);
                numbers.Add(Sun_5_House);
                numbers.Add(Sun_6_House);
                numbers.Add(Sun_7_House);
                numbers.Add(Sun_8_House);
                numbers.Add(Sun_9_House);
                numbers.Add(Sun_10_House);
                numbers.Add(Sun_11_House);
                numbers.Add(Sun_12_House);

                numbers.Add(Moon_1_House);
                numbers.Add(Moon_2_House);
                numbers.Add(Moon_3_House);
                numbers.Add(Moon_4_House);
                numbers.Add(Moon_5_House);
                numbers.Add(Moon_6_House);
                numbers.Add(Moon_7_House);
                numbers.Add(Moon_8_House);
                numbers.Add(Moon_9_House);
                numbers.Add(Moon_10_House);
                numbers.Add(Moon_11_House);
                numbers.Add(Moon_12_House);

                numbers.Add(Mars_1_House);
                numbers.Add(Mars_2_House);
                numbers.Add(Mars_3_House);
                numbers.Add(Mars_4_House);
                numbers.Add(Mars_5_House);
                numbers.Add(Mars_6_House);
                numbers.Add(Mars_7_House);
                numbers.Add(Mars_8_House);
                numbers.Add(Mars_9_House);
                numbers.Add(Mars_10_House);
                numbers.Add(Mars_11_House);
                numbers.Add(Mars_12_House);

                numbers.Add(Mercury_1_House);
                numbers.Add(Mercury_2_House);
                numbers.Add(Mercury_3_House);
                numbers.Add(Mercury_4_House);
                numbers.Add(Mercury_5_House);
                numbers.Add(Mercury_6_House);
                numbers.Add(Mercury_7_House);
                numbers.Add(Mercury_8_House);
                numbers.Add(Mercury_9_House);
                numbers.Add(Mercury_10_House);
                numbers.Add(Mercury_11_House);
                numbers.Add(Mercury_12_House);

                numbers.Add(Jupiter_1_House);
                numbers.Add(Jupiter_2_House);
                numbers.Add(Jupiter_3_House);
                numbers.Add(Jupiter_4_House);
                numbers.Add(Jupiter_5_House);
                numbers.Add(Jupiter_6_House);
                numbers.Add(Jupiter_7_House);
                numbers.Add(Jupiter_8_House);
                numbers.Add(Jupiter_9_House);
                numbers.Add(Jupiter_10_House);
                numbers.Add(Jupiter_11_House);
                numbers.Add(Jupiter_12_House);

                numbers.Add(Venus_1_House);
                numbers.Add(Venus_2_House);
                numbers.Add(Venus_3_House);
                numbers.Add(Venus_4_House);
                numbers.Add(Venus_5_House);
                numbers.Add(Venus_6_House);
                numbers.Add(Venus_7_House);
                numbers.Add(Venus_8_House);
                numbers.Add(Venus_9_House);
                numbers.Add(Venus_10_House);
                numbers.Add(Venus_11_House);
                numbers.Add(Venus_12_House);

                numbers.Add(Saturn_1_House);
                numbers.Add(Saturn_2_House);
                numbers.Add(Saturn_3_House);
                numbers.Add(Saturn_4_House);
                numbers.Add(Saturn_5_House);
                numbers.Add(Saturn_6_House);
                numbers.Add(Saturn_7_House);
                numbers.Add(Saturn_8_House);
                numbers.Add(Saturn_9_House);
                numbers.Add(Saturn_10_House);
                numbers.Add(Saturn_11_House);
                numbers.Add(Saturn_12_House);

                numbers.Add(Rahu_1_House);
                numbers.Add(Rahu_2_House);
                numbers.Add(Rahu_3_House);
                numbers.Add(Rahu_4_House);
                numbers.Add(Rahu_5_House);
                numbers.Add(Rahu_6_House);
                numbers.Add(Rahu_7_House);
                numbers.Add(Rahu_8_House);
                numbers.Add(Rahu_9_House);
                numbers.Add(Rahu_10_House);
                numbers.Add(Rahu_11_House);
                numbers.Add(Rahu_12_House);

                numbers.Add(Kethu_1_House);
                numbers.Add(Kethu_2_House);
                numbers.Add(Kethu_3_House);
                numbers.Add(Kethu_4_House);
                numbers.Add(Kethu_5_House);
                numbers.Add(Kethu_6_House);
                numbers.Add(Kethu_7_House);
                numbers.Add(Kethu_8_House);
                numbers.Add(Kethu_9_House);
                numbers.Add(Kethu_10_House);
                numbers.Add(Kethu_11_House);
                numbers.Add(Kethu_12_House);

                numbers.Add(Sun_Mesha_Rashi);
                numbers.Add(Sun_Vrishabha_Rashi);
                numbers.Add(Sun_Mithuna_Rashi);
                numbers.Add(Sun_Kataka_Rashi);
                numbers.Add(Sun_Simha_Rashi);
                numbers.Add(Sun_Kanya_Rashi);
                numbers.Add(Sun_Thula_Rashi);
                numbers.Add(Sun_Vrichika_Rashi);
                numbers.Add(Sun_Dhanus_Rashi);
                numbers.Add(Sun_Makara_Rashi);
                numbers.Add(Sun_Kumbha_Rashi);
                numbers.Add(Sun_Meena_Rashi);

                numbers.Add(Moon_Mesha_Rashi);
                numbers.Add(Moon_Vrishabha_Rashi);
                numbers.Add(Moon_Mithuna_Rashi);
                numbers.Add(Moon_Kataka_Rashi);
                numbers.Add(Moon_Simha_Rashi);
                numbers.Add(Moon_Kanya_Rashi);
                numbers.Add(Moon_Thula_Rashi);
                numbers.Add(Moon_Vrichika_Rashi);
                numbers.Add(Moon_Dhanus_Rashi);
                numbers.Add(Moon_Makara_Rashi);
                numbers.Add(Moon_Kumbha_Rashi);
                numbers.Add(Moon_Meena_Rashi);

                numbers.Add(Mars_Mesha_Rashi);
                numbers.Add(Mars_Vrishabha_Rashi);
                numbers.Add(Mars_Mithuna_Rashi);
                numbers.Add(Mars_Kataka_Rashi);
                numbers.Add(Mars_Simha_Rashi);
                numbers.Add(Mars_Kanya_Rashi);
                numbers.Add(Mars_Thula_Rashi);
                numbers.Add(Mars_Vrichika_Rashi);
                numbers.Add(Mars_Dhanus_Rashi);
                numbers.Add(Mars_Makara_Rashi);
                numbers.Add(Mars_Kumbha_Rashi);
                numbers.Add(Mars_Meena_Rashi);

                numbers.Add(Mercury_Mesha_Rashi);
                numbers.Add(Mercury_Vrishabha_Rashi);
                numbers.Add(Mercury_Mithuna_Rashi);
                numbers.Add(Mercury_Kataka_Rashi);
                numbers.Add(Mercury_Simha_Rashi);
                numbers.Add(Mercury_Kanya_Rashi);
                numbers.Add(Mercury_Thula_Rashi);
                numbers.Add(Mercury_Vrichika_Rashi);
                numbers.Add(Mercury_Dhanus_Rashi);
                numbers.Add(Mercury_Makara_Rashi);
                numbers.Add(Mercury_Kumbha_Rashi);
                numbers.Add(Mercury_Meena_Rashi);

                numbers.Add(Jupiter_Mesha_Rashi);
                numbers.Add(Jupiter_Vrishabha_Rashi);
                numbers.Add(Jupiter_Mithuna_Rashi);
                numbers.Add(Jupiter_Kataka_Rashi);
                numbers.Add(Jupiter_Simha_Rashi);
                numbers.Add(Jupiter_Kanya_Rashi);
                numbers.Add(Jupiter_Thula_Rashi);
                numbers.Add(Jupiter_Vrichika_Rashi);
                numbers.Add(Jupiter_Dhanus_Rashi);
                numbers.Add(Jupiter_Makara_Rashi);
                numbers.Add(Jupiter_Kumbha_Rashi);
                numbers.Add(Jupiter_Meena_Rashi);

                numbers.Add(Venus_Mesha_Rashi);
                numbers.Add(Venus_Vrishabha_Rashi);
                numbers.Add(Venus_Mithuna_Rashi);
                numbers.Add(Venus_Kataka_Rashi);
                numbers.Add(Venus_Simha_Rashi);
                numbers.Add(Venus_Kanya_Rashi);
                numbers.Add(Venus_Thula_Rashi);
                numbers.Add(Venus_Vrichika_Rashi);
                numbers.Add(Venus_Dhanus_Rashi);
                numbers.Add(Venus_Makara_Rashi);
                numbers.Add(Venus_Kumbha_Rashi);
                numbers.Add(Venus_Meena_Rashi);

                numbers.Add(Saturn_Mesha_Rashi);
                numbers.Add(Saturn_Vrishabha_Rashi);
                numbers.Add(Saturn_Mithuna_Rashi);
                numbers.Add(Saturn_Kataka_Rashi);
                numbers.Add(Saturn_Simha_Rashi);
                numbers.Add(Saturn_Kanya_Rashi);
                numbers.Add(Saturn_Thula_Rashi);
                numbers.Add(Saturn_Vrichika_Rashi);
                numbers.Add(Saturn_Dhanus_Rashi);
                numbers.Add(Saturn_Makara_Rashi);
                numbers.Add(Saturn_Kumbha_Rashi);
                numbers.Add(Saturn_Meena_Rashi);

                numbers.Add(Rahu_Mesha_Rashi);
                numbers.Add(Rahu_Vrishabha_Rashi);
                numbers.Add(Rahu_Mithuna_Rashi);
                numbers.Add(Rahu_Kataka_Rashi);
                numbers.Add(Rahu_Simha_Rashi);
                numbers.Add(Rahu_Kanya_Rashi);
                numbers.Add(Rahu_Thula_Rashi);
                numbers.Add(Rahu_Vrichika_Rashi);
                numbers.Add(Rahu_Dhanus_Rashi);
                numbers.Add(Rahu_Makara_Rashi);
                numbers.Add(Rahu_Kumbha_Rashi);
                numbers.Add(Rahu_Meena_Rashi);

                numbers.Add(Kethu_Mesha_Rashi);
                numbers.Add(Kethu_Vrishabha_Rashi);
                numbers.Add(Kethu_Mithuna_Rashi);
                numbers.Add(Kethu_Kataka_Rashi);
                numbers.Add(Kethu_Simha_Rashi);
                numbers.Add(Kethu_Kanya_Rashi);
                numbers.Add(Kethu_Thula_Rashi);
                numbers.Add(Kethu_Vrichika_Rashi);
                numbers.Add(Kethu_Dhanus_Rashi);
                numbers.Add(Kethu_Makara_Rashi);
                numbers.Add(Kethu_Kumbha_Rashi);
                numbers.Add(Kethu_Meena_Rashi);

                value = numbers;
                return numbers;
            }
        }
        public List<PlanetInHouse> ListOfPlanetPlacedInHouse { get; set; }
        public List<PlanetsInHouse> ListofPlanetsPlacedInHouse { get; set; }
        public List<PlanetInRashi> ListOfPlanetPlacedInRashi { get; set; }
        public List<PlanetsInRashi> ListOfPlanetsPlacedInRashi { get; set; }
        public List<int> ListOfEmptyHouseNumbers { get; set; }
        public List<int> ListOfFilledHouseNumbers { get; set; }

        private bool Exist(int house, EnumPlanet planet)
        {
            return ((ListOfPlanetPlacedInHouse
                    .Exists(x => ((x.HouseNumber == house)
                    && (x.PlanetName == planet)))));
        }

        private bool Exist(EnumRasi rashi, EnumPlanet planet)
        {
            return ((ListOfPlanetPlacedInRashi
                    .Exists(x => ((x.RashiName == rashi)
                    && (x.PlanetName == planet)))));
        }

        public string YogaName { get; set; }
        public long YogaId { get; set; }
        public string YogaDescription { get; set; }
        public int LagnaRashi { get; set; }
        public int NawamsakaRashi { get; set; }
        /// <summary>
        /// True = 2, False = 1
        /// </summary>
        public int IsBornInDayTime { get; set; }
        /// <summary>
        /// True = 2, False = 1
        /// </summary>
        public int IsMale { get; set; }
        /// <summary>
        /// True = 2, False = 1
        /// </summary>
        public int IsLagnaWargoththama { get; set; }

        public int House_1_Empty { get { return (ListOfEmptyHouseNumbers.Contains(1) ? 1 : 0); } } 
        public int House_2_Empty { get { return (ListOfEmptyHouseNumbers.Contains(2) ? 1 : 0); } } 
        public int House_3_Empty { get { return (ListOfEmptyHouseNumbers.Contains(3) ? 1 : 0); } } 
        public int House_4_Empty { get { return (ListOfEmptyHouseNumbers.Contains(4) ? 1 : 0); } } 
        public int House_5_Empty { get { return (ListOfEmptyHouseNumbers.Contains(5) ? 1 : 0); } } 
        public int House_6_Empty { get { return (ListOfEmptyHouseNumbers.Contains(6) ? 1 : 0); } } 
        public int House_7_Empty { get { return (ListOfEmptyHouseNumbers.Contains(7) ? 1 : 0); } } 
        public int House_8_Empty { get { return (ListOfEmptyHouseNumbers.Contains(8) ? 1 : 0); } } 
        public int House_9_Empty { get { return (ListOfEmptyHouseNumbers.Contains(9) ? 1 : 0); } }
        public int House_10_Empty { get { return (ListOfEmptyHouseNumbers.Contains(10) ? 1 : 0); } } 
        public int House_11_Empty { get { return (ListOfEmptyHouseNumbers.Contains(11) ? 1 : 0); } } 
        public int House_12_Empty { get { return (ListOfEmptyHouseNumbers.Contains(12) ? 1 : 0); } }

        public int House_1_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(1) ? 1 : 0); } }
        public int House_2_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(2) ? 1 : 0); } }
        public int House_3_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(3) ? 1 : 0); } }
        public int House_4_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(4) ? 1 : 0); } }
        public int House_5_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(5) ? 1 : 0); } }
        public int House_6_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(6) ? 1 : 0); } }
        public int House_7_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(7) ? 1 : 0); } }
        public int House_8_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(8) ? 1 : 0); } }
        public int House_9_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(9) ? 1 : 0); } }
        public int House_10_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(10) ? 1 : 0); } }
        public int House_11_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(11) ? 1 : 0); } }
        public int House_12_NotEmpty { get { return (ListOfFilledHouseNumbers.Contains(12) ? 1 : 0); } }

        public int Kethu_1_House { get { return (Exist(1, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_2_House { get { return (Exist(2, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_3_House { get { return (Exist(3, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_4_House { get { return (Exist(4, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_5_House { get { return (Exist(5, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_6_House { get { return (Exist(6, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_7_House { get { return (Exist(7, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_8_House { get { return (Exist(8, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_9_House { get { return (Exist(9, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_10_House { get { return (Exist(10, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_11_House { get { return (Exist(11, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_12_House { get { return (Exist(12, EnumPlanet.Kethu) ? 1 : 0); } }

        public int Rahu_1_House { get { return (Exist(1, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_2_House { get { return (Exist(2, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_3_House { get { return (Exist(3, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_4_House { get { return (Exist(4, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_5_House { get { return (Exist(5, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_6_House { get { return (Exist(6, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_7_House { get { return (Exist(7, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_8_House { get { return (Exist(8, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_9_House { get { return (Exist(9, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_10_House { get { return (Exist(10, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_11_House { get { return (Exist(11, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_12_House { get { return (Exist(12, EnumPlanet.Rahu) ? 1 : 0); } }

        public int Saturn_1_House { get { return (Exist(1, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_2_House { get { return (Exist(2, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_3_House { get { return (Exist(3, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_4_House { get { return (Exist(4, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_5_House { get { return (Exist(5, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_6_House { get { return (Exist(6, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_7_House { get { return (Exist(7, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_8_House { get { return (Exist(8, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_9_House { get { return (Exist(9, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_10_House { get { return (Exist(10, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_11_House { get { return (Exist(11, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_12_House { get { return (Exist(12, EnumPlanet.Saturn) ? 1 : 0); } }

        public int Mercury_1_House { get { return (Exist(1, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_2_House { get { return (Exist(2, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_3_House { get { return (Exist(3, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_4_House { get { return (Exist(4, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_5_House { get { return (Exist(5, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_6_House { get { return (Exist(6, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_7_House { get { return (Exist(7, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_8_House { get { return (Exist(8, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_9_House { get { return (Exist(9, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_10_House { get { return (Exist(10, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_11_House { get { return (Exist(11, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_12_House { get { return (Exist(12, EnumPlanet.Mercury) ? 1 : 0); } }

        public int Venus_1_House { get { return (Exist(1, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_2_House { get { return (Exist(2, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_3_House { get { return (Exist(3, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_4_House { get { return (Exist(4, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_5_House { get { return (Exist(5, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_6_House { get { return (Exist(6, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_7_House { get { return (Exist(7, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_8_House { get { return (Exist(8, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_9_House { get { return (Exist(9, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_10_House { get { return (Exist(10, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_11_House { get { return (Exist(11, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_12_House { get { return (Exist(12, EnumPlanet.Venus) ? 1 : 0); } }

        public int Moon_1_House { get { return (Exist(1, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_2_House { get { return (Exist(2, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_3_House { get { return (Exist(3, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_4_House { get { return (Exist(4, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_5_House { get { return (Exist(5, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_6_House { get { return (Exist(6, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_7_House { get { return (Exist(7, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_8_House { get { return (Exist(8, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_9_House { get { return (Exist(9, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_10_House { get { return (Exist(10, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_11_House { get { return (Exist(11, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_12_House { get { return (Exist(12, EnumPlanet.Moon) ? 1 : 0); } }

        public int Sun_1_House { get { return (Exist(1, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_2_House { get { return (Exist(2, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_3_House { get { return (Exist(3, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_4_House { get { return (Exist(4, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_5_House { get { return (Exist(5, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_6_House { get { return (Exist(6, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_7_House { get { return (Exist(7, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_8_House { get { return (Exist(8, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_9_House { get { return (Exist(9, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_10_House { get { return (Exist(10, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_11_House { get { return (Exist(11, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_12_House { get { return (Exist(12, EnumPlanet.Sun) ? 1 : 0); } }

        public int Jupiter_1_House { get { return (Exist(1, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_2_House { get { return (Exist(2, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_3_House { get { return (Exist(3, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_4_House { get { return (Exist(4, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_5_House { get { return (Exist(5, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_6_House { get { return (Exist(6, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_7_House { get { return (Exist(7, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_8_House { get { return (Exist(8, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_9_House { get { return (Exist(9, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_10_House { get { return (Exist(10, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_11_House { get { return (Exist(11, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_12_House { get { return (Exist(12, EnumPlanet.Jupiter) ? 1 : 0); } }

        public int Mars_1_House { get { return (Exist(1, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_2_House { get { return (Exist(2, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_3_House { get { return (Exist(3, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_4_House { get { return (Exist(4, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_5_House { get { return (Exist(5, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_6_House { get { return (Exist(6, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_7_House { get { return (Exist(7, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_8_House { get { return (Exist(8, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_9_House { get { return (Exist(9, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_10_House { get { return (Exist(10, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_11_House { get { return (Exist(11, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_12_House { get { return (Exist(12, EnumPlanet.Mars) ? 1 : 0); } }

        public int Kethu_Mesha_Rashi { get { return (Exist(EnumRasi.Mesha, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Vrishabha_Rashi { get { return (Exist(EnumRasi.Vrishabha, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Mithuna_Rashi { get { return (Exist(EnumRasi.Mithuna, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Kataka_Rashi { get { return (Exist(EnumRasi.Kataka, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Simha_Rashi { get { return (Exist(EnumRasi.Simha, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Kanya_Rashi { get { return (Exist(EnumRasi.Kanya, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Thula_Rashi { get { return (Exist(EnumRasi.Thula, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Vrichika_Rashi { get { return (Exist(EnumRasi.Vrichika, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Dhanus_Rashi { get { return (Exist(EnumRasi.Dhanus, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Makara_Rashi { get { return (Exist(EnumRasi.Makara, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Kumbha_Rashi { get { return (Exist(EnumRasi.Kumbha, EnumPlanet.Kethu) ? 1 : 0); } }
        public int Kethu_Meena_Rashi { get { return (Exist(EnumRasi.Meena, EnumPlanet.Kethu) ? 1 : 0); } }

        public int Rahu_Mesha_Rashi { get { return (Exist(EnumRasi.Mesha, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Vrishabha_Rashi { get { return (Exist(EnumRasi.Vrishabha, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Mithuna_Rashi { get { return (Exist(EnumRasi.Mithuna, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Kataka_Rashi { get { return (Exist(EnumRasi.Kataka, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Simha_Rashi { get { return (Exist(EnumRasi.Simha, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Kanya_Rashi { get { return (Exist(EnumRasi.Kanya, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Thula_Rashi { get { return (Exist(EnumRasi.Thula, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Vrichika_Rashi { get { return (Exist(EnumRasi.Vrichika, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Dhanus_Rashi { get { return (Exist(EnumRasi.Dhanus, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Makara_Rashi { get { return (Exist(EnumRasi.Makara, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Kumbha_Rashi { get { return (Exist(EnumRasi.Kumbha, EnumPlanet.Rahu) ? 1 : 0); } }
        public int Rahu_Meena_Rashi { get { return (Exist(EnumRasi.Meena, EnumPlanet.Rahu) ? 1 : 0); } }

        public int Saturn_Mesha_Rashi { get { return (Exist(EnumRasi.Mesha, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Vrishabha_Rashi { get { return (Exist(EnumRasi.Vrishabha, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Mithuna_Rashi { get { return (Exist(EnumRasi.Mithuna, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Kataka_Rashi { get { return (Exist(EnumRasi.Kataka, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Simha_Rashi { get { return (Exist(EnumRasi.Simha, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Kanya_Rashi { get { return (Exist(EnumRasi.Kanya, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Thula_Rashi { get { return (Exist(EnumRasi.Thula, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Vrichika_Rashi { get { return (Exist(EnumRasi.Vrichika, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Dhanus_Rashi { get { return (Exist(EnumRasi.Dhanus, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Makara_Rashi { get { return (Exist(EnumRasi.Makara, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Kumbha_Rashi { get { return (Exist(EnumRasi.Kumbha, EnumPlanet.Saturn) ? 1 : 0); } }
        public int Saturn_Meena_Rashi { get { return (Exist(EnumRasi.Meena, EnumPlanet.Saturn) ? 1 : 0); } }

        public int Mercury_Mesha_Rashi { get { return (Exist(EnumRasi.Mesha, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Vrishabha_Rashi { get { return (Exist(EnumRasi.Vrishabha, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Mithuna_Rashi { get { return (Exist(EnumRasi.Mithuna, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Kataka_Rashi { get { return (Exist(EnumRasi.Kataka, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Simha_Rashi { get { return (Exist(EnumRasi.Simha, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Kanya_Rashi { get { return (Exist(EnumRasi.Kanya, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Thula_Rashi { get { return (Exist(EnumRasi.Thula, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Vrichika_Rashi { get { return (Exist(EnumRasi.Vrichika, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Dhanus_Rashi { get { return (Exist(EnumRasi.Dhanus, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Makara_Rashi { get { return (Exist(EnumRasi.Makara, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Kumbha_Rashi { get { return (Exist(EnumRasi.Kumbha, EnumPlanet.Mercury) ? 1 : 0); } }
        public int Mercury_Meena_Rashi { get { return (Exist(EnumRasi.Meena, EnumPlanet.Mercury) ? 1 : 0); } }

        public int Venus_Mesha_Rashi { get { return (Exist(EnumRasi.Mesha, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Vrishabha_Rashi { get { return (Exist(EnumRasi.Vrishabha, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Mithuna_Rashi { get { return (Exist(EnumRasi.Mithuna, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Kataka_Rashi { get { return (Exist(EnumRasi.Kataka, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Simha_Rashi { get { return (Exist(EnumRasi.Simha, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Kanya_Rashi { get { return (Exist(EnumRasi.Kanya, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Thula_Rashi { get { return (Exist(EnumRasi.Thula, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Vrichika_Rashi { get { return (Exist(EnumRasi.Vrichika, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Dhanus_Rashi { get { return (Exist(EnumRasi.Dhanus, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Makara_Rashi { get { return (Exist(EnumRasi.Makara, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Kumbha_Rashi { get { return (Exist(EnumRasi.Kumbha, EnumPlanet.Venus) ? 1 : 0); } }
        public int Venus_Meena_Rashi { get { return (Exist(EnumRasi.Meena, EnumPlanet.Venus) ? 1 : 0); } }

        public int Moon_Mesha_Rashi { get { return (Exist(EnumRasi.Mesha, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Vrishabha_Rashi { get { return (Exist(EnumRasi.Vrishabha, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Mithuna_Rashi { get { return (Exist(EnumRasi.Mithuna, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Kataka_Rashi { get { return (Exist(EnumRasi.Kataka, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Simha_Rashi { get { return (Exist(EnumRasi.Simha, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Kanya_Rashi { get { return (Exist(EnumRasi.Kanya, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Thula_Rashi { get { return (Exist(EnumRasi.Thula, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Vrichika_Rashi { get { return (Exist(EnumRasi.Vrichika, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Dhanus_Rashi { get { return (Exist(EnumRasi.Dhanus, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Makara_Rashi { get { return (Exist(EnumRasi.Makara, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Kumbha_Rashi { get { return (Exist(EnumRasi.Kumbha, EnumPlanet.Moon) ? 1 : 0); } }
        public int Moon_Meena_Rashi { get { return (Exist(EnumRasi.Meena, EnumPlanet.Moon) ? 1 : 0); } }

        public int Sun_Mesha_Rashi { get { return (Exist(EnumRasi.Mesha, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Vrishabha_Rashi { get { return (Exist(EnumRasi.Vrishabha, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Mithuna_Rashi { get { return (Exist(EnumRasi.Mithuna, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Kataka_Rashi { get { return (Exist(EnumRasi.Kataka, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Simha_Rashi { get { return (Exist(EnumRasi.Simha, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Kanya_Rashi { get { return (Exist(EnumRasi.Kanya, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Thula_Rashi { get { return (Exist(EnumRasi.Thula, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Vrichika_Rashi { get { return (Exist(EnumRasi.Vrichika, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Dhanus_Rashi { get { return (Exist(EnumRasi.Dhanus, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Makara_Rashi { get { return (Exist(EnumRasi.Makara, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Kumbha_Rashi { get { return (Exist(EnumRasi.Kumbha, EnumPlanet.Sun) ? 1 : 0); } }
        public int Sun_Meena_Rashi { get { return (Exist(EnumRasi.Meena, EnumPlanet.Sun) ? 1 : 0); } }

        public int Jupiter_Mesha_Rashi { get { return (Exist(EnumRasi.Mesha, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Vrishabha_Rashi { get { return (Exist(EnumRasi.Vrishabha, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Mithuna_Rashi { get { return (Exist(EnumRasi.Mithuna, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Kataka_Rashi { get { return (Exist(EnumRasi.Kataka, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Simha_Rashi { get { return (Exist(EnumRasi.Simha, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Kanya_Rashi { get { return (Exist(EnumRasi.Kanya, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Thula_Rashi { get { return (Exist(EnumRasi.Thula, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Vrichika_Rashi { get { return (Exist(EnumRasi.Vrichika, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Dhanus_Rashi { get { return (Exist(EnumRasi.Dhanus, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Makara_Rashi { get { return (Exist(EnumRasi.Makara, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Kumbha_Rashi { get { return (Exist(EnumRasi.Kumbha, EnumPlanet.Jupiter) ? 1 : 0); } }
        public int Jupiter_Meena_Rashi { get { return (Exist(EnumRasi.Meena, EnumPlanet.Jupiter) ? 1 : 0); } }

        public int Mars_Mesha_Rashi { get { return (Exist(EnumRasi.Mesha, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Vrishabha_Rashi { get { return (Exist(EnumRasi.Vrishabha, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Mithuna_Rashi { get { return (Exist(EnumRasi.Mithuna, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Kataka_Rashi { get { return (Exist(EnumRasi.Kataka, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Simha_Rashi { get { return (Exist(EnumRasi.Simha, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Kanya_Rashi { get { return (Exist(EnumRasi.Kanya, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Thula_Rashi { get { return (Exist(EnumRasi.Thula, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Vrichika_Rashi { get { return (Exist(EnumRasi.Vrichika, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Dhanus_Rashi { get { return (Exist(EnumRasi.Dhanus, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Makara_Rashi { get { return (Exist(EnumRasi.Makara, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Kumbha_Rashi { get { return (Exist(EnumRasi.Kumbha, EnumPlanet.Mars) ? 1 : 0); } }
        public int Mars_Meena_Rashi { get { return (Exist(EnumRasi.Meena, EnumPlanet.Mars) ? 1 : 0); } }
    }
}
