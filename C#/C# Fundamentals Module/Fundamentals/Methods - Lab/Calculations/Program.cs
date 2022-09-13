using System;

namespace Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string funcion = Console.ReadLine();
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double sum = 0;
            switch (funcion)
            {
                case "add":
                    add(firstNumber, secondNumber, sum);
                    break;
                case "multiply":
                    multiply(firstNumber, secondNumber, sum);
                    break;
                case "subtract":
                    subtract(firstNumber, secondNumber, sum);
                    break;
                case "divide":
                    divide(firstNumber, secondNumber, sum);
                    break;

                default:
                    break;
            }            
        }

        static void add(double firstNumber, double secondNumber, double sum)
        {
            sum = firstNumber + secondNumber;
            Console.WriteLine(sum);
        }
        static void multiply(double firstNumber, double secondNumber, double sum)
        {
            sum = firstNumber * secondNumber;
            Console.WriteLine(sum);
        }
        static void subtract(double firstNumber, double secondNumber, double sum)
        {
            sum = firstNumber - secondNumber;
            Console.WriteLine(sum);
        }
        static void divide(double firstNumber, double secondNumber, double sum)
        {
            sum = firstNumber / secondNumber;
            Console.WriteLine(sum);
        }

    }
}
