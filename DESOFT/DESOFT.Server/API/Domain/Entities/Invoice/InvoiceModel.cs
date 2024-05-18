using DESOFT.Server.API.Domain.Entities.Order;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;

namespace DESOFT.Server.API.Domain.Entities.Invoice
{
    public class InvoiceModel
    {
        public int InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }

        public String CustomerAddress { get; set; }

        public List<ShoppingCartItem> Items { get; set; }
    }

}


