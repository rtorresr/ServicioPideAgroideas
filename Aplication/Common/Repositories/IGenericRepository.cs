using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Common.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        public Task<TEntity> Add(TEntity entity);
        public Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> list);
        public Task<TEntity> Update(TEntity entity);
        public Task<TEntity> Delete(TEntity entity);
        public Task<IEnumerable<TEntity>> DeleteRange(IEnumerable<TEntity> list);
        public Task<TEntity> GetById(int id);
        public Task<List<TEntity>> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
            );

        public Task<PaginatedListEntity<TEntity>> GetAllPaginanted(
            int page,
            int size,
            dynamic entity = null,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
            );
    }
}
