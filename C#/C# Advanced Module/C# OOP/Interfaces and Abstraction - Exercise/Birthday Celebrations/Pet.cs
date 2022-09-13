using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Pet : IPet
    {
        public string Name { get; private set; }
        public string Birthdate { get; private set; }
        public Pet(string name , string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
    }
}
