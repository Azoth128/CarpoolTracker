using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace CarpoolTracker.Services
{
    internal class EfDataStoreConnector<T> : IDataStore<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;

        public EfDataStoreConnector(DbSet<T> dbSet, DbContext dbContext)
        {
            this.dbSet = dbSet;
            this.dbContext = dbContext;
        }

        public Task<bool> AddAsync(T t)
        {
            throw new NotImplementedException();

            //try
            //{
            //    var newT = dbSet.Add(t);
            //    dbContext.SaveChanges();
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public Task<bool> DeleteAsync(T t)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetListAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T t)
        {
            throw new NotImplementedException();
        }
    }
}