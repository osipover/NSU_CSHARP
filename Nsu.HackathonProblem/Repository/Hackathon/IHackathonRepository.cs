using Nsu.HackathonProblem.Model.Entity;
using Nsu.HackathonProblem.Model.Dto;

namespace Nsu.HackathonProblem.Repository;

public interface IHackathonRepository
{
    void Save(Hackathon hackathon);

    Hackathon FindById(int id);
    double CalculateAverageHarmony();
}