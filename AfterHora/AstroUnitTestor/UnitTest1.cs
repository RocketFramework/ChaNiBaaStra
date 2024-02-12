using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChaNiBaaStra.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Configuration;
using System.Net;
using System.Reflection;
using ChaNiBaaStra.Utilities;
using ChaNiBaaStra.DataModels.Varga;
using SwissEphNet;
using System.Globalization;

namespace AstroUnitTestor
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CuspCalc()
        {
            int house = 0;
            double lat = 6.9271;
            double lng = 79.861244;
            int utc_year = 0;
            int utc_month = 0;
            int utc_day = 0;
            int utc_hour = 0;
            int utc_minute = 0;
            double utc_second = 0;
            string serr = "";
            // [0]:Ephemeris Time [1]:Universal Time
            double[] dret = { 0.0, 0.0 };

            SwissEph s = new SwissEph();

            // utcに変換
            s.swe_utc_time_zone(1975, 07, 02, 12, 23, 00, 79.861244/15.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            double[] cusps = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] ascmc = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            if (house == 0)
            {
                s.swe_houses_ex(dret[1], SwissEph.SEFLG_SIDEREAL, lat, lng, 'A', cusps, ascmc);
                house = 1;
            }
           if (house == 1)
            {
                s.swe_houses_ex(dret[1], SwissEph.SEFLG_SIDEREAL, lat, lng, 'K', cusps, ascmc);
                house = 2;  
            }
             if (house == 2)
            {
                s.swe_houses_ex(dret[1], SwissEph.SEFLG_SIDEREAL,lat, lng, 'C', cusps, ascmc);
                s.swe_houses_ex(dret[1], SwissEph.SEFLG_SIDEREAL, lat, lng, 'E', cusps, ascmc);
            }
            s.swe_close();

            //return cusps;
        }

        [TestMethod]
        public void TestMethodSetSunAsktakaVargaya()
        {
            SunAsktakaVargaya temp = new SunAsktakaVargaya();
            temp.SetAsktakaVargaya(new List<AstroPlanet>());
        }
        [TestMethod]
        public void TestMethodCallChatGTPToSummarize()
        {
            ChatGTPWrapper wrapper = new ChatGTPWrapper();
            //wrapper.CallChatGTPToSummarize();
        }

        [TestMethod]
        public void TestMethodAstroCycleDecreaseNew()
        {
            int i = AstroUtility.AstroCycleIncreaseNew(1, 2);
            int j = AstroUtility.AstroCycleDecreaseNew(12, 2);
            int k = AstroUtility.AstroCycleDecreaseNew(7, 10);
            int l = AstroUtility.AstroCycleDecreaseNew(1, 12);
            int m = AstroUtility.AstroCycleIncreaseNew(3, 12);
        }


        [TestMethod]
        public void TestMethodYogaThatMakeYouGoAbroad()
        {
            YogaAutoUpdator updator = new YogaAutoUpdator();
            List<AstroYogaConfigurationItem> items = updator.YogaThatMakeYouGoAbroad();
            Assert.IsNotNull(items);
        }

        [TestMethod]
        public void TestMethodYogaYogaKajaKeshary()
        {
            YogaAutoUpdator updator = new YogaAutoUpdator();
            List<AstroYogaConfigurationItem> items = updator.YogaKajaKeshary();
            Assert.IsNotNull(items);
        }

        [TestMethod]
        public void TestMethodReflection()
        {
            AstroYogaConfigurationItem obj = new AstroYogaConfigurationItem();
            PropertyInfo propertyInfo = obj.GetType().GetProperties().First(x => x.Name == "House_1_Empty");
            Convert.ToInt32(propertyInfo.GetValue(obj));
        }

        [TestMethod]
        public void TestMethodYogaLeadToUnLuckyLife()
        {
            YogaAutoUpdator updator = new YogaAutoUpdator();
            List<AstroYogaConfigurationItem> items = updator.YogaThatNegatePowerfulYoga();
            Assert.IsNotNull(items);
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<int> goodHosues = AstroGoodBad.GetAllGoodHouseForLagnaAndPlanet(EnumRasi.Kanya, EnumPlanet.Mercury);
            if (goodHosues.Count >0 )
                Console.WriteLine("Result are coming" + goodHosues.ToString());
        }

        [TestMethod]
        public void TestYogaLeadToLuckyLife()
        {
            YogaAutoUpdator updator = new YogaAutoUpdator();
            List<AstroYogaConfigurationItem> items = updator.YogaLeadToLuckyLife();

            if (items.Count > 0)
            {
                Console.WriteLine("Result are coming");

                foreach (var item in items)
                {
                    if (item.LagnaRashi == (int)EnumRasi.Mesha)
                    {
                        if (item.Mars_1_House ==1 && item.Moon_7_House ==1 && item.Venus_7_House ==1 && item.Saturn_10_House==1)
                        {
                            Console.WriteLine("Hurray");
                        }
                    }
                }
            }
        }
    }
}
