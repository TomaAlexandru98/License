using System;
using System.Collections.Generic;
using System.Text;

namespace License.DataAccess.Infrastructure
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> list);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> list);

    }
}
