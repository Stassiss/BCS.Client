using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCS.Client.DTOs;
using BCS.Client.Features;
using BCS.Client.Repository;
using Microsoft.AspNetCore.Components;

namespace BCS.Client.Pages.Project
{
    public partial class Projects
    {
        public List<ProjectOutDto> ProjectsList { get; set; }
        public MetaData MetaData { get; set; }
        private ProjectParameters _projectParameters = new ProjectParameters();
        [Inject]
        public IProjectRepository _projectRepository { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await GetProjects();
        }
        private async Task SelectedPage(int page)
        {
            _projectParameters.PageNumber = page;
            await GetProjects();
        }
        private async Task GetProjects()
        {

            var paginationResponse = await _projectRepository.GetProjects(_projectParameters);
            MetaData = paginationResponse.MetaData;
            ProjectsList = paginationResponse.Items;
        }
        private async Task DeleteProject(ProjectOutDto project)
        {
            var response = await _projectRepository.DeleteProject(project);
            ProjectsList.Remove(project);
            StateHasChanged();
        }
    }
}
