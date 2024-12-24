

using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Service;

class Hackathon(
    HRManager hrManager, 
    HRDirector hrDirector
) {

    public double Start(List<Employee> juniors, List<Employee> teamleads)
    {
        List<Team> teams = hrManager.CreateTeams(juniors, teamleads);
        return hrDirector.EvaluateTeams(teams);
    }
}