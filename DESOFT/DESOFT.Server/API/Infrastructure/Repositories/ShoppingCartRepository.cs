using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;
using Microsoft.EntityFrameworkCore;

namespace DESOFT.Server.API.Infrastructure.Repositories
{
    public class ShoppingCartRepository : AppRepository, IShoppingCartRepository
    {
        private readonly AppDBContext _context;
        private readonly ILogger<ShoppingCartRepository> _logger;

        public ShoppingCartRepository(AppDBContext context, ILogger<ShoppingCartRepository> logger) : base(context, logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<ShoppingCartItem>> GetCartItems(int cartId)
        {
            return await _context.ShoppingCartItems.Where(e => e.ShoppingCartId == cartId).ToListAsync();
        }

        public async Task<List<ShoppingCartItem>> GetCartItemsByUser(string userId)
        {
            var shoppingCart = await _context.ShoppingCarts.SingleOrDefaultAsync(e => e.UserId == userId);
            if (shoppingCart != null)
            {
                return await _context.ShoppingCartItems.Where(e => e.ShoppingCartId == shoppingCart.ShoppingCartId ).ToListAsync();    
            }
            return new List<ShoppingCartItem>();
        }
        public async Task AddToCart(ShoppingCartItem shoppingCartItem)
        {
            await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<ShoppingCart> CreateCart(ShoppingCart shoppingCart)
        {
            var result = await _context.ShoppingCarts.AddAsync(shoppingCart);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task RemoveFromCart(int cartId, int id)
        {
            var itemToRemove = await _context.ShoppingCartItems.FindAsync(id);
            if (itemToRemove != null)
            {
                _context.ShoppingCartItems.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}