using DESOFT.Server.API.Domain.Entities.ComicBooks;
using DESOFT.Server.API.Domain.Entities.Common;

namespace DESOFT.Server.API.Domain.Entities.ShoppingCart
{
    public class ShoppingCartItem : AuditableEntity
    {
        public int ShoppingCartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ComicBookId { get; set; }
        public int Quantity { get; set; }

        public ComicBook ComicBook { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

    }
}
