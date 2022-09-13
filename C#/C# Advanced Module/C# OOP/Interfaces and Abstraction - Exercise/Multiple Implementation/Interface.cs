using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IIdentifiable
    {
        string Id { get; }
    }
    public interface IBirthable
    {
        public string Birthdate { get; }

    }
    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }
    }
}
