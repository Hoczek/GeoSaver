using GeoSave.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GeoSave.GeolocalizationAPI
{
    public class ipstrack : IGeolocalization
    {
        public GeolocalizationData GetGeolocalizeByIP4(string IP4)
        {
            return GeolocalizateAll(IP4);
        }

        public GeolocalizationData GetGeolocalizeByIP6(string IP6)
        {
            return GeolocalizateAll(IP6);
        }

        public GeolocalizationData GetGeolocalizeByUrl(string URL)
        {
            var data = GeolocalizateAll(URL);
            data.URL = URL;
            return data;
        }

        private GeolocalizationData GeolocalizateAll(string name)
        {
            var ipstickURL = String.Format(Properties.Resources.ipstickURL, name, Properties.Resources.ipstickKey);
            using (WebClient wc = new WebClient())
            {
                string HtmlResult = wc.UploadString(ipstickURL, "");
                var json = (JObject)JsonConvert.DeserializeObject(HtmlResult);
                string succes = (string)json.SelectToken("success");
                if(string.Equals(succes, "False"))
                {
                    throw new Exception((string)json.SelectToken("error.info"));
                }
                var data = new GeolocalizationData()
                {
                    IpAdress = (string)json.SelectToken("ip"),
                    URL = "",
                    Country = (string)json.SelectToken("country_name"),
                    City = (string)json.SelectToken("city"),
                    ZipCode = (string)json.SelectToken("zip"),
                    Latitude = double.Parse((string)json.SelectToken("latitude")),
                    Longitude = double.Parse((string)json.SelectToken("longitude"))
                };
                return data;
            }
        }
    }
}
