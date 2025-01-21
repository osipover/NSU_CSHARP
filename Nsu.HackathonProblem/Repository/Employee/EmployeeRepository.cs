using Microsoft.EntityFrameworkCore;
using Nsu.HackathonProblem.Database;
using Nsu.HackathonProblem.Model.Entity;

namespace Nsu.HackathonProblem.Repository;

public class EmployeeRepository(HackathonDB context)
    : IEmployeeRepository
{
    public Employee FindByIdAndRole(int employeeId, Role role)
    {
        return context.Employees
            .FirstOrDefault(e => e.Id == employeeId && e.Role == role);
    }

    public void SaveAll(List<Employee> employees)
    {
        Console.WriteLine(employees.Count);
        foreach (var employee in employees)
        {
            context.Employees.Add(employee);
        }
        context.SaveChanges();
    }

    public List<Employee> FindByRole(Role role)
    {
        var employees = context.Employees
            .Where(e => e.Role == role)
            .ToList();
        return employees;
    }
}