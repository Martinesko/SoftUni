using System;

namespace Data_Types_and_Variables___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fourth = int.Parse(Console.ReadLine());
            long added = (long)first + second;
            long dived = added / third;
            long sum = dived * fourth;
            Console.WriteLine(sum);
        }
    }
}
