using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
    }
    public class RaceMotorcycle : Motorcycle
    {
        public override double FuelConsumption { get { return 8; } }
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
    public class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
}
