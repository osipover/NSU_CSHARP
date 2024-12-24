using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Service;

public class HRDirector(IRatingService ratingService) 
{

    public double EvaluateTeams(List<Team> teams) 
    {
        List<double> priorities = new List<double>();
        teams.ForEach(team => {
            priorities.Add(team.juniorPriority);
            priorities.Add(team.teamLeadPriority);
        });
        return ratingService.Evaluate(priorities);
    }

}