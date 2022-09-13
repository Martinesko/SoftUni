using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int > StudentsPerCourse = new Dictionary<string, int>();
            Dictionary<string,  List<string>> StudentsAtTheCourse = new Dictionary<string, List<string>>();
            while (true)
            {
                List<string> commands = Console.ReadLine().Split(" : ").ToList();
                if (commands[0]=="end")
                {
                  break;
                }
                if (!StudentsPerCourse.ContainsKey(commands[0])||!StudentsAtTheCourse.ContainsKey(commands[0]))
                {
                   StudentsPerCourse.Add(commands[0], 1);
                    StudentsAtTheCourse.Add(commands[0], new List<string>());
                    StudentsAtTheCourse[commands[0]].Add(commands[1]);
                }
                else
                {
                    StudentsPerCourse[commands[0]]++;
                    StudentsAtTheCourse[commands[0]].Add(commands[1]);
                }
            }
            foreach (var item in StudentsPerCourse)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
                
                    for (int i = 0; i < StudentsAtTheCourse[item.Key].Count; i++)
                    {
                     Console.WriteLine($"-- {StudentsAtTheCourse[item.Key][i]}");
                    }
            }
        }
    }
}
