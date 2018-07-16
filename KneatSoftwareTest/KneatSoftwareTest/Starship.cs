using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneatSoftwareTest
{
    public class Starship
    {
        // private data members
        private string _StarshipName;
        private double _ShipFuelMGLT;

        // public data members
        public string StarshipName { get { return _StarshipName; } set { _StarshipName = value; } }
        public double ShipFuelMGLT { get { return _ShipFuelMGLT; } set { _ShipFuelMGLT = value; } }

        public Starship(string starshipName, double shipFuelMGLT)
        {
            StarshipName = starshipName;
            ShipFuelMGLT = shipFuelMGLT;
        }

        public double CalcTripStops(double distanceMGLT)
        {
            // do the calulation
            return (distanceMGLT / ShipFuelMGLT) - 1;
        }
    }
}
