using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaNiBaaStra.Utilities;
using PropertyChanged;
using RestSharp;
using static log4net.Appender.RollingFileAppender;

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
        public Location(string deg, string min, EnumDirection dir)
            : this(Convert.ToInt32(deg), Convert.ToInt32(min), dir)
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
        private const string DateTimeOffsetFormatString = "yyyy-MM-ddTHH:mm:sszzz";
        private DateTimeOffset eventTimeField;
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EventTime
        {
            get { return eventTimeField.ToString(DateTimeOffsetFormatString); }
            set { eventTimeField = DateTimeOffset.Parse(value); }
        }
        public DateTime OriginalDateTime
        {
            get { return DateTime.Parse(EventTime); }
            set { eventTimeField = value; }
        }
        public DateTime AdjustedBirthDate
        {
            get { return adjustedBirthDateTime.Date; }
        }
        public DateTime AdjustedBirthDateTime
        {
            get { return adjustedBirthDateTime; }
        }

        public TimeSpan AdjustedBirthTime
        {
            get { return adjustedBirthDateTime.TimeOfDay; }
        }

        /*public DateTime OriginalDateTime { get; set; }*/
        /*public DateTime AdjustedBirthDate
        {
            get { return adjustedBirthDateTime.Date; }
            set
            {
                adjustedBirthDateTime = new DateTime(value.Year
                    , value.Month, value.Day
                    , BirthTime.Hours, BirthTime.Minutes, BirthTime.Seconds);
            }
        }*/

        private DateTime adjustedBirthDateTime;

        /*public DateTime AdjustedBirthDateTime
        {
            get { return adjustedBirthDateTime;  }
            set
            {
                adjustedBirthDateTime = value;
                AdjustTime(Longitude, value);
            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
        /*public TimeSpan AdjustedBirthTime
        {
            get { return adjustedBirthDateTime.TimeOfDay; }
            set
            {
                adjustedBirthDateTime = new DateTime(AdjustedBirthDate.Year
                    , AdjustedBirthDate.Month, AdjustedBirthDate.Day
                    , value.Hours, value.Minutes, value.Seconds);
            }
        }*/
        public string City { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        private string longitudeAngle;
        public string LongitudeAngle
        {
            get
            {
                return string.IsNullOrEmpty(longitudeAngle) ? GeoAngle.FromDouble(Longitude).ToString()
                    : longitudeAngle;
            }
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
            get
            {
                return string.IsNullOrEmpty(latitudeAngle) ? GeoAngle.FromDouble(Latitude).ToString()
                    : latitudeAngle;
            }
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
        public string PersonName { get; set; }
        public bool IsMale { get; }
        public AstroPlace(string city, string country, string name
            , double latitude, double longitude, DateTime dateTime, bool isMale)
        {
            //+
            OriginalDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day
                , dateTime.Hour, dateTime.Minute, dateTime.Second);
            AdjustTime(longitude, dateTime);

            this.Country = country;
            this.City = city;
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.PersonName = name;
            this.IsMale = isMale;
            int[] tz = AstroUtility.GetDegreeMinuteSeconds(TimeZone);
            this.TimeZoneString = tz[0].ToString() + ":" + tz[1];
        }
        public AstroPlace(double latitude, double longitude, DateTime dateTime)
        {
            //+
            OriginalDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day
                , dateTime.Hour, dateTime.Minute, dateTime.Second);
            AdjustTime(longitude, dateTime);

            this.Country = "Unknown";
            this.City = "Unknown";
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.PersonName = "Unknown";
            this.IsMale = false;
            int[] tz = AstroUtility.GetDegreeMinuteSeconds(TimeZone);
            this.TimeZoneString = tz[0].ToString() + ":" + tz[1];
        }
        private void AdjustTime(double longitude, DateTime dateTime)
        {
            //OriginalDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day
            //, dateTime.Hour, dateTime.Minute, dateTime.Second);

            double actualOffset = longitude / 15.0;
            TimeSpan ts = TimeZoneInfo.Local.BaseUtcOffset;
            double standardOffset = ts.TotalMinutes / 60.0;
            double adjustment = (actualOffset - standardOffset) * 60;

            double minAdjustment = (int)adjustment;
            double secAdjustment = (adjustment - minAdjustment) * 60;

            //DateTime adjustedDateTime = dateTime.AddMinutes((int)minAdjustment).AddSeconds(secAdjustment);
            adjustedBirthDateTime = dateTime.AddMinutes((int)minAdjustment).AddSeconds(secAdjustment);
            this.TimeZone = -1 * actualOffset;
            //this.AdjustedBirthDate = adjustedDateTime.Date;
            //this.AdjustedBirthTime = adjustedDateTime.TimeOfDay;
        }
        public AstroPlace()
        {
            //+
            OriginalDateTime = new DateTime(1975, 7, 2, 12, 34, 0);
            this.Longitude = 79.861244;
            AdjustTime(this.Longitude, OriginalDateTime);

            this.Country = "Sri Lanka";
            this.City = "Colombo";
            this.Latitude = 6.9271;
            this.TimeZone = -1 * Longitude / 15.0;
            this.PersonName = "Nirosh";
            this.IsMale = true;
            int[] tz = AstroUtility.GetDegreeMinuteSeconds(TimeZone);
            this.TimeZoneString = tz[0].ToString() + ":" + tz[1];
            //this.adjustedBirthDateTime = new DateTime(1975, 7, 2, 12, 34, 0);
        }
        /*public static DateTime GetUniversalTime(DateTime locationDateTime, double longitude)
        {
            // Create a DateTimeOffset object from the input DateTime and longitude
            DateTimeOffset localTimeOffset = new DateTimeOffset(locationDateTime, TimeSpan.FromHours(longitude / 15.0));

            // Convert the local time to UTC
            DateTime universalTime = localTimeOffset.UtcDateTime;

            return universalTime;
            /*double actualOffset = longitude / 15.0;
            double minAdjustment = (actualOffset) * 60 * -1;
            double secAdjustment = (minAdjustment - (int)minAdjustment) * 60;
            return locationDateTime.AddMinutes((int)minAdjustment).AddSeconds(secAdjustment);*/
        /*}*/

        public static DateTime GetUniversalTime(DateTime locationDateTime, double longitude)
        {
            string zone = TimeZoneLookup(longitude);
            /*if (zone == "India Standard Time")
            {
                double actualOffset = longitude / 15.0;
                double minAdjustment = (actualOffset) * 60 * -1;
                double secAdjustment = (minAdjustment - (int)minAdjustment) * 60;
                return locationDateTime.AddMinutes((int)minAdjustment).AddSeconds(secAdjustment);
            }*/
            // Get the time zone corresponding to the longitude
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneLookup(longitude));

            // Convert the local time to the time zone's UTC equivalent
            DateTime universalTime = TimeZoneInfo.ConvertTimeToUtc(locationDateTime, timeZone);

            return universalTime;
        }

        // Helper method to determine time zone based on longitude
        private static string TimeZoneLookup(double longitude)
        {
            // Simplified logic for demonstration purposes, actual implementation may vary
            if (longitude >= 67.5 && longitude < 82.5)
                return "India Standard Time";
            else if (longitude >= -180 && longitude < -157.5)
                return "Hawaiian Standard Time";
            else if (longitude >= -157.5 && longitude < -142.5)
                return "Alaskan Standard Time";
            // Add more cases for other time zones as needed
            else
                return "Eastern Standard Time"; // Default to EST for unknown longitudes
        }

        private const string GeoNamesApiBaseUrl = "http://api.geonames.org";

        public static DateTime GetUniversalTime(DateTime locationDateTime, double latitude, double longitude)
        {
            // Fetch the time zone ID based on the geographical coordinates
            string timeZoneId = GetTimeZoneId(latitude, longitude);

            // Convert the local time to the time zone's UTC equivalent
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            DateTime universalTime = TimeZoneInfo.ConvertTimeToUtc(locationDateTime, timeZone);

            return universalTime;
        }

        private static string GetTimeZoneId(double latitude, double longitude)
        {
            var client = new RestClient(GeoNamesApiBaseUrl);
            var request = new RestRequest("timezoneJSON", Method.Get);
            request.AddParameter("lat", latitude);
            request.AddParameter("lng", longitude);
            request.AddParameter("username", "nirosh");

            var response = client.Execute<TimeZoneResponse>(request);

            if (response.IsSuccessful)
            {
                return response.Data.TimeZoneId;
            }
            else
            {
                // If the API call fails, fallback to a default time zone
                return "UTC"; // or any other suitable default
            }
        }

        private class TimeZoneResponse
        {
            public string TimeZoneId { get; set; }
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
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
