
using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Database;
using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Repository;

using Microsoft.EntityFrameworkCore;
using Nsu.HackathonProblem.Workers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program 
{
    static void Main(string[] args) 
    {
        using var host = Host.CreateDefaultBuilder(args)
        
            .ConfigureServices((context, services) =>
            {
                services.Configure<Configuration>(context.Configuration.GetSection("Hackathon"));

                services.AddDbContext<HackathonDB>(options =>
                    options.UseNpgsql(context.Configuration.GetConnectionString("HackathonDB"))
                );

                services.AddHostedService<HackathonWorker>();

                services.AddTransient<IEmployeeProvider, CsvEmployeeReader>();
                services.AddTransient<IWishlistProvider, RandomWishlistProvider>();
                services.AddTransient<ITeamBuildingStrategy, TeamBuildingStrategy>();
                services.AddTransient<IRatingService, HarmonicMeanRatingService>();

                services.AddTransient<HRManager>();
                services.AddTransient<HRDirector>();
                
                services.AddTransient<HackathonService>();
                services.AddTransient<WishlistService>();
                services.AddTransient<EmployeeService>();

                services.AddTransient<IHackathonRepository, HackathonRepository>();
                services.AddTransient<IEmployeeRepository, EmployeeRepository>();
                services.AddTransient<IWishlistRepository, WishlistRepository>();
            })
            .Build();
            host.Run();    
    }
}
