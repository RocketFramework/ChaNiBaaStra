using System;
using Nido.Common.BackEnd;
using ChaNiBaaStra.Dal.Models;
using System.Collections.Generic;

namespace ChaNiBaaStra.Dal.DB
{
    public class WeekDay : BaseObject
    {
        private int weekDayId;

        public int WeekDayId
        {
            get
            {
                return weekDayId;
            }

            set
            {
                weekDayId = value;
            }
        }

        public bool? IsGood
        {
            get
            {
                return isGood;
            }

            set
            {
                isGood = value.Value;
            }
        }

        public override bool CanDelete
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private bool isGood;
        public List<ThithiWeekDay> ThithiWeekDays = new List<ThithiWeekDay>();
        public List<NakathThithiWeekDay> NakathThithiWeekDays = new List<NakathThithiWeekDay>();
        public List<NakathWeekDay> NakathWeekDays = new List<NakathWeekDay>();
    }
}