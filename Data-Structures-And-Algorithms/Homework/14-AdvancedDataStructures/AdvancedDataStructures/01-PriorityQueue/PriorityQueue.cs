using System;
using System.Collections.Generic;

namespace _01_PriorityQueue
{
    public class PriorityQueue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] data;
        private int size = 0;
        private readonly Comparison<T> comparison;

        public PriorityQueue()
            : this(DefaultCapacity)
        {
        }

        public PriorityQueue(Comparison<T> comparison)
            : this(DefaultCapacity, comparison)
        {
        }

        public PriorityQueue(int capacity)
            : this(capacity, null)
        {
        }

        public PriorityQueue(int capacity, Comparison<T> comparison)
        {
            this.data = new T[capacity];
            this.comparison = comparison;
            if (this.comparison == null)
            {
                this.comparison = Comparer<T>.Default.Compare;
            }
        }

        public int Size
        {
            get { return this.size; }
        }

        public int Count
        {
            get { return this.data.Length; }
        }

        ///
        /// Add an item to the heap
        ///
        public void Enqueue(T item)
        {
            if (this.size == this.data.Length)
            {
                this.Resize();
            }
            this.data[this.size] = item;
            this.HeapifyUp(this.size);
            this.size++;
        }

        ///
        /// Get the item of the root
        ///
        public T Peak()
        {
            return this.data[0];
        }

        ///
        /// Extract the item of the root
        ///
        public T Dequeue()
        {
            var item = this.data[0];
            this.size--;
            this.data[0] = this.data[this.size];
            this.HeapifyDown(0);
            return item;
        }

        private void Resize()
        {
            var resizedData = new T[this.data.Length * 2];
            Array.Copy(this.data, 0, resizedData, 0, this.data.Length);
            this.data = resizedData;
        }

        private void HeapifyUp(int childIdx)
        {
            while (childIdx > 0)
            {
                var parentIdx = (childIdx - 1) / 2;
                if (this.comparison.Invoke(this.data[childIdx], this.data[parentIdx]) > 0)
                {
                    var t = this.data[parentIdx];
                    this.data[parentIdx] = this.data[childIdx];
                    this.data[childIdx] = t;
                    childIdx = parentIdx;
                    continue;
                }

                break;
            }
        }

        private void HeapifyDown(int parentIdx)
        {
            while (true)
            {
                var leftChildIdx = 2 * parentIdx + 1;
                var rightChildIdx = leftChildIdx + 1;
                var largestChildIdx = parentIdx;
                if (leftChildIdx < this.size &&
                    this.comparison.Invoke(this.data[leftChildIdx], this.data[largestChildIdx]) > 0)
                {
                    largestChildIdx = leftChildIdx;
                }

                if (rightChildIdx < this.size &&
                    this.comparison.Invoke(this.data[rightChildIdx], this.data[largestChildIdx]) > 0)
                {
                    largestChildIdx = rightChildIdx;
                }

                if (largestChildIdx != parentIdx)
                {
                    var t = this.data[parentIdx];
                    this.data[parentIdx] = this.data[largestChildIdx];
                    this.data[largestChildIdx] = t;
                    parentIdx = largestChildIdx;
                    continue;
                }

                break;
            }
        }
    }
}
