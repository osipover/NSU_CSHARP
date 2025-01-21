using Nsu.HackathonProblem.Model;

namespace Nsu.HackathonProblem.Service {

    public class HarmonicMeanRatingService : IRatingService
    {
        public double Evaluate(List<double> numbers)
        {
            int numOfDevelopers = numbers.Count();
            double harmonicMean = 0.0;
            foreach (double num in numbers) {
                harmonicMean += (1.0 / num);
            }        
            return numOfDevelopers / harmonicMean;
        }
    }
}

