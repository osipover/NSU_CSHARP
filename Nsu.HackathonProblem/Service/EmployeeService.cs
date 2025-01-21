using Microsoft.EntityFrameworkCore;
using Nsu.HackathonProblem.Database;
using Nsu.HackathonProblem.Model.Entity;
using Nsu.HackathonProblem.Model.Dto;
using Nsu.HackathonProblem.Service;
using Nsu.HackathonProblem.Repository;


namespace Nsu.HackathonProblem.Service;

public class EmployeeService(
    IEmployeeRepository employeeRepository,
    IEmployeeProvider employeeReader
)
{
    public void SaveEmployeesFromCsv(string juniorsCsvPath,
        string teamLeadsCsvPath)
    {
        var juniors = employeeReader.GetEmployees(juniorsCsvPath);
        var teamLeads = employeeReader.GetEmployees(teamLeadsCsvPath);

        SaveEmployees(juniors, Role.Junior);
        SaveEmployees(teamLeads, Role.TeamLead);
    }

    public EmployeeDto GetEmployeeById(int employeeId, Role role)
    {
        var employee = employeeRepository.FindByIdAndRole(employeeId, role);
        return new EmployeeDto(
            employee.Id,
            employee.Name
        );
    }

    private void SaveEmployees(List<EmployeeDto> employeesDto, Role role)
    {
        var employees = new List<Employee>();
        foreach (var employee in employeesDto)
        {
            var existingEmployee = employeeRepository.FindByIdAndRole(employee.Id, role);

            if (existingEmployee == null)
            {
                
                var newEmployee = new Employee(employee.Id, employee.Name, role);

                employees.Add(newEmployee);
            }
        }
        employeeRepository.SaveAll(employees);
    }


    public List<EmployeeDto> GetJuniors()
    {
        var juniors = employeeRepository.FindByRole(Role.Junior)
            .Select(j => new EmployeeDto(j.Id, j.Name))
            .ToList();

        return juniors;
    }

    public List<EmployeeDto> GetTeamLeads()
    {
        var teamLeads = employeeRepository.FindByRole(Role.TeamLead)
            .Select(t => new EmployeeDto(t.Id, t.Name))
            .ToList();

        return teamLeads;
    }
}