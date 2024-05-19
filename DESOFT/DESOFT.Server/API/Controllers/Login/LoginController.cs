using DESOFT.Server.API.Application.DTO.Login;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Application.Services;
using DESOFT.Server.API.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.Login
{

    [ApiController]
    [Route("/api/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        //[TypeFilter(typeof(PodeAcederFrontOfficeFilter))]
        [HttpPost(nameof(Login))]
        public async Task<ServiceResult> Login(LoginDTO dto)
        {
            return await _loginService.Login(dto);
        }
        
        [HttpPost(nameof(Register))]
        public async Task<ServiceResult> Register(RegisterDTO dto)
        {
            return await _loginService.Register(dto);
        }

    }
}
