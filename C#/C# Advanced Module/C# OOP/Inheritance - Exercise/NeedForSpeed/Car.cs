using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower , int fuel) : base(horsePower , fuel)
        {
        }
        public override double FuelConsumption { get { return 3; } }
    }
    public class FamilyCar: Car
    {
        public FamilyCar(int horsePower, int fuel) : base(horsePower, fuel)
        {
        }
    }
    public class SportCar: Car
    {
        public SportCar(int horsePower, int fuel) : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption { get { return 10; } }
    }

}
