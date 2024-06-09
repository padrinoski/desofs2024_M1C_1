using DESOFT.Server.API.Application.DTO.User;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Interfaces.Services
{ 
    public interface IUsersService
    {
        Task<ServiceResult> AddAdmin(UserDTO dto);
        Task<ServiceResult<UserDTO>> GetUser(String username);
        Task<ServiceResult> RemoveAdmin(RemoveUserDTO dto);
        Task<ServiceResult> UpdateAdmin(UserDTO dto);
        
        Task<ServiceResult<UserDTO>> getUserById(string id);
    }
}
