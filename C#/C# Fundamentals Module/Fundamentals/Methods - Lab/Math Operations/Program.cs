using System;

namespace Math_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
         double firstNumber = double.Parse(Console.ReadLine());
            string funcion = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());

            switch (funcion)
            {
                case "/":
                    divide(firstNumber, secondNumber);
                    break;
                    
                case "*":
                    sum(firstNumber, secondNumber);
                    break;
                   
                case "+":
                    add(firstNumber, secondNumber);
                    break;
                   
                case "-":
                    sub(firstNumber, secondNumber);
                    break;

                default:
                    break;
            }
        }
        static void divide(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber / secondNumber);
        }
         static void sum(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }
         static void sub(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }
         static void add(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }

    }
}
