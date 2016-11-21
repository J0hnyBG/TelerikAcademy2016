using System;
using System.Collections.Generic;

using NUnit.Framework;

using SearchingHomework.Tests.TestData;

using SortingHomework;

namespace SearchingHomework.Tests
{
    [TestFixture]
    public class SortableCollection_BinarySearch_Should
    {
        [Test, TestCaseSource(typeof(SearchingTestDataFactory), nameof(SearchingTestDataFactory.GetUnFindableData))]
        public void ReturnFalse_WhenNoElementIsFound<T>(IList<T> items, T itemToSearchFor)
            where T : IComparable<T>
        {
            var sut = new SortableCollection<T>(items);

            var result = sut.BinarySearch(itemToSearchFor);

            Assert.IsFalse(result);
        }

        [Test, TestCaseSource(typeof(SearchingTestDataFactory), nameof(SearchingTestDataFactory.GetFindableData))]
        public void ReturnTrue_WhenElementIsFound<T>(IList<T> items, T itemToSearchFor)
            where T : IComparable<T>
        {
            var sut = new SortableCollection<T>(items);

            var result = sut.BinarySearch(itemToSearchFor);

            Assert.IsTrue(result);
        }
    }
}
