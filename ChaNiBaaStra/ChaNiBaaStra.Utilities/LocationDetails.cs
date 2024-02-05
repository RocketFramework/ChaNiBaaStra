using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.Utilities
{
    public class CountryItem
    {
        public CountryItem(string country)
        {
            this.Country = country;
        }
        public string Country { get; set; }
        public List<LocationItem> LocationList { get; set; }

        public override string ToString()
        {
            return Country;
        }
    }

    public class LocationItem
    {
        public LocationItem(string country, string city, double lat, double lon, string id)
        {
            this.Country = country;
            this.City = city;
            this.Longitude = lon;
            this.Id = id;
            this.Latitude = lat;
        }
        public string Country { get; set; }
        public string City { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Id { get; set; }
    }

    public class LocationDetails
    {
        //worldcities.csv
        public List<CountryItem> Countries { get; set; }
        public List<LocationItem> GetCities(string country)
        {
            return Countries?.Where(x=>x.Country == country).FirstOrDefault().LocationList;
        }

        public void Load()
        {
            //city,city_ascii,lat,lng,country,iso2,iso3,
            //admin_name,capital,population,id
            string filePath = @".\worldcities.csv";
            StreamReader reader = null;
            Countries = new List<CountryItem>();
            if (File.Exists(filePath))
            {
                reader = new StreamReader(File.OpenRead(filePath));
                List<string> listA = new List<string>();
                int i = 1;
                while (!reader.EndOfStream)
                {
                    try
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        LocationItem lItem = new LocationItem(values[4]
                            , values[0], Convert.ToDouble(values[2])
                            , Convert.ToDouble(values[3]), values[2] + "|" + values[3]);
                        CountryItem cItem = Countries
                            .Where(x => x.Country == lItem.Country)
                            .FirstOrDefault();
                        if (cItem == null)
                        {
                            cItem = new CountryItem(lItem.Country);
                            cItem.LocationList = new List<LocationItem>();
                            cItem.LocationList.Add(lItem);
                            Countries.Add(cItem);
                        }
                        else
                            cItem.LocationList.Add(lItem);
                    }
                    catch (Exception ex) { }
                }
            }
        }
    }
}
