using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Entry(Object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void Dispose();
    }
}