using DESOFT.Server.API.Application.DTO.ShoppingCart;
using DESOFT.Server.API.Domain.Entities.Order;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DESOFT.Server.API.Application.DTO.Order
{
    public class CompleteOrderDTO
    {
        public int OrderId { get; set; }
        public decimal TotalCost { get; set; }
        public int ShoppingCartId { get; set; }
        public string Address { get; set; }
        
        public PaymentMethod PaymentMethod { get; set; }

        public List<ShoppingCartItemDTO> ShoppingCartItems { get; set; }
    }
}