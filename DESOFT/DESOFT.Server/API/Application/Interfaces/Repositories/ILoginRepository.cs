using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Domain.Entities.User;

namespace DESOFT.Server.API.Application.Interfaces.Repositories
{
    public interface ILoginRepository : IRepository
    {
        Task Login();
        Task Register(User user);
    }
}
