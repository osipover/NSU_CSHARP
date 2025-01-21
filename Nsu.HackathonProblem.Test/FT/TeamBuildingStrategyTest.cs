namespace Nsu.HackathonProblem.Test;

using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Model.Dto;


public class TeamBuildingStrategyTest
{
    [Fact]
    public void BuildTeams_ReturnsTeams() 
    {

        var (juniorsWishlist, teamleadsWishlist) = GetWishlistsDto();

        var teamBuildingStrategy = new TeamBuildingStrategy();

        var teams = teamBuildingStrategy.BuildTeams(juniorsWishlist, teamleadsWishlist);

        Assert.Equal(2, teams[0].Junior.Id);
        Assert.Equal(10, teams[0].TeamLead.Id);
        Assert.Equal(1, teams[1].Junior.Id);
        Assert.Equal(20, teams[1].TeamLead.Id);
    }

    private (List<WishlistDto>, List<WishlistDto>) GetWishlistsDto()
    {
        var juniorWishlist = new List<WishlistDto>(){
            new WishlistDto(new EmployeeDto(1, null), GetPreference(10, 20)),
            new WishlistDto(new EmployeeDto(2, null), GetPreference(20, 10)),
        };
        var teamleadsWishlist = new List<WishlistDto>(){ 
            new WishlistDto(new EmployeeDto(10, null), GetPreference(1, 2) ),
            new WishlistDto(new EmployeeDto(20, null), GetPreference(2, 1) ),
        };
        return (juniorWishlist, teamleadsWishlist);
    }

    private Dictionary<EmployeeDto, int> GetPreference(int id1, int id2)
    {
        return new Dictionary<EmployeeDto, int>() 
        { 
            [new EmployeeDto(id1, null)] = 0, 
            [new EmployeeDto(id2, null)] = 1 
        };
    }
}