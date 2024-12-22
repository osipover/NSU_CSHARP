using Nsu.HackathonProblem.Model;
using Nsu.HackathonProblem.Service;

class HRDirector(
    IRatingService ratingService,
    HRManager hrManager
) {

    public void OrganizeHackathon(int numOfHackathons, List<Employee> juniors, List<Employee> teamLeads) {
        double totalHarmony = 0;
        for (int i = 0; i < numOfHackathons; ++i) {

            List<Team> teams = hrManager.CreateTeams(juniors, teamLeads);
            double harmony = EvaluateTeams(teams);

            Console.WriteLine($"HACKATHON №{i}:\tharmony={harmony}");
            totalHarmony += harmony;
        }
        double averageHarmony = totalHarmony / numOfHackathons;
        Console.WriteLine($"Average harmony = {averageHarmony}");
    }

    public double EvaluateTeams(List<Team> teams) {
        return ratingService.CalculateHarmonicMean(teams);
    }

}