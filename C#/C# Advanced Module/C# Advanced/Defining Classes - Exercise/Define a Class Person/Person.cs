using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Define_a_Class_Person
{
    public class Person
    {
        string name;
        int age;

        public string Name
        {
         get { return name; }
            set { name = value; }   
        }
        public int Age 
        {
            get { return age; }
            set { age = value; }
        }
    }
}
