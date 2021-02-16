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

        public async Task<bool> DeleteProject(ProjectOutDto project)
        {
            var response = await _httpService.Delete($"projects/{project.Id}");
            return response.Success;
        }

        public async Task<ProjectOutDto> GetProject(Guid projectId)
        {
            var httpresponse = await _httpService.Get<ProjectOutDto>($"projects/{projectId}");
            if (!httpresponse.Success)
            {
                throw new ApplicationException();
            }
            return httpresponse.Data;
        }

        public async Task<PaginationResponse<ProjectOutDto>> GetProjects(ProjectParameters projectParameters)
        {
            var queryString = new Dictionary<string, string>
            {
                ["pageNumber"] = projectParameters.PageNumber.ToString(),
                ["pageSize"] = projectParameters.PageSize.ToString()
            };
            var httpResponse = await _httpService.Get<List<ProjectOutDto>>(QueryHelpers.AddQueryString("projects", queryString));


            var paginationResponse = new PaginationResponse<ProjectOutDto>
            {
                Items = httpResponse.Data,
                MetaData = JsonSerializer.Deserialize<MetaData>(httpResponse.HttpResponseMessage.Headers.GetValues("x-pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            };
            return paginationResponse;
        }

    }


}

