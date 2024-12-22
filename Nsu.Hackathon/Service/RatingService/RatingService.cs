using Nsu.HackathonProblem.Model;

namespace Nsu.HackathonProblem.Service {

    public class RatingService : IRatingService
    {
        public double CalculateHarmonicMean(List<Team> teams)
        {
            int numOfDevelopers = teams.Count * 2;
            double harmonicMean = 0.0;
            foreach (Team team in teams) {
                int juniorSatisfaction = team.juniorPriority;
                int teamLeadSatisfaction = team.teamLeadPriority;
                
                harmonicMean += (1.0 / juniorSatisfaction);
                harmonicMean += (1.0 / teamLeadSatisfaction);
            }        
            return numOfDevelopers / harmonicMean;
        }
    }

}

