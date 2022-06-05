using Microsoft.EntityFrameworkCore;
using OrioksServer.Abstractions.Ports.Repositories;
using System.Linq.Expressions;

namespace OrioksServer.Persistance.Adapters.Database.Repositories;

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
    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (!(await ContainsAsync(entity, cancellationToken)))
        {
            await dbSet.AddAsync(entity, cancellationToken);
        }
    }

    /// <inheritdoc/>
    public virtual async Task<bool> ContainsAsync(T entity, CancellationToken cancellationToken = default)
    {
        return (await FirstOrDefaultAsync(x => x.Equals(entity), cancellationToken: cancellationToken)) != default;
    }

    /// <inheritdoc/>
    public async Task<T> FindAsync(int id, CancellationToken cancellationToken = default)
    {
        return await dbSet.FindAsync(new object?[] { id }, cancellationToken: cancellationToken) ?? default!;
    }

    /// <inheritdoc/>
    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null,
                                             string includeProperties = null!,
                                             bool isTracking = true,
                                             CancellationToken cancellationToken = default)
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

        return await query.FirstOrDefaultAsync(cancellationToken) ?? default!;
    }

    /// <inheritdoc/>
    public IEnumerable<T>? GetAll(Expression<Func<T, bool>>? filter = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                  string includeProperties = null!, bool isTracking = true)
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

        return query.Any() ? query.ToList() : default;
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
    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }
}
