using System.Collections.Generic;
using System.Threading.Tasks;
namespace Project.Infrastructure.Dapper
{
    public partial interface IDapperRepository<T> where T : class, new()
    {
        Task<IEnumerable<T>> SelectAllAsync();
        Task<T> SelectAsync(long id);
        Task<long> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}