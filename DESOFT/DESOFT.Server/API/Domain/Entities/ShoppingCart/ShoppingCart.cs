using DESOFT.Server.API.Domain.Entities.ComicBooks;
using DESOFT.Server.API.Domain.Entities.Common;

namespace DESOFT.Server.API.Domain.Entities.ShoppingCart
{
    public class ShoppingCart : AuditableEntity
    {

        public ShoppingCart()
        {
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
        }
        public int ShoppingCartId { get; set; }
        public string UserId { get; set; }

        public User.User User { get; set; }

        public Order.Order Order { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}
