using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar , IElectricCar
    {
        public string Model { get; private set; }

        public string Color { get; private set; }

        public int Batteries { get; private set; }

        public Tesla(string model , string color , int batteries)
        {
            this.Model = model;
            this.Color = color;
            this.Batteries = batteries;
        }

        public override string ToString()
        {
            return $"{this.Color} {this.Model} with {this.Batteries} Batteries{Environment.NewLine}{Start()}{Environment.NewLine}{Stop()}";
        }
        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
    public class Seat : ICar 
    {
        public string Model { get; private set; }

        public string Color { get; private set; }

        public Seat(string model , string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public override string ToString()
        {
            return $"{this.Color} {this.Model}{Environment.NewLine}{Start()}{Environment.NewLine}{Stop()}";
        }
        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
