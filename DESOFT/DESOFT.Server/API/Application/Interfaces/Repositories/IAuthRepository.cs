namespace DESOFT.Server.API.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> PodeAcederBackOffice(int userId);
        Task<bool> PodeAcederFrontOffice(int userId);
        Task<bool> PodeEditarComicBookFilter(int userId, int userId1);
    }
}
