using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsu.HackathonProblem.Model.Dto
{
    public record TeamDto(
        EmployeeDto TeamLead, 
        EmployeeDto Junior,
        int teamLeadPriority,
        int juniorPriority
    );    
}