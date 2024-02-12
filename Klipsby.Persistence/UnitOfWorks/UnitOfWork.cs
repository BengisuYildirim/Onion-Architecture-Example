using Klipsby.Application.Interfaces.Repositories;
using Klipsby.Application.Interfaces.UnitOfWorks;
using Klipsby.Persistence.Context;
using Klipsby.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klipsby.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KlipsbyDbContext _klipsbyDbContext;

        public UnitOfWork(KlipsbyDbContext _klipsbyDbContext)
        {
            this._klipsbyDbContext = _klipsbyDbContext;
        }
        public async ValueTask DisposeAsync() => await _klipsbyDbContext.DisposeAsync();
        
        public int Save() => _klipsbyDbContext.SaveChanges();

        public async Task<int> SaveAsync() => await _klipsbyDbContext.SaveChangesAsync();
        


        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_klipsbyDbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_klipsbyDbContext);
    }
}
