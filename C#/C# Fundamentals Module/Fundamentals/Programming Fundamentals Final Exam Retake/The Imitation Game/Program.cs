using System;
using System.Linq;
using System.Collections.Generic;

namespace The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List <char> chars = input.ToList();
            List <string> stringList = new List<string>();
            foreach (var item in chars)
            {
             stringList.Add(item.ToString());
            }
            bool flag = false;
            while (flag == false)
            {
                List<string> commands = Console.ReadLine().Split("|").ToList();
                switch (commands[0])
                {
                    case "Move":
                        for (int i = 0; i < int.Parse(commands[1]); i++)
                        {
                            string currentletter = stringList[0];
                            stringList.Remove(currentletter);
                            stringList.Insert(stringList.Count , currentletter);
                        }
                        break;
                    case "Insert":
                        stringList.Insert(int.Parse(commands[1])-1, (commands[2]));
                        break;
                    case "ChangeAll":
                        for (int i = 0; i < chars.Count; i++)
                        {
                            if (stringList[i] == (commands[1]))
                            {
                                stringList.RemoveAt(i);
                                stringList.Insert(i,(commands[2]));
                            }
                        }
                        break;
                    case "Decode":
                        flag = true;
                        break;
                    default:
                        break;
                }
               
                
            } 
            Console.Write($"The decrypted message is: ");
                foreach (var item in stringList)
                {
                    Console.Write(item);
                }
        }
    }
}
