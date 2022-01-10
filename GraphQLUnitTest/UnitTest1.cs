using System;
using Xunit;
using ConferencePlanner.GraphQL;
using GraphQL;
using System.Net.Http;
using System.Threading.Tasks;
using ConferecePlanner.GraphQL;

namespace GraphQLUnitTest
{
    public class SchoolServiceUnitTest
    {
        [Fact]
        public async Task CanGetDataAsync()
        {
            //arrange
            HttpClient newHttpClient = new HttpClient { 
                BaseAddress = new Uri("http://jlao-mobl.amr.corp.intel.com:8001/api/")
            };
            var schoolService = new SchoolService(newHttpClient);

            //act
            var exception = await Record.ExceptionAsync(async () => await schoolService.GetAsync());

            //assert
            Assert.Null(exception);
            
        }

        [Fact]
        public async Task CanThrowError()
        {
            //arrange
            HttpClient newHttpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8001/api/")
            };
            var schoolService = new SchoolService(newHttpClient);

            //act
            var exception = await Record.ExceptionAsync(async () => await schoolService.GetAsync());

            //assert
            Assert.NotNull(exception);

        }




    }
}
