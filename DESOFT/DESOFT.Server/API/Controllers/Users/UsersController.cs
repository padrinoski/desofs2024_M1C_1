using DESOFT.Server.API.Application.DTO.User;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.Users
{

    [ApiController]
    [Route("/api/[controller]")]
    [EnableRateLimiting("fixed")]
    public class UsersController : ControllerBase
    {

        private readonly IUsersService _usersService;

        public UsersController(IUsersService userService)
        {
            _usersService = userService;
        }

        
        [HttpGet("{id}")]
        public async Task<ServiceResult<UserDTO>> getUserById(int id)
        {
            return await _usersService.getUserById(id);
        }
        
        //[TypeFilter(typeof(PodeAcederFrontOfficeFilter))]
        [HttpPost(nameof(AddAdmin))]
        public async Task<ServiceResult> AddAdmin(UserDTO dto)
        {
            return await _usersService.AddAdmin(dto);
        }
        
        [HttpDelete(nameof(RemoveAdmin))]
        public async Task<ServiceResult> RemoveAdmin(RemoveUserDTO dto)
        {
            return await _usersService.RemoveAdmin(dto);
        }
        
        [HttpPut(nameof(UpdateAdmin))]
        public async Task<ServiceResult> UpdateAdmin(UserDTO dto)
        {
            return await _usersService.UpdateAdmin(dto);
        }

    }
}
