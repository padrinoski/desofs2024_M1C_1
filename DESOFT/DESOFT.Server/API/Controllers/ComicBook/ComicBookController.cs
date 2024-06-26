﻿using Azure.Core;
using DESOFT.Server.API.Application.DTO.ComicBook;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Application.Services;
using DESOFT.Server.API.Authorization;
using DESOFT.Server.API.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.RateLimiting;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.ComicBook
{

    [ApiController]
    [Route("/api/[controller]")]
    [EnableRateLimiting("fixed")]
    public class ComicBookController : ControllerBase
    {

        private readonly IComicBookService _comicService;

        public ComicBookController(IComicBookService comicService)
        {
            _comicService = comicService;
        }

        [HttpGet(nameof(GetCatalog))]
        public async Task<ServiceResult<List<ComicBookDTO>>> GetCatalog()
        {
            return await _comicService.GetCatalog();
        }
        
        [HttpGet(nameof(GetCatalogBackOffice))]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public async Task<ServiceResult<List<ComicBookDTO>>> GetCatalogBackOffice()
        {
            var authorizationHeader = Request.Headers["Authorization"];

            if (!authorizationHeader.IsNullOrEmpty() || authorizationHeader.ToString().StartsWith("Bearer"))
            {
                var accessToken = authorizationHeader.ToString().Substring("Bearer ".Length).Trim();

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(accessToken);
                var tokenS = jsonToken as JwtSecurityToken;

                var currentUserId = "1";
                if (tokenS.Payload.ContainsKey("userId"))
                {
                    tokenS.Payload.TryGetValue("userId", out var userId);
                    currentUserId = userId.ToString();
                }
                else if (tokenS.Payload.ContainsKey("sub"))
                {
                    tokenS.Payload.TryGetValue("sub", out var userId);
                    currentUserId = userId.ToString();
                }
                
                return await _comicService.GetCatalogBackOffice(currentUserId);

            } else
            {
                return await _comicService.GetCatalog();
            }

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

        [HttpGet((nameof(SearchComicBooks)))]
        public async Task<ServiceResult<List<ComicBookDTO>>> SearchComicBooks([FromQuery] string? title, [FromQuery] string? author, [FromQuery] string sortBy = "title", [FromQuery] string sortOrder = "asc")
        {
            return await _comicService.SearchComicBooks(title, author, sortBy, sortOrder);
        }
        
    }
}
