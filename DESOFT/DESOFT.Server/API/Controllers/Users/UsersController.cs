using DESOFT.Server.API.Application.DTO.User;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Application.Services;
using Microsoft.AspNetCore.Mvc;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.Users
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ComicBookController : ControllerBase
    {

        private readonly IUsersService _usersService;

        public ComicBookController(IUsersService userService)
        {
            _usersService = userService;
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
