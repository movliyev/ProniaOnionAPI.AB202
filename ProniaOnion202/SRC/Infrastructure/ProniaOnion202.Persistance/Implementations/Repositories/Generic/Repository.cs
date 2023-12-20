using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Applicatin.Abstractions.Repositories;
using ProniaOnion202.Domain.Entities;
using ProniaOnion202.Persistance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {

            _context = context;
            _dbSet = context.Set<T>();
        }



        public IQueryable<T> GetAll(
            Expression<Func<T, bool>>? exp = null,
            Expression<Func<T, object>>? orderexp = null,
            bool isdesc = false,
            int skip = 0,
            int take = 0,
            bool istrac = false,
            params string[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (exp != null) query = query.Where(exp);
            if (orderexp != null)
            {
                if (isdesc) query = query.OrderByDescending(orderexp);
                else query = query.OrderBy(orderexp);
            }
            if (skip != 0) query = query.Skip(skip);
            if (take != 0) query = query.Take(take);
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return istrac ? query : query.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
