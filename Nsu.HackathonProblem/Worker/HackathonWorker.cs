
using Nsu.HackathonProblem.Model.Dto;
using Nsu.HackathonProblem.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Nsu.HackathonProblem.Workers
{

    class HackathonWorker(
        IOptions<Configuration> config,
        HackathonService hackathonManager,
        IEmployeeProvider employeeProvider,
        EmployeeService employeeService
    ) : IHostedService
    {    
        public Task StartAsync(CancellationToken cancellationToken)
        {
            StartCLI();
            return Task.CompletedTask;
        }

        private void StartCLI()
        {
            while(true)
            {
                Console.WriteLine("Press 1 to organize hackathon");
                Console.WriteLine("Press 2 to get hackathon info");
                Console.WriteLine("Press 3 to get average harmony");
                Console.WriteLine("Press 4 to exit");
                Console.Write("Enter: ");
                string? command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        OrganizeHackathons(config.Value.NumRounds);
                        break;
                    case "2":
                        DisplayHackathonInfo();
                        break;
                    case "3":
                        DisplayAverageHarmony();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }                
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OrganizeHackathons(int numOfHackathons) 
        {
            employeeService.SaveEmployeesFromCsv(config.Value.JuniorsPath, config.Value.TeamleadsPath);
            var juniors = employeeService.GetJuniors();
            var teamleads = employeeService.GetTeamLeads();
            for (int i = 0; i < numOfHackathons; ++i) 
            {
                hackathonManager.Start(juniors, teamleads);
            }
        }

        private void DisplayHackathonInfo()
        {
            Console.Write("Enter hackaton ID: ");
            string? idStr = Console.ReadLine();
            var isNumeric = int.TryParse(idStr, out int hackathonId);
            if (!isNumeric) 
            {
                Console.WriteLine("ID should be numeric");
                return;
            }
            DisplayHackathonById(hackathonId);
        }

        private void DisplayHackathonById(int id)
        {
            var hackathonInfo = hackathonManager.GetHackathonInfoById(id);
            if (hackathonInfo == null)
            {
                Console.WriteLine($"Hackathon with id = {id} does not exist");
                return;
            }
            Console.WriteLine($"Hackathon [id = {hackathonInfo.id}]");
            Console.WriteLine($"\tHarmony = {hackathonInfo.harmony}");
            var teams = hackathonInfo.teams;
            for (int i = 0; i < teams.Count; ++i)
            {
                Console.WriteLine($"\tTeam N{i+1} [id = {teams[i].teamId}]");
                Console.WriteLine($"\t\tJunior: {teams[i].juniorName} [id = {teams[i].juniorId}]");
                Console.WriteLine($"\t\tTeamlead: {teams[i].teamleadName} [id = {teams[i].teamleadId}]");
            }
        }

        private void DisplayAverageHarmony()
        {
            var averageHarmony = hackathonManager.CalculateAverageHarmony();
            Console.WriteLine($"Average harmony = {averageHarmony}");
        }
    }
    
}