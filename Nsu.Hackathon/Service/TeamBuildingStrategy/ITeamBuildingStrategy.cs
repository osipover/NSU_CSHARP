using Nsu.HackathonProblem.Model;

namespace Nsu.HackathonProblem.Service
{
    public interface ITeamBuildingStrategy
    {

        List<Team> BuildTeams(
            List<Employee> juniors, 
            List<Employee> teamleads,
            List<Wishlist> juniorsWishlists, 
            List<Wishlist> teamleadWishlists
        );
    }
}