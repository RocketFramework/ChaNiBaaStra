using System;
using ChaNiBaaStra.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChaNiBaaStra.UnitTest
{
    [TestClass]
    public class AstroThithiUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            AstroThithi thithi = new AstroThithi(EnumThithi.Amavasya);
            int j = 1;
            for (int i = 7; i < 360; i += 12)
            {
                EnumThithi th = thithi.ofDeg(2, i);
                if (i >= 348)
                    Assert.IsTrue(th == (EnumThithi)16);
                else
                    Assert.IsTrue(th == (EnumThithi)j);
                if (i >= 175 && j == 15)
                    j = 1;
                else
                    j++;
            }
        }
    }
}
