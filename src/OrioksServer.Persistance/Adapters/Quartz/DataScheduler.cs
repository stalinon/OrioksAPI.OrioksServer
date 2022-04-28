using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace OrioksServer.Persistance.Adapters.Quartz
{
    public static class DataScheduler
    {
        public static async void Start(IServiceProvider serviceProvider)
        {
            var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            scheduler.JobFactory = serviceProvider.GetService<IJobFactory>() ?? default!;
            await scheduler.Start();

            var jobDetail = JobBuilder.Create<DataJob>().Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("GettingDataTrigger", "default")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithInterval(TimeSpan.FromDays(7))
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
