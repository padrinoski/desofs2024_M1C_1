using DESOFT.Server.API.Domain.Entities.Common;

namespace DESOFT.Server.API.Domain.Entities.User
{
    public class Role : AuditableEntity
    {
        public Role()
        {
            User_Role = new HashSet<User_Role>();
        }

        public int RoleId {  get; set; }
        public string RoleName { get; set; }

        public ICollection<User_Role> User_Role { get; set;}
    }
}
