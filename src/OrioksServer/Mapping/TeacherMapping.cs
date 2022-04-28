using OrioksServer.Abstractions.Entities;
using OrioksServer.Models.Teacher;

namespace OrioksServer.Mapping
{
    /// <summary>
    ///     Мэппинг для <see cref="TeacherModel"/>
    /// </summary>
    internal static class TeacherMapping
    {
        public static TeacherModel? Map(TeacherEntity? entity)
        {
            if (entity == null) return default;

            var model = new TeacherModel
            {
                Auditory = entity.Auditory,
                Degree = entity.Degree,
                Biography = entity.Biography,
                Chapter = entity.Chapter,
                Courses = entity.Courses,
                Email = entity.Email,
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Position = entity.Position,
                Science = entity.Science
            };

            return model;
        }

        public static TeacherListModel? Map(IEnumerable<TeacherEntity>? entities)
        {
            if (entities == null) return default;

            var model = new TeacherListModel
            {
                Items = entities.Select(Map).ToArray(),
                TotalCount = entities.Count()
            };

            return model;
        }
    }
}
