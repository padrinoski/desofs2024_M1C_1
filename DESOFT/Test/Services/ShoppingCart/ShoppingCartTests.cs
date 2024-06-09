using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using DESOFT.Server.API.Application.DTO.ShoppingCart;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Services;
using Assert = NUnit.Framework.Assert;

namespace DESOFT.Server.API.Tests
{
    [TestFixture]
    public class ShoppingCartServiceTests
    {
        private Mock<IShoppingCartRepository> _shoppingCartRepositoryMock;
        private Mock<ILogger<ShoppingCartService>> _loggerMock;
        private Mock<IMapper> _mapperMock;
        private ShoppingCartService _shoppingCartService;

        [SetUp]
        public void Setup()
        {
            _shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
            _loggerMock = new Mock<ILogger<ShoppingCartService>>();
            _mapperMock = new Mock<IMapper>();
            _shoppingCartService = new ShoppingCartService(_shoppingCartRepositoryMock.Object, _loggerMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task AddToCart_ShouldReturnServiceResult_WhenCalledWithValidData()
        {
            // Arrange
            var shoppingCartItemDTO = new ShoppingCartItemDTO();

            // Act
            var result = await _shoppingCartService.AddToCart(shoppingCartItemDTO);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task CreateCart_ShouldReturnServiceResult_WhenCalledWithValidData()
        {
            // Arrange
            var shoppingCartDTO = new ShoppingCartDTO();

            // Act
            var result = await _shoppingCartService.CreateCart(shoppingCartDTO);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetCartItems_ShouldReturnServiceResult_WhenCalledWithValidCartId()
        {
            // Arrange
            var cartId = 1;

            // Act
            var result = await _shoppingCartService.GetCartItems(cartId);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task RemoveFromCart_ShouldReturnServiceResult_WhenCalledWithValidCartIdAndItemId()
        {
            // Arrange
            var cartId = 1;
            var itemId = 1;

            // Act
            var result = await _shoppingCartService.RemoveFromCart(cartId, itemId);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
