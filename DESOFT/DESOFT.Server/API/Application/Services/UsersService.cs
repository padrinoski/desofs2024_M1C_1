using AutoMapper;
using DESOFT.Server.API.Application.DTO.User;
using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Domain.Entities.User;
using DESOFT.Server.API.Shared.Infrastructure;
using static DESOFT.Server.API.Shared.Infrastructure.Result;


namespace DESOFT.Server.API.Application.Services
{

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ILogger<UsersService> _logger;
        private readonly IMapper _mapper;

        public UsersService(ILogger<UsersService> logger, IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _logger = logger;
            _mapper = mapper;
        }

        
        public async Task<ServiceResult<UserDTO>> getUserById(int id)
        {
            var res = new ServiceResult<UserDTO>();

            try
            {
                var user = await _usersRepository.GetUserById(id);

                if (user != null)
                {
                    res.Data = new UserDTO
                    {
                        Username = user.UserName,
                        Address = user.Address
                    };
                }
                else
                {
                    res.Errors.Add(new KeyVal("User not found"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                res.Errors.Add(new KeyVal("An error occurred while getting the user"));
            }
            
            return res;
        }
        
        public async Task<ServiceResult> AddAdmin(UserDTO dto)
        {
            var res = new ServiceResult();

            try
            {
                var user = new User
                {
                    UserName = dto.Username,
                    Password = dto.Password,
                    Address = dto.Address
                };

                await _usersRepository.AddUser(user);
                res.Messages.Add(new KeyVal("Admin added successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                res.Errors.Add(new KeyVal("An error occurred while adding the admin"));
            }

            return res;
        }
        public async Task<ServiceResult<UserDTO>> GetUser(string username)
        {
            var result = new ServiceResult<UserDTO>();
            try
            {
                var user = await _usersRepository.GetUserByUsername(username);
                if (user != null)
                {
                    result.Data = _mapper.Map<UserDTO>(user);
                }
                else
                {
                    result.Data = null; // Ensure Data is null if user doesn't exist
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> RemoveAdmin(RemoveUserDTO dto)
        {
            var res = new ServiceResult();

            try
            {
                var user = await _usersRepository.GetUserByUsername(dto.Username);

                if (user != null)
                {
                    await _usersRepository.RemoveUser(user);
                    res.Messages.Add(new KeyVal("Admin removed successfully"));
                }
                else
                {
                    res.Errors.Add(new KeyVal("Admin not found"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                res.Errors.Add(new KeyVal("An error occurred while removing the admin"));
            }

            return res;
        }

        public async Task<ServiceResult> UpdateAdmin(UserDTO dto)
        {
            var res = new ServiceResult();

            try
            {
                var user = await _usersRepository.GetUserByUsername(dto.Username);

                if (user != null)
                {
                    user.UserName = dto.Username;
                    user.Password = dto.Password;
                    user.Address = dto.Address;

                    await _usersRepository.UpdateUser(user);
                    res.Messages.Add(new KeyVal("Admin updated successfully"));
                }
                else
                {
                    res.Errors.Add(new KeyVal("Admin not found"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                res.Errors.Add(new KeyVal("An error occurred while updating the admin"));
            }

            return res;
        }
    }
}