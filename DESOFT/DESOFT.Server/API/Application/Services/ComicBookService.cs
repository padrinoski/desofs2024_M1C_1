using AutoMapper;
using DESOFT.Server.API.Application.DTO.ComicBook;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Domain.Entities.ComicBooks;
using DESOFT.Server.API.Shared.Infrastructure;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Services
{
    public class ComicBookService : IComicBookService
    {

        private readonly IComicBookRepository _comicBookRepository;
        private readonly ILogger<ComicBookService> _logger;
        private readonly IMapper _mapper;

        public ComicBookService(IComicBookRepository comicBookRepository, ILogger<ComicBookService> logger, IMapper mapper)
        {
            _comicBookRepository = comicBookRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResult> CreateComicBook(ComicBookDTO comicBookDTO)
        {
            var result = new ServiceResult();

            try
            {
                var model = _mapper.Map<ComicBook>(comicBookDTO);

                await _comicBookRepository.CreateComicBook(model);

                await _comicBookRepository.SaveTransaction(result, "Ocorreu um erro a guardar os dados.");

            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<List<ComicBookDTO>>> GetCatalog()
        {
            var result = new ServiceResult<List<ComicBookDTO>>();

            try
            {
                result.Data = _mapper.Map<List<ComicBookDTO>>(await _comicBookRepository.GetCatalog());

            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }
    }
}
