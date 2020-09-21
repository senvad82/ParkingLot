using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class CashPayment : Payment
    {        
        public CashPayment(double amount) : base(amount)
        {
            

        }
        public override bool ProcessPayment()        {
           
            return true;
        }
    } 
}
