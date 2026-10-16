using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : IPrimary
    {
        public abstract List<T> ReadAll();

        protected abstract void Save(List<T> items);

        public void Create(T item)
        {
            var items = ReadAll();
            items.Add(item);
            Save(items);
        }

        public T? Read(int id)
        {
            return ReadAll().Find(x => x.Id == id);
        }

        public void Update(T item)
        {
            var items = ReadAll();
            int index = items.FindIndex(x => x.Id == item.Id);

            if (index >= 0)
            {
                items[index] = item;
                Save(items);
            }
        }

        public void Delete(int id)
        {
            var items = ReadAll();
            items.RemoveAll(x => x.Id == id);
            Save(items);
        }
    }
}