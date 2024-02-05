using ChaNiBaaStra.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static ChaNiBaaStra.DataModels.AstroDasa;

namespace ChaNiBaaStra.DataModels
{
    public enum DasaResultTypes
    {
        VeryGood = 1,
        Good = 2,
        Mixed = 3,
        Bad = 4,
        VeryBad = 5,
        Unknown = 6
    }
    public class AstroDasas
    {
        public AstroDasa CurrentDasa { get; set; }
        public List<AstroDasa> FutureDasas { get; set; }
        private const double DasaLength = 120.0*365;
        public AstroDasas(double moonLongitude, DateTime birthDate)
        {
            CurrentDasa = new AstroDasa();
            this.CurrentDasa.DasaPlanet = this.getDasaLord(moonLongitude);
            double b = this.computeBalance(moonLongitude, this.CurrentDasa.DasaPlanet);
            long t = Convert.ToInt64(365 * b * AstroConsts.TICKS_PER_DAY);

            this.CurrentDasa.Start = birthDate;
            this.CurrentDasa.End = birthDate.Add(new TimeSpan(t));
            TimeSpan ts = this.CurrentDasa.End.Subtract(birthDate);

            AstroUtility.DateDiff(this.CurrentDasa.End, birthDate
                , out int years, out int months
                , out int days);
            this.CurrentDasa.Remainder = new DasaRemainder(years, months, days);
            FutureDasas = new List<AstroDasa>();
            UpdateUpcomingDasas(this.CurrentDasa.DasaPlanet, dasaList, FutureDasas);
        }

        private void UpdateUpcomingDasas(EnumPlanet currentDasaPlanet, List<AstroDasa> originalDasaList, List<AstroDasa> updatableDasaList)
        {
            ResetDasaList(currentDasaPlanet, originalDasaList, updatableDasaList);
        }

        private void ResetDasaList(EnumPlanet currentDasaPlanet
            , List<AstroDasa> originalDasaList, List<AstroDasa> updatableDasaList
            , double dasaTotal = DasaLength)
        {
            DasaListAdjust(currentDasaPlanet, originalDasaList, updatableDasaList);

            DateTime d = new DateTime();
            foreach (AstroDasa dasa in updatableDasaList)
            {
                d = DasaDataUpdate(currentDasaPlanet, d, dasa);
                dasa.AthuruDasas = CalculateAthuruDasa(dasa.DasaPlanet, dasa.Start
                    , dasa.End, dasa.LengthInDays());
            }
        }

        private void DasaListAdjust(EnumPlanet currentDasaPlanet, List<AstroDasa> originalDasaList, List<AstroDasa> updatableDasaList)
        {
            bool addlast = true;
            int count = 0;
            foreach (AstroDasa dasa in originalDasaList)
            {
                if (currentDasaPlanet == dasa.DasaPlanet)
                    addlast = false;

                if (addlast)
                {
                    int i = (updatableDasaList.Count >= 0) ? updatableDasaList.Count : 0;
                    updatableDasaList.Insert(i, dasa);
                }
                else
                {
                    updatableDasaList.Insert(count, dasa);
                    count++;
                }
            }
        }

        private DateTime DasaDataUpdate(EnumPlanet currentDasaPlanet, DateTime d, AstroDasa dasa)
        {
            if (dasa.DasaPlanet != currentDasaPlanet)
            {
                dasa.Init(d, dasa.DasaPeriod);
                d = dasa.End;
            }
            else
            {
                dasa.End = CurrentDasa.End;
                dasa.Start = CurrentDasa.Start;
                dasa.Remainder = CurrentDasa.Remainder;
                d = dasa.End;
            }

            return d;
        }

        private List<AstroDasa> CalculateAthuruDasa(EnumPlanet dasaPlanet, DateTime start
            , DateTime end, int totalDasaLength)
        {
            // Update dasa list in par with the current total dasa length
            AstroDasa[] originalDasaArray = new AstroDasa[dasaList.Count];

            for (int i = 0; i < originalDasaArray.Length; i++)
            {
                AstroDasa athuruDasa = new AstroDasa(dasaList[i].DasaPlanet
                    , (dasaList[i].DasaPeriod * 365) * (totalDasaLength / DasaLength));
                originalDasaArray[i] = athuruDasa;
            }
            List<AstroDasa> originalDasaList = new List<AstroDasa>();
            originalDasaList.AddRange(originalDasaArray);
            
            List<AstroDasa> futureDasaList = new List<AstroDasa>();
            DasaListAdjust(dasaPlanet, originalDasaList, futureDasaList);

            DateTime d = start;
            foreach (AstroDasa dasa in futureDasaList)
            {
                // I think we need to do some modificaiton around dasa remainder
                // The calculation is not giving the right value for the first rasi of a list
                // I think we need to get the adjustment base on the actual dasa start datetime
                dasa.Start = d;
                dasa.End = d.AddDays(dasa.DasaPeriod);
                dasa.Remainder = new DasaRemainder((int)dasa.DasaPeriod, 0, 0);
                d = dasa.End;
                dasa.AthuruDasas = CalculateAntharAthuruDasa(dasa.DasaPlanet, dasa.Start, dasa.End, dasa.LengthInDays());
            }

            return futureDasaList;
        }

        private List<AstroDasa> CalculateAntharAthuruDasa(EnumPlanet dasaPlanet, DateTime start
        , DateTime end, int totalDasaLength)
        {
            // Update dasa list in par with the current total dasa length
            AstroDasa[] originalDasaArray = new AstroDasa[dasaList.Count];

            for (int i = 0; i < originalDasaArray.Length; i++)
            {
                AstroDasa athuruDasa = new AstroDasa(dasaList[i].DasaPlanet
                    , (dasaList[i].DasaPeriod * 365) * (totalDasaLength / DasaLength));
                originalDasaArray[i] = athuruDasa;
            }
            List<AstroDasa> originalDasaList = new List<AstroDasa>();
            originalDasaList.AddRange(originalDasaArray);

            List<AstroDasa> futureDasaList = new List<AstroDasa>();
            DasaListAdjust(dasaPlanet, originalDasaList, futureDasaList);

            DateTime d = start;
            foreach (AstroDasa dasa in futureDasaList)
            {
                // I think we need to do some modificaiton around dasa remainder
                // The calculation is not giving the right value for the first rasi of a list
                // I think we need to get the adjustment base on the actual dasa start datetime
                dasa.Start = d;
                dasa.End = d.AddDays(dasa.DasaPeriod);
                dasa.Remainder = new DasaRemainder((int)dasa.DasaPeriod, 0, 0);
                d = dasa.End;
            }

            return futureDasaList;
        }

        private List<AstroDasa> dasaList = new System.Collections.Generic.List<AstroDasa>(
            new AstroDasa[] { new AstroDasa(EnumPlanet.Sun, 6.0),
            new AstroDasa(EnumPlanet.Moon, 10.0),
            new AstroDasa(EnumPlanet.Mars, 7.0),
            new AstroDasa(EnumPlanet.Rahu, 18.0),
            new AstroDasa(EnumPlanet.Jupiter, 16.0),
            new AstroDasa(EnumPlanet.Saturn, 19.0),
            new AstroDasa(EnumPlanet.Mercury, 17.0),
            new AstroDasa(EnumPlanet.Kethu, 7.0),
            new AstroDasa(EnumPlanet.Venus, 20.0) });

        public EnumPlanet getDasaLord(double moonLon)
        {
            int i = 0;
            for (i = 0; i <= 26; i++)
                if (((i * (AstroConsts.NakLength)) <= moonLon)
                        && (moonLon < ((i + 1) * (AstroConsts.NakLength))))
                    break;
            int inum = ((int)(i + 7)) % 9;
            //if (inum == 0) inum = 8;
            return dasaList[inum].DasaPlanet;
        }

        public double computeBalance(double moonLongitude, EnumPlanet dasaLoad)
        {
            //How much moon has moved in nakath
            double balance = moonLongitude % AstroConsts.NakLength;
            if (balance == 0)
                balance = AstroConsts.NakLength;
            // How much moon has to go to complete the Nakath
            balance = AstroConsts.NakLength - balance;
            // how many more minutes to go
            balance = balance * 60;

            return (balance * dasaList.Find(x => x.DasaPlanet == dasaLoad).DasaPeriod) / 800;
        }
    }
    public class DasaRemainder
    {
        public DasaRemainder() { }

        public DasaRemainder(int years, int months, int days)
        {
            this.Years = years;
            this.Months = months;
            this.Days = days;
        }
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public override string ToString()
        {
            return this.Years/356 + " : " + this.Months;
        }
    }

    public class AstroDasa
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DasaRemainder Remainder { get; set; }
        public List<AstroDasa> AthuruDasas { get; set; }

        public AstroDasa() { }
        public AstroDasa(EnumPlanet planet, double period) {
            DasaPlanet = planet;
            DasaPeriod = period;
        }
        public EnumPlanet DasaPlanet { get; set; }
        public double DasaPeriod { get; set; }

        public void Init(DateTime dateTime, double dasaPeriod)
        {
            this.Start = dateTime;
            this.End = dateTime.AddDays((int)(dasaPeriod * 365));
            this.Remainder = new DasaRemainder((int)dasaPeriod * 365, 0, 0);
        }

        public int LengthInDays()
        {
            return End.Subtract(Start).Days;
        }

        public DasaEffectTypes GetDasaBirthPlanetEffect(List<AstroPlanet> birthTimePlanets)
        {
            AstroPlanet dasaAdhipathAtBirthChart = birthTimePlanets.FirstOrDefault(x => x.Current == this.DasaPlanet);
            return dasaAdhipathAtBirthChart.DasaBirthPlanetEffect;
        }

        public DasaResultTypes IsDasaTransitTimeGood(List<AstroPlanet> dasaTimePlantes)
        {
            AstroPlanet dasaAdhipathi = dasaTimePlantes.FirstOrDefault(x => x.Current == this.DasaPlanet);

            foreach (AstroPlanet planet in dasaTimePlantes)
            {
                //if (dasaAdhipathi.Current == planet.Current) continue;
                if ((planet.HouseNumber == 1) && (planet.PlanetRasiRelation <= EnumPlanetRasiRelationTypes.Mithra))
                {
                    if (planet.Current == this.DasaPlanet)
                        return DasaResultTypes.VeryGood;
                    else if ((planet.IsGoodPlanet) && (planet.GetPlanetRelation(this.DasaPlanet) == EnumPlanetRelationTypes.Mithra))
                        return DasaResultTypes.VeryGood;
                    else if ((planet.IsGoodPlanet) && (planet.GetPlanetRelation(this.DasaPlanet) == EnumPlanetRelationTypes.Sathuru))
                        return DasaResultTypes.Mixed;
                }
                else if ((planet.HouseNumber == 1) && (planet.IsGoodPlanet))
                { 
                    if ((planet.Current == this.DasaPlanet) &&
                        ((planet.HouseNumber == 3)
                        || (planet.HouseNumber == 7)
                        || (planet.HouseNumber == 10)
                        || (planet.HouseNumber == 11)))
                        return DasaResultTypes.Good;
                }
                else if (planet.Current == EnumPlanet.Moon)
                {
                    setDasaQualityBasedOnMoonPlacement(planet.Rasi.Current);
                    if (dasaAdhipathi.GetRelationToRasi(planet.Rasi.Current) <= EnumPlanetRasiRelationTypes.Mithra)
                        return DasaResultTypes.Good;

                    List<int> list = new List<int>() { 3, 5, 6, 7, 9, 10, 11 };
                    foreach (int i in list)
                        if (AstroUtility.AstroCycleIncreaseNew(dasaAdhipathi.HouseNumber, i) == planet.HouseNumber)
                            return DasaResultTypes.Good;
                }
            }

            return DasaResultTypes.Unknown;
        }

        private string dasaQualityBasedOnMoon;
        public string DasaQualityBasedOnMoon
        {
            get { return dasaQualityBasedOnMoon; }
            set { dasaQualityBasedOnMoon = "Mental Feeling is Like :" + value; }
        }

        private void setDasaQualityBasedOnMoonPlacement(EnumRasi moonRashi)
        {
            switch (moonRashi)
            {
                case EnumRasi.Mesha: DasaQualityBasedOnMoon = "Women get raped"; break;
                case EnumRasi.Vrishabha: DasaQualityBasedOnMoon = "No food shortage"; break;
                case EnumRasi.Mithuna: DasaQualityBasedOnMoon = "Get Knowledge/ Education, Friends and wealth"; break;
                case EnumRasi.Kataka: DasaQualityBasedOnMoon = "Get wealth, happiness, and recognition"; break;
                case EnumRasi.Simha: DasaQualityBasedOnMoon = "Happen to have hard work at distance places, in forest, in road or near house"; break;
                case EnumRasi.Kanya: DasaQualityBasedOnMoon = "Get Knowledge/ Education, Friends and wealth"; break;
                case EnumRasi.Thula: DasaQualityBasedOnMoon = "No food shortage"; break;
                case EnumRasi.Vrichika: DasaQualityBasedOnMoon = "Women get raped"; break;
                case EnumRasi.Dhanus: DasaQualityBasedOnMoon = "Wealth, Hapiness and devotion come after you"; break; ;
                case EnumRasi.Makara: DasaQualityBasedOnMoon = "Get a bad woman"; break;
                case EnumRasi.Kumbha: DasaQualityBasedOnMoon = "Get a bad woman"; break;
                case EnumRasi.Meena: DasaQualityBasedOnMoon = "Wealth, Hapiness and devotion come after you"; break;
            }
            DasaQualityBasedOnMoon = "";
        }

    }
}
