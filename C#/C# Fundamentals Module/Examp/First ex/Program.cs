using System;
using System.Linq;
using System.Collections.Generic;

namespace First_ex_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double biscuitsPerDay = double.Parse(Console.ReadLine());
            int countOfWorkers = int.Parse(Console.ReadLine());
            int competitiveComapanyProducion = int.Parse(Console.ReadLine());
            double percentage = 0;
            double biscuitsPerMouth = 0;
            for (int i = 1; i < 31; i++)
            {
                if (i % 3 == 0)
                {
                    biscuitsPerMouth += biscuitsPerDay *countOfWorkers * 0.75;
                    
                }
                else
                {
                    biscuitsPerMouth += biscuitsPerDay* countOfWorkers;
                }
                biscuitsPerMouth =Math.Floor(biscuitsPerMouth);
            }
            Console.WriteLine($"You have produced {biscuitsPerMouth} biscuits for the past month.");
            if (biscuitsPerMouth>competitiveComapanyProducion)
            {
                percentage = (biscuitsPerMouth - competitiveComapanyProducion) / competitiveComapanyProducion * 100;                              
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                percentage = (biscuitsPerMouth - competitiveComapanyProducion) / competitiveComapanyProducion * 100;
                Console.WriteLine($"You produce {Math.Abs(percentage):f2} percent less biscuits.");
            }
            
        }
    }
}
