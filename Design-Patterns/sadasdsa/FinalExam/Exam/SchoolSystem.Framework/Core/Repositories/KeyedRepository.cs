using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Repositories
{
    public class KeyedRepository<T> : IKeyedRepository<T>
    {
        public KeyedRepository()
        {
            this.All = new Dictionary<int, T>();
        }

        private IDictionary<int, T> All { get; }

        public T GetById(int id)
        {
            return this.All[id];
        }

        public void Add(int itemId, T item)
        {
            this.All.Add(itemId, item);
        }

        public void Remove(int itemId)
        {
            if (!this.All.ContainsKey(itemId))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.All.Remove(itemId);
        }
    }
}
