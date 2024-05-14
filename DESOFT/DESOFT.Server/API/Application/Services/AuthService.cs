using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Services;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepo;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IAuthRepository authRepo, ILogger<AuthService> logger)
        {
            _authRepo = authRepo;
            _logger = logger;
        }

        public async Task<ServiceResult<bool>> PodeAcederBackOffice(int userId)
        {
            var result = new ServiceResult<bool>();

            try
            {
                result.Data = await _authRepo.PodeAcederBackOffice(userId);

            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<bool>> PodeAcederFrontOffice(int userId)
        {
            var result = new ServiceResult<bool>();

            try
            {
                result.Data = await _authRepo.PodeAcederFrontOffice(userId);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return result;
        }
        
        public async Task<ServiceResult<bool>> PodeEditarComicBookFilter(int comicBookId, int userId)
        {
            var result = new ServiceResult<bool>();

            try
            {
                result.Data = await _authRepo.PodeEditarComicBookFilter(comicBookId, userId);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return result;
        }
    }
}
