﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Vehicle
    {
        public string PlateNo { get; }
        public VehicleType VehicleType { get; }
        
        public Vehicle(string plateNo, VehicleType type)
        {
            PlateNo = plateNo;
            VehicleType = type;
        }        
        
    }
}
