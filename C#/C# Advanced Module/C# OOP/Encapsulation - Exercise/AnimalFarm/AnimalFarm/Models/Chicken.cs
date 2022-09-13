using System;
namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be empty.");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentException("Age should be between 0 and 15.");
                }
                this.age = value;
            }
        }
        public double ProductPerDay
        {
            get
            {
                return this.CalculateProductPerDay();
            }
        }
        public double CalculateProductPerDay()
        {
            if(this.Age<=3)
            {
                return 1.5;
            }
            else if(this.Age>3&& this.Age <= 7)
            {
                return 2;
            }
            else if (this.Age >7 && this.Age <= 11)
            {
                return 1;
            }
            else
            {
                return 0.75;
            }            
        }
    }
}
