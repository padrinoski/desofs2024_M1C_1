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
            return await _context.ShoppingCartItems.ToListAsync();
        }

        public async Task AddToCart(int cartId, ShoppingCartItem shoppingCartItem)
        {
            await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
            await _context.SaveChangesAsync();
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