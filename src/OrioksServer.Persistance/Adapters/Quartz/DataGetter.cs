using OrioksDecorator;
using OrioksDecorator.Models.ScheduleNoApi;
using OrioksServer.Abstractions.Entities;
using OrioksServer.Abstractions.Ports.Quartz;
using OrioksServer.Persistance.Adapters.Quartz.Mappings;

namespace OrioksServer.Persistance.Adapters.Quartz
{
    /// <inheritdoc cref="IDataGetter"/>
    internal sealed class DataGetter : IDataGetter
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<ScheduleEntity>> GetSchedules()
        {
            var client = await OrioksClient.Instance(new OrioksAccount());
            var groupKeys = await client.ScheduleNoApi.GetGroupKeys();

            var schedules = new List<ScheduleEntity>();

            foreach (var groupKey in groupKeys)
            {
                var schedule = await client.ScheduleNoApi.GetDisciplineScheduleItemsAsync(groupKey);
                schedules.AddRange(EntityMapper.MapSchedule(schedule));
            }

            return schedules;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<TeacherEntity>> GetTeachers()
        {
            throw new NotImplementedException();
        }
    }
}
