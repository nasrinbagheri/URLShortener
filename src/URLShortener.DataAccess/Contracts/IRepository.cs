using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace URLShortener.DataAccess.Contracts
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> Table { get; }
    }
}
