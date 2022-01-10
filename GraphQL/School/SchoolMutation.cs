using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;
using GraphQL;
using ConferencePlanner.GraphQL.Schools;
using ConferecePlanner.GraphQL;

namespace ConferencePlanner.GraphQL.Schools
{
    [ExtendObjectType("Mutation")]
    public class SchoolMutations
    {
        public async Task<AddSchoolPayload> AddSchoolAsync(
            AddSchoolInput input,
            [Service] SchoolService service)
        {
            var school = new School
            {
                Name = input.Name,
                NumberOfStudents = input.NumberOfStudents,
                City = input.City
            };
            await service.Post(school);

            return new AddSchoolPayload(school);
        }
    }
}
