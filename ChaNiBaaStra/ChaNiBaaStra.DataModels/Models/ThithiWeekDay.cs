namespace ChaNiBaaStra.Dal.DB
{
    public class ThithiWeekDay
    {
        private int thithiId;
        private bool isGood;
        public bool IsGood
        {
            get
            {
                return isGood;
            }

            set
            {
                isGood = value;
            }
        }

        public int ThithiId
        {
            get
            {
                return thithiId;
            }

            set
            {
                thithiId = value;
            }
        }
    }
}