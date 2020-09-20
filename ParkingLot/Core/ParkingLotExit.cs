using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingLotExit
    {
        private string _id;
        private string _name;
        private ParkingLot _lot;
        public ParkingLotExit(string name, ParkingLot lot)
        {
            _name = name;
            _lot = lot;
        }

        public double GetParkingFee(ParkingTicket ticket)
        {
            var totalHours = (DateTime.Now - ticket._issueDateTime).TotalHours;
            var rates = _lot.GetParkingRates();
            var firstHourRate = rates[rates.Keys.FirstOrDefault<int>()];
            if (totalHours <= firstHourRate) return firstHourRate; // first rate hour
            Double totalAmount = 0;
            var count = 0;
            foreach (var key in rates.Keys)
            {
                if (key == 0) { // default amount after 2 hours.
                    totalAmount = totalAmount + rates[key] * (totalHours - count);
                    break;
                } 
                var currentHourRate = rates[key];
                totalAmount = totalAmount + currentHourRate;
                count++;
            }
            return totalAmount;
        }

        public bool ProcessPayment()
        {
            return true;
        }
    }
}
