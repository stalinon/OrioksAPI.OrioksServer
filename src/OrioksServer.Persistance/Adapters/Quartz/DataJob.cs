using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace OrioksServer.Persistance.Adapters.Quartz
{
    /// <summary>
    ///     Класс Quartz'a, реализующий
    ///     получение данных
    /// </summary>
    internal class DataJob : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public DataJob(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {

            }
        }
    }
}
