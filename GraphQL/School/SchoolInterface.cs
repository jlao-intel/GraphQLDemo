using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Schools
{
    public interface ISchoolService
    {
        Task<List<School>> GetAsync();
    }
}
