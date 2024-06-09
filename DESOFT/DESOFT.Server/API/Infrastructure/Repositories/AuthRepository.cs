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

        public async Task<bool> PodeAcederBackOffice(string userId)
        {
            
            var user = await _context.Users
                .Include(e => e.User_Role)
                .Where(u => u.UserId == userId)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (user == null)
                return false;

            return user.User_Role.RoleId == (int)Roles.StoreManager || user.User_Role.RoleId == (int)Roles.StoreClerk || user.User_Role.RoleId == (int)Roles.Admin;
        }

        public async Task<bool> PodeAcederFrontOffice(string userId)
        {
            var user = await _context.Users
                            .Include(e => e.User_Role)
                            .Where(u => u.UserId == userId)
                            .AsNoTracking()
                            .SingleAsync();

            if (user == null)
                return false;

            return user.User_Role.RoleId == (int)Roles.Client || user.User_Role.RoleId == (int)Roles.Admin;
        }
        
        public async Task<bool> PodeEditarComicBookFilter(int comicBookId, string userId)
        {
            var user = await _context.Users
                            .Include(e => e.User_Role)
                            .Where(u => u.UserId == userId)
                            .AsNoTracking()
                            .SingleAsync();

            if (user == null)
                return false;

            if (user.User_Role.RoleId == (int)Roles.Admin)
            {
                return true;
            }

            var comicBook = await _context.ComicBook.SingleOrDefaultAsync(e => e.ComicBookId == comicBookId);

            if (comicBook == null)
                return false;

            return comicBook.CriacaoUtilizadorId == userId;
        }

        public async Task<bool> PodeAcederAInformacoesSensiveisFilter(string userId)
        {
          var user = await _context.Users
          .Include(e => e.User_Role)
          .Where(u => u.UserId == userId)
          .AsNoTracking()
          .SingleOrDefaultAsync();

           if (user == null)
           return false;

           return user.User_Role.RoleId == (int)Roles.StoreManager || user.User_Role.RoleId == (int)Roles.StoreClerk || user.User_Role.RoleId == (int)Roles.Admin;
        }
    }
}
