using System;

namespace SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
         int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int aswersPerHour = firstEmployee + secondEmployee + thirdEmployee;
            int studentCout = int.Parse(Console.ReadLine());
            int neededHours = 0;
            while (studentCout > 0)
            {
                if (studentCout > 0 && neededHours % 4 != 0)
                {
                    studentCout = studentCout - aswersPerHour;
                    
                }
                neededHours++;
            }
            Console.WriteLine($"Time needed: {neededHours-1}h.");
        }
    }
}
