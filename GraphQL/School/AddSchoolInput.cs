using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferencePlanner.GraphQL.Schools
{
    public record AddSchoolInput(
        string Name,
        int? NumberOfStudents,
        string? City);
}
