using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoSave.Model;
using System.Security.Policy;
using GeoSave.Data;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection.Emit;

namespace GeoTest.Saver
{
    internal class MSSql
    {
        [Test]
        public void Pass()
        {
            var options = new DbContextOptionsBuilder<MSsqlContext>()
                .UseInMemoryDatabase(databaseName: "Geo")
                .Options;
            using(var context = new MSsqlContext(options))
            {
                var saver = new GeoSave.Saver.MSSql();
                saver.Initialize(context);

                var data = new GeolocalizationData()
                {
                    IpAdress = "",
                    URL = "",
                    Country = "",
                    City = "",
                    ZipCode = "",
                    Latitude = 0.00,
                    Longitude = 0.00
                };

                saver.Save(data, out string mess);
                Assert.AreEqual(1, context.Geolocalizations.Count());
            }
        }
    }
}
