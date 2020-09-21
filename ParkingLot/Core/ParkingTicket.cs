using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingTicket
    {
        private string _id;
        public DateTime _issueDateTime { get; }
        public ParkingTicketStatus Status { get; set; }

        public Vehicle Vehicle { get; set; }
        public ParkingSpot Spot { get; set; }
        public ParkingTicket(Vehicle vehicle)
        {
            Vehicle = vehicle;
            _id = Guid.NewGuid().ToString();
            _issueDateTime = DateTime.Now;
            Status = ParkingTicketStatus.Issued;
        }

        public void Save()
        {
            //Save Ticket Details to DB.

        }
       
        
    }
}
