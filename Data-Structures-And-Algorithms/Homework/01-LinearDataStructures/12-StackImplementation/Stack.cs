using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _12_StackImplementation
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 8;

        private T[] items;
        private int size;

        public Stack()
        {
            this.size = 0;
            this.items = new T[DefaultCapacity];
        }

        public Stack(int initialCapacity)
        {
            this.size = 0;
            this.items = new T[initialCapacity];
        }

        public int Size { get { return this.size; } }

        public int Capacity
        {
            get
            {
                return this.items.Length;
            }

            private set
            {
                if (value <= this.items.Length)
                {
                    return;
                }

                if (value > 0)
                {
                    var objArray = new T[value];
                    if (this.size > 0)
                    {
                        Array.Copy(this.items, 0, objArray, 0, this.size);
                    }

                    this.items = objArray;
                }
                else
                {
                    this.items = new T[0];
                }
            }
        }

        public T Peek()
        {
            return this.items[this.size - 1];
        }

        public T Pop()
        {
            this.size--;

            var removedItem = this.items[this.size];
            var index = Array.IndexOf(this.items, removedItem);
            this.items = this.items.Where((val, idx) => idx != index).ToArray();

            return removedItem;
        }

        public void Push(T item)
        {
            this.EnsureCapacity(this.size + 1);
            this.items[this.size] = item;

            this.size++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = this.size - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        private void EnsureCapacity(int min)
        {
            if (this.items.Length >= min)
            {
                return;
            }

            int num = this.items.Length == 0
                ? DefaultCapacity
                : this.items.Length * 2;

            if ((uint)num > 2146435071U)
            {
                num = 2146435071;
            }

            if (num < min)
            {
                num = min;
            }

            this.Capacity = num;
        }
    }
}
