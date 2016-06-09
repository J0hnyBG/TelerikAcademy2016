namespace HW.Generic
{
    using System;
    using System.Text;
    //Problem 5
    public class GenericList<T> where T: IComparable
    {
        private const int DefaultCapacity = 4;
        private readonly T[] _emptyArray = new T[0];
        private T[] _items;
        private int _size = 0;

        public T[] Items => _items;

        public int Count => this._size;

        // Indexer declaration
        public T this[int index]
        {
            get
            {
                if (index >= this._size)
                {
                    throw new ArgumentOutOfRangeException("Index can not be larger than the size of the GenericList!");
                }
                return this._items[index];
            }
            set { this._items[index] = value; }
        }

        private int Capacity
        {
            get { return this._items.Length; }
            set
            {
                //Problem 6
                if (value < this._size)
                {
                    throw new ArgumentOutOfRangeException("Generic List capacity can not be less than the number of items contained!");
                }

                if (value == this._items.Length)
                {
                    return;
                }
                if (value > 0)
                {
                    T[] objArray = new T[value];
                    if (this._size > 0)
                    {
                        Array.Copy((Array) this._items, 0, (Array) objArray, 0, this._size);
                    }
                    this._items = objArray;
                }
                else
                {
                    this._items = _emptyArray;
                }
            }
        }
        

        public GenericList(int capacity = DefaultCapacity)
        {
            this._items = _emptyArray;
            this.Capacity = capacity;
        }
        public void Clear()
        {
            if ( this._size > 0 )
            {
                Array.Clear((Array)this._items, 0, this._size);
                this._size = 0;
            }
        }

        public void Add(T item)
        {
            if (this._size == this._items.Length)
            {
                this.Grow(this._size + 1);
            }
            int num = this._size;
            this._size = num + 1;
            int index = num;
            T obj = item;
            _items[index] = obj;

        }

        public void Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index < 0)
            {
                return;
            }
            this.RemoveAt(index);
            
        }

        public void RemoveAt(int index)
        {
            if ((uint) index >= (uint) this._size)
            {
                throw new ArgumentOutOfRangeException("Specified index is larger than the size of the generic list!");
            }
            this._size = this._size - 1;
            if (index < this._size)
            {
                Array.Copy((Array)this._items, index + 1, (Array)this._items, index, this._size - index);
            }
            this._items[this._size] = default(T);
        }

        public void Insert(int index, T item)
        {
            if ((uint) index > (uint) this._size)
            {
                throw new ArgumentOutOfRangeException("Specified index is larger than the size of the generic list!");
            }
            if (this._size == this._items.Length)
            {
                this.Grow(this._size + 1);
            }
            if (index < this._size)
            {
                Array.Copy((Array)this._items, index, (Array)this._items, index + 1, this._size - index);
            }
            this._items[index] = item;
            this._size = this._size + 1;
        }
        public int IndexOf(T item)
        {
            return Array.IndexOf<T>(this._items, item, 0, this._size);
        }

        public void Sort()
        {
            Array.Sort<T>(this._items, 0, this.Count, null);
        }
        //Problem 7
        public T Max()
        {
            if (_size <= 0)
            {
                return default(T);
            }
            var max = _items[0];
            for (int i = 0; i < _size; i++)
            {
                if (max.CompareTo(_items[i]) < 0)
                {
                    max = _items[i];
                }
            }
            return max;
        }
        public T Min()
        {
            if ( _size <= 0 )
            {
                return default(T);
            }
            var min = _items[0];
            for ( int i = 0; i < _size; i++ )
            {
                if ( min.CompareTo(_items[i]) > 0 )
                {
                    min = _items[i];
                }
            }
            return min;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _size; i++)
            {
                sb.Append(_items[i] + Environment.NewLine);
            }
            return sb.ToString();
        }

        private void Grow(int min)
        {   
            if (this._items.Length >= min)
            {
                return;
            }
            //Double the size of the current arr if array length != 0
            int num = this._items.Length == 0 ? DefaultCapacity : this._items.Length * 2;
            //Max capacity
            if ((uint) num > 2146435071U)
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
