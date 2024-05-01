namespace DESOFT.Server.API.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<bool> PodeAcederBackOffice(int userId);
        Task<bool> PodeAcederFrontOffice(int userId);
        
    }
}
