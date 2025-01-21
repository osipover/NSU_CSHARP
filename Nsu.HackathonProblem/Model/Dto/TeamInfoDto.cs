using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsu.HackathonProblem.Model.Dto
{
    public record TeamInfoDto(
        int teamId,
        int juniorId,
        string juniorName,
        int teamleadId,
        string teamleadName
    );    
}