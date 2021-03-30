using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;
        private int[] data;

        [SetUp]
        public void Setup()
        {
            this.data = new int[] { 1, 2, 3 };
            this.database = new Database.Database(data);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { })]
        public void ConstructorIsWorkingProperly(int[] data)
        {
            int expectedCount = data.Length;

            Database.Database database = new Database.Database(data);
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorThrowsExceptionIfElementsOfTheParameterAreMoreThan16()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database.Database database = new Database.Database(data);
            });
        }

        [Test]
        public void AddShouldEncreaseTheDatabaseCount()
        {
            int expectedCount = this.data.Length + 1;

            this.database.Add(3);

            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionIfTheDatabaseIsFull()
        {
            for (int i = 4; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            });
        }

        [Test]
        public void RemoveMethodIsWorkingProperly()
        {
            int expectedCount = this.database.Count - 1;

            this.database.Remove();

            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {

            this.database.Remove();
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchMethodShouldReturnCopyOfTheDatabase(int[] expectedDatabase)
        {
            this.database = new Database.Database(expectedDatabase);

            int[] actualDatabase = this.database.Fetch();

            CollectionAssert.AreEqual(expectedDatabase, actualDatabase);
        }
    }
}