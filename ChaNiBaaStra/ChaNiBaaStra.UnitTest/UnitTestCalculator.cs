using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChaNiBaaStra.UnitTest
{
    [TestClass]
    public class UnitTestCalculator
    {
        [TestMethod]
        public void TestMethod1()
        {
            AstroTransitDate date = new AstroTransitDate(new AstroPlace(), true);
            Assert.IsTrue(date.Horoscope.LagnaRasi.Current == EnumRasi.Kanya);
        }
    }
}
