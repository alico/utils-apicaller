using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.APICaller;

namespace Utils.APICaller.Test
{
    public class UserRequestModel
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Job")]
        public string Job { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
