using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using ConferencePlanner.GraphQL.Data;
using HotChocolate.Types;
using System.Net.Http;
using Newtonsoft.Json;
using GraphQL;
using ConferencePlanner.GraphQL.Schools;
using ConferecePlanner.GraphQL;

namespace ConferencePlanner.GraphQL.Schools
{
    [ExtendObjectType("Query")]
    public class SchoolQueries
    {
        private readonly ISchoolService _schoolService;

        public SchoolQueries(ISchoolService schoolService)
        {
            _schoolService = schoolService;

        }
        //public async Task<List<Weather>> GetWeathers()
        //{
        //    return WeatherController.GetAllWeather();
        //}
        //public Weather GetWeather() =>
        //    new Weather
        //    {
        //        Date = DateTime.Today,
        //        TemperatureC = 32,
        //        Summary = "chilly with rain",
        //    };

        public async Task<List<Data.School>> GetAllSchoolsAsync([Service] SchoolService service)
        {
            //_oWeathers = new List<Weather>();

            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync("https://localhost:5008/weatherforecast"))
            //    {
            //        string result = await response.Content.ReadAsStringAsync();
            //        _oWeathers = JsonConvert.DeserializeObject<List<Weather>>(result);
            //    }

            //}
            //return _oWeathers;
            return await service.GetAsync();

        }
    }
}
