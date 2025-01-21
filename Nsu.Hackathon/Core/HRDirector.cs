using Nsu.HackathonProblem.Model.Dto;
using Nsu.HackathonProblem.Service;

public class HRDirector(IRatingService ratingService) 
{

    public double EvaluateTeams(List<TeamDto> teams) 
    {
        List<double> priorities = new List<double>();
        teams.ForEach(team => {
            priorities.Add(team.juniorPriority);
            priorities.Add(team.teamLeadPriority);
        });
        return ratingService.Evaluate(priorities);
    }

}