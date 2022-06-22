using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace BL1
{
    public class WeatherAPI
    {
        public static async Task<RootObject> WeatherForecastAsync(double Userlat, double Userlon)
        {
            string url = "https://api.openweathermap.org/data/2.5/onecall";

            var httpClient = new HttpClient();

            // Do the actual request and await the response
            var httpResponse = httpClient.GetAsync(url + "?lat=" + Userlat + "&lon=" + Userlon + "&units=" + "metric" + "&lang=" + "he" + "&appid=" + "e79be6c318fa055dd47de69b0db2cab9" );

            // If the response contains content we want to read it!
            if (httpResponse.Result.Content != null)
            {
                var result = await httpResponse.Result.Content.ReadAsStringAsync();

                var serializer = new DataContractJsonSerializer(typeof(RootObject));

                
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));

                var data = (RootObject)serializer.ReadObject(ms);
                return data;

                //var responseContent = httpResponse.Result.Content.ReadAsFormDataAsync();
                //var t = responseContent.Result.Get(0);
                // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                //= JsonConvert.DeserializeObject<>(string json);
                //var t =JsonConvert.DeserializeObject<String>(responseContent.Result);
                //var jarray = JsonConvert.DeserializeObject<List<WeatherApi>>(responseContent.Result);
                //foreach(object item in jarray)             
            }
            else
            {
                return null;
            }
        }
        public class Coord
        {
            [DataMember]
            public double lon { get; set; }
            [DataMember]
            public double lat { get; set; }
        }

        [DataContract]
        public class Weather
        {
            [DataMember]
            public double id { get; set; }
            [DataMember]
            public string main { get; set; }
            [DataMember]
            public string description { get; set; }
            [DataMember]
            public string icon { get; set; }
        }

        [DataContract]
        public class Main
        {
            [DataMember]
            public double temp { get; set; }
            [DataMember]
            public double pressure { get; set; }
            [DataMember]
            public double humidity { get; set; }
            [DataMember]
            public double temp_min { get; set; }
            [DataMember]
            public double temp_max { get; set; }
        }

        [DataContract]
        public class Wind
        {
            [DataMember]
            public double speed { get; set; }
            [DataMember]
            public double deg { get; set; }
        }

        [DataContract]
        public class Clouds
        {
            [DataMember]
            public double all { get; set; }
        }

        [DataContract]
        public class Sys
        {
            [DataMember]
            public double type { get; set; }
            [DataMember]
            public double id { get; set; }
            [DataMember]
            public double message { get; set; }
            [DataMember]
            public string country { get; set; }
            [DataMember]
            public double sunrise { get; set; }
            [DataMember]
            public double sunset { get; set; }
        }

        [DataContract]
        public class RootObject
        {
            [DataMember]
            public Coord coord { get; set; }
            [DataMember]
            public List<Weather> weather { get; set; }
            [DataMember]
            public string @base { get; set; }
            [DataMember]
            public Main main { get; set; }
            [DataMember]
            public Wind wind { get; set; }
            [DataMember]
            public Clouds clouds { get; set; }
            [DataMember]
            public double dt { get; set; }
            [DataMember]
            public Sys sys { get; set; }
            [DataMember]
            public double id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public double cod { get; set; }
        }

         
                
                
            
    }
}
