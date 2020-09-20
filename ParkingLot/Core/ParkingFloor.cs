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

        private int _carSpotsCount;
        private int _largeSpotsCount;
        private int _motorBikeSpotsCount;
        private int _handicappedSpotsCount;


        public ParkingFloor(string Identifier)
        {

        }

        public void AddParkingSpot(ParkingSpotType type, string identifier)
        {            
            if (type == ParkingSpotType.Car) {
                var spot = new ParkingSpot(ParkingSpotType.Car, identifier);
                _carSpots.Add(identifier, spot);
                _availableCarSpots.Add(identifier, spot);
            }   
            else if(type == ParkingSpotType.Large) {
                var spot = new ParkingSpot(ParkingSpotType.Large, identifier);
                _LargeSpots.Add(identifier, spot);
                _availableLargeSpots.Add(identifier, spot);
            }                
            else if(type == ParkingSpotType.MotorBike) {
                var spot = new ParkingSpot(ParkingSpotType.MotorBike, identifier);
                _motorBikeSpots.Add(identifier, spot);
                _availableMotorBikeSpots.Add(identifier, spot);
            }                
            else if (type == ParkingSpotType.HandiCapped) {
                var spot = new ParkingSpot(ParkingSpotType.HandiCapped, identifier);
                _handicappedSpots.Add(identifier, spot);
                _availableHandicappedSpots.Add(identifier, spot);
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

            message = (_availableCarSpots.Keys.Count <= 0)?  message + "Car Spots are Full" : $"Available Car Spot{_availableCarSpots[_availableCarSpots.Keys.FirstOrDefault<string>()]}";
            message = (_availableLargeSpots.Keys.Count <= 0) ? message + "Large Spots are Full" : $"Available Large Spot{_availableLargeSpots[_availableLargeSpots.Keys.FirstOrDefault<string>()]}";
            message = (_availableMotorBikeSpots.Keys.Count <= 0) ? message + "Motorbike Spots are Full" : $"Available Motorbike Spot{_availableMotorBikeSpots[_availableMotorBikeSpots.Keys.FirstOrDefault<string>()]}";
            message = (_availableHandicappedSpots.Keys.Count <= 0) ? message + "Handicap Spots are Full" : $"Available Handicap Spot{_availableHandicappedSpots[_availableHandicappedSpots.Keys.FirstOrDefault<string>()]}";

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


    }
}
