using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace FetchFromAPI
{
    public class Model
    {
        public string country { get; set; }
        public List<string> web_pages { get; set; }
        public string alpha_two_code { get; set; }
        public string name { get; set; }

        [JsonProperty("state-province")]
        public object StateProvince { get; set; }
        public List<string> domains { get; set; }

        [JsonIgnore]
        public Command TapCommand { get; set; }

        public Model()
        {
            TapCommand = new Command(OnTapped);
        }

        private async void OnTapped(object obj)
        {
            var canOpen = await Launcher.TryOpenAsync(new System.Uri(obj.ToString()));
            if (!canOpen)
                await App.Current.MainPage.DisplayAlert("Oops!", "Cannot open browser!", "OK");
        }
    }
}
