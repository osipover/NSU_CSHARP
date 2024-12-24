namespace Nsu.Hackathon.Test;

using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Model;

using Moq;

public class HRManagerTest {

    [Fact]
    public void CreateTeams_StrategyShouldBeCalledOnce() 
    {
        var teamBuildingStrategy = new Mock<ITeamBuildingStrategy>();
        var wishlistProvider = new Mock<IWishlistProvider>();
        var hrManager = new HRManager(teamBuildingStrategy.Object, wishlistProvider.Object);

        var juniors = Examples.GetJuniors();
        var teamleads = Examples.GetTeamleads();
        var (juniorsWishlists, teamleadsWishlist) = Examples.GetWishlists();

        wishlistProvider.Setup(x => x.GetWishlists(juniors, teamleads)).Returns((juniorsWishlists, teamleadsWishlist));
        teamBuildingStrategy
            .Setup(x => x.BuildTeams(juniors, teamleads, juniorsWishlists, teamleadsWishlist))
            .Returns(Examples.GetTeams());

        hrManager.CreateTeams(juniors, teamleads);

        teamBuildingStrategy.Verify(x => x.BuildTeams(juniors, teamleads, juniorsWishlists, teamleadsWishlist), Times.Once());
    }

}