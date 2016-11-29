using System;
using ChaNiBaaStra.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChaNiBaaStra.UnitTest
{
    [TestClass]
    public class UnitTestMuhurtha
    {
        [TestMethod]
        public void MuhurthaTest()
        {
            AstroMuhurtha m = new AstroMuhurtha(new DateTime(2016, 11, 26, 23, 53, 0)
                , new DateTime(2016, 11, 26, 6, 12, 0)
                , new DateTime(2016, 11, 26, 17, 58, 0));
        }
        [TestMethod]
        public void MuhurthaInit()
        {
            AstroMuhurtha m = new AstroMuhurtha(new DateTime(2016, 10, 16, 10, 32, 0)
                , new DateTime(2016, 10, 16, 6, 12, 0)
                , new DateTime(2016, 10, 16, 17, 58, 0));

            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList.Count, 5);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[0].KalaAdhipathiPlanet, EnumPlanet.Saturn);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[0].SukshamaKalaList[0].KalaAdhipathiPlanet, EnumPlanet.Saturn);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[1].KalaAdhipathiPlanet, EnumPlanet.Sun);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[1].SukshamaKalaList[1].KalaAdhipathiPlanet, EnumPlanet.Venus);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[2].KalaAdhipathiPlanet, EnumPlanet.Moon);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[2].SukshamaKalaList[2].KalaAdhipathiPlanet, EnumPlanet.Jupiter);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[3].KalaAdhipathiPlanet, EnumPlanet.Mars);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[4].KalaAdhipathiPlanet, EnumPlanet.Mercury);

            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList.Count, 5);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[0].KalaAdhipathiPlanet, EnumPlanet.Saturn);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[0].SukshamaKalaList[0].KalaAdhipathiPlanet, EnumPlanet.Saturn);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[1].KalaAdhipathiPlanet, EnumPlanet.Sun);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[1].SukshamaKalaList[1].KalaAdhipathiPlanet, EnumPlanet.Venus);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[2].KalaAdhipathiPlanet, EnumPlanet.Moon);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[2].SukshamaKalaList[2].KalaAdhipathiPlanet, EnumPlanet.Jupiter);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[3].KalaAdhipathiPlanet, EnumPlanet.Mars);
            Assert.AreEqual(m.CurrentHoraKala.PanchamaKalaList[4].KalaAdhipathiPlanet, EnumPlanet.Mercury);

            Assert.AreEqual(m.PreviousHoraKala.PanchamaKalaList.Count, 5);
            Assert.AreEqual(m.PreviousHoraKala.PanchamaKalaList[0].KalaAdhipathiPlanet, EnumPlanet.Moon);
            Assert.AreEqual(m.PreviousHoraKala.PanchamaKalaList[0].KalaInterval.IsVisha, true);
            Assert.AreEqual(m.PreviousHoraKala.PanchamaKalaList[0].SukshamaKalaList[0].KalaAdhipathiPlanet, EnumPlanet.Moon);
            Assert.AreEqual(m.PreviousHoraKala.PanchamaKalaList[1].KalaAdhipathiPlanet, EnumPlanet.Mars);
            Assert.AreEqual(m.PreviousHoraKala.PanchamaKalaList[1].SukshamaKalaList[1].KalaAdhipathiPlanet, EnumPlanet.Sun);
            Assert.AreEqual(m.PreviousHoraKala.PanchamaKalaList[2].KalaAdhipathiPlanet, EnumPlanet.Mercury);
            Assert.AreEqual(m.PreviousHoraKala.PanchamaKalaList[2].SukshamaKalaList[2].KalaAdhipathiPlanet, EnumPlanet.Saturn);
        }
    }
}
