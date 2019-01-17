using System.Collections.Generic;

namespace Project.Infrastructure.Dapper
{
    public partial interface IDapperRepository<T> where T : class, new()
    {
        IEnumerable<T> SelectAll();
        T Select(long id);
        long Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}