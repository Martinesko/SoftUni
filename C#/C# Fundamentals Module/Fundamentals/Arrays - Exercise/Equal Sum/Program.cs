using System;
using System.Linq;

namespace Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberArry = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            int index = 0;
            bool flag = false;        
            for (int i = 0; i < numberArry.Length; i++)
            {               
                leftSum = 0;
                rightSum = 0;
                for (int j = 0; j <= i; j++)
                {                
                     leftSum += numberArry[j];                                      
                }
                for (int n = numberArry.Length-1; n >= i; n--)
                {
                    rightSum += numberArry[n];
                }
                if (leftSum == rightSum)
                {
                   
                    Console.WriteLine(i);
                    break;
                }
            }
            if (leftSum != rightSum)
            {
                Console.WriteLine("no");
            }           
        }
    }
}
