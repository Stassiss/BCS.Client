using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BCS.Client.DTOs;
using BCS.Client.Features;
using BCS.Client.Helpers;
using Microsoft.AspNetCore.WebUtilities;

namespace BCS.Client.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IHttpService _httpService;

        public ProjectRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ProjectOutDto> CreateProject(ProjectInputDto project)
        {
            var response = await _httpService.Post<ProjectInputDto, ProjectOutDto>("projects", project);
            if (!response.Success)
            {
                throw new ApplicationException();
            }
            return response.Data;

        }



        //public async Task<PaginationResponse<ProjectOutDto>> GetProjects(ProjectParameters projectParameters)
        //{
        //    var queryString = new Dictionary<string, string>
        //    {
        //        ["pageNumber"] = projectParameters.PageNumber.ToString(),
        //        ["pageSize"] = projectParameters.PageSize.ToString()
        //    };
        //    var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("projects", queryString));
        //    var content = await response.Content.ReadAsStringAsync();
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new ApplicationException(content);
        //    }

        //    var paginationResponse = new PaginationResponse<ProjectOutDto>
        //    {
        //        Items = JsonSerializer.Deserialize<List<ProjectOutDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
        //        MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("x-pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
        //    };
        //    return paginationResponse;
        //}

    }


}

