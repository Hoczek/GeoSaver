using GeoSave.Data;
using GeoSave.GeolocalizationAPI;
using GeoSave.Model;
using GeoSave.Sacer;
using GeoSave.Saver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeoSave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GeolocalizationData lastResult;
        ISaver _saver { get; set; }
        IGeolocalization _geolocalization { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _saver = new MSSql();
            _saver.Initialize();
            _geolocalization = new ipstrack();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lastResult = _geolocalization.GetGeolocalizeByUrl(URL.Text);
                ExceptionLabel.Content = "";
                IPLabel.Content = lastResult.IpAdress;
                UrlLabel.Content = lastResult.URL;
                CountryLabel.Content = lastResult.Country;
                CityLabel.Content = lastResult.City;
                ZipLabel.Content = lastResult.ZipCode;
                latLabel.Content = lastResult.Latitude.ToString();
                lonLabel.Content = lastResult.Longitude.ToString();
            }
            catch (Exception ex)
            {
                ExceptionLabel.Content = ex.Message;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string message;
            try
            {
                if(lastResult == null)
                {
                    ExceptionLabel.Content = "First need geolocalization";
                    return;
                }
                _saver.Save(lastResult, out message);
                ExceptionLabel.Content = "";
            }
            catch(Exception ex)
            {
                ExceptionLabel.Content = ex.Message;
            }
        }
    }
}
