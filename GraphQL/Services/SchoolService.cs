using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ConferencePlanner.GraphQL.Data;
using System.Net;
using System.Text;
using ConferencePlanner.GraphQL.Schools;

namespace ConferecePlanner.GraphQL
{
    public class SchoolService : ISchoolService
    {
        private HttpClient _httpClient;

        public SchoolService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<School>> GetAsync()
        {
          
            var response = await _httpClient.GetAsync("schools");
            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<School>>(json);
            }
            else
            {
                throw new Exception(json);
            }

        }
        //post still need to fixed after get is fixed. 
        public async Task<School> Post(School school)
        {
            var ApiURL = $"schools";
            var json = JsonConvert.SerializeObject(school);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(ApiURL, data);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<School>(result);
        }

    }
}
