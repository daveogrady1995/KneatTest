using KneatSoftwareTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipsCalc.Test
{
    [TestFixture]
    public class ProgramTests
    {
        public StarshipsDistanceCalc calc = new StarshipsDistanceCalc();

        // Test 1 - consume API and expect it to return collection of starships
        [TestCase]
        public void RetrieveShipsFromAPI_ReturnsCollectionOfShips()
        {
            List<Starship> starShips = new List<Starship>();

            starShips = calc.RetrieveShipsFromAPI();

            Assert.NotNull(starShips);
        }

        // Test 2 - expect the ships to make 0 stops if they have enough fuel
        [TestCase]
        public void RetrieveShipsFromAPI_ExpectShipToMakeZeroStops()
        {
            double expected = 0;
            Starship starship = new Starship("TestStarship", 1000);
            double actual = starship.CalcTripStops(500);
            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
