using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public abstract class Payment
    {
        public DateTime TransactionDate { get; }
        public String Transactionid { get; set; }

        public double Amount { get; set; }
        public Payment(double amount)
        {
            TransactionDate = DateTime.Now;
            Amount = amount;
        }

        public abstract bool ProcessPayment();
       
    }
}
