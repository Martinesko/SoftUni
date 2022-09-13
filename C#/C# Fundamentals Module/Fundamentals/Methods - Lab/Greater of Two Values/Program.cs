using System;

namespace Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();
            switch (type)
            {
                case "int":
                    intTest(firstInput, secondInput);
                    break;
                case "char":
                    chartest(firstInput, secondInput);
                    break;
                case "string":
                    stringtest(firstInput, secondInput);
                    break;
         
                default:
                    break;
            }
        }
        static void intTest(string firstInput, string secondInput)
        {
            int firstNumber = int.Parse(firstInput);
            int secondNumber = int.Parse(secondInput);
            if (firstNumber > secondNumber)
            {
                Console.WriteLine(firstNumber);
            }
            else
            {
                Console.WriteLine(secondNumber);
            }
        }
        static void chartest(string firstInput, string secondInput)
        {
            char first = char.Parse(firstInput);
            char second = char.Parse(secondInput);
            int firstNumber = (int)first;
            int secondNumber = (int)second;
            if (firstNumber > secondNumber)
            {
                Console.WriteLine(first);
            }
            else
            {
                Console.WriteLine(second);
            }
        }
        static void stringtest(string firstInput, string secondInput) 
        {
            char[] firstCharArry = new char[firstInput.Length];
            char[] secondCharArry = new char[secondInput.Length];
            int sumOfFirstCharIntegers = 0;
            int sumOfSecondCharIntegers = 0;
            for (int i = 0; i < firstCharArry.Length; i++)
            {
             sumOfFirstCharIntegers += (int)firstCharArry[i];
            }
            for (int i = 0; i < secondInput.Length; i++)
            {
             sumOfSecondCharIntegers += (int)firstCharArry[i];
            }
            if (sumOfFirstCharIntegers > sumOfSecondCharIntegers)
            {
                Console.WriteLine(firstInput);
            }
            else
            {
                Console.WriteLine(secondInput);
            }
        }
    }
}
