using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.APICaller;

namespace Utils.APICaller.Test
{
    public class Support
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
