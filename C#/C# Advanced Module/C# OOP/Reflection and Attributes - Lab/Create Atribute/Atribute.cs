using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorProblem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method , AllowMultiple = true)]
    public class AuthorAtribute : Attribute
    {
     public string Name { get; set; }
        public AuthorAtribute(string name)
        {
            Name = name;
        }
    }

}
