﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        string name;
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
        }
    }

    public class Reptile : Animal
    {
        public Reptile(string name) : base(name)
        {
        }
    }
    public class Lizard : Reptile
    {
        public Lizard(string name) : base(name)
        {
        }
    }
    public class Snake: Reptile
    {
        public Snake(string name) : base(name)
        {
        }
    }

    public class Mammal : Animal
    {
        public Mammal(string name) : base(name)
        {
        }
    }
    public class Gorilla : Mammal
    {
        public Gorilla(string name) : base(name)
        {
        }
    }
    public class Bear : Mammal
    {
        public Bear(string name) : base(name)
        {
        }
    }
}
