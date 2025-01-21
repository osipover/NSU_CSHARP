using Nsu.HackathonProblem.Model.Entity;

namespace Nsu.HackathonProblem.Repository;

public interface IEmployeeRepository
{
    Employee GetEmployeeById(int employeeId, Role role);

    void SaveAll(List<Employee> employees);

    List<Employee> FindByRole(Role role);
}