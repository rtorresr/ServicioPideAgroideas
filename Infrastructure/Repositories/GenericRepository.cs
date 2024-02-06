using Aplication.Common.Repositories;
using Application.Common.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public IApplicationDbContext _context { get; }
        public GenericRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync(default);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> list)
        {
            _context.Set<TEntity>().AddRange(list);
            list.ToList().ForEach(i => _context.Entry(i).State = EntityState.Added);
            await _context.SaveChangesAsync(default);
            return list;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(default);
            return entity;
        }

        public virtual async Task<TEntity> Delete(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync(default);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> DeleteRange(IEnumerable<TEntity> list)
        {
            _context.Set<TEntity>().AttachRange(list);
            list.ToList().ForEach(i => _context.Entry(i).State = EntityState.Deleted);
            await _context.SaveChangesAsync(default);
            return list;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
            )
        {

            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeTable in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeTable);
            }

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            else
                return await query.ToListAsync();

        }

        public virtual async Task<PaginatedListEntity<TEntity>> GetAllPaginanted(
            int page, 
            int size,
            dynamic entity = null,
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = "")
        {
            var resultado = new PaginatedListEntity<TEntity>();

            IQueryable <TEntity> query = _context.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeTable in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeTable);
            }

            resultado.Total = await query.CountAsync();

            if (orderBy != null)
                orderBy(query);

            resultado.Data = await query.Skip(page).Take(size).ToListAsync();

            return resultado;
        }
    }
}
