using AutoMapper;
using DESOFT.Server.API.Application.DTO.ComicBook;
using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Domain.Entities.ComicBooks;
using DESOFT.Server.API.Shared.Infrastructure;
using DESOFS.Server.API.Application.Utils;
using static DESOFT.Server.API.Shared.Infrastructure.Result;
using DESOFS.Server.API.Application.DTO.Common;

namespace DESOFT.Server.API.Application.Services
{
    public class ComicBookService : IComicBookService
    {

        private readonly IComicBookRepository _comicBookRepository;
        private readonly IUsersRepository _userRepository;
        private readonly ILogger<ComicBookService> _logger;
        private readonly IMapper _mapper;

        public ComicBookService(IComicBookRepository comicBookRepository, IUsersRepository userRepository, ILogger<ComicBookService> logger, IMapper mapper)
        {
            _comicBookRepository = comicBookRepository;
            _userRepository = userRepository;
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

        public async Task<ServiceResult> DeleteComicBook(int comicBookId)
        {
            var result = new ServiceResult();

            try
            {
                var model = await _comicBookRepository.GetComicBook(comicBookId,true);

                if (model == null)
                {
                    result.Errors.Add(new KeyVal { Key = "The comic book was not found" });
                    return result;
                }

                await _comicBookRepository.DeleteComicBook(model);

                await _comicBookRepository.SaveTransaction(result, "Ocorreu um erro a guardar os dados.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> EditComicBook(int comicBookId, ComicBookDTO dto)
        {
            var result = new ServiceResult();

            try
            {
                var model = await _comicBookRepository.GetComicBook(comicBookId, true);

                if (model == null)
                {
                    result.Errors.Add(new KeyVal { Key = "The comic book was not found" });
                    return result;
                }

                model.Author = dto.Author;
                model.Description = dto.Description;
                model.Price = dto.Price;
                model.PublishingDate = DateTime.Parse(dto.PublishingDate);
                model.Title = dto.Title;
                model.Version = dto.Version;

                await _comicBookRepository.SaveTransaction(result, "Ocorreu um erro a guardar os dados.");

            }
            catch (Exception ex)
            {
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
        
        public async Task<ServiceResult<List<ComicBookDTO>>> GetCatalogBackOffice(int userId)
        {
            var result = new ServiceResult<List<ComicBookDTO>>();

            try
            {
                var userRole = await _userRepository.GetRoleByUser(userId);
                var catalog = await _comicBookRepository.GetCatalog();
                var catalogDTO = _mapper.Map<List<ComicBookDTO>>(catalog);

                foreach (var comic in catalogDTO)
                {
                    var comicReg = catalog.Single(e => e.ComicBookId == comic.ComicBookId);

                    if (comicReg.CriacaoUtilizadorId == userId || userRole.RoleId == (int)Roles.Admin)
                    {
                        comic.ListButtons = new List<ListButtonDTO>()
                        {
                            new ListButtonDTO()
                            {
                                Id = $"edit_{comic.ComicBookId}",
                                Action = "Edit",
                                Function = $"editComicBook({comic.ComicBookId})"
                            },
                            new ListButtonDTO()
                            {
                                Id = $"delete_{comic.ComicBookId}",
                                Action = "Delete",
                                Function = $"deleteComicBook({comic.ComicBookId})"
                            }
                        };
                    }

                }

                result.Data = catalogDTO;

            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<ComicBookDTO>> GetComicBook(int comicBookId)
        {
            var result = new ServiceResult<ComicBookDTO>();

            try
            {
                var model = _mapper.Map<ComicBookDTO>(await _comicBookRepository.GetComicBook(comicBookId));

                if (model == null)
                {
                    result.Errors.Add(new KeyVal { Key = "The comic book was not found" });
                    return result;
                }

                result.Data = model;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<List<ComicBookDTO>>> SearchComicBooks(string title, string author, string sortBy, string sortOrder)
        {
            var result = new ServiceResult<List<ComicBookDTO>>();

            try
            {
                var comicBooks = await _comicBookRepository.SearchComicBooks(title, author, sortBy, sortOrder);
                result.Data = _mapper.Map<List<ComicBookDTO>>(comicBooks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }
    }
}
