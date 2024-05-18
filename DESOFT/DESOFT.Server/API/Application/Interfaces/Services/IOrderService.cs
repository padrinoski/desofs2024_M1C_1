using DESOFT.Server.API.Application.DTO.Order;
using DESOFT.Server.API.Application.DTO.ShoppingCart;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Interfaces.Services

{
    public interface IOrderService
    {
        Task<ServiceResult> CreateOrder(OrderDTO orderDTO);
        
        Task<ServiceResult<List<CompleteOrderDTO>>> GetOrdersByUserId(int userId);

    }

}