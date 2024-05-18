using DESOFT.Server.API.Domain.Entities.Order;

namespace DESOFT.Server.API.Application.Interfaces.Repositories.Common
{
    public interface IOrderRepository: IRepository
    {
        Task CreateOrder(Order order);
        Task<Order?> GetOrder(int orderId, bool tracking = false);
        Task<List<Order>> GetOrdersByUserId(int userId, bool tracking = false);
        Task<List<Order>> GetAllOrders(bool tracking = false);
    }
}
