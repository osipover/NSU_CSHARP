namespace Nsu.Hackathon.Test;

using Nsu.HackathonProblem.Service;

public class TeamBuildingStrategyTest
{
    [Fact]
    public void BuildTeams_ReturnsTeams() 
    {
        var juniors = Examples.GetJuniors();
        var teamleads = Examples.GetTeamleads();
        var (juniorsWishlist, teamleadsWishlist) = Examples.GetWishlists();

        var teamBuildingStrategy = new TeamBuildingStrategy();

        var expectedTeams = Examples.GetTeams();
        var teams = teamBuildingStrategy.BuildTeams(juniors, teamleads, juniorsWishlist, teamleadsWishlist);

        Assert.Equal(expectedTeams[0].Junior.Id, teams[0].Junior.Id);
        Assert.Equal(expectedTeams[0].TeamLead.Id, teams[0].TeamLead.Id);
        Assert.Equal(expectedTeams[1].Junior.Id, teams[1].Junior.Id);
        Assert.Equal(expectedTeams[1].TeamLead.Id, teams[1].TeamLead.Id);
    }
}