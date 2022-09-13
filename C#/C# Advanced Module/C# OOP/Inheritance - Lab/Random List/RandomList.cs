using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int element = random.Next(0,this.Count);
            string text = "";
            for (int i = 0; i < this.Count; i++)
            {
                if (i == element)
                {
                   text = this[i];
                }
            }
            this.RemoveAt(element);
            return text;
        }
    }
}
