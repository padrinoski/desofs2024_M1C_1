using DESOFT.Server.API.Application.Interfaces.Repositories;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;

namespace DESOFT.Server.API.Infrastructure.Repositories
{
    public class OrderRepository : AppRepository, IOrderRepository
    {
        private readonly AppDBContext _context;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(AppDBContext context, ILogger<OrderRepository> logger) : base(context, logger)
        {
            _logger = logger;
            _context = context;
        }

    
        public async Task<Order> CreateOrder(Order order)
        {
            var result = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Order?> GetOrder(int orderId, bool tracking = false)
        {

            return tracking ? await _context.Orders.Where(e => e.OrderId == orderId).SingleOrDefaultAsync() :
                 await _context.Orders.Where(e => e.OrderId == orderId).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrdersByUserId(int userId, bool tracking = false)
        {
            return tracking ? await _context.Orders.Where(e => e.CriacaoUtilizadorId == userId).ToListAsync() :
                 await _context.Orders.Where(e => e.CriacaoUtilizadorId == userId).AsNoTracking().ToListAsync();
        }

        public async Task<List<Order>> GetAllOrders(bool tracking = false)
        {
            return tracking ? await _context.Orders.ToListAsync() :
                 await _context.Orders.AsNoTracking().ToListAsync();
         }

    }
}