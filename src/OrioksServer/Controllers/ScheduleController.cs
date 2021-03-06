using Microsoft.AspNetCore.Mvc;
using OrioksServer.Abstractions.Entities;
using OrioksServer.Abstractions.Ports;
using OrioksServer.Domain.IServices;
using OrioksServer.Mapping;
using OrioksServer.Models.Schedule;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq.Expressions;

namespace OrioksServer.Controllers;

/// <summary>
///     Контроллер расписаний
/// </summary>
[ApiController]
[SwaggerTag("Расписания")]
[Route("~/v1/schedules")]
public sealed class ScheduleController : Controller
{
    private readonly IDomainServiceFactory _serviceFactory;
    private readonly IUnitOfWork _unitOfWork;

    /// <inheritdoc cref="TeacherController"/>
    public ScheduleController(IDomainServiceFactory serviceFactory,
                             IUnitOfWork unitOfWork)
    {
        _serviceFactory = serviceFactory;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    ///     Получить расписание
    /// </summary>
    [HttpGet("")]
    [SwaggerOperation(OperationId = "ListSchedule")]
    [ProducesResponseType(typeof(ScheduleListModel), 200)]
    public IActionResult List([FromQuery] ScheduleRequest request)
    {
        var service = _serviceFactory.CreateScheduleService(_unitOfWork);

        var date = DateOnly.Parse(request.Date ?? DateOnly.FromDateTime(DateTime.Today).ToString());
        var dayOfWeek = EnumMappings.MapDayOfWeek(date.DayOfWeek);
        var dayNumber = GetDayNumber(date);
        var className = request.Name ?? string.Empty;
        var teacherName = request.TeacherName ?? string.Empty;
        var groupKey = request.GroupKey ?? string.Empty;

        var filter = GetFilter(dayOfWeek, dayNumber, className, teacherName, groupKey);
        var entities = service.GetAll(filter)?.Where(x => EnumMappings.MapDayOfWeek(x.Day) == dayOfWeek);

        var model = ScheduleMapping.Map(entities);

        if (model == null || model.TotalCount == 0)
        {
            NotFound();
        }

        return Ok(model);

        static Expression<Func<ScheduleEntity, bool>> GetFilter(Models.Schedule.DayOfWeek dayOfWeek,
            int dayNumber,
            string className,
            string teacherName,
            string groupKey) => x => x.DayNumber == dayNumber && x.ClassName.Contains(className!) &&
                                x.TeacherName.Contains(teacherName!) && x.GroupKey.Trim() == groupKey;

    }

    /// <summary>
    ///     Получить пустые аудитории
    /// </summary>
    [HttpGet("empty-auditories")]
    [SwaggerOperation(OperationId = "ListEmptyAuditories")]
    [ProducesResponseType(typeof(EmptyAuditoriesListModel), 200)]
    public IActionResult EmptyAuditories()
    {
        var service = _serviceFactory.CreateScheduleService(_unitOfWork);

        var date = DateOnly.FromDateTime(DateTime.Today);
        var dayOfWeek = EnumMappings.MapDayOfWeek(date.DayOfWeek);
        var dayNumber = GetDayNumber(date);
        var nowTime = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(3));

        var filter = (Expression<Func<ScheduleEntity, bool>>)
            (x => x.DayNumber == dayNumber
                  && nowTime.IsBetween(TimeOnly.FromDateTime(x.TimeFrom), TimeOnly.FromDateTime(x.TimeTo)));

        var pairs = service.GetAll(filter)?
                           .Where(x => EnumMappings.MapDayOfWeek(x.Day) == dayOfWeek);

        var takenAuditories = pairs?.Select(x => x.Auditory)
                                    .Distinct();

        var entities = service
            .GetAll()?
            .Select(x => x.Auditory)
            .Distinct()
            .Where(x => takenAuditories == null || !takenAuditories.Contains(x));

        var model = new EmptyAuditoriesListModel
        {
            Items = entities?.ToArray() ?? Array.Empty<string>(),
            TotalCount = entities?.Count() ?? 0,
            Pair = pairs?.First().Time ?? null
        };

        if (model == null || model.TotalCount == 0)
        {
            NotFound();
        }

        return Ok(model);
    }

    /// <summary>
    ///     Получить расписание для группы
    /// </summary>
    [HttpGet("{groupKey}")]
    [SwaggerOperation(OperationId = "GroupSchedule")]
    [ProducesResponseType(typeof(ScheduleListModel), 200)]
    public IActionResult GetGroupsSchedule(string groupKey)
    {
        var service = _serviceFactory.CreateScheduleService(_unitOfWork);

        var entities = service.GetAll(x => x.GroupKey == groupKey);

        var model = ScheduleMapping.Map(entities);

        if (model == null || model.TotalCount == 0)
        {
            NotFound();
        }

        return Ok(model);
    }

    private static int GetDayNumber(DateOnly date)
    {
        var semesterStart = DateTime.Parse("2019-02-11");
        var delta = date.ToDateTime(TimeOnly.Parse("00:01 PM")) - semesterStart;
        var currentWeek = (delta.Days / 7) + 1;
        var dayNumber = (currentWeek - 1) % 4;

        return dayNumber;
    }
}
