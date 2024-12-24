
using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Nsu.HackathonProblem.Workers
{

    class HackathonWorker(
        IOptions<Configuration> config,
        Hackathon hackathon,
        IEmployeeProvider employeeProvider
    ) : IHostedService
    {    
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var juniors = employeeProvider.GetEmployees(config.Value.JuniorsPath);
            var teamLeads = employeeProvider.GetEmployees(config.Value.TeamleadsPath);
            OrganizeHackathons(config.Value.NumRounds, juniors, teamLeads);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OrganizeHackathons(int numOfHackathons, List<Employee> juniors, List<Employee> teamLeads) 
        {
            double totalHarmony = 0;
            for (int i = 0; i < numOfHackathons; ++i) {
                var harmony = hackathon.Start(juniors, teamLeads);
                Console.WriteLine($"HACKATHON №{i + 1}:\tharmony={harmony}");
                totalHarmony += harmony;
            }
            double averageHarmony = totalHarmony / numOfHackathons;
            Console.WriteLine($"Average harmony = {averageHarmony}");
        }
    }
    
    
}