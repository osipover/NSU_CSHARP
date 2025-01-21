using Nsu.HackathonProblem.Model.Dto;
using Nsu.HackathonProblem.Service;

public class HRManager(
    ITeamBuildingStrategy teamBuildingStrategy,
    IWishlistProvider wishlistProvider
) {

    public (List<WishlistDto>, List<WishlistDto>) GetWishlists(List<EmployeeDto> juniors, List<EmployeeDto> teamLeads)
    {
        return wishlistProvider.GetWishlists(juniors, teamLeads);
    }

    public List<TeamDto> CreateTeams(List<WishlistDto> juniorsWishlists, List<WishlistDto> teamleadsWishlists) 
    {
        return teamBuildingStrategy.BuildTeams(juniorsWishlists, teamleadsWishlists);
    } 
}