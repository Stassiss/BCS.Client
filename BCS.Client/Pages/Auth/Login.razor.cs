using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCS.Client.Auth;
using BCS.Client.Auth.DTOs;
using Microsoft.AspNetCore.Components;

namespace BCS.Client.Pages.Auth
{
    public partial class Login
    {
        private UserForAuthDto _userForAuthentication = new UserForAuthDto();
        [Inject]
        public IAuthService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowAuthError { get; set; }
        public string Error { get; set; }
        public async Task ExecuteLogin()
        {
            ShowAuthError = false;
            var result = await AuthenticationService.Login(_userForAuthentication);
            if (!result.IsAuthSuccessful)
            {
                Error = result.ErrorMessage;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
