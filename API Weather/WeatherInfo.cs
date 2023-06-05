using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace API_Weather
{
    public partial class WeatherInfo : Form
    {
        public WeatherInfo()
        {
            InitializeComponent();
        }

        string APIkey = "cdc61387ae140db99fd4683780fc1c69";
        private void button1_Click(object sender, EventArgs e)
        {
            getWeather();
        }

        void getWeather()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", tblCity.Text, APIkey);
                    var json = web.DownloadString(url);
                    WeatherInpo1.root Info = JsonConvert.DeserializeObject<WeatherInpo1.root>(json);

                    picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                    labCondition.Text = Info.weather[0].main;
                    labDetail.Text = Info.weather[0].description;
                    labSunrise.Text = Info.sys.sunrise.ToString();
                    labSunset.Text = Info.sys.sunset.ToString();

                    labWind.Text = Info.wind.speed.ToString();
                    labPressure.Text = Info.main.pressure.ToString();
                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
