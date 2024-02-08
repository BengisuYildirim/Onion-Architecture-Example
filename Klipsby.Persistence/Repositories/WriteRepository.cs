using Klipsby.Application.Interfaces.Repositories;
using Klipsby.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klipsby.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;
        public WriteRepository(DbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        private DbSet<T> _dbSet { get => dbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
            return entity;
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => _dbSet.Remove(entity));
        }

        //public async Task SoftDeleteAsync(T entity)
        //{
        //    await Task.Run(() => _dbSet.Update(entity));
        //}

        
    }
}
