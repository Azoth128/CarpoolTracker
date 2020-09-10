using CarpoolTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolTracker.Services
{
    public class MockDataStore<T> : IDataStore<T> where T : IDataModel, new()
    {
        protected List<T> items;

        public MockDataStore()
        {
            var t = new T();
            if (t.GetType().GetInterfaces().Any(x =>
            {
                return x.IsGenericType
                    && x.GetGenericTypeDefinition() == typeof(IHasDefaults<>);
            }))
            {
                items = (t as IHasDefaults<T>).DefaultValues();
            };
        }

        public async Task<bool> AddAsync(T t)
        {
            items.Add(t);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(T t)
        {
            var oldItem = items.Where(arg => arg.Id == t.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(t);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = items.Where(arg => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetListAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}