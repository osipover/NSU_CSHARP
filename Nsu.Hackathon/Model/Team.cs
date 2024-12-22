using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsu.HackathonProblem.Model
{
    public record Team(
        Employee TeamLead, 
        Employee Junior,
        int teamLeadPriority,
        int juniorPriority
    );    
}