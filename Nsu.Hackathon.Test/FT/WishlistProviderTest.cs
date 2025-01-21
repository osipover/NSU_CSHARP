namespace Nsu.HackathonProblem.Test;

using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Model.Dto;

public class WishlistProviderTest {

    [Fact]
    public void GetWishlists_CountIsCorrect() {
        var juniors = GetJuniors();
        var teamleads = GetTeamleads();
        
        IWishlistProvider wishlistProvider = new RandomWishlistProvider();
        var (juniorsWishlists, teamleadsWishlists) = wishlistProvider.GetWishlists(juniors, teamleads);

        Assert.Equal(2, juniorsWishlists.Count);
        Assert.Equal(2, teamleadsWishlists.Count);
    }

    [Fact]
    public void GetWishlists_KnownEmployeeInWishlist() {
        var juniors = GetJuniors();
        var teamleads = GetTeamleads();
        
        IWishlistProvider wishlistProvider = new RandomWishlistProvider();
        var (juniorsWishlists, teamleadsWishlists) = wishlistProvider.GetWishlists(juniors, teamleads);

        Assert.Equal(true, juniorsWishlists[0].preferredEmployee.ContainsKey(teamleads[0]));
        Assert.Equal(true, juniorsWishlists[0].preferredEmployee.ContainsKey(teamleads[1]));

        Assert.Equal(true, teamleadsWishlists[0].preferredEmployee.ContainsKey(juniors[0]));
        Assert.Equal(true, teamleadsWishlists[0].preferredEmployee.ContainsKey(juniors[1]));
    }

    private List<EmployeeDto> GetJuniors() 
    {
        return new List<EmployeeDto>() { new EmployeeDto(1, "Tom"), new EmployeeDto(2, "Tim") };
    }

    private List<EmployeeDto> GetTeamleads() 
    {
        return new List<EmployeeDto>() { new EmployeeDto(10, "Ben"), new EmployeeDto(20, "Bob") }; 
    }


}