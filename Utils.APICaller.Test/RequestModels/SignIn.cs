using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.APICaller;

namespace Utils.APICaller.Test
{
    public class SignIn
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
