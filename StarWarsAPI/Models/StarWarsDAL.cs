using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StarWarsAPI.Models
{
    public class StarWarsDAL
    {

        public string GetAPIJson(string endpoint, int Id)
        {
            string url = $"https://swapi.dev/api/{endpoint}/{Id}/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert the response into something useable 
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;
        }

        public Person GetPerson(string endpoint, int Id)
        {
            string personData = GetAPIJson(endpoint, Id);
            Person p = JsonConvert.DeserializeObject<Person>(personData);
            return p;

        }
        public Planet GetPlanet(string endpoint, int Id)
        {
            string planetData = GetAPIJson(endpoint, Id);
            Planet pl = JsonConvert.DeserializeObject<Planet>(planetData);
            return pl;
        }

        public string GetAPIJson(string endpoint)
        {
            string url = $"https://swapi.dev/api/{endpoint}/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert the response into something useable 
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;
        }
        public People GetPeople()
        {
            string endpointData = GetAPIJson("people");

            return JsonConvert.DeserializeObject<People>(endpointData);
        }

      
    }
}
