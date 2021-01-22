using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BCS.Client.DTOs;
using BCS.Client.Features;
using Microsoft.AspNetCore.WebUtilities;

namespace BCS.Client.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly HttpClient _httpClient;

        public ProjectRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }




        public async Task<PaginationResponse<ProjectOutDto>> GetProjects(ProjectParameters projectParameters)
        {
            var queryString = new Dictionary<string, string>
            {
                ["pageNumber"] = projectParameters.PageNumber.ToString(),
                ["pageSize"] = projectParameters.PageSize.ToString()
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("projects", queryString));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var paginationResponse = new PaginationResponse<ProjectOutDto>
            {
                Items = JsonSerializer.Deserialize<List<ProjectOutDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("x-pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            };
            return paginationResponse;
        }

    }


}

