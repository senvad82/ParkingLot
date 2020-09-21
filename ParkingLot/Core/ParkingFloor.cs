using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingFloor
    {
        public string Identifier { get; }
        //public Dictionary<string, ParkingSpot> _allParkingSpots { get; set; }
        private Dictionary<string, ParkingSpot> _carSpots;
        private Dictionary<string, ParkingSpot> _LargeSpots;
        private Dictionary<string, ParkingSpot> _motorBikeSpots;
        private Dictionary<string, ParkingSpot> _handicappedSpots;

        private Dictionary<string, ParkingSpot> _availableCarSpots;
        private Dictionary<string, ParkingSpot> _availableLargeSpots;
        private Dictionary<string, ParkingSpot> _availableMotorBikeSpots;
        private Dictionary<string, ParkingSpot> _availableHandicappedSpots;

        private Dictionary<string, ParkingFloorCustomerInfoPanel> _customerInfoPortals;

        private Dictionary<string, ParkingFloorDisplay> _floorDisplay;

        private ParkingFloorDisplay _display;

        private int _carSpotsCount;
        private int _largeSpotsCount;
        private int _motorBikeSpotsCount;
        private int _handicappedSpotsCount;

        //private ParkingLot _lot;

        public ParkingFloor(string identifier)
        {
            Identifier = identifier;
            _carSpots = new Dictionary<string, ParkingSpot>();
            _LargeSpots = new Dictionary<string, ParkingSpot>();
            _motorBikeSpots = new Dictionary<string, ParkingSpot>();
            _handicappedSpots = new Dictionary<string, ParkingSpot>();

            _availableCarSpots = new Dictionary<string, ParkingSpot>();
            _availableLargeSpots = new Dictionary<string, ParkingSpot>();
            _availableMotorBikeSpots = new Dictionary<string, ParkingSpot>();
            _availableHandicappedSpots = new Dictionary<string, ParkingSpot>();

            _customerInfoPortals = new Dictionary<string, ParkingFloorCustomerInfoPanel>();

            _floorDisplay = new Dictionary<string, ParkingFloorDisplay>();
            // _lot = lot;
        }

        public void AddParkingSpot(ParkingSpotType type, string identifier)
        {            
            if (type == ParkingSpotType.Car) {
                var spot = new ParkingSpot(ParkingSpotType.Car, identifier);
                spot.Floor = this;
                _carSpots.Add(identifier, spot);
                _availableCarSpots.Add(identifier, spot);
            }   
            else if(type == ParkingSpotType.Large) {
                var spot = new ParkingSpot(ParkingSpotType.Large, identifier);
                spot.Floor = this;
                _LargeSpots.Add(identifier, spot);
                _availableLargeSpots.Add(identifier, spot);
            }                
            else if(type == ParkingSpotType.MotorBike) {
                var spot = new ParkingSpot(ParkingSpotType.MotorBike, identifier);
                spot.Floor = this;
                _motorBikeSpots.Add(identifier, spot);
                _availableMotorBikeSpots.Add(identifier, spot);
            }                
            else if (type == ParkingSpotType.HandiCapped) {
                var spot = new ParkingSpot(ParkingSpotType.HandiCapped, identifier);
                spot.Floor = this;
                _handicappedSpots.Add(identifier, spot);
                _availableHandicappedSpots.Add(identifier, spot);
            }
               
        }

        public void AddParkingSpot(ParkingSpot spot)
        {
            spot.Floor = this;
            if (spot.Type == ParkingSpotType.Car)
            {spot.Floor = this;
                _carSpots.Add(spot.Identifier, spot);
                _availableCarSpots.Add(spot.Identifier, spot);
            }
            else if (spot.Type == ParkingSpotType.Large)
            {
                _LargeSpots.Add(spot.Identifier, spot);
                _availableLargeSpots.Add(spot.Identifier, spot);
               
            }
            else if (spot.Type == ParkingSpotType.MotorBike)
            {
                _motorBikeSpots.Add(spot.Identifier, spot);
                _availableMotorBikeSpots.Add(spot.Identifier, spot);              
            }
            else if (spot.Type == ParkingSpotType.HandiCapped)
            {
                _handicappedSpots.Add(spot.Identifier, spot);
                _availableHandicappedSpots.Add(spot.Identifier, spot);
            }

        }

        public void RemoveParkingSpot(ParkingSpot spot)
        {            
            if (spot.Type == ParkingSpotType.Car) { 
                _carSpots.Remove(spot.Identifier);
                _availableCarSpots.Remove(spot.Identifier);
            }                
            else if (spot.Type == ParkingSpotType.Large) { 
                _LargeSpots.Remove(spot.Identifier);
                _availableLargeSpots.Remove(spot.Identifier);
            }                
            else if (spot.Type == ParkingSpotType.MotorBike) { 
                _motorBikeSpots.Remove(spot.Identifier);
               _availableMotorBikeSpots.Remove(spot.Identifier);
            }                
            else if (spot.Type == ParkingSpotType.HandiCapped) { 
                _handicappedSpots.Remove(spot.Identifier);
                _availableHandicappedSpots.Remove(spot.Identifier);
            }               
        }

        public void AssignSpot(ParkingSpot spot, Vehicle vehicle)
        {
            if(vehicle.VehicleType==VehicleType.Car && spot.Type == ParkingSpotType.Car && spot.Reserved==false)
            {
                spot.ReserveSpot(vehicle);
                _carSpotsCount++;
                _availableCarSpots.Remove(spot.Identifier);
            }
            else if(vehicle.VehicleType == VehicleType.Large && spot.Type == ParkingSpotType.Large && spot.Reserved == false)
            {
                 spot.ReserveSpot(vehicle);
                _largeSpotsCount++;
                _availableLargeSpots.Remove(spot.Identifier);
            }
            else if (vehicle.VehicleType == VehicleType.MotorBike && spot.Type == ParkingSpotType.MotorBike && spot.Reserved == false)
            {
                 spot.ReserveSpot(vehicle);
                _motorBikeSpotsCount++;
                _availableMotorBikeSpots.Remove(spot.Identifier);
            }
            else if (vehicle.VehicleType == VehicleType.Car && spot.Type == ParkingSpotType.HandiCapped && spot.Reserved == false)
            {
                 spot.ReserveSpot(vehicle);
                _handicappedSpotsCount++;
                _availableHandicappedSpots.Remove(spot.Identifier);
            }

        }

        public void ReleseSpot(ParkingSpot spot)
        {
            if (spot.Type == ParkingSpotType.Car)
            {
                spot.ReleaseSpot();
                _carSpotsCount--;
                _availableCarSpots.Add(spot.Identifier, spot);
            }
            else if (spot.Type == ParkingSpotType.Large)
            {
                spot.ReleaseSpot();
                _largeSpotsCount--;
                _availableLargeSpots.Add(spot.Identifier, spot);
            }
            else if (spot.Type == ParkingSpotType.MotorBike)
            {
                spot.ReleaseSpot();
                _motorBikeSpotsCount--;
                _availableMotorBikeSpots.Add(spot.Identifier, spot);
            }
            else if (spot.Type == ParkingSpotType.HandiCapped)
            {
                spot.ReleaseSpot();
                _handicappedSpotsCount--;
                _availableHandicappedSpots.Add(spot.Identifier, spot);
            }

        }

        public ParkingSpot GetParkingSpot(Vehicle vehicle)
        {

            if (vehicle.VehicleType == VehicleType.Car)
            {                
                return _availableCarSpots[_availableCarSpots.Keys.FirstOrDefault<string>()];
            }
            else if (vehicle.VehicleType == VehicleType.Large)
            {
                return _availableLargeSpots[_availableLargeSpots.Keys.FirstOrDefault<string>()];
            }
            else if (vehicle.VehicleType == VehicleType.MotorBike )
            {
                return _availableMotorBikeSpots[_availableMotorBikeSpots.Keys.FirstOrDefault<string>()];
            }
            else if (vehicle.VehicleType == VehicleType.Car)
            {
                return _availableHandicappedSpots[_availableHandicappedSpots.Keys.FirstOrDefault<string>()];
            }

            return null;

        }

        public string ParkingFloorDisplayMessage()
        {
            var message = string.Empty;

            message = (_availableCarSpots.Keys.Count <= 0)?  message + "Car Spots are Full\n" : $"Available Car Spot{_availableCarSpots.Keys.FirstOrDefault<string>()}\n";
            message = (_availableLargeSpots.Keys.Count <= 0) ? message + "Large Spots are Full\n" : $"Available Large Spot{_availableLargeSpots.Keys.FirstOrDefault<string>()}\n";
            message = (_availableMotorBikeSpots.Keys.Count <= 0) ? message + "Motorbike Spots are Full\n" : $"Available Motorbike Spot{_availableMotorBikeSpots.Keys.FirstOrDefault<string>()}\n";
            message = (_availableHandicappedSpots.Keys.Count <= 0) ? message + "Handicap Spots are Full\n" : $"Available Handicap Spot{_availableHandicappedSpots.Keys.FirstOrDefault<string>()}";

            return message;
        }
        
        public bool IsSpotAvailable(Vehicle vehicle)
        {
            if (vehicle.VehicleType == VehicleType.Car && _availableCarSpots.Keys.Count> 0)
            {
                return true;
            }
            else if (vehicle.VehicleType == VehicleType.Large && _availableLargeSpots.Keys.Count > 0)
            {
                return true;
            }
            else if (vehicle.VehicleType == VehicleType.MotorBike && _availableMotorBikeSpots.Keys.Count > 0)
            {
                return true;
            }
            else if (vehicle.VehicleType == VehicleType.Car && _availableHandicappedSpots.Keys.Count > 0)
            {
                return true;
            }

            return false;

        }

        public bool IsFull()
        {
            return (_availableCarSpots.Count == 0 && _availableLargeSpots.Count == 0 && _availableHandicappedSpots.Count == 0 && _availableMotorBikeSpots.Count == 0) ? true : false;
        }

        public void AddCustomerInfoPortal(ParkingFloorCustomerInfoPanel portal)
        {
            portal.floor = this;
            _customerInfoPortals.Add(portal.Identifier, portal);
        }

        public void AddFloorDisplay(ParkingFloorDisplay display)
        {
            display.floor = this;
            _floorDisplay.Add(display.Identifier, display);
        }


    }
}
