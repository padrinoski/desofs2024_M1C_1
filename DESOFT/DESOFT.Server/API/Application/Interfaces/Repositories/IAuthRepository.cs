namespace DESOFT.Server.API.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> PodeAcederBackOffice(string userId);
        Task<bool> PodeAcederFrontOffice(string userId);
        Task<bool> PodeEditarComicBookFilter(int userId, string userId1);
        Task<bool> PodeAcederAInformacoesSensiveisFilter(string userId);
    }
}
