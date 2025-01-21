namespace Nsu.HackathonProblem.Test.FT;

using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Model.Dto;

using Moq;

public class HRDirectorTest {

    [Fact]
    public void EvaluateTeams_ReturnsHarmonicMean() 
    {
        var hrDirector = new HRDirector(new HarmonicMeanRatingService());
        var teams = GetTeamsDto();
        Assert.Equal(1.3, Math.Round(hrDirector.EvaluateTeams(teams), 1));
    }

    private List<TeamDto> GetTeamsDto()
    {
        var team1 = new TeamDto(new EmployeeDto(0, null), new EmployeeDto(0, null), 1, 2 );
        var team2 = new TeamDto(new EmployeeDto(0, null), new EmployeeDto(0, null), 2, 1 );
        return new List<TeamDto>() {team1, team2};
    }
}