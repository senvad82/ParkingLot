using System;
using System.ComponentModel;
using System.Dynamic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Setup Parking Lot.
            ParkingLot lot = new ParkingLot("ParkingLot1", "ParkingLot1Name");

            var attendent = new ParkingAttendantUser(new Person(), "attendent", "pwd");
            //Add Floors
            var floor1 = new ParkingFloor("floor1");
            //Add Spots
            var spot1 = new ParkingSpot(ParkingSpotType.Car, "C1");
            var spot2 = new ParkingSpot(ParkingSpotType.Car, "C2");
            var spot3 = new ParkingSpot(ParkingSpotType.Car, "C3");
            floor1.AddParkingSpot(spot1);
            floor1.AddParkingSpot(spot2);
            floor1.AddParkingSpot(spot3);

            //Add Customer Info Portal
            var infoPortal = new ParkingFloorCustomerInfoPanel("InfoPortal1");
            floor1.AddCustomerInfoPortal(infoPortal);

            var display = new ParkingFloorDisplay("Display1");
            floor1.AddFloorDisplay(display);

            var display2 = new ParkingGarageDisplay("Display2");
            lot.AddDisplay(display2);

            lot.AddParkingFloors(floor1);

            //Add Entrance and Exits

            var entrance = new ParkingLotEntry("Entry1");
            var exit = new ParkingLotExit("Exit1");
            lot.AddEntrance(entrance);
            lot.AddExit(exit);           
            

            //Create Vehicle
            var vehicle = new Vehicle("UASF80", VehicleType.Car);

        
            var ticket = entrance.GetParkingTicket(vehicle);
            Console.WriteLine(ticket._issueDateTime);
            Console.WriteLine(ticket.Status);
            Console.WriteLine(ticket.Vehicle.PlateNo);
            Console.WriteLine(display.ShowMessage());

            var amount = exit.GetParkingFee(ticket);
            var payment = new CashPayment(amount);
            exit.ProcessPayment(ticket, payment);
            Console.WriteLine(amount);
            Console.WriteLine(ticket._issueDateTime);
            Console.WriteLine(ticket.Status);
            Console.WriteLine(ticket.Vehicle.PlateNo);

            Console.WriteLine(display.ShowMessage());

            Console.WriteLine(display2.ShowMessage());


        }

    }
}
