using DESOFT.Server.API.Application.DTO.Login;
using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Domain.Entities.User;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Services
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;
        private readonly ILogger<LoginService> _logger;
        public LoginService(ILogger<LoginService> logger, ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            _logger = logger;
        }

        public Task<ServiceResult> Login(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> Register(RegisterDTO dto)
        {
            var res = new ServiceResult();

            try
            {
                var user = new User { 
                    Address = dto.Address,
                    Password = dto.Password,
                    UserName = dto.UserName
                };

                await _loginRepository.Register(user);

                await _loginRepository.SaveTransaction(res,"Ocorreu um erro a guardar os dados.");

            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);   
            }

            return res;
        }
    }
}
