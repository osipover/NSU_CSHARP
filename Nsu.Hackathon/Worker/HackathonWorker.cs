
using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Nsu.HackathonProblem.Workers
{

    class HackathonWorker(
        IOptions<Configuration> config,
        HRDirector hrDirector,
        IEmployeeProvider employeeProvider
    ) : IHostedService
    {    
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var juniors = employeeProvider.GetEmployees(config.Value.JuniorsPath);
            var teamLeads = employeeProvider.GetEmployees(config.Value.TeamleadsPath);
            hrDirector.OrganizeHackathon(config.Value.NumRounds, juniors, teamLeads);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
    
    
}