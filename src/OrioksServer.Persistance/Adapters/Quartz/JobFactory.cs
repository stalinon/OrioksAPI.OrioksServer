using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace OrioksServer.Persistance.Adapters.Quartz;

public class JobFactory : IJobFactory
{
    protected readonly IServiceScopeFactory _serviceScopeFactory;

    public JobFactory(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var job = scope.ServiceProvider.GetService(bundle.JobDetail.JobType) as IJob;
        return job ?? default!;

    }

    public void ReturnJob(IJob job)
    {

    }
}
