using Nsu.HackathonProblem.Model.Entity;
using Nsu.HackathonProblem.Model.Dto;

namespace Nsu.HackathonProblem.Repository;

public interface IHackathonRepository
{
    void SaveHackathon(Hackathon hackathon);

    Hackathon GetHackathonById(int hackathonId);
    IEnumerable<Hackathon> GetAllHackathons();
    double CalculateAverageHarmony();
}