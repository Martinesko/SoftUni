using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Citizen : ICitizen , IID
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
    }
}
