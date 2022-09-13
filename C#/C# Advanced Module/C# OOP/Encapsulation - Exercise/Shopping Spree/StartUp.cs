using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Shopping_Spree
{
    public class StartUp
    {
        private static List<Person> people;
        private static List<Product> products;
        static void Main()
        {
            people = new List<Person>();
            products = new List<Product>();
            string[] input1 = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            AddPerson(input1);
            string[] input2 = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            AddProduct(input2);
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END")
                {
                    break;
                }
                string currPersonName = input[0];
                string currProductName = input[1];
                Person currPerson = people.FirstOrDefault(x => x.Name == currPersonName);
                Product currProduct = products.FirstOrDefault(x => x.Name == currProductName);
                currPerson.AddProductToList(currProduct);
            }
            foreach (var item in people)
            {
                if (item.Bag.Count == 0)
                {
                    Console.WriteLine($"{item.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{item.Name} - {String.Join(", ", item.Bag.Select(x => $"{x.Name}"))}");
                }
            }
        }
        static void AddPerson(string[] NameandMoney)
        {
            foreach (var person in NameandMoney)
            {
                string[] split = person.Split("=");
                string name = split[0];
                decimal money = decimal.Parse(split[1]);
                Person currPerson = null;
                try
                {
                    currPerson = new Person(name, money);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);

                }
                if (currPerson != null)
                {
                    people.Add(currPerson);
                }
            }


        }
        static void AddProduct(string[] NameandMoney)
        {
            foreach (var product in NameandMoney)
            {
                string[] split = product.Split("=");
                string name = split[0];
                decimal money = decimal.Parse(split[1]);
                Product currProduct = null;
                try
                {
                    currProduct = new Product(name, money);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);

                }
                if (currProduct != null)
                {
                    products.Add(currProduct);
                }
            }


        }
    }
}
