using DESOFT.Server.API.Application.DTO.Login;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Application.Services;
using DESOFT.Server.API.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.Login
{

    [ApiController]
    [Route("/api/[controller]")]
    [EnableRateLimiting("fixed")]
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
        
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        [HttpGet(nameof(IsBackOffice))]
        public async Task<ServiceResult<bool>> IsBackOffice()
        {

            var res = new ServiceResult<bool>();

            await Task.Run(() =>
            {
                res.Data = true;
            });

            return res;
        }
        
        [HttpPost(nameof(Register))]
        public async Task<ServiceResult> Register(RegisterDTO dto)
        {
            return await _loginService.Register(dto);
        }

    }
}
