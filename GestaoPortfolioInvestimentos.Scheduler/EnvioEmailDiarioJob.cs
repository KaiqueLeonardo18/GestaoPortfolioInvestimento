using GestaoPortfolioInvestimentos.Application.Interfaces;
using GestaoPortfolioInvestimentos.Application.Services;
using GestaoPortfolioInvestimentos.Scheduler.Helpers;
using GestaoPortfolioInvestimentos.Scheduler.Service;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPortfolioInvestimentos.Scheduler
{
    public class EnvioEmailDiarioJob : IJob
    {

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job executed at " + DateTime.Now);
            Worker();
            await Task.CompletedTask;
        }

        public async void Worker()
        {
            using HttpClient client = new HttpClient();

            HttpService clientService = new HttpService(client, "http://localhost:7095/");

            EnvioEmailService service = new EnvioEmailService(clientService);
            service.EnvioEmail();

        }
    }
}
