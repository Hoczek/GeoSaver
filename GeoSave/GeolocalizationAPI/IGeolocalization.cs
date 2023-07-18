using GeoSave.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoSave.GeolocalizationAPI
{
    interface IGeolocalization
    {
        public GeolocalizationData GetGeolocalizeByUrl(string URL);
        public GeolocalizationData GetGeolocalizeByIP4(string IP4);
        public GeolocalizationData GetGeolocalizeByIP6(string IP6);
    }
}
