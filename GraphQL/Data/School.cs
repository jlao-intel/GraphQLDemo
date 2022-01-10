using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferencePlanner.GraphQL.Data
{
    public class School
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? NumberOfStudents { get; set; }
        public string? City { get; set; }

    }
}
