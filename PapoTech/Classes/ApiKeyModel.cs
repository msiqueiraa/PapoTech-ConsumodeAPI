using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapoTech.Classes
{
    internal class ApiKeyModel
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        public ApiKeyModel(string key)
        {
            this.Key = key;
        }

        public string RetornaKey()
        {
            return this.Key;
        }
    }
}

   
