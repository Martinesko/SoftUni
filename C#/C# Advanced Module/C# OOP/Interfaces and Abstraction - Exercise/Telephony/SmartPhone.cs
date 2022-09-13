using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    internal class Smartphone : ISmartphone
    {
        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
        public void Browsing(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
