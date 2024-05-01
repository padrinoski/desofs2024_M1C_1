using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Services;

namespace DESOFT.Server.API.Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepo;

        public AuthService(IAuthRepository authRepo)
        {

            _authRepo = authRepo;

        }

        public Task<bool> PodeAcederBackOffice(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PodeAcederFrontOffice(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
