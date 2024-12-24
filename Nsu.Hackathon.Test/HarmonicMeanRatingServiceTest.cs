namespace Nsu.Hackathon.Test;

using Nsu.HackathonProblem.Service;

public class HarmonicMeanRatingServiceTest 
{

    [Theory]
    [InlineData(new double[]{10, 10, 10, 10})]
    [InlineData(new double[]{3.14, 3.14, 3.14, 3.14, 3.14, 3.14})]
    public void Evaluate_InputIsEqualNumbers_ReturnSameNumber(double[] numbers) 
    {
        var ratinService = new HarmonicMeanRatingService();
        Assert.Equal(numbers[0], ratinService.Evaluate(numbers.ToList()));
    }

    [Fact]
    public void Evaluate_SomeExample_ReturnHarmonicMean() 
    {
        double[] numbers = {2, 6};
        var ratinService = new HarmonicMeanRatingService();
        Assert.Equal(3, ratinService.Evaluate(numbers.ToList()));
    }
}