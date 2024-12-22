using Nsu.HackathonProblem.Model;

namespace Nsu.HackathonProblem.Service
{
    public interface IEmployeeProvider
    {
        List<Employee> GetEmployees(string filePath);
    }
}