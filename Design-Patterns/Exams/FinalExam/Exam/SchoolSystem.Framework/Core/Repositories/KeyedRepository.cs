using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Framework.Core.Repositories.Contracts;

namespace SchoolSystem.Framework.Core.Repositories
{
    public class KeyedRepository<T> : IRepository<T>
    {
        private readonly IDictionary<int, T> all;

        public KeyedRepository()
        {
            this.all = new SortedDictionary<int, T>();
        }

        private int NextId
        {
            get
            {
                if (this.All.Count > 0)
                {
                    return this.All.Keys.Last() + 1;
                }

                return 0;
            }
        }

        private IDictionary<int, T> All
        {
            get { return this.all; }
        }

        public T GetById(int id)
        {
            return this.All[id];
        }

        public int Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var id = this.NextId;
            this.All.Add(id, item);

            return id;
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
