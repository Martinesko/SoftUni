﻿using System;

namespace Stealer
{
    internal class StartUp
    {
        static void Main()
        {
           Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker","username","password");
            Console.WriteLine(result);
        }
    }
}
