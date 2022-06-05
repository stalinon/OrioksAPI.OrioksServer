using System.Linq.Expressions;

namespace OrioksServer.Domain.IServices;

/// <summary>
///     Основа доменных сервисов
/// </summary>
public interface IDomainService<T> where T : class
{
    /// <summary>
    ///     Найти по id
    /// </summary>
    Task<T> FindAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Получить все объекты
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="orderBy">Порядок вывода</param>
    /// <param name="includeProperties">Включение параметров</param>
    /// <param name="isTracking">Отслеживание запроса</param>
    IEnumerable<T>? GetAll(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = null!,
        bool isTracking = true
        );

    /// <summary>
    ///     Получить первый или по умолчанию объект
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="includeProperties">Включение параметров</param>
    /// <param name="isTracking">Отслеживание запроса</param>
    Task<T> FirstOrDefaultAsync(
        Expression<Func<T, bool>>? filter = null,
        string includeProperties = null!,
        bool isTracking = true, CancellationToken cancellationToken = default
        );

    /// <summary>
    ///     Добавить объект
    /// </summary>
    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Удалить объект
    /// </summary>
    Task RemoveAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Удалить несколько объектов
    /// </summary>
    Task RemoveRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default);
}
