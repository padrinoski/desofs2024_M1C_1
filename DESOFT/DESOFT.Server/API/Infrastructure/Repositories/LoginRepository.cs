using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Domain.Entities.User;

namespace DESOFT.Server.API.Infrastructure.Repositories
{
    public class LoginRepository : AppRepository, ILoginRepository
    {

        private readonly AppDBContext _context;
        private readonly ILogger<LoginRepository> _logger;

        public LoginRepository(AppDBContext context, ILogger<LoginRepository> logger) : base(context, logger)
        {
            _logger = logger;
            _context = context;
        }

        public Task Login()
        {
            throw new NotImplementedException();
        }

        public async Task Register(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
