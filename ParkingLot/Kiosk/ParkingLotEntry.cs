using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingLotEntry
    {
        public string Identifier { get; }
        public ParkingLot Lot { get; set; }
        public ParkingLotEntry(string name)
        {
            Identifier = name;          
        }

        public ParkingTicket GetParkingTicket(Vehicle vehicle)
        {
            return Lot.GetParkingTicket(vehicle);
        }
    }
}
