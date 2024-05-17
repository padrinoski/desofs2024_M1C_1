using AutoMapper;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Application.DTO.Order;
using DESOFT.Server.API.Domain.Entities.Order;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Services

{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IComicBookService _comicBookService;
        private readonly ILogger<OrderService> _logger;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IShoppingCartService shoppingCartService, IComicBookService comicBookService, ILogger<OrderService> logger, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _shoppingCartService = shoppingCartService;
            _comicBookService = comicBookService;
            _logger = logger;
            _mapper = mapper;
        }



        public async Task<ServiceResult> CreateOrder(OrderDTO orderDTO)
        {
        
            var result = new ServiceResult();

            try
            {
                if (orderDTO.TotalCost == 0.0m)
                {
                    var cartItemsResult = await _shoppingCartService.GetCartItems(orderDTO.ShoppingCartId);
                    if (cartItemsResult.Success)
                    {
                        decimal totalCost = 0.0m;
                        foreach (var item in cartItemsResult.Data)
                        {
                            var comicBook = await _comicBookService.GetComicBook(item.ComicBookId);
                            if (comicBook.Success)
                            {
                                totalCost += item.Quantity * comicBook.Data.Price;
                            }

                        }
                        _logger.LogInformation("total cost is " + totalCost);

                        orderDTO.TotalCost = totalCost;
                    }
                    else
                    {
                        _logger.LogError("Failed to retrieve cart items.");
                    }
                }

                var order = _mapper.Map<Order>(orderDTO);

                await _orderRepository.CreateOrder(order);

                await _orderRepository.SaveTransaction(result, "An error occurred while saving the data.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

    }
}