using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Net;



namespace WeatherDisplayProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string city;
            city = txtCity.Text;

            var uri = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&mode=xml&appid=18e45e3c316106ddd1654970d4ae5cbc", city);

            XDocument doc = XDocument.Load(uri);
            WebClient client = new WebClient();

            //string maxTemp = (string)doc.Descendants("temperature").FirstOrDefault();
            string maxTemp=(string)doc.Descendants("temperature").FirstOrDefault().Attribute("max").Value;
            string minTemp = (string)doc.Descendants("temperature").FirstOrDefault().Attribute("min").Value;
            string weatherType = (string)doc.Descendants("weather").FirstOrDefault().Attribute("value").Value;
            string country = (string)doc.Descendants("country").FirstOrDefault();


            txtMaxTemp.Text = maxTemp;
            txtMinTemp.Text = minTemp;
            txtWeather.Text=weatherType;
            txtCountry.Text = country;

        }
    }
}
