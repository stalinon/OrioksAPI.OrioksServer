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
        public void Add(TeacherEntity entity)
        {
            _unitOfWork.Teachers.Add(entity);
            _unitOfWork.Teachers.Save();
        }

        /// <inheritdoc/>
        public TeacherEntity Find(int id)
        {
            return _unitOfWork.Teachers.Find(id);
        }

        /// <inheritdoc/>
        public TeacherEntity FindByName(string name)
        {
            return GetAll(x => x.Name == name).FirstOrDefault()!;
        }

        /// <inheritdoc/>
        public TeacherEntity FirstOrDefault(Expression<Func<TeacherEntity, bool>>? filter = null, string includeProperties = null!, bool isTracking = true)
        {
            return _unitOfWork.Teachers.FirstOrDefault(filter, includeProperties, isTracking);
        }

        /// <inheritdoc/>
        public IEnumerable<TeacherEntity> GetAll(Expression<Func<TeacherEntity, bool>>? filter = null, Func<IQueryable<TeacherEntity>, IOrderedQueryable<TeacherEntity>>? orderBy = null, string includeProperties = null!, bool isTracking = true)
        {
            return _unitOfWork.Teachers.GetAll(filter, orderBy, includeProperties, isTracking);
        }

        /// <inheritdoc/>
        public void Remove(TeacherEntity entity)
        {
            _unitOfWork.Teachers.Remove(entity);
            _unitOfWork.Teachers.Save();
        }

        /// <inheritdoc/>
        public void RemoveRange(IEnumerable<TeacherEntity> entity)
        {
            _unitOfWork.Teachers.RemoveRange(entity);
            _unitOfWork.Teachers.Save();
        }
    }
}
