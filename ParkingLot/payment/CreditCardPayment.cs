using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class CreditCardPayment:Payment
    {
        private string _creditNo;
        private string _name;
        public CreditCardPayment(string creditCardNumber,string name,Double amount):base(amount)
        {
            _creditNo = creditCardNumber;
            _name = name;
        }
        public override bool ProcessPayment()
        {
            return true;
        }
    }
}
