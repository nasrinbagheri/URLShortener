using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.DataAccess.Contracts;

namespace URLShortener.DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private IDbContext _context;
        private bool disposed;

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => _context.Set<T>();

        public async Task<T> GetByIdAsync(int id)
        {
            var result =await _context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var context = _context as DbContext;
            if (context.Entry(entity).State == EntityState.Detached)
                context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        #region dispos
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }
            _context = null;
            disposed = true;
        }
        #endregion



    }
}
