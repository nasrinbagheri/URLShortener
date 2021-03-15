using System;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortener.DataAccess.Contracts
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> Table { get; }
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
