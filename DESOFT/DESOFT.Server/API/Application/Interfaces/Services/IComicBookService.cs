using DESOFT.Server.API.Application.DTO.ComicBook;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Interfaces.Services
{
    public interface IComicBookService
    {

        Task<ServiceResult> CreateComicBook(ComicBookDTO comicBookDTO);
        Task<ServiceResult<List<ComicBookDTO>>> GetCatalog();
    }
}
