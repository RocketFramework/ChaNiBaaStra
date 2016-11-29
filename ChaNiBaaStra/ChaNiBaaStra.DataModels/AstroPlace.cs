using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Utilities;
using PropertyChanged;

namespace ChaNiBaaStra.DataModels
{
    public enum EnumLocationType
    {
        Longitude,
        Latitude
    }
    public enum EnumDirection
    {
        EAST = 1,
        WEST = -1,
        NORTH = 1,
        SOUTH = -1,
        NONE = 0
    }
    public class AstroDirection
    {
        public EnumDirection ofVal(double val, EnumLocationType type)
        {
            switch (type)
            {
                case EnumLocationType.Latitude: return val < 0 ? EnumDirection.SOUTH : EnumDirection.NORTH;
                case EnumLocationType.Longitude: return val < 0 ? EnumDirection.WEST : EnumDirection.EAST;
            }
            return EnumDirection.NONE;
        }
    }
    public class Location : AstroDirection
    {
        public int DegValue;
        public int MinuteValue;
        public EnumDirection DirectionValue;
        public Location(int deg, int min, EnumDirection dir)
        {
            this.DegValue = deg;
            this.MinuteValue = min;
            this.DirectionValue = dir;
        }
        public Location(string deg, string min, EnumDirection dir) : this(Convert.ToInt32(deg), Convert.ToInt32(min), dir)
        { }
        public Location(double value, EnumLocationType type)
        {
            int[] degmin = AstroUtility.GetDegreeMinuteSeconds(value);
            DegValue = Math.Abs(degmin[0]);
            MinuteValue = Math.Abs(degmin[1]);
            DirectionValue = this.ofVal(value, type);
        }
    }

    [ImplementPropertyChanged]
    public class AstroPlace : INotifyPropertyChanged
    {
        public DateTime OriginalDateTime { get; set; }
        public DateTime BirthDate
        {
            get { return birthDateTime.Date; }
            set
            {
                birthDateTime = new DateTime(value.Year
                    , value.Month, value.Day
                    , BirthTime.Hours, BirthTime.Minutes, BirthTime.Seconds);
            }
        }
        private DateTime birthDateTime;
        public DateTime BirthDateTime
        {
            get { return birthDateTime;  }
            set
            {
                birthDateTime = value;
                AdjustTime(Longitude, value);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public TimeSpan BirthTime
        {
            get { return birthDateTime.TimeOfDay; }
            set
            {
                birthDateTime = new DateTime(BirthDate.Year
                    , BirthDate.Month, BirthDate.Day
                    , value.Hours, value.Minutes, value.Seconds);
            }
        }
        public string City { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        private string longitudeAngle;
        public string LongitudeAngle
        {
            get { return string.IsNullOrEmpty(longitudeAngle) ? GeoAngle.FromDouble(Longitude).ToString() : longitudeAngle; }
            set
            {
                Longitude = AstroUtility.ConvertDegreeAngleToDouble(value);
                longitudeAngle = value;
                OnPropertyChanged("LongitudeAngle");
                OnPropertyChanged("Longitude");
            }
        }
        public double Latitude { get; set; }
        private string latitudeAngle;
        public string LatitudeAngle
        {
            get { return string.IsNullOrEmpty(latitudeAngle)? GeoAngle.FromDouble(Latitude).ToString(): latitudeAngle; }
            set
            {
                Latitude = AstroUtility.ConvertDegreeAngleToDouble(value);
                latitudeAngle = value;
                OnPropertyChanged("LatitudeAngle");
                OnPropertyChanged("Latitude");
            }
        }
        public double TimeZone { get; set; }
        public string TimeZoneId { get; set; }
        public string TimeZoneString { get; set; }

        public AstroPlace(string city, string country, double latitude, double longitude, double timeZone, DateTime dateTime)
        {
            AdjustTime(longitude, dateTime);

            this.Country = country;
            this.City = city;
            this.Longitude = longitude;
            this.Latitude = latitude;
            
            int[] tz = AstroUtility.GetDegreeMinuteSeconds(TimeZone);
            this.TimeZoneString = tz[0].ToString() + ":" + tz[1];
        }

        private void AdjustTime(double longitude, DateTime dateTime)
        {
            OriginalDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);

            double actualOffset = longitude / 15.0;
            TimeSpan ts = TimeZoneInfo.Local.BaseUtcOffset;
            double standardOffset = ts.TotalMinutes / 60.0;
            double adjustment = (actualOffset - standardOffset) * 60;

            double minAdjustment = (int)adjustment;
            double secAdjustment = (adjustment - minAdjustment) * 60;

            DateTime adjustedDateTime = dateTime.AddMinutes((int)minAdjustment).AddSeconds(secAdjustment);

            this.TimeZone = -1 * actualOffset;
            this.BirthDate = adjustedDateTime.Date;
            this.BirthTime = adjustedDateTime.TimeOfDay;
        }

        public AstroPlace()
        {
            this.Country = "Sri Lanka";
            this.City = "Colombo";
            this.Longitude = 79.861244;
            this.Latitude = 6.9271;
            this.TimeZone = -1 * Longitude / 15.0;
            int[] tz = AstroUtility.GetDegreeMinuteSeconds(TimeZone);
            this.TimeZoneString = tz[0].ToString() + ":" + tz[1];

            this.birthDateTime = new DateTime(1975, 7, 2, 12, 34, 0);
        }

        public static DateTime GetUniversalTime(DateTime locationDateTime, double longitude)
        {
            double actualOffset = longitude / 15.0;
            double minAdjustment = (actualOffset) * 60 * -1;
            double secAdjustment = (minAdjustment - (int)minAdjustment) * 60;
            return locationDateTime.AddMinutes((int)minAdjustment).AddSeconds(secAdjustment);
        }

        public DateTime GetStandardTime(DateTime adjustedTime)
        {
            double actualOffset = Longitude / 15.0;
            TimeSpan ts = TimeZoneInfo.Local.BaseUtcOffset;
            double standardOffset = ts.TotalMinutes / 60.0;
            double adjustment = (actualOffset - standardOffset) * 60;

            double minAdjustment = (int)adjustment;
            double secAdjustment = (adjustment - minAdjustment) * 60;

            return adjustedTime.AddMinutes((int)minAdjustment * -1).AddSeconds(secAdjustment * -1);
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
