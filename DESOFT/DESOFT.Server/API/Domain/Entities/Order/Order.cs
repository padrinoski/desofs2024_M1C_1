using DESOFT.Server.API.Domain.Entities.Common;

namespace DESOFT.Server.API.Domain.Entities.Order
{
    public class Order : AuditableEntity
    {

        public int OrderId { get; set; }
        public decimal TotalCost { get; set; }
        public int ShoppingCartId { get; set; }
        public string Address { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ShoppingCart.ShoppingCart ShoppingCart { get; set; }

    }
}
