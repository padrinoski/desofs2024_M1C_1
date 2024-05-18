namespace DESOFT.Server.API.Application.DTO.ShoppingCart
{
    public class CompleteOrderItemDTO
    {
        public int ShoppingCartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public string ComicBookTitle { get; set; }
        public decimal ComicBookPrice { get; set; }
        public int Quantity { get; set; }
    }
}