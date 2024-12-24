using Nsu.HackathonProblem.Model;


namespace Nsu.HackathonProblem.Service {
    public interface IRatingService
    {
        double Evaluate(List<double> numbers);
    }
}
