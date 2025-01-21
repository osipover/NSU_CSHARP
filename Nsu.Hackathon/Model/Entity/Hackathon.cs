namespace Nsu.HackathonProblem.Model.Entity;

public class Hackathon
{
    public int Id { get; set; }
    public decimal Harmony { get; set; }
    public List<Team> Teams { get; set; }
}