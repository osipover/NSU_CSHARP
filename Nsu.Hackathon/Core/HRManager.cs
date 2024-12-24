using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Service;

public class HRManager(
    ITeamBuildingStrategy teamBuildingStrategy,
    IWishlistProvider wishlistProvider
) {
    public List<Team> CreateTeams(List<Employee> juniors, List<Employee> teamLeads) 
    {
        var (juniorsWishlists, teamleadsWishlists) = wishlistProvider.GetWishlists(juniors, teamLeads);
        return teamBuildingStrategy.BuildTeams(juniors, teamLeads, juniorsWishlists, teamleadsWishlists);
    } 
}