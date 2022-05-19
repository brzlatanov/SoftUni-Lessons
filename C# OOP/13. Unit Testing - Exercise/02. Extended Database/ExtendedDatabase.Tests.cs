using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDb;
        [SetUp]
        public void Setup()
        {
            extendedDb = new ExtendedDatabase();
        }

        [Test]
        public void TestWhetherConstructorInitializesWithNoElementsWhenEmpty()
        {
            Assert.IsTrue(extendedDb.Count == 0);
        }
        [Test]
        public void Ctor_InitializeWithValidItems()
        {
            Person[] elements = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                elements[i] = new Person(i, "asd" + i);
            }
            extendedDb = new ExtendedDatabase(elements);
            Assert.That(extendedDb.Count, Is.EqualTo(elements.Length));
        }
        [Test]
        public void TestCountWhenAddingDifferentValidPersonsToDb()
        {
            extendedDb.Add(new Person(123, "asd"));
            extendedDb.Add(new Person(124, "asdf"));
            Assert.IsTrue(extendedDb.Count == 2);
        }
        [Test]
        public void TestAddingPersonsWithSameUsernameButDifferentIDsToDb()
        {
            extendedDb.Add(new Person(123, "asd"));
            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(124, "asd")),
                "There is already user with this username!");
        }
        [Test]
        public void TestAddingPersonsWithSameIDButDifferentUsernamesToDb()
        {
            extendedDb.Add(new Person(123, "asd"));
            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(123, "asdf")),
                "There is already user with this Id!");
        }
        [Test]
        public void TestAddingPersonIfDbHasFreeCapacity()
        {
            //ArgumentException("Provided data length should be in range [0..16]!");
           extendedDb.Add(new Person(13, "asd"));
           var person = extendedDb.FindByUsername("asd");
           Assert.That(person != null);

        }
        [Test]
        public void TestAddingPersonIfDbIsAlreadyAtCapacity()
        {
            //ArgumentException("Provided data length should be in range [0..16]!");
            for (int i = 0; i < 16; i++)
            {
                extendedDb.Add(new Person(i, "asd" +i));
            }
            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(123, "asdf")),
                "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void TestRemoveMethodWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.Remove());
        }
        [Test]
        public void TestRemoveMethodWhenDbContainsItems()
        {
            extendedDb.Add(new Person(13, "Boyan"));
            extendedDb.Add(new Person(14, "Ivan"));
            extendedDb.Remove();
            Assert.AreEqual(extendedDb.Count, 1);
        }
        [Test]
        public void RemoveRemovesSpecificElementFromDb()
        {
            extendedDb.Add(new Person(13, "Boyan"));
            extendedDb.Add(new Person(14, "Ivan"));
            extendedDb.Remove();
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindByUsername("Ivan"));
        }

        [Test]
        public void SearchForNonexistentUsernameShouldThrowException()
        {
            extendedDb.Add(new Person(13, "Ivan"));
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindByUsername("Boyan"));
        }

        [Test]
        public void SearchByUsernameWithNullParameterShouldThrowException()
        {
            extendedDb.Add(new Person(13, "Ivan"));
            Assert.Throws<ArgumentNullException>(() => extendedDb.FindByUsername(null));
        }
        [Test]
        public void SearchByUsernameWithEmptyStringShouldThrowException()
        {
            extendedDb.Add(new Person(13, "Ivan"));
            Assert.Throws<ArgumentNullException>(() => extendedDb.FindByUsername(""));
        }
        [Test]
        public void SearchByCorrectUsernameWithDifferentCasingShouldThrowException()
        {
            extendedDb.Add(new Person(13, "Ivan"));
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindByUsername("ivan"));
        }

        [Test]
        public void SearchByNonexistingIDShouldThrowException()
        {
            extendedDb.Add(new Person(13, "Ivan"));
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindById(14));
        }

        [Test]
        public void SearchByNegativeIDShouldThrowException()
        {
            extendedDb.Add(new Person(13, "Ivan"));
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDb.FindById(-13));
        }
        [Test]
        public void SearchByCorrectID()
        {
            var person = new Person(13, "Ivan");
            extendedDb.Add(person);
            var person2 = extendedDb.FindById(13);
            Assert.IsTrue(person == person2);
        }
        [Test]
        public void SearchByCorrectUsername()
        {
            var person = new Person(13, "Ivan");
            extendedDb.Add(person);
            var person2 = extendedDb.FindByUsername("Ivan");
            Assert.IsTrue(person == person2);
        }

        [Test]
        public void InitializingCtorWithRangeAbove16ShouldReturnException()
        {
            Person[] personList = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                personList[i] = new Person(i, "asd" + i);
            }
            //Person[] personList = new Person[]

            Assert.Throws<ArgumentException>(() => extendedDb = new ExtendedDatabase(personList));

        }
        
    }
}
