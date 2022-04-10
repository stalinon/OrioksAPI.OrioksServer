using OrioksServer.Abstractions.Entities;

namespace OrioksServer.Domain.IServices
{
    /// <summary>
    ///     Доменный сервис преподавателей
    /// </summary>
    public interface ITeacherService : IDomainService<TeacherEntity>
    {
        /// <summary>
        ///     Найти преподавателя по его 
        ///     полному имени
        /// </summary>
        TeacherEntity FindByName(string name);
    }
}
