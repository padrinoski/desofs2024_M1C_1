using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Domain.Entities.ComicBooks;
using Microsoft.EntityFrameworkCore;

namespace DESOFT.Server.API.Infrastructure.Repositories
{
    public class ComicBookRepository : AppRepository, IComicBookRepository
    {

        private readonly AppDBContext _context;
        private readonly ILogger<ComicBookRepository> _logger;

        public ComicBookRepository(AppDBContext context, ILogger<ComicBookRepository> logger) : base(context, logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task CreateComicBook(ComicBook model)
        {
            await _context.ComicBook.AddAsync(model);
        }

        public async Task DeleteComicBook(ComicBook model)
        {
            await Task.Run(() =>
            {
                _context.ComicBook.Remove(model);
            });
        }

        public async Task<List<ComicBook>> GetCatalog()
        {
            return await _context.ComicBook
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ComicBook?> GetComicBook(int comicBookId, bool tracking = false)
        {
            return tracking ? await _context.ComicBook.Where(e => e.ComicBookId == comicBookId).SingleOrDefaultAsync() :
                 await _context.ComicBook.Where(e => e.ComicBookId == comicBookId).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<ComicBook>> FilterComicBooks(string title, string author)
        {
            return await _context.ComicBook
                .Where(cb => cb.Title.ToLower().Contains(title.ToLower()) && cb.Author.ToLower().Contains(author.ToLower()))
                .ToListAsync();
        }
    }
}
