using DESOFT.Server.API.Domain.Entities.ComicBooks;
using DESOFT.Server.API.Domain.Entities.Common;

namespace DESOFT.Server.API.Domain.Entities.Inventory
{
    public class Inventory : AuditableEntity
    {
        public int InventoryId { get; set; }
        public int ComicBookId { get; set; }
        public int Quantity { get; set; }

        public ComicBook ComicBook { get; set; }
    }
}
