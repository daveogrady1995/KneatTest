using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneatSoftwareTest
{
    public class StarshipsDistanceCalc
    {
        // api end point
        private const string URL = "https://swapi.co/api/starships/";

        // target 3 starships ids
        private int[] starshipIDs = { 2, 3, 9 };

        public StarshipsDistanceCalc()
        {
        }

        public List<Starship> RetrieveShipsFromAPI()
        {
            RestClient restClient = new RestClient();
            JObject json = new JObject();

            // list to hold starship objects
            List<Starship> starShips = new List<Starship>();

            // for each starship call the api and retieve json data
            for (int i = 0; i < starshipIDs.Length; i++)
            {
                // alter URL to include ID
                restClient.EndPoint = URL + starshipIDs[i];

                string strResponse = "";

                // retrieve response string from rest api
                strResponse = restClient.makeRequest();

                // parse string into JSON object
                json = JObject.Parse(strResponse);

                // now harvest the relevant data 
                string name = (string)json.SelectToken("name");
                double mglt = (double)json.SelectToken("MGLT");

                // create a new Starship object and add to list
                Starship starship = new Starship(name, mglt);

                starShips.Add(starship);
            }

            return starShips;
        }

        public void DisplayShipsCalc(List<Starship>starShips, double distance)
        {
            foreach (var ship in starShips)
            {
                Console.WriteLine("{0}: {1:F2}", ship.StarshipName, ship.CalcTripStops(distance));
            }
        }

        public int SimpleCalc(int num1, int num2)
        {
            return num1 + num2;
        }


    }
}
