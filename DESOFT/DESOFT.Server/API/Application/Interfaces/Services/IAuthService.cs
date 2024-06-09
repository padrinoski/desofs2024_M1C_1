using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ServiceResult<bool>> PodeAcederBackOffice(string userId);
        Task<ServiceResult<bool>> PodeAcederFrontOffice(string userId);
        Task<ServiceResult<bool>> PodeEditarComicBookFilter(int comicBookId,string userId);
        Task<ServiceResult<bool>> PodeAcederAInformacoesSensiveisFilter(string userId);
    }
}
