using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Dal.Handlers;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.Utilities;
using ChaNiBaaStra.Dal.DB;

namespace ChaNiBaaStra.DataModels
{
    public enum EnumWeekDay
    {
        //
        // Summary:
        //     Indicates Sunday.
        Sunday = 1,
        //
        // Summary:
        //     Indicates Monday.
        Monday = 2,
        //
        // Summary:
        //     Indicates Tuesday.
        Tuesday =3,
        //
        // Summary:
        //     Indicates Wednesday.
        Wednesday = 4,
        //
        // Summary:
        //     Indicates Thursday.
        Thursday = 5,
        //
        // Summary:
        //     Indicates Friday.
        Friday = 6,
        //
        // Summary:
        //     Indicates Saturday.
        Saturday = 7
    }

    public class AstroWeekDay : AstroBase<EnumWeekDay, WeekDay>
    { 
        public double Zone { get; set; }
        public AstroWeekDay(EnumWeekDay weekDay) : base(weekDay, 7, AstroConsts.InvalidIntInput)
        {
            this.DataModel = new WeekDayHandler().Get(x => x.WeekDayId == this.CurrentInt);
        }

        private string[] Rahukala = {
            "04:30 PM - 06:00 PM", "07:30 AM - 09:00 AM", "03:00 PM - 4:30 PM",
            "12:00 PM - 01:30 PM", "01:30 PM - 03:00 PM", "10:30 AM - 12:00 PM",
            "09:00 AM - 10:30 AM"
        };

        private string[] Yamakanda = {
            "12:00 PM - 1:30 PM", "10:30 AM - 12:00 AM", "09:00 AM - 10:30 AM",
            "07:30 AM - 09:00 AM", "06:00 AM - 07:30 AM", "03:00 PM - 04:30 PM",
            "01:30 PM - 03:00 PM"
        };

        private string[][] AuspiciousTime = new string[7][] {
            new string[] {"07.30 - 10.00 am", "02.00 - 04.30 pm", "09.00 pm - 12.00 am"},
            new string[] {"06.00 - 07.00 am ", "12.00 - 02.00 pm", "06.00 - 09.00 pm , 10.00 - 11.00 pm"},
            new string[] {"10.30 - 11.00 am", "12.00 - 01.00 pm , 04.30 - 06.00 pm ", "07.00 - 08.00 pm"},
            new string[] {"09.00 - 10.00 am", "01.30 - 03.00 pm , 04.00 - 05.00 pm", "07.00 - 10.00 pm , 11.00 pm - 12.00 am"},
            new string[] {"09.00 - 10.30 am", "01.00 - 01.30 pm , 04.30 - 06.00 pm", "06.00 - 07.00 pm , 08.00 - 09.00 pm"},
            new string[] {"06.00 - 09.00  am", "01.00 - 01.30 pm , 05.00 - 06.00 pm", "08.00 - 9.00 pm , 10.30 - 11.00 pm"},
            new string[] {"07.00 - 07.30 am , 10.30 - 12.00 pm", "12.00 - 01.00 pm , 05.00 - 06.00 pm", "06.00 - 07.30 pm , 09.00 - 10.00 pm"}
        };
        public EnumWeekDay ofDay(int yr, int mon, int date)
        {
            return ofCalendar(new DateTime(yr, mon - 1, date));
        }
        public EnumWeekDay ofCalendar(DateTime dateTime)
        {
            return ofIndex((int)dateTime.DayOfWeek - 1);
        }
        public Tuple<DateTime, DateTime> Rahukalaya(DateTime SunRise, DateTime Sunset)
        {
            return GetTimes(Rahukala[CurrentInt-1], SunRise, Sunset);
        }
        public Tuple<DateTime, DateTime> YamakandaYA(DateTime SunRise, DateTime Sunset)
        {
            return GetTimes(Yamakanda[CurrentInt-1], SunRise, Sunset);
        }
        public String[] AuspiciousTiming()
        {
            return AuspiciousTime[CurrentInt-1];
        }
        /// <summary>
        /// Get the time 4, 30, 6, 0 seperately considering PM AM as well
        /// </summary>
        /// <param name="time">Something like "04:30 PM - 06:00 PM"</param>
        /// <returns></returns>
        private Tuple<DateTime, DateTime> GetTimes(string time, DateTime SunRise, DateTime SunSet)
        {
            DateTime dayStart = new DateTime(SunRise.Year, SunRise.Month, SunRise.Day, 6, 0, 0);

            string[] items = time.Split('-');
            DateTime startTime = DateTime.Now;
            string[] times = items[0].Split(':', ' ');
            int h0 = Convert.ToInt32(times[0]);
            h0 = times[2] != "PM" ? h0 : h0 == 12 ? h0 : 12 + h0;
            int m0 = Convert.ToInt32(times[1]);
         
            DateTime TimingStart = new DateTime(SunRise.Year, SunRise.Month, SunRise.Day, h0, m0, 0);
            times = items[1].Split(':', ' ');
            int h = Convert.ToInt32(times[1]);
            h = times[3] != "PM" ? h : h == 12 ? h : 12 + h;
            int m = Convert.ToInt32(times[2]);
           
            DateTime TimingEnd = new DateTime(SunRise.Year, SunRise.Month, SunRise.Day, h, m, 0);
            double minuteAdjustment = (SunSet.Subtract(SunRise).TotalMinutes / 720);
            DateTime actualTimingStartTime = SunRise.AddMinutes(TimingStart.Subtract(dayStart).TotalMinutes * minuteAdjustment);
            DateTime actualTimingEndTime = SunRise.AddMinutes(TimingEnd.Subtract(dayStart).TotalMinutes * minuteAdjustment);

            return new Tuple<DateTime, DateTime>(actualTimingStartTime
                , actualTimingEndTime);
        }

        public bool IsGood
        {
            get
            {
                return !(this.Current == EnumWeekDay.Sunday ||
                        this.Current == EnumWeekDay.Tuesday ||  
                        this.Current == EnumWeekDay.Saturday);
            }
        }
    }
}
