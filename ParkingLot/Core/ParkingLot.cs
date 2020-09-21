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

        public Dictionary<string, ParkingLotEntry> ParkingEntries { get; }

        public Dictionary<string, ParkingLotExit> ParkingExits { get; }

        public Dictionary<string, ParkingGarageDisplay> ParkingDisplay { get; }

        public ParkingLot(string id, string name)
        {
            _id = id;
            _name = name;
            ParkingFloors = new Dictionary<string, ParkingFloor>();
            ParkingEntries = new Dictionary<string, ParkingLotEntry>();
            ParkingExits = new Dictionary<string, ParkingLotExit>();
            ParkingDisplay = new Dictionary<string, ParkingGarageDisplay>();

        }

        public ParkingTicket GetParkingTicket(Vehicle vehicle)
        {
            var ticket = new ParkingTicket(vehicle);
            var spot = FindParkingSpotInAnyFloors(vehicle);
            ticket.Spot = spot;
            spot.Floor.AssignSpot(spot,vehicle);
            ticket.Save();
            return ticket;
        }

        public void ReleaseSpot(ParkingSpot spot)
        {
            spot.Floor.ReleseSpot(spot);
            
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

        public void AddEntrance(ParkingLotEntry entry)
        {
            entry.Lot = this;
            ParkingEntries.Add(entry.Identifier, entry);
        }

        public void RemoveEntrance(string name)
        {
            ParkingEntries.Remove(name);
        }

        public void AddDisplay(ParkingGarageDisplay display)
        {
            display.Lot = this;
            ParkingDisplay.Add(display.Identifier, display);
        }
        

        public void AddExit(ParkingLotExit exit)
        {
            exit.Lot = this;
            ParkingExits.Add(exit.Identifier, exit);
        }

        public void RemoveExit(string name)
        {
            ParkingExits.Remove(name);
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

        public bool IsFull()
        {
            foreach (var key in ParkingFloors.Keys)
            {
                var floor = ParkingFloors[key];
                if (!floor.IsFull()) return false;
            }
            return true;
        }


    }
}
