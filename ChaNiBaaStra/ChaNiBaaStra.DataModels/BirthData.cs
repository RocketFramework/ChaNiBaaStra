using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public class BirthData
    {
        public DateTime DateTime { get; set; }
        public string Langna { get; set; }
        public string Nawamsa { get; set; }
        public string MostPowerfulPlanet { get; set; }
        public string Nakath { get; set; }
        public double AscendentDegrees { get; set; }
        public bool IsMaleRashi { get; set; }
        public bool IsOddRashi { get; set; }
        public bool IsThiraRashi { get; set; }
        public bool IsCharaRashi { get; set; }
        public bool IsUbhayaRashi { get; set; }

        // Properties for Sun
        public double SunLocaltionFromMesha { get; set; }
        public double SunLocaltion { get; set; }
        public int SunHouse { get; set; }
        public string SunRashi { get; set; }

        // Properties for Moon
        public double MoonLocaltionFromMesha { get; set; }
        public double MoonLocaltion { get; set; }
        public int MoonHouse { get; set; }
        public string MoonRashi { get; set; }

        // Properties for Mars
        public double MarsLocaltionFromMesha { get; set; }
        public double MarsLocaltion { get; set; }
        public int MarsHouse { get; set; }
        public string MarsRashi { get; set; }

        // Properties for Jupiter
        public double JupiterLocaltionFromMesha { get; set; }
        public double JupiterLocaltion { get; set; }
        public int JupiterHouse { get; set; }
        public string JupiterRashi { get; set; }

        // Properties for Saturn
        public double SaturnLocaltionFromMesha { get; set; }
        public double SaturnLocaltion { get; set; }
        public int SaturnHouse { get; set; }
        public string SaturnRashi { get; set; }

        // Properties for Mercury
        public double MercuryLocaltionFromMoon { get; set; }
        public double MercuryLocaltion { get; set; }
        public int MercuryHouse { get; set; }
        public string MercuryRashi { get; set; }

        // Properties for Venus
        public double VenusLocaltionFromMesha { get; set; }
        public double VenusLocaltion { get; set; }
        public int VenusHouse { get; set; }
        public string VenusRashi { get; set; }

        // Properties for Rahu
        public double RahuLocaltionFromMesha { get; set; }
        public double RahuLocaltion { get; set; }
        public int RahuHouse { get; set; }
        public string RahuRashi { get; set; }

        // Properties for Kethu
        public double KethuLocaltionFromMesha { get; set; }
        public double KethuLocaltion { get; set; }
        public int KethuHouse { get; set; }
        public string KethuRashi { get; set; }

        // Properties for Uranus
        public double UranusLocaltionFromMesha { get; set; }
        public double UranusLocaltion { get; set; }
        public int UranusHouse { get; set; }
        public string UranusRashi { get; set; }

        // Properties for Neptune
        public double NeptuneLocaltionFromMesha { get; set; }
        public double NeptuneLocaltion { get; set; }
        public int NeptuneHouse { get; set; }
        public string NeptuneRashi { get; set; }

        // Properties for Pluto
        public double PlutoLocaltionFromMesha { get; set; }
        public double PlutoLocaltion { get; set; }
        public int PlutoHouse { get; set; }
        public string PlutoRashi { get; set; }
        public double SunLocaltionFromMoon { get; set; }
        public double MoonLocaltionFromSun { get; set; }
        public double MarsLocaltionFromSun { get; set; }
        public double MarsLocaltionFromMoon { get; set; }
        public double JupiterLocaltionFromSun { get; set; }
        public double JupiterLocaltionFromMoon { get; set; }
        public double SaturnLocaltionFromSun { get; set; }
        public double SaturnLocaltionFromMoon { get; set; }
        public double MercuryLocaltionFromSun { get; set; }
        public double VenusLocaltionFromSun { get; set; }
        public double VenusLocaltionFromMoon { get; set; }
        public double MercuryLocaltionFromMesha { get; set; }
        public double RahuLocaltionFromSun { get; set; }
        public double RahuLocaltionFromMoon { get; set; }
        public double KethuLocaltionFromSun { get; set; }
        public double KethuLocaltionFromMoon { get; set; }
        public double UranusLocaltionFromSun { get; set; }
        public double UranusLocaltionFromMoon { get; set; }
        public double NeptuneLocaltionFromSun { get; set; }
        public double NeptuneLocaltionFromMoon { get; set; }
        public double PlutoLocaltionFromSun { get; set; }
        public double PlutoLocaltionFromMoon { get; set; }
    }

}
