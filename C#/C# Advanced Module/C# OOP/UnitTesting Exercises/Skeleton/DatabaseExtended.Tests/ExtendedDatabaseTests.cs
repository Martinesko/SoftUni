namespace ExtendedDatabase.Tests
{
    using NUnit.Compatibility;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        //PersonTests\\
        [Test]
        public void PersonConstructor()
        {
            Person person = new Person(3, "name");
            FieldInfo usernameField = person.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(x => x.Name == "userName");
            FieldInfo IdField = person.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(x => x.Name == "id");
            Assert.AreEqual((string)usernameField.GetValue(person), "name");
            Assert.AreEqual((long)IdField.GetValue(person), 3);
        }
        [Test]
        public void UsernameTestGetter()
        {
            string username = "Username";
            Person person = new Person(3, username);
            Assert.That(person.UserName == username);
        }
        [Test]
        public void IdTestGetter()
        {
            long id = 3;
            Person person = new Person(id, "name");
            Assert.That(id == person.Id);
        }


        //DatabaseTests\\
        [Test]
        public void IsCountWorkingProperlly()
        {
            Person person = new Person(3, "name");
            Database database = new Database();
            database.Add(person);
            Assert.AreEqual(1, database.Count);
        }
        [Test]
        public void CapasityTest()
        {
            Database database = new Database();
            FieldInfo CapasityInfo = database.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(x => x.Name == "persons");
            Person[] peoples = (Person[])CapasityInfo.GetValue(database);
            Assert.That(peoples.Length == 16);
        }
        [Test]
        public void IfThereIsAlreadyThisUsername()
        {
            Database database = new Database();
            Person person = new Person(3, "name");
            Person dubOfPerson = new Person(5, "name");
            Assert.That(() =>
            {
                database.Add(person);
                database.Add(dubOfPerson);
            }, Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void IsAddWorkingProperlly()
        {
            Person[] people = new Person[]
                 { new Person(1, "1"),
                      new Person(2, "2"),
                      new Person(3, "3"),
                      new Person(4, "4"),
                      new Person(5, "5"),
                      new Person(6, "6"),
                      new Person(7, "7"),
                      new Person(8, "8"),
                      new Person(9, "9"),
                      new Person(10, "10"),
                      new Person(11, "11"),
                      new Person(12, "12"),
                      new Person(13, "13"),
                      new Person(14, "14"),
                      new Person(15, "15"),
                     new Person(16, "16")
                 };
            var database = new Database();
            foreach (var person in people)
            {
                database.Add(person);
            }
            FieldInfo infoForPeopleInTheDatabase = database.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.Name == "persons");
            Person[] databaseArray = (Person[])infoForPeopleInTheDatabase.GetValue(database);
            CollectionAssert.AreEqual(people, databaseArray);

        }
        [Test]
        public void IsAddRangeWorking()
        {
            Assert.That(() =>
            {
                Person[] people = new Person[]
                     { new Person(1, "Pesho"),
                     new Person(2, "Misho"),
                     new Person(2, "Misho"),
                     new Person(3, "Gosho"),
                     new Person(4, "Mimi"),
                     new Person(5, "Rosana"),
                     new Person(6, "Peshito"),
                     new Person(7, "Mishto"),
                     new Person(8, "Goshko"),
                     new Person(9, "Mimito"),
                     new Person(10, "Roxana"),
                     new Person(11, "Pepi"),
                     new Person(12, "Mishko"),
                     new Person(13, "Gosheto"),
                     new Person(14, "Mitko"),
                     new Person(15, "Roximira"),
                     new Person(16, "Nikolina"),
                     new Person(17, "Pedal")
                     };
                Database database = new Database();
                foreach (var person in people)
                {
                    database.Add(person);
                }
            },Throws.Exception.TypeOf<InvalidOperationException>());

        }
        [Test]
        public void IsAddRangeWorking2()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Person[] people = new Person[]
                     { new Person(1, "Pesho"),
                     new Person(2, "Misho"),
                     new Person(3, "Gosho"),
                     new Person(4, "Mimi"),
                     new Person(5, "Rosana"),
                     new Person(6, "Peshito"),
                     new Person(7, "Mishto"),
                     new Person(8, "Goshko"),
                     new Person(9, "Mimito"),
                     new Person(10, "Roxana"),
                     new Person(11, "Pepi"),
                     new Person(12, "Mishko"),
                     new Person(13, "Gosheto"),
                     new Person(14, "Mitko"),
                     new Person(15, "Roximira"),
                     new Person(16, "Nikolina"),
                     new Person(17, "Pedal")
                     };
                Database database = new Database(people);
            });

        }
        [Test]
        public void IsRemoveWorkingProperlly()
        {
            Person[] people = new Person[]
                 { new Person(1, "Pesho"),
                      new Person(2, "Misho"),
                      new Person(3, "Gosho"),
                      new Person(4, "Mimi"),
                      new Person(5, "Rosana"),
                      new Person(6, "Peshito"),
                      new Person(7, "Mishto"),
                      new Person(8, "Goshko"),
                      new Person(9, "Mimito"),
                      new Person(10, "Roxana"),
                      new Person(11, "Pepi"),
                      new Person(12, "Mishko"),
                      new Person(13, "Gosheto"),
                      new Person(14, "Mitko"),
                      new Person(15, "Roximira"),
                      new Person(16, "Nikolina"),
                 };
            Database database = new Database(people);
            List<Person> list = new List<Person>(people);
            list.RemoveAt(list.Count - 1);
            list.Add(null);
            database.Remove();
            FieldInfo infoForThePeopleInTheDatabase = database.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(x => x.Name == "persons");
            Person[] peopleInTheDatabase = (Person[])infoForThePeopleInTheDatabase.GetValue(database);
            CollectionAssert.AreEqual(peopleInTheDatabase, list);
            Assert.AreEqual(peopleInTheDatabase.Length, list.Count);
        }
        [Test]
        public void IsRemoveWorkingProperlly2()
        {
            Assert.That(() =>
            {
                Database database = new Database();
                database.Remove();
            }, Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void IfThereIsAlreadyThisId()
        {
            Database database = new Database();
            Person person = new Person(3, "name");
            Person dubOfPerson = new Person(3, "dubbedPerson");
            Assert.That(() =>
            {
                database.Add(person);
                database.Add(dubOfPerson);
            }, Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void NoPersonWithThisUsername()
        {
            Assert.That(() =>
           {
               string username = "name";
               Database database = new Database();
               database.FindByUsername(username);

           }, Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void SearchedUsernameIsNull()
        {
            Assert.That(() =>
            {
                Database database = new Database();
                database.FindByUsername(null);
            }, Throws.Exception.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void IsNameSearchCaseSensitive()
        {
            Assert.That(() =>
            {
                string username = "name";
                Person person = new Person(3, "username");
                string caseSensitiveUsername = "Name";
                Database database = new Database(person);
                database.FindByUsername(caseSensitiveUsername);
            }, Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void NoPersonWithThisId()
        {
            Assert.That(() =>
           {
               int id = 3;
               Database database = new Database();
               database.FindById(id);

           }, Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void SearchedIdNegative()
        {
            Assert.That(() =>
            {
                Database database = new Database();
                database.FindById(-1);
            }, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

    }
}