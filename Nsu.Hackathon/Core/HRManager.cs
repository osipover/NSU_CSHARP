using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Service;

class HRManager(
    ITeamBuildingStrategy _teamBuildingStrategy,
    IWishlistProvider _wishlistProvider
) {
    public List<Team> CreateTeams(List<Employee> juniors, List<Employee> teamLeads) {

        var (juniorsWishlists, teamleadsWishlists) = _wishlistProvider.GetWishlists(juniors, teamLeads);

        return _teamBuildingStrategy.BuildTeams(juniors, teamLeads, juniorsWishlists, teamleadsWishlists);
    } 
}