using System;
using ChaNiBaaStra.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChaNiBaaStra.UnitTest
{
    [TestClass]
    public class AsroKarnaTest
    {
        [TestMethod]
        public void KarnaTestMethod()
        {
            AstroKarna karna = new AstroKarna(EnumKarana.Balava);
            double sepDeg = 5.0;
            EnumKarana myKarn = karna.ofDeg(sepDeg);
            Assert.IsTrue(myKarn == EnumKarana.Kimstughna);
            for (int i = 1; i < 8; i++)
            {
                sepDeg += 6;
                myKarn = karna.ofDeg(sepDeg);
                Assert.IsTrue(myKarn == (EnumKarana)i);
            }
            for (int i = 1; i < 8; i++)
            {
                sepDeg += 6;
                myKarn = karna.ofDeg(sepDeg);
                Assert.IsTrue(myKarn == (EnumKarana)i);
            }
            for (int i = 1; i < 8; i++)
            {
                sepDeg += 6;
                myKarn = karna.ofDeg(sepDeg);
                Assert.IsTrue(myKarn == (EnumKarana)i);
            }
            for (int i = 1; i < 8; i++)
            {
                sepDeg += 6;
                myKarn = karna.ofDeg(sepDeg);
                Assert.IsTrue(myKarn == (EnumKarana)i);
            }
            for (int i = 1; i < 8; i++)
            {
                sepDeg += 6;
                myKarn = karna.ofDeg(sepDeg);
                Assert.IsTrue(myKarn == (EnumKarana)i);
            }
            for (int i = 1; i < 8; i++)
            {
                sepDeg += 6;
                myKarn = karna.ofDeg(sepDeg);
                Assert.IsTrue(myKarn == (EnumKarana)i);
            }
            for (int i = 1; i < 8; i++)
            {
                sepDeg += 6;
                myKarn = karna.ofDeg(sepDeg);
                Assert.IsTrue(myKarn == (EnumKarana)i);
            }
            for (int i = 1; i < 8; i++)
            {
                sepDeg += 6;
                myKarn = karna.ofDeg(sepDeg);
                Assert.IsTrue(myKarn == (EnumKarana)i);
            }
            sepDeg += 6;
            myKarn = karna.ofDeg(sepDeg);
            Assert.IsTrue(myKarn == EnumKarana.Sakuna);

            sepDeg += 6;
            myKarn = karna.ofDeg(sepDeg);
            Assert.IsTrue(myKarn == EnumKarana.Chatushpada);

            sepDeg += 6;
            myKarn = karna.ofDeg(sepDeg);
            Assert.IsTrue(myKarn == EnumKarana.Naga);
        }
    }
}
