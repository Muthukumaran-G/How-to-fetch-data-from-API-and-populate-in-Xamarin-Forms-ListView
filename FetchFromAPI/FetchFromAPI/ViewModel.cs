using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace FetchFromAPI
{
    public class ViewModel
    {
        public List<Model> Items { get; set; }
        public ViewModel()
        {
            var taskString = new HttpClient().GetStringAsync(new Uri("http://universities.hipolabs.com/search?country=United+States"));
            var modelList = JsonConvert.DeserializeObject<List<Model>>(taskString.Result);
            Items = modelList.ToList();
        }
    }
}
