using DESOFT.Server.API.Application.DTO.ComicBook;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Test.ComicBook
{
    public class ComicBookTests : BaseTestes
    {

        private readonly ComicBookService comicBookService;
        private readonly IComicBookRepository _comicBookRepository = Substitute.For<IComicBookRepository>();
        private readonly ILogger<ComicBookService> _logger = Substitute.For<ILogger<ComicBookService>>();

        public ComicBookTests()
        {
            comicBookService = new ComicBookService(_comicBookRepository, _logger,_mapper);
        }

        [Fact]
        public async void GetCatalog_Empty()
        {

            //Arrange
            var catalog = new List<DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook>();

            _comicBookRepository.GetCatalog().Returns(catalog);

            //Act
            var result = await comicBookService.GetCatalog();

            //Assert

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.StatusCode.Should().BeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().BeEmpty();
        }
        
        [Fact]
        public void GetCatalog()
        {
            var dto = new ComicBookDTO()
            {
                Author = "Ian Brooke",
                Description = "It's a story.",
                Price = 20.50m,
                PublishingDate = DateTime.UtcNow,
                Title = "Title",
                Version = "1.0"
            };




        }



    }
}