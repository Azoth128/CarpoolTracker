using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolTracker.Models;

namespace CarpoolTracker.Services
{
    public class MockDataStore<T> : IDataStore<T> where T : IDataModel, new()
    {
        protected List<T> items;

        public MockDataStore() {
            var t = new T();
            if (t.GetType().GetInterfaces().Any(x =>
            {
                return x.IsGenericType
                    && x.GetGenericTypeDefinition() == typeof(IHasDefaults<>);
            })) {
                items = (t as IHasDefaults<T>).DefaultValues();
            };
        }

        public async Task<bool> AddItemAsync(T t)
        {
            items.Add(t);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(T t)
        {
            var oldItem = items.Where(arg => arg.Id == t.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(t);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where(arg => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}