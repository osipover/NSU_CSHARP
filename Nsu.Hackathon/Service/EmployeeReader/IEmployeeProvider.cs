using Nsu.HackathonProblem.Model.Dto;

namespace Nsu.HackathonProblem.Service
{
    public interface IEmployeeProvider
    {
        List<EmployeeDto> GetEmployees(string filePath);
    }
}