using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoSave.Model
{
    public class MSsqlContext : DbContext
    {
        public MSsqlContext()
        {
            
        }
        public MSsqlContext(DbContextOptions options) :base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Properties.Resources.ConnectionString);
            }

        }

        public DbSet<Geolocalization> Geolocalizations { get; set; }
    }
}
