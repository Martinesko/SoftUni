namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldWork(int[] input)
        {
            var database = new Database(input);
            int[] actualArray = database.Fetch();
            int actualCount = input.Length;
            CollectionAssert.AreEqual(input, actualArray);
            Assert.That(database.Count, Is.EqualTo(actualCount));
        }
        [Test]
        public void IsCapasity16integers()
        {
            Assert.That(() =>
            {
                Database database = new Database();
                database.Add(1);
                database.Add(2);
                database.Add(3);
                database.Add(4);
                database.Add(5);
                database.Add(6);
                database.Add(7);
                database.Add(8);
                database.Add(9);
                database.Add(10);
                database.Add(11);
                database.Add(12);
                database.Add(13);
                database.Add(14);
                database.Add(15);
                database.Add(16);
                database.Add(17);
            }, Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void AddTest()
        {
            Assert.That(() =>
            {
                Database database = new Database();
                database.Add(1);
                database.Add(2);
                database.Add(3);
                database.Add(4);
                database.Add(5);
                database.Add(6);
                database.Add(7);
                database.Add(8);
                database.Add(9);
                database.Add(10);
                database.Add(11);
                database.Add(12);
                database.Add(13);
                database.Add(14);
                database.Add(15);
                database.Add(16);
                database.Add(17);
            }, Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void CountTest()
        {
            Database database = new Database();
            database.Add(1);
            Assert.That(database.Count == 1);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        public void Remove(int[] input)
        {

                Database database = new Database(input);
                
                List<int> expected = new List<int>(input);
            database.Remove();
            int[] fetched = database.Fetch();
            expected.RemoveAt(expected.Count - 1);
            CollectionAssert.AreEqual(fetched, expected);
        }
        [Test]
        public void RemoveTestInvalidOperationException()
        {
            Assert.That(() =>
            {
                Database database = new Database();
                database.Remove();
            }, Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [TestCase(new int[] { 1, 6, 7 })]
        public void FetchTest(int[] input)
        {
            Database database = new Database(input);
            Assert.AreEqual(database.Fetch(), input);
        }

    }
}
