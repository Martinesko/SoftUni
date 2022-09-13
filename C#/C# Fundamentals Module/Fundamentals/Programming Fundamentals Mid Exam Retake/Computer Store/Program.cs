using System;
using System.Linq;

namespace Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double inputInDouble = 0; 
            double PriceWithoutTaxes = 0;
            double PriceWithTaxes = 0;
            bool flag = false;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "special" && PriceWithoutTaxes == 0 || input == "regular" && PriceWithoutTaxes == 0)
                {
                    Console.WriteLine("Invalid order!");
                    flag = true;
                    break;
                }
                else if (input == "special" || input == "regular")
                {
                    break;
                }
                inputInDouble = double.Parse(input);
                if (inputInDouble <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                   PriceWithoutTaxes += inputInDouble;
                }
            }
            PriceWithTaxes = (PriceWithoutTaxes * 0.2) + PriceWithoutTaxes;
            if (input == "special")
            {
                PriceWithTaxes -= PriceWithTaxes * 0.1; 
            }
            if (flag != true)
            {
            Console.WriteLine($"Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: { PriceWithoutTaxes:f2}$");
            Console.WriteLine($"Taxes: { PriceWithoutTaxes*0.2:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {PriceWithTaxes:f2}$");
            }
            
        }
    }
}
