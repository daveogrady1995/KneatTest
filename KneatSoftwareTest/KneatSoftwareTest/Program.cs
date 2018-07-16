using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KneatSoftwareTest
{
    class Program
    {
        // list to hold starship objects
        private static List<Starship> starShips = new List<Starship>();

        static void Main(string[] args)
        {
            bool userInput = false;
            double distanceMGLT = 0;
           
            do
            {
                try
                {
                    // get user input
                    distanceMGLT = UserDistanceInput();
                    userInput = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Input");
                }

            } while (!userInput);

            // reference class to perform operations
            StarshipsDistanceCalc starshipsDistCalc = new StarshipsDistanceCalc();

            // retrieve ships from api
            starShips = starshipsDistCalc.RetrieveShipsFromAPI();

            // now output these ships along with stoppages needed
            starshipsDistCalc.DisplayShipsCalc(starShips, distanceMGLT);

   
        }

        private static double UserDistanceInput()
        {
            Console.Write("Please enter distance to travel (MGLT): ");
            double distance = Convert.ToDouble(Console.ReadLine());
            return distance;
        }

    }
}
