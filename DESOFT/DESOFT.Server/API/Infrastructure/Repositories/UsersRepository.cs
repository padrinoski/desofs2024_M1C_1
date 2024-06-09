using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace DESOFT.Server.API.Infrastructure.Repositories
{
    public class UsersRepository : AppRepository, IUsersRepository
    {
        private readonly AppDBContext _context;
        private readonly ILogger<UsersRepository> _logger;

        public UsersRepository(AppDBContext context, ILogger<UsersRepository> logger) : base(context, logger)
        {
            _logger = logger;
            _context = context;
        }

        
        public async Task<User> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Role> GetRoleByUser(string userId)
        {
            return await _context.UserRoles
                .Include(e => e.Role)
                .Where(e => e.UserId == userId)
                .Select(e => e.Role)
                .SingleAsync();                
        }
    }
}
