using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.DataModels
{
    public class SubhaTime
    {
        public DateTime Time { get; set; }
        public DateTime SunRise { get; set; }
        public DateTime SunSet { get; set; }
        public string Dinaya { get; set; }
        public string Hora { get; set; }
        public string RahuKalaya { get; set; }
        public string Nakatha { get; set; }
        public string NakathRelation { get; set; }
        public string Thithiya { get; set; }
        public string Yogaya { get; set; }
        public string Karnaya { get; set; }
        public string Lagnaya { get; set; }
        public string MoonHouseFromLagna { get; set; }
        public string MoonHouseFromTransitLagna { get; set; }
        public string SunNakath { get; set; }
        public string OtherPlanetWithMoon { get; set; }
        public string OtherPlanetOppositeMoon { get; set; }
        public string PlanetInEigthHouse { get; set; }
        /// <summary>
        /// 8 - I am 1,2 Adhipathi, Saturn, Jupiter See me
        /// </summary>
        public string Mars { get; set; }
        public string Saturn { get; set; }
        public string Jupiter { get; set; }
        public string Venus { get; set; }
        public string Mercury { get; set; }

    }
}
