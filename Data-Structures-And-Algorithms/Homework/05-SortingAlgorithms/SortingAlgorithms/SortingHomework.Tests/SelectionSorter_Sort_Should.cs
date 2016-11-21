using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using SortingHomework.Tests.TestData;

namespace SortingHomework.Tests
{
    [TestFixture]
    public class SelectionSorter_Sort_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenCollectionIsNull()
        {
            var sorter = new QuickSorter<int>();

            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
        public void ThrowInvalidOperationException_WhenCollectionIsEmpty()
        {
            var collection = new List<int>();
            var sorter = new QuickSorter<int>();

            Assert.Throws<InvalidOperationException>(() => sorter.Sort(collection));
        }

        [Test, TestCaseSource(typeof(SortingTestDataFactory), nameof(SortingTestDataFactory.GetData))]
        public void SortElementsCorrectly_WhenValidArgumentsArePassed<T>(IList<T> collection)
            where T : IComparable<T>
        {
            var expected = collection.Select(x => x).ToList();
            expected.Sort();
            var sorter = new QuickSorter<T>();

            sorter.Sort(collection);

            CollectionAssert.AreEqual(expected, collection);
        }
    }
}
