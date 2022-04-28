using Microsoft.EntityFrameworkCore;
using OrioksServer.Abstractions.Ports.Repositories;
using System.Linq.Expressions;

namespace OrioksServer.Persistance.Adapters.Database.Repositories
{
    /// <inheritdoc cref="IRepository{T}"/>
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;

        internal DbSet<T> dbSet;

        /// <inheritdoc cref="Repository{T}"/>
        public Repository(AppDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        /// <inheritdoc/>
        public virtual void Add(T entity)
        {
            if (!Contains(entity))
                dbSet.Add(entity);
        }

        /// <inheritdoc/>
        public virtual bool Contains(T entity)
        {
            return FirstOrDefault(x => x.Equals(entity)) != default;
        }

        /// <inheritdoc/>
        public T Find(int id)
        {
            return dbSet.Find(id) ?? default!;
        }

        /// <inheritdoc/>
        public T FirstOrDefault(Expression<Func<T, bool>>? filter = null, string includeProperties = null!, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return query.FirstOrDefault() ?? default!;
        }

        /// <inheritdoc/>
        public IEnumerable<T>? GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = null!, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return query.Count() != 0 ? query.ToList() : default;
        }

        /// <inheritdoc/>
        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        /// <inheritdoc/>
        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        /// <inheritdoc/>
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
