using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FaveoriteFood { get; protected set; }
        protected Animal(string name , string favoritefood)
        {
            this.Name = name;
            this.FaveoriteFood = favoritefood;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FaveoriteFood}";
        }
    }
    public class Cat : Animal
    {
        public string Name { get; }
        public string Faveoritefood { get; }
        public Cat(string name, string favoritefood) : base (name , favoritefood)
        {
        }
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "MEEOW";
        }
    }
    public class Dog : Animal
    {
        public string Name { get; }
        public string Faveoritefood { get; }
        public Dog(string name, string favoritefood) : base (name , favoritefood)
        {
        }
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "DJAAF";
        }
    }

}
