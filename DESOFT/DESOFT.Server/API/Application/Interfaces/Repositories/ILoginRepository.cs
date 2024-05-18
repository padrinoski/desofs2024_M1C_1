using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Domain.Entities.User;

namespace DESOFT.Server.API.Application.Interfaces.Repositories
{
    public interface ILoginRepository : IRepository
    {
        Task Register(User user);

        Task<User> GetUserByUsernameAndPassword(string username, string password);

    }
}
