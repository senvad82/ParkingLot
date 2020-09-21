using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public abstract class ParkingDisplayBase
    {
        public string Identifier { get; }
        public ParkingLot Lot { get; set; }

        public ParkingDisplayBase(string name)
        {
            Identifier = name;
        }

        public abstract string ShowMessage();
        
    }
}
