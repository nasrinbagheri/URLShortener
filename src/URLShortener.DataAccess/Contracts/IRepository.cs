using System;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Domain;

namespace URLShortener.DataAccess.Contracts
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> Table { get; }
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
