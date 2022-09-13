using System;
using System.Linq;
using System.Collections.Generic;

namespace Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentDic = new Dictionary<string, List<double>>();
            for (int count = 0; count < counter; count++)
            {
                List<string> student = Console.ReadLine().Split(" ").ToList();
                string studentName = student[0];
                double studentGrate = double.Parse(student[1]);
                if (!studentDic.ContainsKey(studentName))
                    studentDic.Add(studentName, new List<double>());
               
                studentDic[studentName].Add(studentGrate);
                
            }
            foreach (var student in studentDic)
            {
                    Console.WriteLine( $"{student.Key} -> {String.Join(" ", student.Value.Select(g => g.ToString("f2")))} (avg: {student.Value.Average():f2})");
                
            }
        }
    }
}
