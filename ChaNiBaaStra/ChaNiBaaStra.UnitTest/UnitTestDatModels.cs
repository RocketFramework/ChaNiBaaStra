using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChaNiBaaStra.Utilities;

namespace ChaNiBaaStra.UnitTest
{
    [TestClass]
    public class UnitTestDatModels
    {
        [TestMethod]
        public void TestMethod1()
        {
            AstroPlace p = new AstroPlace();
            AstroTransitDate wd = new AstroTransitDate(p, true);
            double time = wd.GetTarnsit(EnumPlanet.Moon, p);
            Tuple<DateTime, DateTime> rahu = wd.WeekDay.Rahukalaya(wd.SunRise, wd.SunSet);
        }
    }
}
