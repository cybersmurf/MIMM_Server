using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MimmClientBlazor.Models.MimmApi
{
    public partial class Albums
    {
        [JsonPropertyName("id")]
        public int? Id
        {
            get;
            set;
        }

        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
    }
}
