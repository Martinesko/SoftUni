using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> username = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                username.Add(input);
            }
            foreach (var user in username)
            {
                Console.WriteLine(user);
            }
        }
    }
}
