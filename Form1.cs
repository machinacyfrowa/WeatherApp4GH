using Newtonsoft.Json;

namespace WeatherApp4GH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //stwórz nowego klienta HTTP
            HttpClient client = new HttpClient();
            //zdefiniuj adres api wraz z parametrami
            string url = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,relative_humidity_2m,weather_code,surface_pressure,wind_speed_10m&forecast_days=1";
            //œci¹gnij dane z serwera
            //u¿ywamy .Result wiêc program poczeka w tym miejscu na odpowiedŸ serwera
            HttpResponseMessage response = client.GetAsync(url).Result;
            //przeczytaj faktyczn¹ treœæ odpowiedzi do zmiennej json jako string
            string json = response.Content.ReadAsStringAsync().Result;
            //wyœwietl json w polu tekstowym
            richTextBox1.Text = json;
            //deserializuj json do obiektu
            APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(json);
            //wyœwietl temperaturê w polu tekstowym
            temperatureTextBox.Text = apiResponse.current.temperature_2m.ToString();
            //dodaj spacjê
            temperatureTextBox.Text += " ";
            //dopisz jednostki
            temperatureTextBox.Text += apiResponse.current_units.temperature_2m;
        }
    }
}
