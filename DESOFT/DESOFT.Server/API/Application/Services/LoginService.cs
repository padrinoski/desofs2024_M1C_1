using DESOFT.Server.API.Application.DTO.Login;
using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Domain.Entities.User;
using DESOFT.Server.API.Shared.Infrastructure;
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

    public async Task<ServiceResult> Login(LoginDTO loginDTO)
    {
        var res = new ServiceResult();

        try
        {
            // Check if a user with the provided username and password exists
            var user = await _loginRepository.GetUserByUsernameAndPassword(loginDTO.Username, loginDTO.Password);

            if (user != null)
            {
                // If the user exists, return a successful result
                
                res.Success = true;
                res.Messages.Add(new KeyVal("Login successful"));
            }
            else
            {
                // If the user doesn't exist, return an error
                res.Success = false;
                res.Errors.Add(new KeyVal("Invalid username or password"));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            res.Success = false;
            res.Errors.Add(new KeyVal("An error occurred while logging in"));
        }

        return res;
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
