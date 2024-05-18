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
        
        [HttpGet(nameof(GetComicBook)+"/{comicBookId}")]
        [TypeFilter(typeof(PodeAcederFrontOfficeFilter))]
        public async Task<ServiceResult<ComicBookDTO>> GetComicBook(int comicBookId)
        {
            return await _comicService.GetComicBook(comicBookId);
        }
        
        [HttpPost(nameof(CreateComicbook))]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public async Task<ServiceResult> CreateComicbook(ComicBookDTO dto)
        {
            return await _comicService.CreateComicBook(dto);
        }
        
        [HttpPost(nameof(EditComicBook)+ "/{comicBookId}")]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        [TypeFilter(typeof(PodeEditarComicBookFilter))]
        public async Task<ServiceResult> EditComicBook(int comicBookId, ComicBookDTO dto)
        {
            return await _comicService.EditComicBook(comicBookId,dto);
        }
        
        [HttpDelete(nameof(DeleteComicBook)+ "/{comicBookId}")]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        [TypeFilter(typeof(PodeEditarComicBookFilter))]
        public async Task<ServiceResult> DeleteComicBook(int comicBookId)
        {
            return await _comicService.DeleteComicBook(comicBookId);
        }

        [HttpGet((nameof(FilterComicBooks)))]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public async Task<IActionResult> FilterComicBooks([FromQuery] string? title, [FromQuery] string? author)
        {
            var result = await _comicService.FilterComicBooks(title, author);
            return Ok(result);
        }
        
    }
}
