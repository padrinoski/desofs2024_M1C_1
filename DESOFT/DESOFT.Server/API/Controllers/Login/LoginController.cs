﻿using DESOFT.Server.API.Application.DTO.Login;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Application.Services;
using DESOFT.Server.API.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.Login
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ComicBookController : ControllerBase
    {

        private readonly ILoginService _loginService;

        public ComicBookController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        //[TypeFilter(typeof(PodeAcederFrontOfficeFilter))]
        [HttpPost(nameof(Login))]
        public async Task<bool> Login(LoginDTO dto)
        {
            return await Task.Run(() => true);
        }
        
        [HttpPost(nameof(Register))]
        public async Task<ServiceResult> Register(RegisterDTO dto)
        {
            return await _loginService.Register(dto);
        }

    }
}