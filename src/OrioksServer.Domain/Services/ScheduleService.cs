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
        public Task<ScheduleEntity> FindEmptyRooms(DateTime dateTime)
        {
            //  TODO : IMPLEMENT THIS
            throw new NotImplementedException();
        }

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
