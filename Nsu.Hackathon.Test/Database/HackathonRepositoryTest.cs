using Xunit;
using Microsoft.EntityFrameworkCore;
using Nsu.HackathonProblem.Database;
using Nsu.HackathonProblem.Model.Entity;
using Nsu.HackathonProblem.Repository;

namespace Nsu.HackathonProblem.Test.Database;

public class HackathonRepositoryTests
{
    private readonly HackathonDB _context = null;
    private readonly IHackathonRepository _repository = null;

    public HackathonRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<HackathonDB>()
            .UseSqlite("DataSource=:memory:")
            .Options;

        _context = new HackathonDB(options);
        _context.Database.OpenConnection();
        _context.Database.EnsureCreated();
        _repository = new HackathonRepository(_context);
    }

    [Fact]
    public void SaveHackathon_ShouldSave()
    {
        var hackathon = new Hackathon { Harmony = 10.0m };

        _repository.Save(hackathon);

        var savedHackathon = _repository.FindById(hackathon.Id);
        Assert.NotNull(savedHackathon);
        Assert.Equal(hackathon.Harmony, savedHackathon.Harmony);
    }

    [Fact]
    public void FindById_ShouldReturnEntity()
    {
        var team1 = new Team { TeamLeadId = 1, JuniorId = 2 };
        var team2 = new Team { TeamLeadId = 10, JuniorId = 20 };

        var hackathon = new Hackathon { 
            Harmony = 15.0m,
            Teams = new List<Team> { team1, team2 }
        };

        _repository.Save(hackathon);

        var savedHackathon = _repository.FindById(hackathon.Id);

        Assert.NotNull(savedHackathon);
        Assert.Equal(hackathon.Harmony, savedHackathon.Harmony);
        Assert.Equal(hackathon.Id, savedHackathon.Id);
        Assert.Equal(hackathon.Teams.Count, savedHackathon.Teams.Count);
        Assert.Equal(team1.TeamLeadId, savedHackathon.Teams[0].TeamLeadId);
        Assert.Equal(team1.JuniorId, savedHackathon.Teams[0].JuniorId);
        Assert.Equal(team2.TeamLeadId, savedHackathon.Teams[1].TeamLeadId);
        Assert.Equal(team2.JuniorId, savedHackathon.Teams[1].JuniorId);
    }

    [Fact]
    public void CalculateAverageHarmony_ShouldReturnsAverageHarmony()
    {
        var hackathons = new List<Hackathon>
        {
            new Hackathon { Harmony = 10.0m },
            new Hackathon { Harmony = 20.0m }
        };

        foreach (var hackathon in hackathons)
        {
            _repository.Save(hackathon);
        }


        var averageHarmony = _repository.CalculateAverageHarmony();

        Assert.Equal(15.0d, averageHarmony);
    }
}