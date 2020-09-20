using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingLot
    {
        private string _id;
        private string _name;
        private int _carSpotsCount;
        private int _largeSpotsCount;
        private int _motorBikeSpotsCount;
        private int _handicappedSpotsCount;
        public Dictionary<string, ParkingFloor> ParkingFloors { get; }
       
        public ParkingLot()
        {
            ParkingFloors = new Dictionary<string, ParkingFloor>();
        }

        public ParkingTicket GetParkingTicket(Vehicle vehicle)
        {
            var ticket = new ParkingTicket(vehicle);
            var spot = FindParkingSpotInAnyFloors(vehicle);
            spot.ReserveSpot(vehicle);
            ticket.Save();
            return ticket;
        }

        private ParkingSpot FindParkingSpotInAnyFloors(Vehicle vehicle)
        {
            foreach(var key in ParkingFloors.Keys)
            {
                var floor = ParkingFloors[key];
                if(floor.IsSpotAvailable(vehicle)) return floor.GetParkingSpot(vehicle);
            }
            return null;
        }

        

        public void AddParkingFloors(ParkingFloor floor)
        {
            ParkingFloors.Add(floor.Identifier, floor);
        }

        public void RemoveParkingFloors(ParkingFloor floor)
        {
            ParkingFloors.Remove(floor.Identifier);
        }

        public Dictionary<int,double> GetParkingRates()
        {
            //return from database
            var rates = new Dictionary<int, double>();
            rates.Add(1, 4);
            rates.Add(2, 3.5);
            rates.Add(0, 2.5);//rest of hours
            return rates;
        }


    }
}
