using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nsu.HackathonProblem.Model
{
    public record Employee(int Id, string Name) {
        public override string ToString()
        {
            return $"Employee[id={Id}, name={Name}]";
        }
    }
}