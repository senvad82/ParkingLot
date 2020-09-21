using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingGarageDisplay:ParkingDisplayBase
    {        
        public ParkingGarageDisplay(string name):base(name)
        {

        }
        
        public override string ShowMessage()
        {
            return Lot.IsFull() ? $"Parking Spots are Full" : "Parking Spots are Available";
        }
        
        
    }
}
