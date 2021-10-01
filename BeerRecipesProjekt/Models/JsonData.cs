using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BeerRecipesProjekt.Models
{
    [Keyless]
    public class Ingredients
    {
        public Malt _Malt { get; set; }
        public Hops _Hops { get; set; }

        public Ingredients()
        {
            malt = new List<Malt>();
            hops = new List<Hops>();
        }
        public List<Malt> malt { get; set; }
        public List<Hops> hops { get; set; }

        public class Malt
        {
            public string name { get; set; }

        }
        public class Hops
        {
            public string name { get; set; }
        }

    }

    public class JsonData
    {
        public List<JsonData> Liste { get; set; }

        public int id { get; set; }

        public string name { get; set; }
        public string tagline { get; set; }
        public string description { get; set; }

        public Ingredients ingredients { get; set; }
        public string[] food_pairing { get; set; }

        public static List<JsonData> GetJsonData(string url)
        {
            string str = APIProcess(url);
            List<JsonData> list = JsonSerializer.Deserialize<List<JsonData>>(str);

            return list;

        }

        static dynamic APIProcess(string url)
        {
            var webRequest = WebRequest.Create(string.Format(@"{0}", url));

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                return reader.ReadToEnd();
            }

        }

    }

}
