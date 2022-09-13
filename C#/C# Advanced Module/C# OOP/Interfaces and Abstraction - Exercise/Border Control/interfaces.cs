using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public interface ICitizen : IID
    {
        public string Name { get; }
        public int Age { get; }
    }
    public interface IRobot : IID
    {
        public string Model { get; }
        
    }
    public interface IID
    {
      public string Id { get; }
    }
}
