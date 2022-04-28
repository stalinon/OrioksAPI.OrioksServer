using Microsoft.AspNetCore.Mvc;
using OrioksServer.Abstractions.Ports;
using OrioksServer.Domain.IServices;
using OrioksServer.Mapping;
using OrioksServer.Models.Teacher;
using Swashbuckle.AspNetCore.Annotations;

namespace OrioksServer.Controllers
{
    /// <summary>
    ///     Контроллер преподавателей
    /// </summary>
    [ApiController]
    [SwaggerTag("Преподаватели")]
    [Route("~/v1/teachers")]
    public sealed class TeacherController : Controller
    {
        private readonly IDomainServiceFactory _serviceFactory;
        private readonly IUnitOfWork _unitOfWork;

        /// <inheritdoc cref="TeacherController"/>
        public TeacherController(IDomainServiceFactory serviceFactory,
                                 IUnitOfWork unitOfWork)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Получить список преподавателей
        /// </summary>
        [HttpGet("")]
        [SwaggerOperation(OperationId = "ListTeachers")]
        [ProducesResponseType(typeof(TeacherListModel), 200)]
        public IActionResult List([FromQuery] TeacherNameRequest request)
        {
            var service = _serviceFactory.CreateTeacherService(_unitOfWork);

            var entities = (request.Name == null) ? service.GetAll() : 
                service.GetAll(x => x.Name.Contains(request.Name));

            var model = TeacherMapping.Map(entities);
            return Ok(model);
        }
    }
}
