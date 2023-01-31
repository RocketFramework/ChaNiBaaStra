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
            this.End = dateTime.AddDays((int)(dasaPeriod*365));
            this.Remainder = new DasaRemainder((int)dasaPeriod*365, 0, 0);
        }

        public int LengthInDays()
        {
            return End.Subtract(Start).Days;
        }
    }
}
