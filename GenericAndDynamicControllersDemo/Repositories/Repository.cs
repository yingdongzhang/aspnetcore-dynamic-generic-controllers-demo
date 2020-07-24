using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAndDynamicControllersDemo.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly Dictionary<Guid, T> store = new Dictionary<Guid, T>();

        public IEnumerable<T> GetAll() => store.Values;

        public T GetById(Guid id)
        {
            return store.FirstOrDefault(x => x.Key == id).Value;
        }

        public void AddOrUpdate(Guid id, T item)
        {
            store[id] = item;
        }
    }
}
