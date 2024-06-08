using DESOFT.Server.API.Application.DTO.User;
using DESOFT.Server.API.Domain.Entities.User;

namespace DESOFT.Server.API.Application.Mapping
{
    public class UserMapper : MappingProfile
    {
        public UserMapper() : base()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
