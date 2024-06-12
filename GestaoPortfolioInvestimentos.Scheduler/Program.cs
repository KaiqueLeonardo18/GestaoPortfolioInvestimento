using Quartz.Impl;
using Quartz;
using GestaoPortfolioInvestimentos.Scheduler;

ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
IScheduler scheduler = await schedulerFactory.GetScheduler();

IJobDetail job = JobBuilder.Create<EnvioEmailDiarioJob>()
    .WithIdentity("meuJob", "grupoJobs")
    .Build();

ITrigger trigger = TriggerBuilder.Create()
    .WithIdentity("meuTrigger", "grupoTriggers")
    .StartNow()
    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(17, 15))
    .Build();

await scheduler.ScheduleJob(job, trigger);
await scheduler.Start();

Console.WriteLine("Pressione qualquer tecla para sair...");
Console.ReadKey();

await scheduler.Shutdown();