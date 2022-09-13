using System;
using System.Linq;

namespace Telephony
{
    internal class StartUp
    {
        static void Main()
        {
            string[] inputNumbers = Console.ReadLine().Split(" ").ToArray();
            string[] inputSites = Console.ReadLine().Split(" ").ToArray();
            IStationaryPhone stationaty = new StationaryPhone();
            ISmartphone smart = new Smartphone();

            foreach (string number in inputNumbers)
            {
                bool invalid = false;
                if (number.Length == 7)
                {
                    foreach (char ch in number)
                    {
                        if (!char.IsDigit(ch))
                        {
                            invalid = true;
                            break;
                        }
                    }
                    if (!invalid)
                    {
                        stationaty.Calling(number);
                    }
                }
                else 
                {
                    foreach (char ch in number)
                    {
                        if (!char.IsDigit(ch))
                        {
                            invalid = true;
                            break;
                        }
                    }
                    if (!invalid)
                    {
                        smart.Calling(number);
                    }
                }
                if (invalid == true)
                {
                    Console.WriteLine("Invalid number!");
                }

            }
            foreach (string site in inputSites)
            {
                bool invalid = false;
                foreach (char ch in site)
                {
                    if (char.IsDigit(ch))
                    {                       
                        invalid = true;
                        break;
                    }
                }
                if (!invalid)
                {
                    smart.Browsing(site);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
