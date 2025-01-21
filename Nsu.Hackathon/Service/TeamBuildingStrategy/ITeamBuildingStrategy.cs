using Nsu.HackathonProblem.Model.Dto;

namespace Nsu.HackathonProblem.Service
{
    public interface ITeamBuildingStrategy
    {

        List<TeamDto> BuildTeams(
            List<WishlistDto> juniorsWishlists,
            List<WishlistDto> teamLeadsWishlists
        );
    }
}