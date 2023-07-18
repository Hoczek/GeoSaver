using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoSave.Model
{
    public class Geolocalization
    {
        public Guid ID { get; set; }
        public string IpAdress { get; set; }
        public string URL { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
