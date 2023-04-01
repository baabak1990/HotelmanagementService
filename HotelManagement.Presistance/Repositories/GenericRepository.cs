using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Presistance.Context;
using Hotelmanagment.Application.Contract.Repository;
using Hotlemanagment.Domain.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using X.PagedList;

namespace HotelManagement.Presistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DefaultContext _context;
        private readonly DbSet<T> _db;


        public GenericRepository(DefaultContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }



        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>,
                IOrderedQueryable<T>> orderby = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var IncludeProperty in includes)
                {
                    query = query.Include(IncludeProperty);
                }
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            return await query.AsNoTracking().ToListAsync();

        }

        public async Task<IPagedList<T>> GetAllWithPaging(RequestParams requestParams, List<string> includes = null)
        {
            IQueryable<T> query = _db;


            if (includes != null)
            {
                foreach (var IncludeProperty in includes)
                {
                    query = query.Include(IncludeProperty);
                }
            }

            return await query.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.pageSize);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if (includes != null)
            {
                foreach (var IncludeProperty in includes)
                {
                    query = query.Include(IncludeProperty);
                }
            }

            var entity = await query.AsNoTracking().FirstOrDefaultAsync(expression);
            return entity;
        }

        public void UpdateAsync(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task Add(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }
    }
}
