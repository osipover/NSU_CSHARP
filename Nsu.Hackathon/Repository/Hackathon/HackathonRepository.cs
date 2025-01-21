using Microsoft.EntityFrameworkCore;
using Nsu.HackathonProblem.Database;
using Nsu.HackathonProblem.Model.Entity;
using Nsu.HackathonProblem.Model.Dto;


namespace Nsu.HackathonProblem.Repository;

public class HackathonRepository(HackathonDB context)
    : IHackathonRepository
{
    public void SaveHackathon(Hackathon hackathon)
    {
        Console.WriteLine($"Hackathon: {hackathon}");
        context.Hackathons.Add(hackathon);
        context.SaveChanges();
    }

    public Hackathon GetHackathonById(int hackathonId)
    {
        return context.Hackathons
            .Include(h => h.Teams)
            .FirstOrDefault(h => h.Id == hackathonId);
    }

    public IEnumerable<Hackathon> GetAllHackathons()
    {
        return context.Hackathons.ToList();
    }

    public double CalculateAverageHarmony()
    {
        var harmonies = context.Hackathons
            .Select(h => h.Harmony)
            .ToList();

        return harmonies.DefaultIfEmpty(0).Average(h => (double)h);
    }
}