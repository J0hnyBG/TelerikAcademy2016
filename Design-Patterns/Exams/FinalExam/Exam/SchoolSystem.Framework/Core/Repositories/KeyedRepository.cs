using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Repositories
{
    public class KeyedRepository<T> : IKeyedRepository<T>
    {
        public KeyedRepository()
        {
            this.All = new Dictionary<int, T>();
        }

        public int NextId
        {
            get
            {
                if (this.All.Count > 0)
                {
                    return this.All.Keys.Max() + 1;
                }

                return 0;
            }
        }

        private IDictionary<int, T> All { get; }

        public T GetById(int id)
        {
            return this.All[id];
        }

        public void Add(T item)
        {
            this.All.Add(this.NextId, item);
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
