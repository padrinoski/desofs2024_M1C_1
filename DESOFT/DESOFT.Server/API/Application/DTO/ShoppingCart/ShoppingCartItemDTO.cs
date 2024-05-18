namespace DESOFT.Server.API.Application.DTO.ShoppingCart
{
    public class ShoppingCartItemDTO
    {
        public int ShoppingCartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ComicBookId { get; set; }
        public int Quantity { get; set; }
    }
}