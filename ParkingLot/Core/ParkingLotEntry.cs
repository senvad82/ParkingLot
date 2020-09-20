using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingLotEntry
    {
        private string _id;
        private string _name;
        private ParkingLot _lot;
        public ParkingLotEntry(string name, ParkingLot lot)
        {
            _name = name;
            _lot = lot;
        }

        public ParkingTicket GetParkingTicket(Vehicle vehicle)
        {
            return _lot.GetParkingTicket(vehicle);
        }
    }
}
