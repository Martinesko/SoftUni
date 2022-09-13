using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> nameAndGrade = new Dictionary<string, double>();
            int reps = int.Parse(Console.ReadLine());
            for (int i = 0; i < reps; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!nameAndGrade.ContainsKey(name))
                {
                    nameAndGrade.Add(name , grade);
                }
                else
                {
                    nameAndGrade[name] = (nameAndGrade[name] + grade)/2;
                }
            }
            foreach (var item in nameAndGrade)
            {
                if (item.Value>= 4.50)
                {
                   Console.WriteLine($"{item.Key} -> {item.Value:f2}");
                }               
            }
        }
    }
}
