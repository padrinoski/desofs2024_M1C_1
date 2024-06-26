using System.Collections.Generic;
using System.Threading.Tasks;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Interfaces.Repositories.Common
{
    public interface IShoppingCartRepository: IRepository
    {
        Task<List<ShoppingCartItem>> GetCartItems(int cartId);
        Task<List<ShoppingCartItem>> GetCartItemsByUser(string userId);
        Task AddToCart(ShoppingCartItem shoppingCartItem);
        Task<ShoppingCart> CreateCart(ShoppingCart shoppingCart);
        Task RemoveFromCart(int cartId, int id);
    }
}
