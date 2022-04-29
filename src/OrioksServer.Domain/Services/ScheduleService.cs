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
        public async Task AddAsync(ScheduleEntity entity, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Schedules.AddAsync(entity, cancellationToken);
            await _unitOfWork.Schedules.SaveAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ScheduleEntity> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Schedules.FindAsync(id, cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<ScheduleEntity> FirstOrDefaultAsync(Expression<Func<ScheduleEntity, bool>>? filter = null, 
                                                              string includeProperties = null!, 
                                                              bool isTracking = true, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Schedules.FirstOrDefaultAsync(filter, includeProperties, isTracking, cancellationToken);
        }

        /// <inheritdoc/>
        public IEnumerable<ScheduleEntity>? GetAll(Expression<Func<ScheduleEntity, bool>>? filter = null, 
                                                   Func<IQueryable<ScheduleEntity>, IOrderedQueryable<ScheduleEntity>>? orderBy = null, 
                                                   string includeProperties = null!, bool isTracking = true)
        {
            return _unitOfWork.Schedules.GetAll(filter, orderBy, includeProperties, isTracking);
        }

        /// <inheritdoc/>
        public async Task RemoveAsync(ScheduleEntity entity, CancellationToken cancellationToken = default)
        {
            _unitOfWork.Schedules.Remove(entity);
            await _unitOfWork.Schedules.SaveAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task RemoveRangeAsync(IEnumerable<ScheduleEntity> entity, CancellationToken cancellationToken = default)
        {
            _unitOfWork.Schedules.RemoveRange(entity);
            await _unitOfWork.Schedules.SaveAsync(cancellationToken);
        }
    }
}
