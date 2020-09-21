using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingFloorDisplay:ParkingDisplayBase
    {
        public ParkingFloor floor { get; set; }
        public ParkingFloorDisplay(string name):base(name)
        {

        }
        
        public override string ShowMessage()
        {
            return floor.ParkingFloorDisplayMessage();
        }
        
    }
}
