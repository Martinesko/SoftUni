using System;

namespace Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
         string theString = Console.ReadLine();
         int reps = int.Parse(Console.ReadLine());
            repeater(theString, reps);
        }
        static void repeater (string theString , int reps)
        {
            for (int i = 0; i < reps ; i++)
            {
                Console.Write(theString);
            }
        }
    }
}
