using System;

using _11_LinkedListImplementation;
using _11_LinkedListImplementation.Contracts;

namespace _13_QueueImplementation
{
    public class LinkedQueue<T>
    {
        public LinkedQueue()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        private ILinkedListItem<T> FirstItem { get; set; }

        private ILinkedListItem<T> LastItem { get; set; }

        public void Enqueue(T value)
        {
            var item = new LinkedListItem<T>(value);

            if (this.LastItem != null)
            {
                this.LastItem.NextItem = item;
            }
            this.LastItem = item;

            if (this.FirstItem == null)
            {
                this.FirstItem = item;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.FirstItem == null)
            {
                throw new InvalidOperationException("No elements to dequeue!");
            }

            var currentItem = this.FirstItem.Value;
            this.FirstItem = this.FirstItem.NextItem;

            this.Count--;
            return currentItem;
        }

        public T Peek()
        {
            if (this.FirstItem == null)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            return this.FirstItem.Value;
        }
    }
}
