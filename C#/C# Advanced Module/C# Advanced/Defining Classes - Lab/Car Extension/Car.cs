using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    class Car
    {
        string make;
        string model;
        int year;
        double fuelQuantity;
        double fuelConsumption;
        double drive;

        public string Make
        { 
        get { return make; }
        set { make = value; }
        }
        public string Model
        { 
        get { return model; }
        set { model = value; }
        }
        public int Year
        { 
        get { return year; }
        set { year = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public double Drive
        {
            get { return drive; }
            set { drive = value; }
        }
    }
}
