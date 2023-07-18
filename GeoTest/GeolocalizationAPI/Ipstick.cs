using GeoSave.GeolocalizationAPI;
using System.Windows;

namespace GeoTest.GeolocalizationAPI
{
    public class Tests
    {
        [Test]
        public void Pass()
        {
            ipstrack service = new ipstrack();
            var response = service.GetGeolocalizeByUrl("134.201.250.155");
            if (response != null)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void EmptyURL()
        {
            ipstrack service = new ipstrack();
            Assert.Throws<System.Net.WebException>(() => service.GetGeolocalizeByUrl(""), "The remote server returned an error: (403) Forbidden.");
        }
    }
}