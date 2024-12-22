
using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Workers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

class Program 
{
    static void Main(string[] args) 
    {
        using var host = Host.CreateDefaultBuilder(args)
        
            .ConfigureServices((context, services) =>
            {
                services.Configure<Configuration>(context.Configuration.GetSection("Hackathon"));

                services.AddHostedService<HackathonWorker>();

                services.AddTransient<IEmployeeProvider, CsvEmployeeReader>();
                services.AddTransient<IWishlistProvider, RandomWishlistProvider>();
                services.AddTransient<ITeamBuildingStrategy, TeamBuildingStrategy>();
                services.AddTransient<IRatingService, RatingService>();

                services.AddTransient<HRManager>();
                services.AddTransient<HRDirector>();
            })
            .Build();

        host.Run();
    }
}
