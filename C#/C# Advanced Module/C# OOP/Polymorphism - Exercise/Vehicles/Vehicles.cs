namespace Vehicles
{
    using System;
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }
        public override void Drive(double distance)
        {
            double fuelneed = distance * (FuelConsumption + 1.6);
            if (FuelQuantity >= fuelneed)
            {
                FuelQuantity -= fuelneed;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }
        public override void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }
    }
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }
        public override void Drive(double distance)
        {
            double duelneed = distance * (FuelConsumption + 0.9);
            if (FuelQuantity >= duelneed)
            {
                FuelQuantity -= duelneed;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }
        public override void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
