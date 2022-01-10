using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.Schools;

namespace ConferencePlanner.GraphQL.Schools
{
    public class AddSchoolPayload : SchoolPayloadBase
    {
        public AddSchoolPayload(School school)
            : base(school)
        {
        }

        public AddSchoolPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
