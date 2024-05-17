using DESOFT.Server.API.Domain.Entities.ComicBooks;
using DESOFT.Server.API.Domain.Entities.Common;

namespace DESOFT.Server.API.Domain.Entities.Order
{
    public class OrderItem : AuditableEntity
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ComicBookId { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public ComicBook ComicBook { get; set; }

    }
}
