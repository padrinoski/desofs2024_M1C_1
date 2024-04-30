using DESOFT.Server.API.Domain.Entities.Common;
using DESOFT.Server.API.Domain.Entities.Order;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;

namespace DESOFT.Server.API.Domain.Entities.ComicBooks
{
    public class ComicBook : AuditableEntity
    {

        public ComicBook()
        {
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
            Inventory = new HashSet<Inventory.Inventory>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int ComicBookId { get; set; }
        public string Version { get; set; }
        public DateOnly PublishingDate { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
        public ICollection<Inventory.Inventory> Inventory { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
