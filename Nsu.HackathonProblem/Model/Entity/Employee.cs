namespace Nsu.HackathonProblem.Model.Entity;

public class Employee {
    public int Id { get; set; }
    public string Name { get; set; }
    public Role Role { get; set; }

    public Employee(int id, string name, Role role)
    {
        Id = id;
        Name = name;
        Role = role;
    }
}