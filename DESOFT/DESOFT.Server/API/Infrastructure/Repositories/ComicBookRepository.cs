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

        public async Task<List<ComicBook>> SearchComicBooks(string? title, string? author, string? sortBy, string? sortOrder)
        {
            var query = _context.ComicBook.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(cb => cb.Title.ToLower().Contains(title.ToLower()));
            }

            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(cb => cb.Author.ToLower().Contains(author.ToLower()));
            }

            switch (sortBy)
            {
                case "price":
                    query = sortOrder == "desc" ? query.OrderByDescending(cb => cb.Price) : query.OrderBy(cb => cb.Price);
                    break;
                case "publishingDate":
                    query = sortOrder == "desc" ? query.OrderByDescending(cb => cb.PublishingDate) : query.OrderBy(cb => cb.PublishingDate);
                    break;
                default:
                    query = query.OrderBy(cb => cb.Title);
                    break;
            }

            return await query.ToListAsync();
        }
    }
}
