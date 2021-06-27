using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BacheloretteClient.Models
{
    public class Bachelorette
    {
        public int BacheloretteId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public string Hometown { get; set; }
        public int Season { get; set; }

        public static List<Bachelorette> GetAll()
        {
            var getAllResult = ApiHelper.GetAll();
            var result = getAllResult.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Bachelorette> bachelorettesList =JsonConvert.DeserializeObject<List<Bachelorette>>(jsonResponse.ToString());
            return bachelorettesList;  
        }
        public static Bachelorette GetDetails(int id)
        {
          var apiCallTask = ApiHelper.Get(id);
          var result = apiCallTask.Result;

          JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
          Bachelorette thisBachelorette = JsonConvert.DeserializeObject<Bachelorette>(jsonResponse.ToString());
          return thisBachelorette;
        }
        public static void Post(Bachelorette bachelorette)
        {
          string jsonBach = JsonConvert.SerializeObject(bachelorette);
          var apiCallTask = ApiHelper.Post(jsonBach);
        }
        public static void Put(Bachelorette bachelorette)
        {
          string jsonBach = JsonConvert.SerializeObject(bachelorette);
          var apiCallTask = ApiHelper.Put(bachelorette.BacheloretteId, jsonBach);
        }
        public static void Delete(int id)
        {
          var apiCallTask = ApiHelper.Delete(id);
        }
    }
}