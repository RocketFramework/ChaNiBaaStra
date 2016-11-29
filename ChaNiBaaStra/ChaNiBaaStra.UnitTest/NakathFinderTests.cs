using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChaNiBaaStra.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.DataModels;

namespace ChaNiBaaStra.Calculator.Tests
{
    [TestClass()]
    public class NakathFinderTests
    {
        [TestMethod()]
        public void NakathFinderTest()
        {
            AstroTransitDate date = new AstroTransitDate(new AstroPlace(), false);
            NakathFinder finder = new NakathFinder(date, new NakathFinderInput());
            finder.BeneficPlanetPosition = new int[] { 1, 4, 7, 10, 11, 2};
            finder.LangnaToConsider = new EnumRasi[] { EnumRasi.Kanya, EnumRasi.Thula, EnumRasi.Mithuna, EnumRasi.Simha };
            finder.MaleficPlanetPosition = new int[] { 3, 6, 12 };
            finder.NakathToConsider = new EnumNakath[] { (EnumNakath)1, (EnumNakath)7, (EnumNakath)11 };
            finder.NakathNumberFromRaviNakath = new int[] { 6, 8 };
            finder.EmptyHousesToConsider = new int[] { 6, 8 };

            Assert.IsTrue(finder.LagnaMatched() == ResultTypes.TRUE);//50
            Assert.IsTrue(finder.BadPlanetInGoodPosition() == ResultTypes.FALSE);//30
            Assert.IsTrue(finder.EmptyHousesToConsiderMatched() == ResultTypes.FALSE);//30
            Assert.IsTrue(finder.GoodPlanetInGoodPosition() == ResultTypes.FALSE);//30
            Assert.IsTrue(finder.MoonIsStrong().Result == ResultTypes.NA);//30
            Assert.IsTrue(finder.NakathMatched() == ResultTypes.TRUE);//60
            Assert.IsTrue(finder.NakathNumberFromRaviNakathMatched() == ResultTypes.FALSE);//60
            ResultTypes ntWeekDay = finder.GoodNakathThithiWeekDays();// 80
            finder.HasGoodYoga();//60
            finder.GoodThithiWeekDay();//60
            finder.IsGoodNakath();//60
            finder.IsGoodThithi();//30
            finder.IsGoodYoga();//30
            finder.IsGoodKarna();//30
            finder.IsGoodDay();//50
        }
    }
}