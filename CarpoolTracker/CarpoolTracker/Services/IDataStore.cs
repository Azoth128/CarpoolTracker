using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarpoolTracker.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddAsync(T t);

        Task<bool> DeleteAsync(string id);

        Task<T> GetAsync(string id);

        Task<IEnumerable<T>> GetListAsync(bool forceRefresh = false);

        Task<bool> UpdateAsync(T t);
    }
}