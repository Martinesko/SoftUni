using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public interface ICitizen : IID , IBirthdate
    {
        public string Name { get; }
        public int Age { get; }
    }
    public interface IRobot : IID
    {
        public string Model { get; }
    }
    public interface IPet : IBirthdate
    {
        public string Name { get; }
    }
    public interface IID
    {
        public string Id { get; }
    }
    public interface IBirthdate
    {
        public string Birthdate { get; }
    }
}
