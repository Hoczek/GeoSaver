using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeoSave.Data
{
    public class GeolocalizationData
    {
        public string IpAdress { get; set; }
        public string URL { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public GeolocalizationData()
        {
            
        }
        public GeolocalizationData(
            string ipAdress,
            string uRL, 
            string country, 
            string city, 
            string zipCode,
            double latitude,
            double longitude)
        {
            IpAdress = ipAdress;
            URL = uRL;
            Country = country;
            City = city;
            ZipCode = zipCode;
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}
