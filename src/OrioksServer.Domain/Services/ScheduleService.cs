using OrioksServer.Abstractions.Entities;
using OrioksServer.Abstractions.Ports;
using OrioksServer.Domain.IServices;
using System.Linq.Expressions;

namespace OrioksServer.Domain.Services
{
    /// <inheritdoc cref="IScheduleService"/>
    internal sealed class ScheduleService : IScheduleService
    {
        private IUnitOfWork _unitOfWork = default!;

        /// <inheritdoc cref="ScheduleService"/>
        public ScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <inheritdoc/>
        public void Add(ScheduleEntity entity)
        {
            _unitOfWork.Schedules.Add(entity);
            _unitOfWork.Schedules.Save();
        }

        /// <inheritdoc/>
        public ScheduleEntity Find(int id)
        {
            return _unitOfWork.Schedules.Find(id);
        }

        /// <inheritdoc/>
        public IEnumerable<string> FindEmptyRooms(int time)
        {
            //  TODO : IMPLEMENT THIS using afficient way (flyweight, for example)
            var semesterStart = DateTime.Parse("2019-02-11");
            var delta = DateTime.Today - semesterStart;
            var currentWeek = (delta.Days / 7) + 1;
            var n = (currentWeek - 1) % 4;

            var today = DateTime.Today.DayOfWeek;

            var takenAuditories = GetAll(x => DayOfWeek(x.Day) == today && x.DayNumber == n && DateTime.Now <= x.TimeTo && DateTime.Now >= x.TimeFrom).Select(x => x.Auditory).Distinct();
            var auditories = GetAll().Select(x => x.Auditory).Distinct().Where(x => !takenAuditories.Contains(x));

            return auditories ?? default!;
        }

        DayOfWeek DayOfWeek(int day) => day switch
        {
            1 => System.DayOfWeek.Monday,
            2 => System.DayOfWeek.Tuesday,
            3 => System.DayOfWeek.Wednesday,
            4 => System.DayOfWeek.Thursday,
            5 => System.DayOfWeek.Friday,
            6 => System.DayOfWeek.Saturday,
            7 => System.DayOfWeek.Sunday,
            _ => throw new NotImplementedException()
        };

        /// <inheritdoc/>
        public ScheduleEntity FirstOrDefault(Expression<Func<ScheduleEntity, bool>>? filter = null, string includeProperties = null!, bool isTracking = true)
        {
            return _unitOfWork.Schedules.FirstOrDefault(filter, includeProperties, isTracking);
        }

        /// <inheritdoc/>
        public IEnumerable<ScheduleEntity> GetAll(Expression<Func<ScheduleEntity, bool>>? filter = null, Func<IQueryable<ScheduleEntity>, IOrderedQueryable<ScheduleEntity>>? orderBy = null, string includeProperties = null!, bool isTracking = true)
        {
            return _unitOfWork.Schedules.GetAll(filter, orderBy, includeProperties, isTracking);
        }

        /// <inheritdoc/>
        public void Remove(ScheduleEntity entity)
        {
            _unitOfWork.Schedules.Remove(entity);
            _unitOfWork.Schedules.Save();
        }

        /// <inheritdoc/>
        public void RemoveRange(IEnumerable<ScheduleEntity> entity)
        {
            _unitOfWork.Schedules.RemoveRange(entity);
            _unitOfWork.Schedules.Save();
        }
    }
}
