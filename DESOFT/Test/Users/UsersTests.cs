using DESOFT.Server.API.Application.DTO.User;
using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Services;
using DESOFT.Server.API.Domain.Entities.User;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Test.User
{
    public class UserTests : BaseTestes
    {
        private readonly UsersService _usersService;
        private readonly IUsersRepository _usersRepository = Substitute.For<IUsersRepository>();
        private readonly ILogger<UsersService> _logger = Substitute.For<ILogger<UsersService>>();

        private DESOFT.Server.API.Domain.Entities.User.User model = new DESOFT.Server.API.Domain.Entities.User.User()
        {
            UserName = "TestUser",
            Password = "TestPassword",
            Address = "TestAddress"
        };

        private UserDTO dto = new UserDTO()
        {
            Username = "TestUser",
            Password = "TestPassword",
            Address = "TestAddress"
        };

        public UserTests()
        {
            _usersService = new UsersService(_logger, _usersRepository);
        }

        [Fact]
        public async void AddAdmin_ValidUser()
        {
            // Arrange
            _usersRepository.AddUser(model).Returns(Task.CompletedTask);

            // Act
            var result = await _usersService.AddAdmin(dto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async void UpdateAdmin_ValidUser()
        {
            // Arrange
            _usersRepository.GetUserByUsername(dto.Username).Returns(model);
            _usersRepository.UpdateUser(model).Returns(Task.CompletedTask);

            // Act
            var result = await _usersService.UpdateAdmin(dto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
        
        [Fact]
        public async void RemoveAdmin_ValidUser()
        {
            // Arrange
            _usersRepository.GetUserByUsername(dto.Username).Returns(model);
            _usersRepository.RemoveUser(model).Returns(Task.CompletedTask);

            // Act
            var result = await _usersService.RemoveAdmin(new RemoveUserDTO { Username = dto.Username });

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
        
    }
}