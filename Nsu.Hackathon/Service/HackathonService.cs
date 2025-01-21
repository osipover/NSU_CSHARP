namespace Nsu.HackathonProblem.Service;

using Nsu.HackathonProblem.Model.Dto;
using Nsu.HackathonProblem.Model.Entity;
using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Repository;

public class HackathonService(
    HRManager hrManager, 
    HRDirector hrDirector,
    EmployeeService employeeService,
    WishlistService wishlistService,
    IHackathonRepository hackathonRepository
) {

    public void Start(List<EmployeeDto> juniors, List<EmployeeDto> teamleads)
    {
        (var juniorsWishlists, var teamleadsWishlist) = hrManager.GetWishlists(juniors, teamleads);
        List<TeamDto> teams = hrManager.CreateTeams(juniorsWishlists, teamleadsWishlist);
        double harmony = hrDirector.EvaluateTeams(teams);
        var hackathon = CreateHackathon(teams, harmony);
        hackathonRepository.SaveHackathon(hackathon);
        wishlistService.SaveWishlists(juniorsWishlists, Role.Junior, hackathon.Id);
        wishlistService.SaveWishlists(teamleadsWishlist, Role.TeamLead, hackathon.Id);
    }

    public HackathonInfoDto GetHackathonInfoById(int id)
    {
        var hackathon = hackathonRepository.GetHackathonById(id);
        if (hackathon == null) return null;

        var teamsInfo = hackathon.Teams
            .Select(t => ConvertToTeamInfoDto(t))
            .ToList();
        return new HackathonInfoDto(
            hackathon.Id,
            hackathon.Harmony,
            teamsInfo
        );
    }

    public double CalculateAverageHarmony()
    {
        return hackathonRepository.CalculateAverageHarmony();
    }

    private TeamInfoDto ConvertToTeamInfoDto(Team team)
    {
        var junior = employeeService.GetEmployeeById(team.JuniorId, Role.Junior);
        var teamlead = employeeService.GetEmployeeById(team.TeamLeadId, Role.TeamLead);
        return new TeamInfoDto(
            team.Id,
            junior.Id,
            junior.Name,
            teamlead.Id,
            teamlead.Name
        );
    }

    private Hackathon CreateHackathon(List<TeamDto> teams, double harmony)
    {
        return new Hackathon
            {
                Harmony = (decimal)harmony,
                Teams = teams.Select(t => new Team
                {
                    TeamLeadId = t.TeamLead.Id,
                    JuniorId = t.Junior.Id
                }).ToList()
            };
    }
}