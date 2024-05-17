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

    
        public async Task CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order?> GetOrder(int orderId, bool tracking = false)
        {

            return tracking ? await _context.Orders.Where(e => e.OrderId == orderId).SingleOrDefaultAsync() :
                 await _context.Orders.Where(e => e.OrderId == orderId).AsNoTracking().SingleOrDefaultAsync();
        }

    }
}