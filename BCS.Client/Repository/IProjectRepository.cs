using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BCS.Client.DTOs;
using BCS.Client.Features;

namespace BCS.Client.Repository
{
    public interface IProjectRepository
    {
        Task<ProjectOutDto> CreateProject(ProjectInputDto project);
        Task<PaginationResponse<ProjectOutDto>> GetProjects(ProjectParameters projectParameters);
        Task<bool> DeleteProject(ProjectOutDto project);
        Task<ProjectOutDto> GetProject(Guid projectId);
    }
}
