using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Domain.Entities.User;

namespace DESOFT.Server.API.Application.Interfaces.Repositories;

public interface IUsersRepository : IRepository
{
    Task<User> GetUserByUsername(string username);
    Task AddUser(User user);
    Task RemoveUser(User user);
    Task UpdateUser(User user);
    Task<Role> GetRoleByUser(int userId);
    
    Task<User> GetUserById(int id);

}