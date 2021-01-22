﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCS.Client.DTOs;
using BCS.Client.Features;
using BCS.Client.Repository;
using Microsoft.AspNetCore.Components;

namespace BCS.Client.Pages
{
    public partial class Projects
    {
        public List<ProjectOutDto> ProjectsList { get; set; } = new List<ProjectOutDto>();
        public MetaData MetaData { get; set; }
        private ProjectParameters _projectParameters = new ProjectParameters { PageSize = 3 };
        [Inject]
        public IProjectRepository _projectRepository { get; set; }
        protected async override Task OnInitializedAsync()
        {
            var paginationResponse = await _projectRepository.GetProjects(_projectParameters);
            MetaData = paginationResponse.MetaData;
            ProjectsList = paginationResponse.Items;
        }

    }
}
