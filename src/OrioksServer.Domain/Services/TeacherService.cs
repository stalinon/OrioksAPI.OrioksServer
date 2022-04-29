using OrioksServer.Abstractions.Entities;
using OrioksServer.Abstractions.Ports;
using OrioksServer.Domain.IServices;
using System.Linq.Expressions;

namespace OrioksServer.Domain.Services
{
    /// <inheritdoc cref="ITeacherService"/>
    internal sealed class TeacherService : ITeacherService
    {
        private IUnitOfWork _unitOfWork = default!;

        /// <inheritdoc cref="TeacherService"/>
        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <inheritdoc/>
        public async Task AddAsync(TeacherEntity entity, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.Teachers.AddAsync(entity, cancellationToken);
            await _unitOfWork.Teachers.SaveAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<TeacherEntity> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Teachers.FindAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<TeacherEntity> FirstOrDefaultAsync(Expression<Func<TeacherEntity, bool>>? filter = null, 
                                                             string includeProperties = null!, 
                                                             bool isTracking = true, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Teachers.FirstOrDefaultAsync(filter, includeProperties, isTracking, cancellationToken);
        }

        /// <inheritdoc/>
        public IEnumerable<TeacherEntity>? GetAll(Expression<Func<TeacherEntity, bool>>? filter = null, 
                                                  Func<IQueryable<TeacherEntity>, 
                                                  IOrderedQueryable<TeacherEntity>>? orderBy = null, 
                                                  string includeProperties = null!, 
                                                  bool isTracking = true)
        {
            return _unitOfWork.Teachers.GetAll(filter, orderBy, includeProperties, isTracking);
        }

        /// <inheritdoc/>
        public async Task RemoveAsync(TeacherEntity entity, CancellationToken cancellationToken = default)
        {
            _unitOfWork.Teachers.Remove(entity);
            await _unitOfWork.Teachers.SaveAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task RemoveRangeAsync(IEnumerable<TeacherEntity> entity, CancellationToken cancellationToken = default)
        {
            _unitOfWork.Teachers.RemoveRange(entity);
            await _unitOfWork.Teachers.SaveAsync(cancellationToken);
        }
    }
}
