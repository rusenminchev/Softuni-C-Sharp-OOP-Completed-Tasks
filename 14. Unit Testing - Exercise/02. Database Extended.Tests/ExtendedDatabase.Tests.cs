using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDatabase;
        private Person[] persons;

        [SetUp]
        public void Setup()
        {
            this.persons = new Person[]
            {
            new Person(001010101010, "CS_Maniaka99"),
            new Person(101001100101, "KaciVapcarov"),
            new Person(110100100110, "NezakonniaSinNaFikiStoraro"),

            };

            this.extendedDatabase = new ExtendedDatabase(this.persons);
        }

        [Test]
        public void ConstructorIsWorkingProperly()
        {
            Person[] persons = new Person[]
            {
            new Person(001010101010, "CS_Maniaka99"),
            new Person(101001100101, "KaciVapcarov"),
            new Person(110100100110, "NezakonniaSinNaFikiStoraro"),
            };

            int expectedCount = persons.Length;

            ExtendedDatabase extendedDatabase = new ExtendedDatabase(this.persons);

            int actualCount = extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfParametersHasMoreThan16Elements()
        {
            Person[] persons = new Person[17];

            for (int i = 0; i <= 16; i++)
            {
                persons[i] = new Person(i, $"Username{i}");
            }

            Assert.Throws<ArgumentException>(() =>
            {
                ExtendedDatabase extendedDatabase = new ExtendedDatabase(persons);
            });
        }

        [Test]
        public void AddMethodShouldIncreseDatabaseCount()
        {
            int expectedCount = this.extendedDatabase.Count + 1;

            Person person = new Person(312312, "GoshoHubaveca");

            this.extendedDatabase.Add(person);

            int actualCount = this.extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenTheDatabaseIsFull()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i <= 15; i++)
            {
                persons[i] = new Person(i, $"Username{i}");
            }

            ExtendedDatabase extendedDatabase = new ExtendedDatabase(persons);

            Person person = new Person(312312, "GoshoHubaveca");

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Add(person);
            });
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfTryToAddExistingPerson()
        {
            Person personToAdd = new Person(0, "NezakonniaSinNaFikiStoraro");

            Assert.Throws<InvalidOperationException>(() =>
                {
                    this.extendedDatabase.Add(personToAdd);
                }).Message.Equals("There is already user with this username!");
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfTryToAddExistingPersonById()
        {
            Person personToAdd = new Person(110100100110, "");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(personToAdd);
            }).Message.Equals("There is already user with this Id!");
        }

        [Test]
        public void RemoveMethodShouldDecreaseDatabaseCount()
        {
            int expectedCount = this.extendedDatabase.Count - 1;

            this.extendedDatabase.Remove();

            int actualCount = this.extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            this.extendedDatabase.Remove();
            this.extendedDatabase.Remove();
            this.extendedDatabase.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Remove();
            });
        }

        [Test]
        public void FindByUserNameMethodShouldFindAndReturnTheRightPerson()
        {
            Person expectedPerson = new Person(101001100101, "KaciVapcarov");

            string expectedUserName = expectedPerson.UserName;

            Person actualPerson = this.extendedDatabase.FindByUsername("KaciVapcarov");

            string actualUserName = actualPerson.UserName;

            Assert.AreEqual(expectedUserName, actualUserName);
        }

        [TestCase("")]
        [TestCase(null)]
        public void FindByUserNameMethodShouldTrhowExceptionIfUserNameIsNullOrEmpty(string userName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.extendedDatabase.FindByUsername(userName);
            });
        }

        [Test]
        public void FindByUserNameMethodShouldTrhowExceptionIfUserWithThisNameDoesNotExist()
        {
            string userName = "IvanKostov";

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.FindByUsername(userName);
            });
        }

        [Test]
        public void FindByIdShouldShouldFindAndReturnTheRightPerson()
        {
            Person expectedPerson = new Person(101001100101, "KaciVapcarov");

            long expectedId = expectedPerson.Id;

            Person actualPerson = this.extendedDatabase.FindById(101001100101);

            long actualId = actualPerson.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void FindByIdShouldShouldThrowExceptionIfIdValueIsSmallerThanZero()
        {
            long id = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Person actualPerson = this.extendedDatabase.FindById(id);
            });
        }

        [Test]
        public void FindByIdShouldShouldThrowExceptionIfUserWithThisIdDoesNotExist()
        {
            long id = 32132131;

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person actualPerson = this.extendedDatabase.FindById(id);
            });
        }
    }
}