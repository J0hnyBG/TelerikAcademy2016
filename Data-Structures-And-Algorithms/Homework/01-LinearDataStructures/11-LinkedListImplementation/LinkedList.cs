using System.Collections;
using System.Collections.Generic;

using _11_LinkedListImplementation.Contracts;

namespace _11_LinkedListImplementation
{
    internal class LinkedList<T> : IEnumerable<T>
    {
        private ILinkedListItem<T> firstElement;

        public ILinkedListItem<T> FirstElement
        {
            get { return this.firstElement; }
            private set { this.firstElement = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.FirstElement;
            while (current != null)
            {
                yield return current.Value;

                current = current.NextItem;
            }
        }

        public ILinkedListItem<T> Find(T value)
        {
            if (this.FirstElement == null)
            {
                return null;
            }

            var current = this.FirstElement;
            while (!current.Value.Equals(value))
            {
                if (current.NextItem == null)
                {
                    return null;
                }

                current = current.NextItem;
            }

            return current;
        }

        public void AddFirst(T value)
        {
            var listItem = new LinkedListItem<T>(value);

            listItem.NextItem = this.FirstElement;

            this.FirstElement = listItem;
        }

        public void AddLast(T value)
        {
            var listItem = new LinkedListItem<T>(value);
            if (this.FirstElement == null)
            {
                this.FirstElement = listItem;
                return;
            }

            var currentItem = this.FirstElement;

            while (currentItem.NextItem != null)
            {
                currentItem = currentItem.NextItem;
            }

            currentItem.NextItem = listItem;
        }

        public void AddLastRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }

        public void RemoveFirst()
        {
            if (this.FirstElement == null)
            {
                return;
            }

            var next = this.FirstElement.NextItem;
            this.FirstElement = next;
        }

        public void RemoveFirst(T value)
        {
            if (this.FirstElement == null)
            {
                return;
            }

            var current = this.FirstElement;
            ILinkedListItem<T> previous = null;

            while (!current.Value.Equals(value))
            {
                if (current.NextItem == null)
                {
                    return;
                }

                previous = current;
                current = current.NextItem;
            }

            if (previous == null)
            {
                this.FirstElement = current.NextItem;
            }
            else
            {
                previous.NextItem = current.NextItem;
            }
        }

        public void RemoveLast()
        {
            if (this.FirstElement == null)
            {
                return;
            }

            if (this.FirstElement.NextItem == null)
            {
                this.FirstElement = null;
                return;
            }

            var current = this.FirstElement;
            var previous = this.FirstElement;
            while (current.NextItem != null)
            {
                previous = current;
                current = current.NextItem;
            }

            previous.NextItem = null;
        }
    }
}
