using DESOFT.Server.API.Domain.Entities.Order;

namespace DESOFT.Server.API.Application.Interfaces.Repositories.Common
{
    public interface IOrderRepository: IRepository
    {
        Task CreateOrder(Order order);
    }
}
