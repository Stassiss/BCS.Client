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
        Task<PaginationResponse<ProjectOutDto>> GetProjects(ProjectParameters projectParameters);
    }
}
