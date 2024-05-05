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

        public async Task<List<ComicBook>> GetCatalog()
        {
            return await _context.ComicBook
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
