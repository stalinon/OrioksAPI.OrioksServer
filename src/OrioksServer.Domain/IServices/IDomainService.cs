using System.Linq.Expressions;

namespace OrioksServer.Domain.IServices
{
    /// <summary>
    ///     Основа доменных сервисов
    /// </summary>
    public interface IDomainService<T> where T : class
    {
        /// <summary>
        ///     Найти по id
        /// </summary>
        T Find(int id);

        /// <summary>
        ///     Получить все объекты
        /// </summary>
        /// <param name="filter">Фильтр</param>
        /// <param name="orderBy">Порядок вывода</param>
        /// <param name="includeProperties">Включение параметров</param>
        /// <param name="isTracking">Отслеживание запроса</param>
        IEnumerable<T> GetAll(
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
        T FirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string includeProperties = null!,
            bool isTracking = true
            );

        /// <summary>
        ///     Добавить объект
        /// </summary>
        void Add(T entity);

        /// <summary>
        ///     Удалить объект
        /// </summary>
        void Remove(T entity);

        /// <summary>
        ///     Удалить несколько объектов
        /// </summary>
        void RemoveRange(IEnumerable<T> entity);
    }
}
