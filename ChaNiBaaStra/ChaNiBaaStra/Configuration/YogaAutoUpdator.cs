using ChaNiBaaStra.Dal.DB;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChaNiBaaStra.Configuration
{
    public class YogaAutoUpdator
    {
        public YogaAutoUpdator() { }

        public List<AstroYogaConfigurationItem> CalculateAll()
        {
            List<AstroYogaConfigurationItem> allYoga = new List<AstroYogaConfigurationItem>();
            allYoga.AddRange(this.YogaThatReduceBrothers());
            allYoga.AddRange(this.YogaThatMakeYouGoAbroad());
            allYoga.AddRange(this.YogaThatNegatePowerfulYoga());
            allYoga.AddRange(this.YogaThatKeepLegacy());
            allYoga.AddRange(this.YogaLeadToLuckyLife());
            allYoga.AddRange(this.YogaMahaPurusha());
            allYoga.AddRange(this.YogaKajaKeshary());
            allYoga.AddRange(this.CareerTypes());
            allYoga.AddRange(this.SomeRajaYoga());
            allYoga.AddRange(this.SomeDeadYoga());
            return allYoga;
        }

        public List<AstroYogaConfigurationItem> SomeDeadYoga()
        {
            List<AstroYogaConfigurationItem> yogaList = new List<AstroYogaConfigurationItem>();

            AstroYogaConfigurationItem yogaItem13 = new AstroYogaConfigurationItem();
            yogaItem13.YogaName = "Dead By the Birth";
            yogaItem13.YogaDescription = "Moon at 1, Saturn at 4, Mars at 7 and Sun at 10";
            yogaItem13.ListOfPlanetPlacedInHouse = new List<PlanetInHouse>();
            yogaItem13.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Moon));
            yogaItem13.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(4, EnumPlanet.Saturn));
            yogaItem13.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(7, EnumPlanet.Mars));
            yogaItem13.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(10, EnumPlanet.Sun));
            yogaList.Add(yogaItem13);

            return yogaList;
        }

        public List<AstroYogaConfigurationItem> SomeRajaYoga()
        {
            List<AstroYogaConfigurationItem> yogaCareerLife = new List<AstroYogaConfigurationItem>();
            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            // The page 155 of Waraha-Mihira has Jupiter in the list
            List<EnumPlanet> badPlanets = new List<EnumPlanet>() { EnumPlanet.Saturn, EnumPlanet.Mars
                , EnumPlanet.Sun, EnumPlanet.Jupiter };

            //// Waraha-Mihira page 158
            SetAnotherRajaYoga(yogaCareerLife, EnumPlanet.Moon, EnumRasi.Vrishabha);
            SetAnotherRajaYoga(yogaCareerLife, EnumPlanet.Saturn, EnumRasi.Thula);
            SetAnotherRajaYoga(yogaCareerLife, EnumRasi.Makara);
            SetAnotherRajaYoga(yogaCareerLife, EnumRasi.Kumbha);
            SetAnotherRajaYoga(yogaCareerLife);

            AstroYogaConfigurationItem rajaYoga0 = new AstroYogaConfigurationItem();
            rajaYoga0.YogaName = "Very Powerfull Raja Yoga - Three Bad planet in Exalted Rashies";
            rajaYoga0.YogaDescription = "Mars in Makara, Saturn in Thula, Sun in MEsha and Jupiter in Kataka";
            rajaYoga0.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Makara, EnumPlanet.Mars));
            rajaYoga0.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Thula, EnumPlanet.Saturn));
            rajaYoga0.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Mesha, EnumPlanet.Sun)); 
            rajaYoga0.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kataka, EnumPlanet.Jupiter));
            yogaCareerLife.Add(rajaYoga0);

            foreach (EnumRasi lagnaRashi in langaRashies)
            {
                if ((int)lagnaRashi == 0) continue;
                AstroRasi lagna = new AstroRasi(lagnaRashi);
                SetRareRajaYoga(yogaCareerLife, lagnaRashi, 1, false);

                for (int i = 0; i < badPlanets.Count; i++)
                {
                    EnumPlanet badPlanet1 = badPlanets[i];
                    List<int> bp1UchchaHouses = AstroGoodBad.GetAllUchchaHouseForLagnaAndPlanet(lagnaRashi, badPlanet1);
                    foreach (int uhouse1 in bp1UchchaHouses)
                    {
                        if (uhouse1 == 1)
                        {
                            AstroYogaConfigurationItem rajaYoga = new AstroYogaConfigurationItem();
                            rajaYoga.YogaName = "Powerfull Raja Yoga - Three Bad planet in Exalted Rashies";
                            rajaYoga.LagnaRashi = (int)lagnaRashi;
                            rajaYoga.YogaDescription = "" + badPlanet1 + " in " + uhouse1 + "";
                            rajaYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(uhouse1, badPlanet1));
                            rajaYoga.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kataka, EnumPlanet.Moon));
                            yogaCareerLife.Add(rajaYoga);
                        }
                    }
                }
            }
            return yogaCareerLife;
        }

        private void SetAnotherRajaYoga(List<AstroYogaConfigurationItem> yogaCareerLife)
        {
            AstroYogaConfigurationItem yogaItem13 = new AstroYogaConfigurationItem();
            yogaItem13.YogaName = "Raja Yoga";
            yogaItem13.YogaDescription = "Saturn Makara and it is lagna, Mercury Mithuna, Venus on Thula, Moon on Kataka, Mars on Mesha, Sun on Simha";
            yogaItem13.ListOfPlanetPlacedInRashi = new List<PlanetInRashi>();
            yogaItem13.LagnaRashi = (int)EnumRasi.Makara;
            yogaItem13.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Mithuna, EnumPlanet.Mercury));
            yogaItem13.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Makara, EnumPlanet.Saturn));
            yogaItem13.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Thula, EnumPlanet.Venus));
            yogaItem13.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kataka, EnumPlanet.Moon));
            yogaItem13.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Mesha, EnumPlanet.Mars));
            yogaItem13.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Simha, EnumPlanet.Sun));
            yogaCareerLife.Add(yogaItem13);

            AstroYogaConfigurationItem yogaItem12 = new AstroYogaConfigurationItem();
            yogaItem12.YogaName = "Raja Yoga";
            yogaItem12.YogaDescription = "Mercury on Kanya, Mars on Makara, Moon on Dhanus, Jupiter on Dhanus";
            yogaItem12.ListOfPlanetPlacedInRashi = new List<PlanetInRashi>();
            yogaItem12.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Dhanus, EnumPlanet.Jupiter));
            yogaItem12.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Dhanus, EnumPlanet.Moon));
            yogaItem12.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Makara, EnumPlanet.Mars));
            yogaItem12.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kanya, EnumPlanet.Mercury));
            yogaCareerLife.Add(yogaItem12);

            AstroYogaConfigurationItem yogaItem2 = new AstroYogaConfigurationItem();
            yogaItem2.YogaName = "Raja Yoga";
            yogaItem2.YogaDescription = "Jupiter on Dhanus, Moon on Dhanus, Mars on Makara, Venus on Meena";
            yogaItem2.ListOfPlanetPlacedInRashi = new List<PlanetInRashi>();
            yogaItem2.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Dhanus, EnumPlanet.Jupiter));
            yogaItem2.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Dhanus, EnumPlanet.Moon));
            yogaItem2.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Makara, EnumPlanet.Mars));
            yogaItem2.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Meena, EnumPlanet.Venus));
            yogaCareerLife.Add(yogaItem2);

            AstroYogaConfigurationItem yogaItem3 = new AstroYogaConfigurationItem();
            yogaItem3.YogaName = "Raja Yoga";
            yogaItem3.YogaDescription = "Moon, meena, Sun on Simha, Mars on Makara and Saturn on Kumbha";
            yogaItem3.ListOfPlanetPlacedInRashi = new List<PlanetInRashi>();
            yogaItem3.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kumbha, EnumPlanet.Saturn));
            yogaItem3.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Makara, EnumPlanet.Mars));
            yogaItem3.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Simha, EnumPlanet.Sun));
            yogaItem3.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Meena, EnumPlanet.Moon));
            yogaCareerLife.Add(yogaItem3);

            AstroYogaConfigurationItem yogaItem4 = new AstroYogaConfigurationItem();
            yogaItem4.YogaName = "Raja Yoga";
            yogaItem4.YogaDescription = "Saturn in Mesha and Jupiter in Kataka";
            yogaItem4.ListOfPlanetPlacedInRashi = new List<PlanetInRashi>();
            yogaItem4.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Mesha, EnumPlanet.Saturn));
            yogaItem4.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kataka, EnumPlanet.Jupiter));
            yogaCareerLife.Add(yogaItem4);

            AstroYogaConfigurationItem yogaItem5 = new AstroYogaConfigurationItem();
            yogaItem5.YogaName = "Raja Yoga";
            yogaItem5.YogaDescription = "Mars in Mesha and Jupter in Kataka";
            yogaItem5.ListOfPlanetPlacedInRashi = new List<PlanetInRashi>();
            yogaItem5.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Mesha, EnumPlanet.Mars));
            yogaItem5.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kataka, EnumPlanet.Jupiter));
            yogaCareerLife.Add(yogaItem5);

            AstroYogaConfigurationItem yogaItem6 = new AstroYogaConfigurationItem();
            yogaItem6.YogaName = "Raja Yoga";
            yogaItem6.YogaDescription = "Mars in Mesha and Jupter in Kataka";
            yogaItem6.ListOfPlanetPlacedInRashi = new List<PlanetInRashi>();
            yogaItem6.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(11, EnumPlanet.Moon));
            yogaItem6.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(11, EnumPlanet.Venus));
            yogaItem6.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(11, EnumPlanet.Mercury));
            yogaItem6.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kataka, EnumPlanet.Jupiter));
            yogaItem6.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Mesha, EnumPlanet.Sun));
            yogaCareerLife.Add(yogaItem6);
        }

        private void SetRareRajaYoga(List<AstroYogaConfigurationItem> yogaCareerLife, EnumRasi lagnaRashi
            , int houseISee, bool addMoon)
        {
            List<EnumPlanet> enumPlanets = new List<EnumPlanet>() { EnumPlanet.Saturn
                , EnumPlanet.Sun, EnumPlanet.Moon };
            foreach (EnumPlanet planet in enumPlanets)
            {
                // Waraha-Mihira page 157
                AstroYogaConfigurationItem rajaYoga = new AstroYogaConfigurationItem();
                rajaYoga.YogaName = "Definite Raja Yoga";
                rajaYoga.YogaDescription = "Saturn, Moon, Sun in good Rashies and one of them in Lagna";
                if (planet == EnumPlanet.Saturn)
                    rajaYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Saturn));
                rajaYoga.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kumbha, EnumPlanet.Saturn));
                if (planet == EnumPlanet.Moon)
                    rajaYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Moon));
                rajaYoga.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Vrishabha, EnumPlanet.Moon));
                if (planet == EnumPlanet.Sun)
                    rajaYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Sun));
                rajaYoga.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Mesha, EnumPlanet.Sun));
                rajaYoga.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Mithuna, EnumPlanet.Mercury));
                rajaYoga.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Simha, EnumPlanet.Jupiter));
                rajaYoga.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Vrichika, EnumPlanet.Mars));
                yogaCareerLife.Add(rajaYoga);
            }

            AstroYogaConfigurationItem rajaYogaSure2 = new AstroYogaConfigurationItem();
            rajaYogaSure2.YogaName = "Definite Raja Yoga";
            rajaYogaSure2.YogaDescription = "Saturn, Moon, Sun in good Rashies and one of them in Lagna";
            rajaYogaSure2.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Vrishabha, EnumPlanet.Moon));
            rajaYogaSure2.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Moon));
            rajaYogaSure2.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Thula, EnumPlanet.Venus));
            rajaYogaSure2.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Mesha, EnumPlanet.Mars));
            rajaYogaSure2.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kataka, EnumPlanet.Jupiter));
            rajaYogaSure2.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kanya, EnumPlanet.Mercury));
            rajaYogaSure2.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kanya, EnumPlanet.Sun));
            yogaCareerLife.Add(rajaYogaSure2);

            // Four of the main planet see the wargoththama Lagna or Moon
            List<EnumPlanet> yogaPlanets = new List<EnumPlanet>() { EnumPlanet.Saturn, EnumPlanet.Mars
                , EnumPlanet.Sun, EnumPlanet.Jupiter
                , EnumPlanet.Mercury, EnumPlanet.Venus };
            for (int i = 0; i < yogaPlanets.Count; i++)
            {
                EnumPlanet yogaPlanet1 = yogaPlanets[i];
                for (int j = i + 1; j < yogaPlanets.Count; j++)
                {
                    EnumPlanet yogaPlanet2 = yogaPlanets[j];
                    for (int k = j + 1; k < yogaPlanets.Count; k++)
                    {
                        EnumPlanet yogaPlanet3 = yogaPlanets[k];
                        for (int l = k + 1; l < yogaPlanets.Count; l++)
                        {
                            EnumPlanet yogaPlanet4 = yogaPlanets[l];

                            List<int> p4houses = AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(yogaPlanet4, houseISee);
                            List<int> p3houses = AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(yogaPlanet3, houseISee);
                            List<int> p2houses = AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(yogaPlanet2, houseISee);
                            List<int> p1houses = AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(yogaPlanet1, houseISee);

                            foreach (int p1i in p1houses)
                                foreach (int p2i in p2houses)
                                    foreach (int p3i in p3houses)
                                        foreach (int p4i in p4houses)
                                        {
                                            AstroYogaConfigurationItem rajaYoga = new AstroYogaConfigurationItem();
                                            rajaYoga.YogaName = "Rare Raja Yoga - Four Yoga planet see wargoththama (just moon) " + ((addMoon) ? "Moon" : "Lagna");
                                            rajaYoga.LagnaRashi = (int)lagnaRashi;
                                            if (!addMoon)
                                                rajaYoga.NawamsakaRashi = (int)lagnaRashi;
                                            rajaYoga.YogaDescription = "" + yogaPlanet1 + " in " + p1i + ", " + yogaPlanet2 + " in "
                                                + p2i + ", " + yogaPlanet3 + " in " + p3i + ", " + yogaPlanet4 + " in "
                                                + p4i + ".";
                                            rajaYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(p1i, yogaPlanet1));
                                            rajaYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(p2i, yogaPlanet2));
                                            rajaYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(p3i, yogaPlanet3));
                                            rajaYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(p4i, yogaPlanet4));
                                            if (addMoon)
                                                rajaYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(houseISee, EnumPlanet.Moon));

                                            yogaCareerLife.Add(rajaYoga);
                                        }
                        }
                    }
                }
            }
        }

        private void SetAnotherRajaYoga(List<AstroYogaConfigurationItem> yogaCareerLife
            , EnumPlanet planet, EnumRasi rasi)
        {
            AstroYogaConfigurationItem rajaYogaSure = new AstroYogaConfigurationItem();
            rajaYogaSure.YogaName = "Definite Raja Yoga";
            rajaYogaSure.YogaDescription = "Venus, Mars, Jupiter in good Rashies and " + planet + " in Lagna with power";
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(rasi, planet));
            rajaYogaSure.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, planet));
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Thula, EnumPlanet.Venus));
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Mesha, EnumPlanet.Mars));
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kataka, EnumPlanet.Jupiter));
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kanya, EnumPlanet.Mercury));
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kanya, EnumPlanet.Sun));
            yogaCareerLife.Add(rajaYogaSure);
        }

        private void SetAnotherRajaYoga(List<AstroYogaConfigurationItem> yogaCareerLife, EnumRasi rasi)
        {
            AstroYogaConfigurationItem rajaYogaSure = new AstroYogaConfigurationItem();
            rajaYogaSure.YogaName = "Definite Raja Yoga";
            rajaYogaSure.YogaDescription = "Venus, Mars, Jupiter in good Rashies and Saturn in Lagna with power";
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Makara, EnumPlanet.Mars));
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(rasi, EnumPlanet.Saturn));
            rajaYogaSure.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Saturn));
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Dhanus, EnumPlanet.Moon));
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Dhanus, EnumPlanet.Sun));

            SetAnotherRajaYoga2(yogaCareerLife);
            SetAnotherRajaYoga3(yogaCareerLife);
            yogaCareerLife.Add(rajaYogaSure);
        }

        private void SetAnotherRajaYoga2(List<AstroYogaConfigurationItem> yogaCareerLife)
        {
            AstroYogaConfigurationItem rajaYogaSure = new AstroYogaConfigurationItem();
            rajaYogaSure.YogaName = "Definite Raja Yoga";
            rajaYogaSure.YogaDescription = "Saturn in Kumbha, Jupiter in Vrishabha, Moon in Lagna, with Jupiter, and Sun in Simha";
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Kumbha, EnumPlanet.Saturn));//
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Vrishabha, EnumPlanet.Jupiter));//
            rajaYogaSure.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Moon));//
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Vrishabha, EnumPlanet.Moon));//
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Simha, EnumPlanet.Sun));//
            yogaCareerLife.Add(rajaYogaSure);
        }

        private void SetAnotherRajaYoga3(List<AstroYogaConfigurationItem> yogaCareerLife)
        {
            AstroYogaConfigurationItem rajaYogaSure = new AstroYogaConfigurationItem();
            rajaYogaSure.YogaName = "Famous King - Raja Yoga";
            rajaYogaSure.YogaDescription = "Saturn in Makara and lagna, Moon 3rd, Mars 6th, Mercury 9th and Jupiter on 12th";
            rajaYogaSure.ListOfPlanetPlacedInRashi.Add(new PlanetInRashi(EnumRasi.Makara, EnumPlanet.Saturn));//
            rajaYogaSure.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Saturn));
            rajaYogaSure.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(3, EnumPlanet.Moon));
            rajaYogaSure.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(6, EnumPlanet.Mars));
            rajaYogaSure.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(9, EnumPlanet.Mercury));
            rajaYogaSure.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(12, EnumPlanet.Jupiter));
            yogaCareerLife.Add(rajaYogaSure);
        }

        public List<AstroYogaConfigurationItem> CareerTypes()
        {
            List<AstroYogaConfigurationItem> yogaCareerLife = new List<AstroYogaConfigurationItem>();
            EnumPlanet[] allPlanets = AstroPlanet.GetAllPlanets();
            for (int i = 0; i < allPlanets.Length; i++)
            {
                EnumPlanet planet = allPlanets[i];
                if ((planet == EnumPlanet.Uranus)
                    || (planet == EnumPlanet.Neptune)
                    || (planet == EnumPlanet.Pluto)
                    || (planet == EnumPlanet.Rahu)
                    || (planet == EnumPlanet.Kethu)) continue;

                AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                LegacyMan.YogaName = "Mode of Earning Money - " + AstroPlanet.GetModeofEarnings(planet);
                LegacyMan.YogaDescription = planet + " on 10th House";
                LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(10, planet));
                yogaCareerLife.Add(LegacyMan);
            }
            return yogaCareerLife;
        }

        public List<AstroYogaConfigurationItem> GetKahalYoga(EnumRasi lagnaRashi)
        {
            List<AstroYogaConfigurationItem> yogaLife = new List<AstroYogaConfigurationItem>();

            EnumPlanet planet_4_Adhipathy = new AstroRasi(GetIncrementRashi(lagnaRashi, 3)).AdhipathiEnumPlanets[0];
            EnumPlanet planet_9_Adhipathy = new AstroRasi(GetIncrementRashi(lagnaRashi, 8)).AdhipathiEnumPlanets[0];
            EnumPlanet lagnaAdhipathy = new AstroRasi(lagnaRashi).AdhipathiEnumPlanets[0];

            List<int> uchchaLagnaLoardHouses = AstroGoodBad.GetAllUchchaHouseForLagnaAndPlanet(lagnaRashi
                , lagnaAdhipathy);
            List<int> uchchaLagna4AdhipathiHouses = AstroGoodBad.GetAllUchchaHouseForLagnaAndPlanet(lagnaRashi
                , planet_4_Adhipathy);

            for (int i = 0; i < uchchaLagnaLoardHouses.Count; i++)
                for (int j = 0; j < uchchaLagna4AdhipathiHouses.Count; j++)
                {
                    AstroYogaConfigurationItem kahalYoga = new AstroYogaConfigurationItem();
                    kahalYoga.YogaName = "Khahal Yoga - Rich, prosperous, famous, glorious, and a kingly person.";
                    kahalYoga.LagnaRashi = (int)lagnaRashi;
                    kahalYoga.YogaDescription = "The lord of 4th and 9th house placed in mutual Kendra and the lord of the ascendant becomes powerful.";
                    kahalYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, lagnaAdhipathy));
                    kahalYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(j, planet_4_Adhipathy));
                    kahalYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(AstroUtility.AstroCycleIncrease(j, 3), planet_9_Adhipathy));
                    //AstroUtility.AstroCycleIncrease(2, 1)
                    yogaLife.Add(kahalYoga);
                }
            return yogaLife;
        }

        public List<AstroYogaConfigurationItem> YogaBeautifulPeople()
        {
            List<AstroYogaConfigurationItem> yogaluckyLife = new List<AstroYogaConfigurationItem>();
            for (int i = 1; i < 12; i++)
            {
                //Venus and Rahu together in any houses possess high levels of sexual energy 
                AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                LegacyMan.YogaName = "Beautiful Person";
                LegacyMan.YogaDescription = "Venus and Rahu together in any houses possess high levels of sexual energy";
                LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Venus));
                LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Rahu));
                yogaluckyLife.Add(LegacyMan);
            }

            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            //Venus first House placed well
            foreach (EnumRasi lagnaRashi in langaRashies)
            {
                if ((int)lagnaRashi == 0) continue;

                yogaluckyLife.AddRange(GetKahalYoga(lagnaRashi));

                if (new AstroRasi(lagnaRashi).GetRelationToPlanet(EnumPlanet.Venus) < EnumPlanetRasiRelationTypes.Sathuru)
                {
                    AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                    LegacyMan.YogaName = "Beautiful Person";
                    LegacyMan.YogaDescription = "Venus is Strong in 1st House";
                    LegacyMan.LagnaRashi = (int)lagnaRashi;
                    LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Venus));
                    yogaluckyLife.Add(LegacyMan);
                }
            }

            return yogaluckyLife;
        }

        public List<AstroYogaConfigurationItem> YogaKajaKeshary()
        {
            List<AstroYogaConfigurationItem> yogaluckyLife = new List<AstroYogaConfigurationItem>();
            // Jupiter is in Kendra, i.e.,Ascendant, fourth, seventh and tenth house from Moon.
            for (int i = 1; i <= 12; i = i + 3)
            {
                int k = 1;
                for (int j = 1; j < 4; j++)
                {    
                    AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                    LegacyMan.YogaName = "Kaja Keshary";
                    LegacyMan.YogaDescription = "Moon is at " + i + " House and Jupiter is at " + k + " House";
                    LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Moon));
                    LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(k, EnumPlanet.Jupiter));
                    yogaluckyLife.Add(LegacyMan);
                    k = AstroUtility.AstroCycleIncrease(k, 3);
                }
            }
            return yogaluckyLife;
        }
        
        public List<AstroYogaConfigurationItem> YogaMahaPurusha()
        {
            List<AstroYogaConfigurationItem> yogaluckyLife = new List<AstroYogaConfigurationItem>();
            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            //Mars, Jupiter, Saturn, Venus, Mercury are own sign in Kendra
            foreach (EnumRasi lagnaRashi in langaRashies)
            {
                if ((int)lagnaRashi == 0) continue;
                List<EnumPlanet> planet_1_Adhipathies = new AstroRasi(lagnaRashi).AdhipathiEnumPlanets;
                yogaluckyLife.AddRange(UpdateForMahaPurusha(planet_1_Adhipathies, lagnaRashi, 1));
                List<EnumPlanet> planet_4_Adhipathies = new AstroRasi(GetIncrementRashi(lagnaRashi, 3)).AdhipathiEnumPlanets;
                yogaluckyLife.AddRange(UpdateForMahaPurusha(planet_4_Adhipathies, lagnaRashi, 4));
                List<EnumPlanet> planet_7_Adhipathies = new AstroRasi(GetIncrementRashi(lagnaRashi, 6)).AdhipathiEnumPlanets;
                yogaluckyLife.AddRange(UpdateForMahaPurusha(planet_7_Adhipathies, lagnaRashi, 7));
                List<EnumPlanet> planet_10_Adhipathies = new AstroRasi(GetIncrementRashi(lagnaRashi, 9)).AdhipathiEnumPlanets;
                yogaluckyLife.AddRange(UpdateForMahaPurusha(planet_10_Adhipathies, lagnaRashi, 10));
            }
            return yogaluckyLife;
        }

        private List<AstroYogaConfigurationItem> UpdateForMahaPurusha(List<EnumPlanet> adhipathies
            , EnumRasi lagnaRashi, int houseNumber)
        {
            List<AstroYogaConfigurationItem> yogaluckyLife = new List<AstroYogaConfigurationItem>();
            foreach (EnumPlanet planet in adhipathies)
            {
                switch (planet)
                {
                    case EnumPlanet.Saturn:
                        {
                            AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                            LegacyMan.YogaName = "Maha Purusha";
                            LegacyMan.YogaDescription = "House " + houseNumber + " Adhipathi " + planet + " in " + houseNumber + " House";
                            LegacyMan.LagnaRashi = (int)lagnaRashi;
                            LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(houseNumber, planet));
                            yogaluckyLife.Add(LegacyMan);
                            break;
                        }
                    case EnumPlanet.Jupiter:
                        {
                            AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                            LegacyMan.YogaName = "Maha Purusha";
                            LegacyMan.YogaDescription = "House " + houseNumber + " Adhipathi " + planet + " in " + houseNumber + " House";
                            LegacyMan.LagnaRashi = (int)lagnaRashi;
                            LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(houseNumber, planet));
                            yogaluckyLife.Add(LegacyMan);
                            break;
                        }
                    case EnumPlanet.Venus:
                        {
                            AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                            LegacyMan.YogaName = "Maha Purusha";
                            LegacyMan.YogaDescription = "House " + houseNumber + " Adhipathi " + planet + " in " + houseNumber + " House";
                            LegacyMan.LagnaRashi = (int)lagnaRashi;
                            LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(houseNumber, planet));
                            yogaluckyLife.Add(LegacyMan);
                            break;
                        }
                    case EnumPlanet.Mercury:
                        {
                            AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                            LegacyMan.YogaName = "Maha Purusha";
                            LegacyMan.YogaDescription = "House " + houseNumber + " Adhipathi " + planet + " in " + houseNumber + " House";
                            LegacyMan.LagnaRashi = (int)lagnaRashi;
                            LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, planet));
                            yogaluckyLife.Add(LegacyMan);
                            break;
                        }
                    case EnumPlanet.Mars:
                        {
                            AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                            LegacyMan.YogaName = "Maha Purusha";
                            LegacyMan.YogaDescription = "House " + houseNumber + " Adhipathi " + planet + " in " + houseNumber + " House";
                            LegacyMan.LagnaRashi = (int)lagnaRashi;
                            LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(houseNumber, planet));
                            yogaluckyLife.Add(LegacyMan);
                            break;
                        }
                }
            }
            return yogaluckyLife;
        }

        public List<AstroYogaConfigurationItem> YogaThatKeepLegacy()
        {
            List<AstroYogaConfigurationItem> yogaluckyLife = new List<AstroYogaConfigurationItem>();
            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            //Langnadhathi, Moon, and 9 adhipathi neecha
            foreach (EnumRasi lagnaRashi in langaRashies)
            {
                if ((int)lagnaRashi == 0) continue;

                EnumPlanet planet_8_Adhipathi = new AstroRasi(GetIncrementRashi(lagnaRashi
                    , 7)).AdhipathiEnumPlanets[0];
                AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                LegacyMan.YogaName = "Will Keep a Legacy";
                LegacyMan.YogaDescription = "8th Adhipathi " + planet_8_Adhipathi + " placed on 8th";
                LegacyMan.LagnaRashi = (int)lagnaRashi;
                LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(8, planet_8_Adhipathi));
                yogaluckyLife.Add(LegacyMan);
            }
            return yogaluckyLife;
        }

        public List<AstroYogaConfigurationItem> YogaThatMakeYouGoAbroad()
        {
            List<AstroYogaConfigurationItem> yogaluckyLife = new List<AstroYogaConfigurationItem>();
            List<EnumPlanet> planets = AstroGoodBad.GetBadPlanet();
            foreach (EnumPlanet planet in planets)
            {
                AstroYogaConfigurationItem LegacyMan = new AstroYogaConfigurationItem();
                LegacyMan.YogaName = "Will Travel Abroad";
                LegacyMan.YogaDescription = "8 house has melific planets - " + planet;
                LegacyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(8, planet));
                yogaluckyLife.Add(LegacyMan);
            }

            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            //Langnadhathi, Moon, and 9 adhipathi neecha
            foreach (EnumRasi lagnaRashi in langaRashies)
            {
                if ((int)lagnaRashi == 0) continue;
                EnumPlanet planet_12_Adhipathi = new AstroRasi(GetIncrementRashi(lagnaRashi
                    , 11)).AdhipathiEnumPlanets[0];
                AstroRasi current = new AstroRasi(lagnaRashi);
                List<int> Houses = current.GetDebilitatedHouses(planet_12_Adhipathi);
                foreach (int house in Houses)
                {
                    AstroYogaConfigurationItem travelMan = new AstroYogaConfigurationItem();
                    travelMan.YogaName = "Will Travel Abroad";
                    travelMan.LagnaRashi = (int)lagnaRashi;
                    travelMan.YogaDescription = "12th house lord " + planet_12_Adhipathi + " is idebilitated (at place of Neecha or sathuru) from ascendant";
                    travelMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(house, planet_12_Adhipathi));
                    yogaluckyLife.Add(travelMan);
                }
            }

            //the 7th house is associated with 8th, 9th or 12th house,
            foreach (EnumRasi lagnaRashi in langaRashies)
            {
                if ((int)lagnaRashi == 0) continue;
                EnumPlanet planet_7_Adhipathi = new AstroRasi(GetIncrementRashi(lagnaRashi, 6)).AdhipathiEnumPlanets[0];
                AstroYogaConfigurationItem travelMan1 = new AstroYogaConfigurationItem();
                travelMan1.YogaName = "Will Travel Abroad";
                travelMan1.LagnaRashi = (int)lagnaRashi;
                travelMan1.YogaDescription = "the load of 7th house lord " + planet_7_Adhipathi + " is associated with 8th house";
                travelMan1.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(8, planet_7_Adhipathi));
                yogaluckyLife.Add(travelMan1);

                AstroYogaConfigurationItem travelMan2 = new AstroYogaConfigurationItem();
                travelMan2.YogaName = "Will Travel Abroad";
                travelMan2.LagnaRashi = (int)lagnaRashi;
                travelMan2.YogaDescription = "the load of 7th house lord " + planet_7_Adhipathi + " is associated with 9th house";
                travelMan2.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(9, planet_7_Adhipathi));
                yogaluckyLife.Add(travelMan2);

                AstroYogaConfigurationItem travelMan3 = new AstroYogaConfigurationItem();
                travelMan3.YogaName = "Will Travel Abroad";
                travelMan3.LagnaRashi = (int)lagnaRashi;
                travelMan3.YogaDescription = "the load of 7th house lord " + planet_7_Adhipathi + " is associated with 12th house";
                travelMan3.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(12, planet_7_Adhipathi));
                yogaluckyLife.Add(travelMan3);
            }
            return yogaluckyLife;
        }

        public List<AstroYogaConfigurationItem> YogaThatNegatePowerfulYoga()
        {
            // Page 351 - Jeewithaya saha Grahayo
            List<AstroYogaConfigurationItem> yogaUnluckyLife = new List<AstroYogaConfigurationItem>();
            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            //Langnadhathi, Moon, and 9 adhipathi neecha
            foreach (EnumRasi lagnaRashi in langaRashies)
            {
                if ((int)lagnaRashi == 0) continue;
                EnumPlanet lagnaAdhipathiPlanet = new AstroRasi(lagnaRashi).AdhipathiEnumPlanets[0];
                EnumPlanet planet_9_Adhipathi = new AstroRasi(GetIncrementRashi(lagnaRashi, 8)).AdhipathiEnumPlanets[0];
                AstroRasi current = new AstroRasi(lagnaRashi);
                List<int> lagnadhipathNeeechaHouses = AstroGoodBad.GetAllNeechaHouseForLagnaAndPlanet(lagnaRashi, lagnaAdhipathiPlanet);
                List<int> nineadhipathNeeechaHouses = AstroGoodBad.GetAllNeechaHouseForLagnaAndPlanet(lagnaRashi, planet_9_Adhipathi);
                List<int> moonNeeechaHouses = AstroGoodBad.GetAllNeechaHouseForLagnaAndPlanet(lagnaRashi
                    , EnumPlanet.Moon);
                foreach (int lagnadhipathNeeechaHouse in lagnadhipathNeeechaHouses)
                    foreach (int nineadhipathNeeechaHouse in nineadhipathNeeechaHouses)
                        foreach (int moonNeeechaHouse in moonNeeechaHouses)
                        {
                            AstroYogaConfigurationItem unluckyMan = new AstroYogaConfigurationItem();
                            unluckyMan.YogaName = "Never be of good luck";
                            unluckyMan.YogaDescription = "Lagnadhipath (" + lagnaAdhipathiPlanet + ") is neecha at " + lagnadhipathNeeechaHouse + ", Moon is neecha at " + moonNeeechaHouse + " and Nine Adhipathi (" + planet_9_Adhipathi + ") Neecha at " + nineadhipathNeeechaHouse;
                            unluckyMan.LagnaRashi = (int)lagnaRashi;
                            unluckyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(moonNeeechaHouse, EnumPlanet.Moon));
                            unluckyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(lagnadhipathNeeechaHouse, lagnaAdhipathiPlanet));
                            unluckyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(nineadhipathNeeechaHouse, planet_9_Adhipathi));
                            yogaUnluckyLife.Add(unluckyMan);
                        }
            }
            return yogaUnluckyLife;
        }
       
        public List<AstroYogaConfigurationItem> YogaLeadToLuckyLife()
        {
            // Page 353 - Jeewithaya Shaha Grahayo
            List<AstroYogaConfigurationItem> yogaLuckyLife = new List<AstroYogaConfigurationItem>();
            //If the planet Moon and Mars placed in the 9th house or
            //11th house or if it is posited in the own sign or exalted sign,
            //this Chandra+Mangal Yoga happens.
            List<int> ints = new List<int>() { 9, 11 };
            foreach (int i in ints)
                foreach (int j in ints)
                {
                    AstroYogaConfigurationItem chandraYoga1 = new AstroYogaConfigurationItem();
                    chandraYoga1.YogaName = "Chandra Mangala Yoga - becomes extremely rich";
                    chandraYoga1.YogaDescription = "The planet Moon and Mars placed in the " + i + " th and " + j + "th house";
                    chandraYoga1.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Moon));
                    chandraYoga1.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(j, EnumPlanet.Mars));
                    yogaLuckyLife.Add(chandraYoga1);
                }

            //Shukra Yoga
            //Generally, the 12th house is considered to be bad.
            //However, when the planet Venus remains in the 12th house, it makes Shukra yoga.
            //This Shukra makes the person super-rich.
            AstroYogaConfigurationItem sakuraYoga = new AstroYogaConfigurationItem();
            sakuraYoga.YogaName = "Shukra Yoga - Super-Rich";
            sakuraYoga.YogaDescription = "The planet Venus remains in the 12th house. Super Rich";
            sakuraYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(12, EnumPlanet.Venus));
            yogaLuckyLife.Add(sakuraYoga);

            //Lagna and 10th and place of Moon
            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            foreach (EnumRasi lagnaRashi in langaRashies)
            {
                if ((int)lagnaRashi == 0) continue;
                AstroRasi lagna = new AstroRasi(lagnaRashi);

                //Chandra Mangala Yoga - if it is posited in the own sign or exalted sign,
                //this Chandra+Mangal Yoga happens.
                List<int> marUchchaHouses = AstroGoodBad.GetAllUchchaHouseForLagnaAndPlanet(lagnaRashi, EnumPlanet.Mars);
                List<int> moonUchhaHouses = AstroGoodBad.GetAllUchchaHouseForLagnaAndPlanet(lagnaRashi, EnumPlanet.Moon);
                List<int> jupiterUchhaHouses = AstroGoodBad.GetAllUchchaHouseForLagnaAndPlanet(lagnaRashi, EnumPlanet.Jupiter);
                foreach (int moonUchhaHouse in moonUchhaHouses)
                {
                    foreach (int marsUchchaHouse in marUchchaHouses)
                    {
                        AstroYogaConfigurationItem chandraYoga11 = new AstroYogaConfigurationItem();
                        chandraYoga11.YogaName = "Chandra Mangala Yoga - becomes extremely rich";
                        chandraYoga11.LagnaRashi = (int)lagnaRashi;
                        chandraYoga11.YogaDescription = "The planet Moon and Mars placed in the " + moonUchhaHouse + " th and " + marsUchchaHouse + "th house";
                        chandraYoga11.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(marsUchchaHouse, EnumPlanet.Mars));
                        chandraYoga11.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(moonUchhaHouse, EnumPlanet.Moon));
                        yogaLuckyLife.Add(chandraYoga11);
                    }
                    foreach (int jupiterUchhaHouse in jupiterUchhaHouses)
                    {
                        AstroYogaConfigurationItem chandraYoga11 = new AstroYogaConfigurationItem();
                        chandraYoga11.YogaName = "Guru Mangala Yoga - becomes highly rich and prosperous";
                        chandraYoga11.LagnaRashi = (int)lagnaRashi;
                        chandraYoga11.YogaDescription = "The planet Moon and Jupiter placed in the " + moonUchhaHouse + " th and " + jupiterUchhaHouse + "th house";
                        chandraYoga11.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(jupiterUchhaHouse, EnumPlanet.Jupiter));
                        chandraYoga11.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(moonUchhaHouse, EnumPlanet.Moon));
                        yogaLuckyLife.Add(chandraYoga11);
                    }
                }

                //Mahalaxmi Yoga - Ultimate luck
                //When, the lord of the 5th and 9th are in Kendra
                //and get aspect of auspicious Jupiter, Moon and Mercury,
                //Mahalaxmi yoga happens.
                EnumPlanet planet_5_Adhipathi = new AstroRasi(GetIncrementRashi(lagnaRashi, 4)).AdhipathiEnumPlanets[0];
                EnumPlanet planet_9_Adhipathi = new AstroRasi(GetIncrementRashi(lagnaRashi, 8)).AdhipathiEnumPlanets[0];
                List<int> jHouses = AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet.Jupiter, 1);
                List<int> mHouses = AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet.Moon, 1);
                List<int> mercHouses = AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(EnumPlanet.Mercury, 1);
                for (int j= 0; j < jHouses.Count; j++)
                {
                    for (int m=0; m<mHouses.Count; m++)
                    {
                        for (int merc = 0; merc < mercHouses.Count; merc++)
                        {
                            AstroYogaConfigurationItem laxmiYoga = new AstroYogaConfigurationItem();
                            laxmiYoga.YogaName = "Mahalaxmi Yoga - Ultimate luck";
                            laxmiYoga.LagnaRashi = (int)lagnaRashi;
                            laxmiYoga.YogaDescription = "The lord of the 5th and 9th are in Kendra..and get aspect of auspicious Jupiter, Moon and Mercury";
                            laxmiYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, planet_5_Adhipathi));
                            laxmiYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, planet_9_Adhipathi));
                            if ((EnumPlanet.Jupiter != planet_5_Adhipathi) && (EnumPlanet.Jupiter != planet_9_Adhipathi))
                                laxmiYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(jHouses[j], EnumPlanet.Jupiter));
                            if ((EnumPlanet.Moon != planet_5_Adhipathi) && (EnumPlanet.Moon != planet_9_Adhipathi))
                                laxmiYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(mHouses[m], EnumPlanet.Moon));
                            if ((EnumPlanet.Mercury != planet_5_Adhipathi) && (EnumPlanet.Mercury != planet_9_Adhipathi))
                                laxmiYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(mercHouses[merc], EnumPlanet.Mercury));
                            yogaLuckyLife.Add(laxmiYoga);
                        }
                    }
                }         

                //Lagna belongs to a movable sign (CharaRashi), Venus and Jupiter placed in
                //the Kendra and Saturn also in Kendra.
                if (lagna.IsCharaRashi)
                {
                    AstroYogaConfigurationItem kotipathiYoga = new AstroYogaConfigurationItem();
                    kotipathiYoga.YogaName = "Kotipati Yoga";
                    kotipathiYoga.LagnaRashi = (int)lagnaRashi;
                    kotipathiYoga.YogaDescription = "Lagna belongs to a movable sign (CharaRashi), Venus and Jupiter placed in the Kendra and Saturn also in Kendra.";
                    kotipathiYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Venus));
                    kotipathiYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Jupiter));
                    kotipathiYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(1, EnumPlanet.Saturn));
                    yogaLuckyLife.Add(kotipathiYoga);
                }
                EnumPlanet lagnaAdhipathiPlanet = new AstroRasi(lagnaRashi).AdhipathiEnumPlanets[0];
                EnumPlanet planet_10_Adhipathi = new AstroRasi(GetIncrementRashi(lagnaRashi, 9)).AdhipathiEnumPlanets[0];
                bool roshiOdd = lagna.IsOddRashi;
                for (int i = 1; i <= 12; i++)
                {
                    SetNeechaBangaRajaYoga(yogaLuckyLife, lagnaRashi, i);
                    SetRareRajaYoga(yogaLuckyLife, lagnaRashi, i, true);

                    if ((yogaLuckyLife.Where(x => x.ListOfPlanetPlacedInHouse.Where(y => (y.PlanetName == EnumPlanet.Moon) && (y.HouseNumber == i)).Count() > 0).Count() == 0) ||
                        (yogaLuckyLife.Where(x => x.ListOfPlanetPlacedInHouse.Where(y => (y.PlanetName == EnumPlanet.Jupiter) && (y.HouseNumber == i)).Count() > 0).Count() == 0))
                    {
                        AstroYogaConfigurationItem guruAllPlanetYoga = new AstroYogaConfigurationItem();
                        guruAllPlanetYoga.YogaName = "Guru Mangala Yoga - relatively rich";
                        guruAllPlanetYoga.YogaDescription = "The planet Moon and Jupiter placed in the " + i + "th house";
                        guruAllPlanetYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Moon));
                        guruAllPlanetYoga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Jupiter));
                        yogaLuckyLife.Add(guruAllPlanetYoga);
                    }

                    if (roshiOdd && (i % 2 != 0))
                    {
                        for (int j = 1; j < 12; j += 2)
                        {
                            //Sun and Moon occupies in odd signs such as Aries, Gemini, Leo,
                            //Libra, Sagittarius and Aquarius, Mahabhagya yoga takes place.
                            AstroYogaConfigurationItem sunMoonOddMale = new AstroYogaConfigurationItem();
                            sunMoonOddMale.YogaName = "Maha Bhagya yoga";
                            sunMoonOddMale.IsMale = 2;
                            sunMoonOddMale.IsBornInDayTime = 2;
                            sunMoonOddMale.YogaDescription = "Male and Born During Day time and Sun and Moon occupies in odd signs";
                            // 1, 3, 5, 7, 9, 11
                            sunMoonOddMale.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Sun));
                            sunMoonOddMale.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(AstroUtility.AstroCycleIncreaseNew(i, j), EnumPlanet.Moon));
                            yogaLuckyLife.Add(sunMoonOddMale);

                            AstroYogaConfigurationItem sunMoonOddFemale = new AstroYogaConfigurationItem();
                            sunMoonOddFemale.YogaName = "Maha Bhagya yoga";
                            sunMoonOddFemale.IsMale = 1;
                            sunMoonOddFemale.IsBornInDayTime = 1;
                            sunMoonOddFemale.YogaDescription = "Female and Born During Night time and Sun and Moon occupies in Even signs";
                            // 1, 3, 5, 7, 9, 11
                            sunMoonOddFemale.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(AstroUtility.AstroCycleIncrease(i, 1), EnumPlanet.Sun));
                            sunMoonOddFemale.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(AstroUtility.AstroCycleIncrease(i, j), EnumPlanet.Moon));
                            yogaLuckyLife.Add(sunMoonOddFemale);
                        }
                    }
                    EnumPlanet planetAdhipathiToRashiWhereMoonIs = new AstroRasi((i == 1) ? lagnaRashi : GetIncrementRashi(lagnaRashi, i - 1)).AdhipathiEnumPlanets[0];
                    List<int> goodHouseForLagnaAdhipathi = AstroGoodBad.GetAllGoodHouseForLagnaAndPlanet(lagnaRashi, lagnaAdhipathiPlanet);
                    List<int> goodHouseFor_10_Adhipathi = AstroGoodBad.GetAllGoodHouseForLagnaAndPlanet(lagnaRashi, planet_10_Adhipathi);
                    List<int> goodHouseForAdhipathiToRashiWhereMoonIs = AstroGoodBad.GetAllGoodHouseForLagnaAndPlanet(lagnaRashi, planetAdhipathiToRashiWhereMoonIs);

                    foreach (int lagnaAdhipathiPlace in goodHouseForLagnaAdhipathi)
                    {
                        foreach (int the_10_AdhipathiPlace in goodHouseFor_10_Adhipathi)
                        {
                            foreach (int moonPlaceAdhipathiPlace in goodHouseForAdhipathiToRashiWhereMoonIs)
                            {
                                AstroYogaConfigurationItem luckyMan = new AstroYogaConfigurationItem();
                                luckyMan.YogaName = "Never be of Bad luck";
                                luckyMan.LagnaRashi = (int)lagnaRashi;
                                luckyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Moon));
                                luckyMan.YogaDescription = "Moon is at " + i + " House, ";

                                if (EnumPlanet.Moon != lagnaAdhipathiPlanet)
                                {
                                    luckyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(lagnaAdhipathiPlace, lagnaAdhipathiPlanet));
                                    luckyMan.YogaDescription += "Lagnadhipathi (" + lagnaAdhipathiPlanet + ") is at " + lagnaAdhipathiPlace + " House, ";
                                }
                                if ((EnumPlanet.Moon != planetAdhipathiToRashiWhereMoonIs) && (lagnaAdhipathiPlanet != planetAdhipathiToRashiWhereMoonIs))
                                {
                                    luckyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(moonPlaceAdhipathiPlace, planetAdhipathiToRashiWhereMoonIs));
                                    luckyMan.YogaDescription += "Loard of the place where moon is (" + planetAdhipathiToRashiWhereMoonIs + ") is at " + moonPlaceAdhipathiPlace + " House, ";
                                }
                                if ((EnumPlanet.Moon != planet_10_Adhipathi) && (lagnaAdhipathiPlanet != planet_10_Adhipathi) && (planetAdhipathiToRashiWhereMoonIs != planet_10_Adhipathi))
                                {
                                    luckyMan.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(the_10_AdhipathiPlace, planet_10_Adhipathi));
                                    luckyMan.YogaDescription += "10th House Lord is (" + planet_10_Adhipathi + ") is at " + the_10_AdhipathiPlace + " House. All Powerfully Placed";
                                }
                                yogaLuckyLife.Add(luckyMan);
                            }
                        }
                    }
                }
            }
            return yogaLuckyLife;
        }

        private void SetNeechaBangaRajaYoga(List<AstroYogaConfigurationItem> yogaList, EnumRasi lagnaRashi, int currentHouseNumber)
        {
            //If the lord of the rashi where debilitated planet is, either placed in its own sign
            //or gives aspect to the debilitated planet, then Neecha Bhanga Raja Yoga happens.
            EnumPlanet current_House_Adhipathi;
            EnumRasi currentRashi = lagnaRashi;
            if (currentHouseNumber > 1)
            {
                currentRashi = GetIncrementRashi(lagnaRashi, AstroUtility.AstroCycleDecreaseNew(currentHouseNumber, 2));
                current_House_Adhipathi = new AstroRasi(currentRashi).AdhipathiEnumPlanets[0];
            }
            else
                current_House_Adhipathi = new AstroRasi(lagnaRashi).AdhipathiEnumPlanets[0];

            List<EnumPlanet> planetesNeechaInRashi = AstroGoodBad.GetAllNeechaPlanetsForRashi(currentRashi);
            List<int> housestheLordIn = AstroView.GetHouses_ForPlanetBe_ToSeeThisHouse(current_House_Adhipathi, currentHouseNumber);
            foreach (EnumPlanet neechaPlanet in planetesNeechaInRashi)
            {
                AstroYogaConfigurationItem neechaBanga1 = new AstroYogaConfigurationItem();
                neechaBanga1.YogaName = "Neecha Banga Raja Yoga - relatively rich, live like a king";
                neechaBanga1.LagnaRashi = (int)lagnaRashi;
                neechaBanga1.YogaDescription = "The " + neechaPlanet.ToString() + " is Neecha in " + currentRashi + ". But get companied by Rashi Load " + current_House_Adhipathi + " at the same House.";
                neechaBanga1.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(currentHouseNumber, neechaPlanet));
                neechaBanga1.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(currentHouseNumber, current_House_Adhipathi));
                yogaList.Add(neechaBanga1);

                for (int i = 0; i < housestheLordIn.Count; i++)
                {
                    AstroYogaConfigurationItem neechaBanga = new AstroYogaConfigurationItem();
                    neechaBanga.YogaName = "Neecha Banga Raja Yoga - relatively rich, live like a king";
                    neechaBanga.LagnaRashi = (int)lagnaRashi;
                    neechaBanga.YogaDescription = "The " + neechaPlanet.ToString() + " is Neecha in " + currentRashi + ". But get seen by Rashi Load " + current_House_Adhipathi + " from " + housestheLordIn[i] + "th House.";
                    neechaBanga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(currentHouseNumber, neechaPlanet));
                    neechaBanga.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(housestheLordIn[i], current_House_Adhipathi));
                    yogaList.Add(neechaBanga);
                }
            }
        }

        public List<AstroYogaConfigurationItem> YogaThatReduceBrothers()
        {
            List<AstroYogaConfigurationItem> yogaThatReduceBrothers = new List<AstroYogaConfigurationItem>();

            // Mars - 6, Rahu -8, Saturn -8
            AstroYogaConfigurationItem marsRahuSaturn = new AstroYogaConfigurationItem();
            marsRahuSaturn.YogaName = "Will Have Dead Brothers";
            marsRahuSaturn.YogaDescription = "Mars - 6, Rahu -8, Saturn -8";
            marsRahuSaturn.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(6, EnumPlanet.Mars));
            marsRahuSaturn.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(8, EnumPlanet.Saturn));
            marsRahuSaturn.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(8, EnumPlanet.Rahu));
            yogaThatReduceBrothers.Add(marsRahuSaturn);

            foreach (EnumPlanet badPlanet in AstroGoodBad.GetBadPlanet())
            {
                for (int i = 1; i <= 12; i++)
                {
                    AstroYogaConfigurationItem trdFromMarsHasBad = new AstroYogaConfigurationItem();
                    trdFromMarsHasBad.YogaName = "Will Have Dead Brothers";
                    int houseDadPlanet = GetIncrementHouse(i, 2);
                    trdFromMarsHasBad.YogaDescription = "Mars at " + i + " and " + badPlanet + " is at " + houseDadPlanet;
                    trdFromMarsHasBad.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Mars));
                    trdFromMarsHasBad.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(houseDadPlanet, badPlanet));
                    yogaThatReduceBrothers.Add(trdFromMarsHasBad);
                }
            }

            for (int i = 1; i <= 12; i++)
            {
                AstroYogaConfigurationItem jupiterRahuMars = new AstroYogaConfigurationItem();
                jupiterRahuMars.YogaName = "Will Have Damaged Brothers";
                jupiterRahuMars.YogaDescription = "Rahu at " + 3 + " and Jupiter at " + 2;
                jupiterRahuMars.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(3, EnumPlanet.Rahu));
                jupiterRahuMars.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(2, EnumPlanet.Jupiter));
                jupiterRahuMars.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Mars));
                jupiterRahuMars.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(i, EnumPlanet.Saturn));
                yogaThatReduceBrothers.Add(jupiterRahuMars);
            }

            EnumRasi[] langaRashies = AstroRasi.GetAllRashes();
            // Third House Owner is in Third House
            foreach (EnumRasi rashi in langaRashies)
            {
                if ((int)rashi == 0) continue;

                List<EnumPlanet> planets = new AstroRasi(GetIncrementRashi(rashi, 2)).AdhipathiEnumPlanets;
                foreach (EnumPlanet adhipathPlanet in planets)
                {
                    if ((adhipathPlanet == EnumPlanet.Uranus) 
                        || (adhipathPlanet == EnumPlanet.Neptune) 
                        || (adhipathPlanet == EnumPlanet.Pluto)) continue;

                    AstroYogaConfigurationItem thirdHouseOwnerInOwnHouse = new AstroYogaConfigurationItem();
                    thirdHouseOwnerInOwnHouse.YogaName = "Will Have Less Brothers";
                    thirdHouseOwnerInOwnHouse.YogaDescription = "Lord of 3rd House (" + adhipathPlanet + ") is at 3rd House";
                    thirdHouseOwnerInOwnHouse.LagnaRashi = (int)rashi;
                    thirdHouseOwnerInOwnHouse.ListOfPlanetPlacedInHouse.Add(new PlanetInHouse(3, adhipathPlanet));
                    yogaThatReduceBrothers.Add(thirdHouseOwnerInOwnHouse);

                    foreach (EnumPlanet badPlanet in AstroGoodBad.GetBadPlanet())
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            if ((badPlanet != adhipathPlanet) && (EnumPlanet.Mars != adhipathPlanet))
                            {
                                AstroYogaConfigurationItem thirdHouseOwnerWithBads = new AstroYogaConfigurationItem();
                                thirdHouseOwnerWithBads.YogaName = "Will Have Dead Young Brothers";
                                thirdHouseOwnerWithBads.YogaDescription = "Lord of 3rd House (" + adhipathPlanet + ") is at " + i + " with bad planet " + badPlanet;
                                thirdHouseOwnerWithBads.LagnaRashi = (int)rashi;
                                thirdHouseOwnerWithBads.ListOfPlanetPlacedInHouse.AddRange(new List<PlanetInHouse>() { new PlanetInHouse(i, badPlanet), new PlanetInHouse(i, adhipathPlanet) });
                                yogaThatReduceBrothers.Add(thirdHouseOwnerWithBads);
                            }
                            if (badPlanet != EnumPlanet.Mars)
                            {
                                AstroYogaConfigurationItem kujaWithBads = new AstroYogaConfigurationItem();
                                kujaWithBads.YogaName = "Will Have Dead Young Brothers";
                                kujaWithBads.YogaDescription = "Planet Mars is with a bad planet " + badPlanet + " located at " + i;
                                kujaWithBads.LagnaRashi = (int)rashi;
                                kujaWithBads.ListOfPlanetPlacedInHouse.AddRange(new List<PlanetInHouse>() { new PlanetInHouse(i, badPlanet), new PlanetInHouse(i, EnumPlanet.Mars) });
                                yogaThatReduceBrothers.Add(kujaWithBads);
                            }
                        }
                    }
                }
            }
            return yogaThatReduceBrothers;
        }

        public static EnumRasi GetIncrementRashi(EnumRasi value, int increment)
        {
            return (EnumRasi)AstroUtility.AstroCycleIncrease(Convert.ToInt32(value), increment);
        }

        public static int GetIncrementHouse(int house, int increment)
        {
            return AstroUtility.AstroCycleIncrease(house, increment);
        }
    }
}
