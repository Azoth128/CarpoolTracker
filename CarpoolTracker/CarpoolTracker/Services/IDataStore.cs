using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarpoolTracker.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddAsync(T t);

        Task<bool> DeleteAsync(T t);

        Task<T> GetAsync(Guid id);

        Task<IEnumerable<T>> GetListAsync(bool forceRefresh = false);

        Task<bool> UpdateAsync(T t);
    }
}