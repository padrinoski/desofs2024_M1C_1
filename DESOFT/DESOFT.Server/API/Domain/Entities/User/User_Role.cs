using DESOFT.Server.API.Domain.Entities.Common;

namespace DESOFT.Server.API.Domain.Entities.User
{
    public class User_Role : AuditableEntity
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public string UserId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
