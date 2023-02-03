﻿using HumanResourcesApp.Domain.Abstract;
using HumanResourcesApp.Domain.Repositories;
using HumanResourcesApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Infrastructure.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, IBaseEntity
    {
        private readonly HRDbContext _hrDbContext;
        protected DbSet<T> _table;

        public BaseRepo(HRDbContext hrDbContext)
        {
            _hrDbContext = hrDbContext;
            _table = _hrDbContext.Set<T>();
        }

     
        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public async Task Create(T entity)
        {
            await _table.AddAsync(entity);
            await _hrDbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            await _hrDbContext.SaveChangesAsync();
        }

        public async Task<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await _table.FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;

            if (where != null)
            {
                query = query.Where(where);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Select(select).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(select).FirstOrDefaultAsync();
            }
        }

        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;

            if (where != null)
            {
                query = query.Where(where);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Select(select).ToListAsync();
            }
            else
            {
                return await query.Select(select).ToListAsync();
            }
        }

        public async Task Update(T entity)
        {
            _hrDbContext.Entry<T>(entity).State = EntityState.Modified;
            await _hrDbContext.SaveChangesAsync();
        }
    }
}
