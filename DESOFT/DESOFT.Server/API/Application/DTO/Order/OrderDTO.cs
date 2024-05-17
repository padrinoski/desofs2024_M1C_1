using DESOFT.Server.API.Domain.Entities.Order;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DESOFT.Server.API.Application.DTO.Order
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public decimal TotalCost { get; set; }
        public int ShoppingCartId { get; set; }
        public string Address { get; set; }
        
        public PaymentMethod PaymentMethod { get; set; }
    }
}