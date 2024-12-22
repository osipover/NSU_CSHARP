using Microsoft.VisualBasic;
using Nsu.HackathonProblem.Model;

namespace Nsu.HackathonProblem.Service;

class CsvEmployeeReader : IEmployeeProvider
{
    public List<Employee> GetEmployees(string filePath) {
        var employees = new List<Employee>();
        try
        {
            using (var reader = new StreamReader(filePath))
            {
                var headerLine = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (TryReadEmployee(line, out int id, out string name))
                    {
                        var employee = new Employee(id, name);
                        employees.Add(employee);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
        }

        return employees;
    }

    private bool TryReadEmployee(string line, out int id, out string name) 
    {
        var values = line?.Split(';');
        if (values?.Length == 2 && int.TryParse(values[0], out id) && !string.IsNullOrWhiteSpace(values[1])) {
            name = values[1];
            return true;
        }
        id = -1;
        name = ""; 
        return false;
    }
}
