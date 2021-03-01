using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCS.Client.Auth.DTOs;

namespace BCS.Client.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Login(UserForAuthDto userForAuthentication);
        Task Logout();
        Task<string> RefreshToken();
    }
}
