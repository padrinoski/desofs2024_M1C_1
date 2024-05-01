using DESOFT.Server.API.Application.DTO.Login;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Interfaces.Services
{
    public interface ILoginService
    {
        Task<ServiceResult> Login(LoginDTO loginDTO);
        Task<ServiceResult> Register(RegisterDTO registerDTO);
    }
}
