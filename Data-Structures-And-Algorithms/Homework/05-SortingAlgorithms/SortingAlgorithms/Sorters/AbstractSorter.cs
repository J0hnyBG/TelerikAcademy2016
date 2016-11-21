using System;
using System.Collections.Generic;

namespace SortingHomework
{
    public abstract class AbstractSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Collection must contain elements in order to be sorted!");
            }

            if (collection.Count == 1)
            {
                return;
            }

            this.SortElements(collection);
        }

        protected abstract void SortElements(IList<T> collection);
    }
}
