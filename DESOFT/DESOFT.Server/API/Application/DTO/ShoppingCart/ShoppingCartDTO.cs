namespace DESOFT.Server.API.Application.DTO.ShoppingCart
{
    public class ShoppingCartDTO
    {
        public int ShoppingCartId { get; set; }
        public string UserId { get; set; }
        public List<ShoppingCartItemDTO> ShoppingCartItems { get; set; }
    }
}