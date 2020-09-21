using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingFloorCustomerInfoPanel : ParkingLotPaymentPortalBase
    {
        public ParkingFloor floor { get; set; }
        public ParkingFloorCustomerInfoPanel(string name):base(name)
        {
           
        }

        
    }
}
