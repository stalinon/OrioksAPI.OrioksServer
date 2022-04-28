using Microsoft.Extensions.DependencyInjection;
using OrioksServer.Abstractions.Ports;
using Quartz;

namespace OrioksServer.Persistance.Adapters.Quartz
{
    /// <summary>
    ///     Класс Quartz'a, реализующий
    ///     получение данных
    /// </summary>
    public class DataJob : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        /// <inheritdoc cref="DataJob"/>
        public DataJob(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var uof = scope.ServiceProvider.GetService<IUnitOfWork>()!;
                var dataGetter = new DataGetter();

                var teachers = await dataGetter.GetTeachers();
                var schedules = await dataGetter.GetSchedules();

                foreach (var item in teachers)
                {
                    uof.Teachers.Add(item);
                }

                foreach (var item in schedules)
                {
                    uof.Schedules.Add(item);
                }
                
                uof.Teachers.Save();
                uof.Schedules.Save();
            }
        }
    }
}
