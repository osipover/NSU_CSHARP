namespace Nsu.Hackathon.Test;

using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Model;

using Moq;

public class HRDirectorTest {

    [Fact]
    public void EvaluateTeams_ReturnsHarmonicMean() 
    {
        var hrDirector = new HRDirector(new HarmonicMeanRatingService());
        var teams = Examples.GetTeams();
        Assert.Equal(1.3, Math.Round(hrDirector.EvaluateTeams(teams), 1));
    }
}