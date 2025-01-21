

namespace Nsu.HackathonProblem.Model.Dto
{
    public class EmployeePreferenceDto(
        EmployeeDto employee,
        Dictionary<EmployeeDto, int> preferredEmployees)
    {
        public EmployeeDto Employee { get; init; } = employee;
        public Dictionary<EmployeeDto, int> PreferredEmployees { get; init; } = preferredEmployees;
    }
}