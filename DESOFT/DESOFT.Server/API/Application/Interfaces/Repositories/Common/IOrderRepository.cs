using DESOFT.Server.API.Domain.Entities.Order;

namespace DESOFT.Server.API.Application.Interfaces.Repositories.Common
{
    public interface IOrderRepository: IRepository
    {
        Task<Order> CreateOrder(Order order);
        Task<Order?> GetOrder(int orderId, bool tracking = false);
        Task<List<Order>> GetOrdersByUserId(string userId, bool tracking = false);
        Task<List<Order>> GetAllOrders(bool tracking = false);
    }
}
