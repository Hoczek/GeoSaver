using GeoSave.Model;
using GeoSave.Sacer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using GeoSave.Data;

namespace GeoSave.Saver
{
    public class MSSql : ISaver
    {
        MSsqlContext _context { get; set; }
        public MSSql()
        {

        }

        public void Initialize()
        {
            _context = new MSsqlContext();
        }
        public void Initialize(MSsqlContext context)
        {
            _context = context;
        }

        public bool Save(GeolocalizationData data, out string message)
        {
            message = "";
            Geolocalization record = new Geolocalization()
            {
                ID = new Guid(),
                IpAdress = data.IpAdress,
                URL = data.URL,
                Country = data.Country,
                City = data.City,
                ZipCode = data.ZipCode,
                Latitude = data.Latitude,
                Longitude = data.Longitude
            };
            _context.Geolocalizations.Add(record);
            _context.SaveChanges();
            return true;
        }
    }
}
