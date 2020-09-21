using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public abstract class ParkingLotKioskBase
    {
        public string Identifier { get; }        
        public ParkingLot Lot { get; set; }
        public ParkingLotKioskBase(string name)
        {
            Identifier = name;           
        }
      
    }
}
