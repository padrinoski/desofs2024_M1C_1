using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ServiceResult<bool>> PodeAcederBackOffice(int userId);
        Task<ServiceResult<bool>> PodeAcederFrontOffice(int userId);
        Task<ServiceResult<bool>> PodeEditarComicBookFilter(int comicBookId,int userId);
        Task<ServiceResult<bool>> PodeAcederAInformacoesSensiveisFilter(int userId);
    }
}
