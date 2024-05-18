using DESOFT.Server.API.Domain.Entities.Order;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;

namespace DESOFT.Server.API.Domain.Entities.Invoice
{
    public class InvoiceModel
    {
        public int InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }

        public String CustomerAddress { get; set; }

        public List<InvoiceItem> Items { get; set; }
    }

    public class InvoiceItem
    {
        public int ShoppingCartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public string ComicBookTitle { get; set; }
        public decimal ComicBookPrice { get; set; }
        public int Quantity { get; set; }
    }

}


