using DESOFT.Server.API.Domain.Entities.Common;

namespace DESOFT.Server.API.Domain.Entities.User
{
    public class User : AuditableEntity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public ShoppingCart.ShoppingCart ShoppingCart { get; set; }
        public User_Role User_Role { get; set; }
    }
}
