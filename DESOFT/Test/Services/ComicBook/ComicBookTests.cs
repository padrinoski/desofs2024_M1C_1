using DESOFT.Server.API.Application.DTO.ComicBook;
using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Services;
using DESOFT.Server.API.Domain.Entities.ComicBooks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Test.ComicBook
{
    public class ComicBookTests : BaseTestes
    {

        private readonly ComicBookService comicBookService;
        private readonly IComicBookRepository _comicBookRepository = Substitute.For<IComicBookRepository>();
        private readonly IUsersRepository _userRepository = Substitute.For<IUsersRepository>();
        private readonly ILogger<ComicBookService> _logger = Substitute.For<ILogger<ComicBookService>>();

        private DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook model = new DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook()
        {
            Author = "Ian Brooke",
            Description = "It's a story.",
            Price = 20.50m,
            PublishingDate = DateTime.UtcNow,
            Title = "Title",
            Version = "1.0",
            AlteracaoData = DateTime.UtcNow,
            AlteracaoUtilizadorId = 1,
            ComicBookId = 1,
            CriacaoData = DateTime.UtcNow,
            CriacaoUtilizadorId = 1
        };

        private ComicBookDTO dto = new ComicBookDTO()
        {
            Author = "Ian Brooke",
            Description = "It's a story.",
            Price = 20.50m,
            PublishingDate = DateTime.UtcNow.ToString(),
            Title = "Title",
            Version = "1.0"
        };
        
        private ComicBookDTO dto1 = new ComicBookDTO()
        {
            ComicBookId = 2,
            Author = "Ian Brooke",
            Description = "It's a story.",
            Price = 20.50m,
            PublishingDate = DateTime.UtcNow.ToString(),
            Title = "Title",
            Version = "1.0"
        };

        public ComicBookTests()
        {
            comicBookService = new ComicBookService(_comicBookRepository, _userRepository, _logger,_mapper);
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
        public async void GetCatalog()
        {

            var catalog = new List<DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook>();

            catalog.Add(model);

            _comicBookRepository.GetCatalog().Returns(catalog);

            //Act
            var result = await comicBookService.GetCatalog();

            //Assert

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.StatusCode.Should().BeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().BeEquivalentTo(_mapper.Map<List<ComicBookDTO>>(catalog));

        }
        
        [Fact]
        public async void GetComicBook()
        {

            _comicBookRepository.GetComicBook(1).Returns(model);

            //Act
            var result = await comicBookService.GetComicBook(1);

            //Assert

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.StatusCode.Should().BeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().BeEquivalentTo(_mapper.Map<ComicBookDTO>(result.Data));

        }
        
        [Fact]
        public async void GetComicBook_NotFound()
        {

            _comicBookRepository.GetComicBook(1).ReturnsNull();

            //Act
            var result = await comicBookService.GetComicBook(1);

            //Assert

            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Errors.Should().NotBeNullOrEmpty();
            result.Data.Should().BeNull();
        }

        [Fact]
        public async void CreateComicBook()
        {
            _comicBookRepository.CreateComicBook(_mapper.Map<DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook>(dto)).Returns(Task.CompletedTask);

            //Act
            var result = await comicBookService.CreateComicBook(dto);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.StatusCode.Should().BeNull();
            
        }
        
        [Fact]
        public async void EditComicBook_NotFound()
        {
            _comicBookRepository.GetComicBook(1,true).ReturnsNull();

            //Act
            var result = await comicBookService.EditComicBook(1, dto1);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Errors.Should().NotBeNullOrEmpty();

        }
        
        [Fact]
        public async void EditComicBook()
        {

            _comicBookRepository.GetComicBook(1,true).Returns(model);

            //Act
            var result = await comicBookService.EditComicBook(1,dto);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.StatusCode.Should().BeNull();

        }
        
        [Fact]
        public async void DeleteComicBook_NotFound()
        {
            _comicBookRepository.GetComicBook(2,true).ReturnsNull();

            //Act
            var result = await comicBookService.DeleteComicBook(2);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Errors.Should().NotBeNullOrEmpty();

        }
        
        [Fact]
        public async void DeleteComicBook()
        {

            _comicBookRepository.GetComicBook(1,true).Returns(model);

            //Act
            var result = await comicBookService.DeleteComicBook(1);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.StatusCode.Should().BeNull();

        }

        [Fact]
        public async void SearchComicBooks()
        {
            var catalog = new List<DESOFT.Server.API.Domain.Entities.ComicBooks.ComicBook>();

            catalog.Add(model);

            _comicBookRepository.SearchComicBooks("Title", "Ian Brooke", "title", "asc").Returns(catalog);

            //Act
            var result = await comicBookService.SearchComicBooks("Title", "Ian Brooke", "title", "asc");

            //Assert

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.StatusCode.Should().BeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().BeEquivalentTo(_mapper.Map<List<ComicBookDTO>>(catalog));

        }

    }
}