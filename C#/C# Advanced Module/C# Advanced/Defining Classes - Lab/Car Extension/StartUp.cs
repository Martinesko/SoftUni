﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManufacturer;


    public class StartUp
    {
        static void Main() 
        
        {
            Car car = new Car();
            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 200;
        car.FuelConsumption = 200;
        car.Drive = 2000;
             

            
            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year} Fuel:{car.FuelQuantity:f2}");
        }
    }

