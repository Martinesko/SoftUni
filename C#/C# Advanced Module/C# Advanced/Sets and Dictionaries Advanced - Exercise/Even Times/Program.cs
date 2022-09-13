using System;
using System.Linq;
using System.Collections.Generic;

namespace Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int , int> dic = new Dictionary<int , int>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (!dic.ContainsKey(input))
                {
                    dic.Add(input ,0);
                }
                dic[input]++;
            }
            foreach (var curnumber in dic)
            {
                if (curnumber.Value % 2 == 0)
                {
                    Console.WriteLine(curnumber.Key);
                }
            }
        }
    }
}
