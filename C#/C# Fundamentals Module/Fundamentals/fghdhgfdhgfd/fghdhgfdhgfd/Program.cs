using System;
using System.Numerics;
namespace fghdhgfdhgfd
{
    class Program
    {
        class ITM
        {
            private double height;
            private double weight;

            public double Height
            {
                set
                {
                    if (value > 0)
                    {
                        this.height = value;
                    }
                }
                get { return this.height; }
            }
            public double Weight
            {
                set
                {
                    if (value > 0)
                    {
                        this.weight = value;
                    }
                }
                get { return this.weight; }
            }

            public double CalculateITM()
            {
                return weight / Math.Pow(height / 100, 2);
            }

            public void Output()
            {
                if (CalculateITM() < 18.5)
                {
                    Console.WriteLine("Поднормено тегло");
                }
                else if (CalculateITM() >= 18.5 && CalculateITM() <= 25)
                {
                    Console.WriteLine("Нормално тегло");
                }
                else if (CalculateITM() > 25 && CalculateITM() <= 30)
                {
                    Console.WriteLine("Наднормено тегло");
                }
                else if (CalculateITM() > 30)
                {
                    Console.WriteLine("Затлъстяване");
                }
            }
        }
        static void Main(string[] args)
        {
            ITM Person1 = new ITM();
            Person1.Height = double.Parse(Console.ReadLine());
            Person1.Weight = double.Parse(Console.ReadLine());

            Person1.Output();
        }
    }
}
