using System;
using System.Collections.Generic;
using System.Text;

namespace _01E_Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override void Drive(double distance)
        {
            double fuelNeed = distance * (FuelConsumption + 0.9);

            if (FuelQuantity >= fuelNeed)
            {
                FuelQuantity -= fuelNeed;

                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }
    }
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override void Drive(double distance)
        {
            double fuelNeed = distance * (FuelConsumption + 1.4);
            CalculateQuantity(distance, fuelNeed);
        }

        public void DriveEmpty(double distance)
        {
            double fuelNeed = distance * FuelConsumption;
            CalculateQuantity(distance, fuelNeed);
        }

        private void CalculateQuantity(double distance, double fuelNeed)
        {
            if (FuelQuantity >= fuelNeed)
            {
                FuelQuantity -= fuelNeed;

                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
    }
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override void Drive(double distance)
        {
            double fuelNeed = distance * (FuelConsumption + 1.6);

            if (FuelQuantity >= fuelNeed)
            {
                FuelQuantity -= fuelNeed;

                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else
            {
                if (liters > TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    FuelQuantity += liters * 0.95;
                }
            }
        }
    }


}
