using System;
using Nido.Common.BackEnd;

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
    }
}