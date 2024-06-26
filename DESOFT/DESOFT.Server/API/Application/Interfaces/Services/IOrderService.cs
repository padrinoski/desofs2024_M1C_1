using DESOFT.Server.API.Application.DTO.Order;
using DESOFT.Server.API.Application.DTO.ShoppingCart;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Interfaces.Services

{
    public interface IOrderService
    {
        Task<ServiceResult<OrderDTO>> CreateOrder(OrderDTO orderDTO);

        Task<ServiceResult<CompleteOrderDTO>> GetOrderInformationById(int orderId);
        
        Task<ServiceResult<List<CompleteOrderDTO>>> GetOrdersByUserId(string userId);

        Task<ServiceResult<List<CompleteOrderDTO>>> GetAllOrders();
    }

}