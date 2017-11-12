using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Utilities;
using static ChaNiBaaStra.DataModels.AstroMuhurtha;
namespace ChaNiBaaStra.DataModels
{
    public abstract class KalaBase
    {
        public KalaBase()
        { }
        public enum EnumHoraTypes
        {
            Hora,
            PanchamaHora,
            SukshamaHora
        }
        public class TimeInterval
        {
            public TimeInterval(DateTime startTime, DateTime endTime)
            {
                StartTime = startTime;
                EndTime = endTime;
                IsVisha = false;
            }
            public TimeInterval(DateTime startTime, DateTime endTime, bool isVisha)
            {
                StartTime = startTime;
                EndTime = endTime;
                IsVisha = isVisha;
            }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool IsVisha { get; set; }
        }
        public EnumPlanet KalaAdhipathiPlanet { get; set; }
        public TimeInterval KalaInterval { get; set; }
        public EnumPlanet GetDayPlanet(DayOfWeek dayOfWeek)
        {
            EnumPlanet dayPlanet = EnumPlanet.Sun;
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday: dayPlanet = EnumPlanet.Sun; break;
                case DayOfWeek.Monday: dayPlanet = EnumPlanet.Moon; break;
                case DayOfWeek.Tuesday: dayPlanet = EnumPlanet.Mars; break;
                case DayOfWeek.Wednesday: dayPlanet = EnumPlanet.Mercury; break;
                case DayOfWeek.Thursday: dayPlanet = EnumPlanet.Jupiter; break;
                case DayOfWeek.Friday: dayPlanet = EnumPlanet.Venus; break;
                case DayOfWeek.Saturday: dayPlanet = EnumPlanet.Saturn; break;
            };
            return dayPlanet;
        }
        public abstract void Init(DateTime date, EnumPlanet? upperHoraPlanet);
    }
    public abstract class KalaCalculator<T> : KalaBase
        where T : KalaBase, new()
    {
        public List<T> GetKalaList(EnumHoraTypes depth, EnumPlanet upperHoraPlanet)
        {
            TimeSpan ts = new TimeSpan(KalaInterval.EndTime.Ticks);
            ts = ts.Subtract(new TimeSpan(KalaInterval.StartTime.Ticks));
            int increment = 0;
            if (ts.Hours == 1) increment = 12; else if (ts.Minutes == 12) increment = 4;

            int length = 0;
            if (increment == 12) length = 5; else if (increment == 4) length = 3;

            List<T> kalaList = new List<T>();
            T s1 = new T();
            s1.KalaInterval = new TimeInterval(KalaInterval.StartTime
                , KalaInterval.StartTime.AddMinutes(increment));
            s1.KalaAdhipathiPlanet = GetHoraPlanet(KalaInterval.StartTime, depth, upperHoraPlanet);
            s1.KalaInterval.IsVisha = (depth == EnumHoraTypes.PanchamaHora) 
                ? IsVishaHora(upperHoraPlanet, s1.KalaAdhipathiPlanet) : false;
            s1.Init(s1.KalaInterval.StartTime, s1.KalaAdhipathiPlanet);

            kalaList.Add(s1);
            DateTime startTime = s1.KalaInterval.EndTime;

            for (int i = 1; i < length; i++)
            {
                T s = new T();
                s.KalaInterval = new TimeInterval(startTime, startTime.AddMinutes(increment));
                s.KalaAdhipathiPlanet = GetHoraPlanet(s.KalaInterval.StartTime, depth, upperHoraPlanet);
                s.KalaInterval.IsVisha = (depth == EnumHoraTypes.PanchamaHora) 
                    ? IsVishaHora(upperHoraPlanet, s.KalaAdhipathiPlanet) : false;
                s.Init(s.KalaInterval.StartTime, s.KalaAdhipathiPlanet);
                kalaList.Add(s);

                startTime = s.KalaInterval.EndTime;
            }
            return kalaList;
        }
        public EnumPlanet GetPlanet(int horaInt, EnumHoraTypes depth)
        {
            if (depth == EnumHoraTypes.Hora)
                return GetHoraOrSukshamaHoraPlanet(horaInt);
            else if (depth == EnumHoraTypes.PanchamaHora)
                return GetPanchamaHoraPlanet(horaInt);
            else
                return GetHoraOrSukshamaHoraPlanet(horaInt);
        }
        private EnumPlanet GetHoraOrSukshamaHoraPlanet(int horaInt)
        {
            EnumPlanet horaPlanet = EnumPlanet.Sun;
            switch (horaInt)
            {
                case 1: horaPlanet = EnumPlanet.Sun; break;
                case 2: horaPlanet = EnumPlanet.Venus; break;
                case 3: horaPlanet = EnumPlanet.Mercury; break;
                case 4: horaPlanet = EnumPlanet.Moon; break;
                case 5: horaPlanet = EnumPlanet.Saturn; break;
                case 6: horaPlanet = EnumPlanet.Jupiter; break;
                case 7: horaPlanet = EnumPlanet.Mars; break;
            };
            return horaPlanet;
        }
        private bool IsVishaHora(EnumPlanet upperHoraPlanet, EnumPlanet horaPlanet)
        {
            return (upperHoraPlanet == EnumPlanet.Sun) ? horaPlanet ==  EnumPlanet.Jupiter
                : (upperHoraPlanet == EnumPlanet.Moon) ? horaPlanet ==  EnumPlanet.Moon
                : (upperHoraPlanet == EnumPlanet.Mars) ? horaPlanet == EnumPlanet.Saturn
                : (upperHoraPlanet == EnumPlanet.Mercury) ? horaPlanet == EnumPlanet.Venus
                : (upperHoraPlanet == EnumPlanet.Jupiter) ? horaPlanet == EnumPlanet.Moon
                : (upperHoraPlanet == EnumPlanet.Venus) ? horaPlanet == EnumPlanet.Sun
                : (upperHoraPlanet == EnumPlanet.Saturn) ? horaPlanet == EnumPlanet.Saturn : false;
        }
        protected EnumPlanet GetHoraPlanet(DateTime dateTime
            , EnumHoraTypes depth, EnumPlanet? upperHoraPlanet)
        {
            int horaInt = 0;
            int panchaHoraInt = 0;
            int sukshamaHoraInt = 0;
            DayOfWeek day = dateTime.DayOfWeek;
            switch (depth)
            {
                case EnumHoraTypes.Hora:
                    {
                        horaInt = dateTime.AddHours(-5).Hour % 7;
                        if (horaInt == 0) horaInt = 7;
                        horaInt = (day == DayOfWeek.Sunday) ? horaInt
                            : (day == DayOfWeek.Monday) ? horaInt + 3
                            : (day == DayOfWeek.Tuesday) ? horaInt + 6
                            : (day == DayOfWeek.Wednesday) ? horaInt + 2
                            : (day == DayOfWeek.Thursday) ? horaInt + 5
                            : (day == DayOfWeek.Friday) ? horaInt + 1
                            : (day == DayOfWeek.Saturday) ? horaInt + 4 : 0;
                        horaInt = horaInt % 7;
                        if (horaInt == 0) horaInt = 7;
                        return GetPlanet(horaInt, EnumHoraTypes.Hora);
                    }
                case EnumHoraTypes.PanchamaHora:
                    {
                        panchaHoraInt = 1 + (dateTime.Minute / 12);

                        panchaHoraInt = (upperHoraPlanet == EnumPlanet.Sun) ? panchaHoraInt
                                        : (upperHoraPlanet == EnumPlanet.Moon) ? panchaHoraInt + 1
                                        : (upperHoraPlanet == EnumPlanet.Mars) ? panchaHoraInt + 2
                                        : (upperHoraPlanet == EnumPlanet.Mercury) ? panchaHoraInt + 3
                                        : (upperHoraPlanet == EnumPlanet.Jupiter) ? panchaHoraInt + 4
                                        : (upperHoraPlanet == EnumPlanet.Venus) ? panchaHoraInt + 5
                                        : (upperHoraPlanet == EnumPlanet.Saturn) ? panchaHoraInt + 6 : 0;
                        panchaHoraInt = panchaHoraInt % 7;
                        if (panchaHoraInt == 0) panchaHoraInt = 7;
                        return GetPlanet(panchaHoraInt, EnumHoraTypes.PanchamaHora);
                    }
                case EnumHoraTypes.SukshamaHora:
                    {
                        sukshamaHoraInt = 1 + ((dateTime.Minute % 12) / 4);
                        sukshamaHoraInt = (upperHoraPlanet == EnumPlanet.Sun) ? sukshamaHoraInt
                                        : (upperHoraPlanet == EnumPlanet.Moon) ? sukshamaHoraInt + 3
                                        : (upperHoraPlanet == EnumPlanet.Mars) ? sukshamaHoraInt + 6
                                        : (upperHoraPlanet == EnumPlanet.Mercury) ? sukshamaHoraInt + 2
                                        : (upperHoraPlanet == EnumPlanet.Jupiter) ? sukshamaHoraInt + 5
                                        : (upperHoraPlanet == EnumPlanet.Venus) ? sukshamaHoraInt + 1
                                        : (upperHoraPlanet == EnumPlanet.Saturn) ? sukshamaHoraInt + 4 : 0;
                        sukshamaHoraInt = sukshamaHoraInt % 7;
                        if (sukshamaHoraInt == 0) sukshamaHoraInt = 7;
                        return GetPlanet(sukshamaHoraInt, EnumHoraTypes.SukshamaHora);
                    }
            }
            return EnumPlanet.Sun;
        }
        private EnumPlanet GetPanchamaHoraPlanet(int horaInt)
        {
            EnumPlanet horaPlanet = EnumPlanet.Sun;
            switch (horaInt)
            {
                case 1: horaPlanet = EnumPlanet.Sun; break;
                case 2: horaPlanet = EnumPlanet.Moon; break;
                case 3: horaPlanet = EnumPlanet.Mars; break;
                case 4: horaPlanet = EnumPlanet.Mercury; break;
                case 5: horaPlanet = EnumPlanet.Jupiter; break;
                case 6: horaPlanet = EnumPlanet.Venus; break;
                case 7: horaPlanet = EnumPlanet.Saturn; break;
            };
            return horaPlanet;
        }
        public int GetPanetInt(EnumPlanet planet)
        {
            int planetInt = 0;
            switch (planet)
            {
                case EnumPlanet.Sun: planetInt = 1; break;
                case EnumPlanet.Venus: planetInt = 2; break;
                case EnumPlanet.Mercury: planetInt = 3; break;
                case EnumPlanet.Moon: planetInt = 4; break;
                case EnumPlanet.Saturn: planetInt = 5; break;
                case EnumPlanet.Jupiter: planetInt = 6; break;
                case EnumPlanet.Mars: planetInt = 7; break;
            };
            return planetInt;
        }
    }
    public class HoraKala : KalaCalculator<PanchamaKala>
    {
        public override void Init(DateTime date, EnumPlanet? upperHoraPlanet)
        {
            DateTime startInteval = new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
            this.KalaInterval = new TimeInterval(startInteval, startInteval.AddHours(1));
            this.KalaAdhipathiPlanet = GetHoraPlanet(startInteval, EnumHoraTypes.Hora, upperHoraPlanet);
            PanchamaKalaList = GetKalaList(EnumHoraTypes.PanchamaHora, this.KalaAdhipathiPlanet);
        }

        public void InitForNext(DateTime date, EnumPlanet? upperHoraPlanet)
        {
            DateTime startInteval = new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
            this.KalaInterval = new TimeInterval(startInteval, startInteval.AddHours(1));
            this.KalaAdhipathiPlanet = GetHoraPlanet(startInteval, EnumHoraTypes.Hora, upperHoraPlanet);
            PanchamaKalaList = GetKalaList(EnumHoraTypes.PanchamaHora, this.KalaAdhipathiPlanet);
        }
        public List<PanchamaKala> PanchamaKalaList { get; set; }
    }
    public class PanchamaKala : KalaCalculator<SukshamaKala>
    {
        public PanchamaKala() { }
        public override void Init(DateTime date, EnumPlanet? upperHoraPlanet)
        {
            DateTime startInteval = new DateTime(date.Year, date.Month
                , date.Day, date.Hour, date.Minute, date.Second);
            SukshamaKalaList = GetKalaList(EnumHoraTypes.SukshamaHora
                , this.KalaAdhipathiPlanet);
        }
        public List<SukshamaKala> SukshamaKalaList { get; set; }
    }
    public class SukshamaKala : KalaBase
    {
        public SukshamaKala() { }
        public override void Init(DateTime date, EnumPlanet? upperHoraPlanet)
        {
            DateTime startInteval = new DateTime(date.Year, date.Month
                , date.Day, date.Hour, date.Minute, date.Second);
        }
    }
    public class AstroMuhurtha
    {
        public DateTime ThisDateTime { get; set; }
        public string ThisHoraAdhipathiPlanet { get; set; }
        public EnumPlanet ThisPachamaHoraAdhipathiPlanet { get; set; }
        public KalaBase.TimeInterval ThisPachamaHora { get; set; }
        public EnumPlanet ThisSukshamaHoraAdhipathiPlanet { get; set; }
        public KalaBase.TimeInterval ThisSukshamaHora { get; set; }
        public DateTime SunRise { get; set; }
        public DateTime SunSet { get; set; }
        public AstroMuhurtha(DateTime dateTime, DateTime sunRise, DateTime sunSet)
        {
            ThisDateTime = dateTime;
            SunRise = sunRise;
            SunSet = sunSet;
            Init();
        }
        private void Init()
        {
            bool timeAdjustmentFailed = false;
            CurrentHoraKala = new HoraKala();
            CurrentHoraKala.Init(ThisDateTime, null);
            if (!TimeAdjustment(CurrentHoraKala))
            {
                CurrentHoraKala.Init(ThisDateTime.AddHours(1), null);
                TimeAdjustment(CurrentHoraKala);
                timeAdjustmentFailed = true;
            }

            NextHoraKala = new HoraKala();
            NextHoraKala.Init(ThisDateTime.AddHours((timeAdjustmentFailed) ? 2 : 1), null);
            TimeAdjustment(NextHoraKala);
            PreviousHoraKala = new HoraKala();
            PreviousHoraKala.Init(ThisDateTime.AddHours((timeAdjustmentFailed) ? 0 : -1), null);
            TimeAdjustment(PreviousHoraKala);
        }
        private bool TimeAdjustment(HoraKala currentHoraKala)
        {
            currentHoraKala.KalaInterval = new KalaBase.TimeInterval(
                SunTimes.GetTimeAdjustedForSunTime(currentHoraKala.KalaInterval.StartTime, SunRise, SunSet)
                , SunTimes.GetTimeAdjustedForSunTime(currentHoraKala.KalaInterval.EndTime, SunRise, SunSet)
                , currentHoraKala.KalaInterval.IsVisha);

            if (currentHoraKala.KalaInterval.StartTime <= ThisDateTime && currentHoraKala.KalaInterval.EndTime >= ThisDateTime)
                this.ThisHoraAdhipathiPlanet = currentHoraKala.KalaAdhipathiPlanet.ToString();
            else
                return false;

            foreach (PanchamaKala pKala in currentHoraKala.PanchamaKalaList)
            {
                pKala.KalaInterval = new KalaBase.TimeInterval(
                    SunTimes.GetTimeAdjustedForSunTime(pKala.KalaInterval.StartTime, SunRise, SunSet)
                , SunTimes.GetTimeAdjustedForSunTime(pKala.KalaInterval.EndTime, SunRise, SunSet)
                , pKala.KalaInterval.IsVisha);

                if (pKala.KalaInterval.StartTime <= ThisDateTime && pKala.KalaInterval.EndTime >= ThisDateTime)
                {
                    this.ThisPachamaHoraAdhipathiPlanet = pKala.KalaAdhipathiPlanet;
                    ThisPachamaHora= pKala.KalaInterval;
                }

                foreach (SukshamaKala sKala in pKala.SukshamaKalaList)
                {
                    sKala.KalaInterval = new KalaBase.TimeInterval(
                        SunTimes.GetTimeAdjustedForSunTime(sKala.KalaInterval.StartTime, SunRise, SunSet)
                    , SunTimes.GetTimeAdjustedForSunTime(sKala.KalaInterval.EndTime, SunRise, SunSet)
                    , sKala.KalaInterval.IsVisha);

                    if (sKala.KalaInterval.StartTime <= ThisDateTime && sKala.KalaInterval.EndTime >= ThisDateTime)
                    {
                        this.ThisSukshamaHoraAdhipathiPlanet = sKala.KalaAdhipathiPlanet;
                        this.ThisSukshamaHora = sKala.KalaInterval;
                    }
                }
            }
            return true;
        }
        public AstroMuhurtha()
        { }
        public HoraKala CurrentHoraKala { get; set; }
        public HoraKala NextHoraKala { get; set; }
        public HoraKala PreviousHoraKala { get; set; }
    }
}
