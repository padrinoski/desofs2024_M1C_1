using DESOFT.Server.API.Application.DTO.ComicBook;
using DESOFT.Server.API.Application.DTO.Login;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.ComicBook
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ComicBookController : ControllerBase
    {

        private readonly IComicBookService _comicService;

        public ComicBookController(IComicBookService comicService)
        {
            _comicService = comicService;
        }

        [HttpGet(nameof(GetCatalog))]
        [TypeFilter(typeof(PodeAcederFrontOfficeFilter))]
        public async Task<ServiceResult<List<ComicBookDTO>>> GetCatalog()
        {
            return await _comicService.GetCatalog();
        }
        
        [HttpPost(nameof(CreateComicbook))]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public async Task<ServiceResult> CreateComicbook(ComicBookDTO dto)
        {
            return await _comicService.CreateComicBook(dto);
        }
        
    }
}
