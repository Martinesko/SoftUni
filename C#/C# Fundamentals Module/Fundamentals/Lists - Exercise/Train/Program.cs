using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> wagonsList = Console.ReadLine().Split().Select(double.Parse).ToList();
            int capasity = int.Parse(Console.ReadLine());
            while (true)
            {
                List<string> funcion = Console.ReadLine().Split().ToList();
                switch (funcion[0])
                {
                    case "Add":
                        wagonsList.Add(double.Parse(funcion[1]));
                        break;
                    case "end":
                        break;
                    default:
                        double people = double.Parse(funcion[0]);
                        for (int i = 0; i < wagonsList.Count; i++)
                        {
                            if (capasity >= wagonsList[i] + people)
                            {
                                wagonsList[i] += people;
                                break;
                            }
                        }
                        break;
                }
                if (funcion[0] == "end")
                {
                    break;
                }
            }
            Console.WriteLine(string.Join(" ",wagonsList));
        }
    }
}
