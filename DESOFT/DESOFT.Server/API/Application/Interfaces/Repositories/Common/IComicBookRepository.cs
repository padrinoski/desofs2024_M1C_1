
using DESOFT.Server.API.Domain.Entities.ComicBooks;

namespace DESOFT.Server.API.Application.Interfaces.Repositories.Common
{
    public interface IComicBookRepository : IRepository
    {
        Task CreateComicBook(ComicBook model);
        Task<List<ComicBook>> GetCatalog();
    }
}
