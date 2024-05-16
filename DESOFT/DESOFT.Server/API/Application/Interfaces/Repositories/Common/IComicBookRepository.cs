
using DESOFT.Server.API.Domain.Entities.ComicBooks;

namespace DESOFT.Server.API.Application.Interfaces.Repositories.Common
{
    public interface IComicBookRepository : IRepository
    {
        Task CreateComicBook(ComicBook model);
        Task DeleteComicBook(ComicBook model);
        Task<List<ComicBook>> GetCatalog();
        Task<ComicBook?> GetComicBook(int comicBookId, bool tracking = false);
        Task<List<ComicBook>> FilterComicBooks(string title, string author);
    }
}
