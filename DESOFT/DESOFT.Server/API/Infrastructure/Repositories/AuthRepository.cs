using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Domain.Entities.User;
using DESOFT.Server.API.Shared;
using Microsoft.EntityFrameworkCore;

namespace DESOFT.Server.API.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly AppDBContext _context;

        public AuthRepository(AppDBContext context)
        {
            _context = context;   
        }

        public async Task<bool> PodeAcederBackOffice(int userId)
        {

            var user = await _context.Users
                .Include(e => e.Role)
                .Where(u => u.UserId == userId)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (user == null)
                return false;

            return user.Role.RoleId == (int)Roles.StoreManager || user.Role.RoleId == (int)Roles.StoreClerk || user.Role.RoleId == (int)Roles.Admin;
        }

        public async Task<bool> PodeAcederFrontOffice(int userId)
        {
            var user = await _context.Users
                            .Include(e => e.Role)
                            .Where(u => u.UserId == userId)
                            .AsNoTracking()
                            .SingleAsync();

            if (user == null)
                return false;

            return user.Role.RoleId == (int)Roles.Client || user.Role.RoleId == (int)Roles.Admin;
        }
        
        public async Task<bool> PodeEditarComicBookFilter(int comicBookId, int userId)
        {
            var user = await _context.Users
                            .Include(e => e.Role)
                            .Where(u => u.UserId == userId)
                            .AsNoTracking()
                            .SingleAsync();

            if (user == null)
                return false;

            var comicBook = await _context.ComicBook.SingleOrDefaultAsync(e => e.ComicBookId == comicBookId);

            if (comicBook == null)
                return false;

            return comicBook.CriacaoUtilizadorId == userId;
        }

        public async Task<bool> PodeAcederAInformacoesSensiveisFilter(int userId)
        {
          var user = await _context.Users
          .Include(e => e.Role)
          .Where(u => u.UserId == userId)
          .AsNoTracking()
          .SingleOrDefaultAsync();

           if (user == null)
           return false;

           return user.Role.RoleId == (int)Roles.StoreManager || user.Role.RoleId == (int)Roles.StoreClerk || user.Role.RoleId == (int)Roles.Admin;
        }
    }
}
