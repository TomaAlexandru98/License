using System;
using System.Collections.Generic;
using System.Text;
using License.DataAccess.Infrastructure;

namespace License.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly LicenseDbContext _dbContext;

        public BaseRepository(LicenseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> list)
        {
            _dbContext.Set<T>().AddRange(list);
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> list)
        {
            _dbContext.Set<T>().RemoveRange(list);
        }
    }
}
