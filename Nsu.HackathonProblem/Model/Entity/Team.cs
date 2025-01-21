namespace Nsu.HackathonProblem.Model.Entity;

public class Team
{
    public int Id { get; set; }
    public int HackathonId { get; set; }
    public int TeamLeadId { get; set; }
    public int JuniorId { get; set; }
    public virtual Hackathon Hackathon { get; set; }
}