using DESOFT.Server.API.Shared.Infrastructure;

namespace DESOFT.Server.API.Application.Interfaces.Repositories.Common
{
    public interface IRepository
    {
        Task<bool> SaveTransaction(Result result, string error);
    }
}
