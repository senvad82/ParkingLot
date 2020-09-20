using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingTicket
    {
        private string _id;
        public DateTime _issueDateTime { get; }
        public bool paid { get; }

        private Vehicle _vehicle;
        public ParkingTicket(Vehicle vehicle)
        {
            _vehicle = vehicle;
            _id = Guid.NewGuid().ToString();
            _issueDateTime = DateTime.Now;            
        }

        public void Save()
        {
            //Save Ticket Details to DB.

        }
       
        
    }
}
