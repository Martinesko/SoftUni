using System;
using System.Linq;

namespace Border_Control
{
    using System;
    using System.Collections.Generic;
    public class Program
    {

        static void Main()
        {
            List<IID> IDs = new List<IID>();
            while (true)
            {
                string[] commnad = Console.ReadLine().Split(" ").ToArray();
                if (commnad[0] == "End")
                {
                    break;
                }
                if (commnad.Length == 3)
                {
                    ICitizen citizen = new Citizen(commnad[0], int.Parse(commnad[1]), commnad[2]);
                    IDs.Add(citizen);
                }
                else if (commnad.Length == 2)
                {
                    IRobot robot = new Robot(commnad[0], commnad[1]);
                    IDs.Add(robot);
                }
            }
            string endOfFake = Console.ReadLine();
            foreach (var thing in IDs)
            {
                if (thing.Id.EndsWith(endOfFake))
                {
                    Console.WriteLine(thing.Id);
                }
            }
        }
    }
}
