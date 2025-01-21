namespace Nsu.HackathonProblem.Test;

using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Model.Dto;

using Moq;

public class HRManagerTest {

    [Fact]
    public void CreateTeams_StrategyShouldBeCalledOnce() 
    {
        var teamBuildingStrategy = new Mock<ITeamBuildingStrategy>();
        var wishlistProvider = new Mock<IWishlistProvider>();
        var hrManager = new HRManager(teamBuildingStrategy.Object, wishlistProvider.Object);

        var (juniorsWishlists, teamleadsWishlist) = GetWishlistsDto();
        var teams = GetTeamsDto();

        teamBuildingStrategy
            .Setup(x => x.BuildTeams(juniorsWishlists, teamleadsWishlist))
            .Returns(teams);

        hrManager.CreateTeams(juniorsWishlists, teamleadsWishlist);

        teamBuildingStrategy.Verify(x => x.BuildTeams(juniorsWishlists, teamleadsWishlist), Times.Once());
    }

    private (List<WishlistDto>, List<WishlistDto>) GetWishlistsDto()
    {
        var juniorWishlist = new List<WishlistDto>(){
            new WishlistDto(new EmployeeDto(0, null), new Dictionary<EmployeeDto, int>() { [new EmployeeDto(1, null)] = 0 } )
        };
        var teamleadsWishlist = new List<WishlistDto>(){ 
            new WishlistDto(new EmployeeDto(1, null), new Dictionary<EmployeeDto, int>() { [new EmployeeDto(0, null)] = 0 } )
        };
        return (juniorWishlist, teamleadsWishlist);
    }

    private List<TeamDto> GetTeamsDto()
    {
        var team1 = new TeamDto(new EmployeeDto(0, null), new EmployeeDto(1, null), 0, 0 );
        return new List<TeamDto>() {team1};
    }

}