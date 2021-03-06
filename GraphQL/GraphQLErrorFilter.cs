using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace GraphQL
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(error.Exception.Message);
        }
    }
}
