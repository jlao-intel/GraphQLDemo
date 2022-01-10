using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Schools
{
    public class SchoolPayloadBase : Payload
    {
        protected SchoolPayloadBase(School school)
        {
            School = school;
        }

        protected SchoolPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public School? School { get; }
    }
}
