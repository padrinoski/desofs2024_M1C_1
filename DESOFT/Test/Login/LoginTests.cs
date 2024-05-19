using DESOFT.Server.API.Application.DTO.Login;
using DESOFT.Server.API.Application.DTO.User;
using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Services;
using DESOFT.Server.API.Domain.Entities.User;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Test.Login
{
    public class LoginTests : BaseTestes
    {
        private readonly LoginService _loginService;
        private readonly UsersService _usersService;
        private readonly IUsersRepository _usersRepository = Substitute.For<IUsersRepository>();
        private readonly ILoginRepository _loginRepository = Substitute.For<ILoginRepository>();
        private readonly ILogger<LoginService> _logger = Substitute.For<ILogger<LoginService>>();
        private readonly ILogger<UsersService> _logger2 = Substitute.For<ILogger<UsersService>>();


        private DESOFT.Server.API.Domain.Entities.User.User model = new DESOFT.Server.API.Domain.Entities.User.User()
        {
            UserName = "TestUser",
            Password = "TestPassword",
            Address = "TestAddress"
        };

        private LoginDTO dto = new LoginDTO()
        {
            Username = "TestUser",
            Password = "TestPassword"
        };

        public LoginTests()
        {
            _loginService = new LoginService(_logger, _loginRepository);
            _usersService = new UsersService(_logger2, _usersRepository);
        }

        [Fact]
        public async void Login_ValidUser()
        {
            // Arrange
            _loginRepository.GetUserByUsernameAndPassword(dto.Username, dto.Password).Returns(model);

            // Act
            var result = await _loginService.Login(dto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async void Login_InvalidUser()
        {
            // Arrange
            _loginRepository.GetUserByUsernameAndPassword(dto.Username, dto.Password).ReturnsNull();

            // Act
            var result = await _loginService.Login(dto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
        }

        [Fact]
        public async void Register_ValidUser()
        {
            // Arrange
            var registerDTO = new RegisterDTO()
            {
                UserName = "TestUser",
                Address = "TestAddress",
                Name = "TestUser",
                Email = "TestEmail@gmail.com"
            };

            // Act
            var result = await _loginService.Register(registerDTO);
            
            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();

        }
    }
}