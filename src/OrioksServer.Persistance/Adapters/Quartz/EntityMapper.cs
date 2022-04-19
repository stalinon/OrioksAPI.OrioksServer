using OrioksDecorator.Models.ScheduleNoApi;
using OrioksDecorator.Models.Teacher;
using OrioksServer.Abstractions.Entities;

namespace OrioksServer.Adapters.Quartz
{
    /// <summary>
    ///     Маппинг к сущностям
    /// </summary>
    internal static class EntityMapper
    {
        /// <summary>
        ///     Маппинг расписаний
        /// </summary>
        public static ScheduleEntity[] MapSchedule(DisciplineSchedule schedule)
        {
            var entities = new List<ScheduleEntity>();

            foreach (var data in schedule.Data)
            {
                entities.Add(new ScheduleEntity
                {
                    TimeFrom = DateTime.Parse(data.Time.TimeFrom),
                    TeacherName = data.Class.TeacherFull,
                    Auditory = data.Room.Name,
                    Day = data.Day,
                    DayNumber = data.DayNumber,
                    ClassName = data.Class.Name,
                    GroupKey = data.Group.Name,
                    Semester = schedule.Semestr,
                    Time = data.Time.Time,
                    TimeTo = DateTime.Parse(data.Time.TimeTo)
                });
            }

            return entities.ToArray();
        }

        /// <summary>
        ///     Маппинг преподавателей
        /// </summary>
        public static TeacherEntity MapTeacher(Teacher teacher)
        {
            var entity = new TeacherEntity
            {
                Auditory = teacher.Auditory,
                Biography = teacher.Biography,
                Chapter = teacher.Chapter,
                Courses = teacher.Courses,
                Email = teacher.Email,
                Degree = teacher.Degree,
                ImageUrl = teacher.ImageUrl,
                Name = teacher.Name,
                PhoneNumber = teacher.PhoneNumber,
                Position = teacher.Position,
                Science = teacher.Science
            };

            return entity;
        }
    }
}
