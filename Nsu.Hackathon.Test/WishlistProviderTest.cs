namespace Nsu.Hackathon.Test;

using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Model;

public class WishlistProviderTest {

    [Fact]
    public void GetWishlists_CountIsCorrect() {
        var juniors = Examples.GetJuniors();
        var teamleads = Examples.GetTeamleads();
        
        IWishlistProvider wishlistProvider = new RandomWishlistProvider();
        var (juniorsWishlists, teamleadsWishlists) = wishlistProvider.GetWishlists(juniors, teamleads);

        Assert.Equal(2, juniorsWishlists.Count);
        Assert.Equal(2, teamleadsWishlists.Count);
    }

    [Fact]
    public void GetWishlists_KnownEmployeeInWishlist() {
        var juniors = Examples.GetJuniors();
        var teamleads = Examples.GetTeamleads();
        
        IWishlistProvider wishlistProvider = new RandomWishlistProvider();
        var (juniorsWishlists, teamleadsWishlists) = wishlistProvider.GetWishlists(juniors, teamleads);

        Assert.Equal(true, juniorsWishlists[0].DesiredEmployees.Contains(10));
        Assert.Equal(true, juniorsWishlists[0].DesiredEmployees.Contains(20));

        Assert.Equal(true, teamleadsWishlists[0].DesiredEmployees.Contains(1));
        Assert.Equal(true, teamleadsWishlists[0].DesiredEmployees.Contains(2));
    }

}