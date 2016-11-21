namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : AbstractSorter<T>
        where T : IComparable<T>
    {
        protected override void SortElements(IList<T> collection)
        {
            for (var i = 0; i < collection.Count - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[min]) < 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    var lowerElement = collection[min];
                    collection[min] = collection[i];
                    collection[i] = lowerElement;
                }
            }
        }
    }
}
