namespace SortingTestProject
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class LinearSearch
    {
        [TestMethod]
        public void TestOnEmptyCollection()
        {
            var collection = new SortableCollection<int>();
            var searchedNumber = 22;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void TestSuccessAtBegining()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            var searchedNumber = 22;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void TestSuccessAtEnd()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            var searchedNumber = 101;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void TestSuccessAtMiddle()
        {
            var collection = new SortableCollection<int>(new[] { 1, 2, 3 });
            var searchedNumber = 2;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void TestOnOneElement()
        {
            var collection = new SortableCollection<int>(new[] { 1 });
            var searchedNumber = 1;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<bool>(expected, actual);
        }

        [TestMethod]
        public void TestOnMissingElement()
        {
            var collection = new SortableCollection<int>(new[] { 1, 2, 3 });
            var searchedNumber = 4;
            var expected = FindFirst(collection.Items, searchedNumber);
            var actual = collection.LinearSearch(searchedNumber);

            Assert.AreEqual<bool>(expected, actual);
        }

        private static bool FindFirst<T>(IList<T> collection, T item) where T : IComparable<T>
        {
            for (int index = 0; index < collection.Count; index++)
            {
                if (collection[index].CompareTo(item) == 0) return true;
            }

            return false;
        }
    }
}
