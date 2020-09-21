using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingSpot
    {
        public string Identifier { get; }
        public Vehicle Vehicle { get; set; }
        public ParkingSpotType Type { get; set; }

        public bool Reserved { get; set; }

        public ParkingFloor Floor {get; set;}
        public ParkingSpot(ParkingSpotType type, string identifier)
        {
            Type = type;
            Identifier = identifier;
        }

        public void ReserveSpot(Vehicle vehicle)
        {
            Vehicle = vehicle;
            Reserved = true;            
        }

        public void ReleaseSpot()
        {
            Vehicle = null;
            Reserved = false;
        }

    }
}
