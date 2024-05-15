using DESOFT.Server.API.Application.DTO.ShoppingCart;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Interfaces.Services

{
    public interface IShoppingCartService
    {
        Task<ServiceResult> CreateCart(ShoppingCartDTO shoppingCartDTO);
        Task<ServiceResult<List<ShoppingCartItemDTO>>> GetCartItems(int cartId);
        Task<ServiceResult> AddToCart(int cartId, ShoppingCartItemDTO shoppingCartItemDTO);
        Task<ServiceResult> RemoveFromCart(int cartId, int id);
    }

}