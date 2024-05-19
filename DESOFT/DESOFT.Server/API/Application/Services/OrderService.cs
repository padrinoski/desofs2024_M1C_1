using AutoMapper;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Application.DTO.Order;
using DESOFT.Server.API.Domain.Entities.Order;
using static DESOFT.Server.API.Shared.Infrastructure.Result;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;
using DESOFT.Server.API.Application.DTO.ShoppingCart;
using DESOFT.Server.API.Domain.Entities.ComicBooks;

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



        public async Task<ServiceResult<OrderDTO>> CreateOrder(OrderDTO orderDTO)
        {
        
            var result = new ServiceResult<OrderDTO>();

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

                var createdItem = await _orderRepository.CreateOrder(order);

                result.Data = _mapper.Map<OrderDTO>(createdItem);

                await _orderRepository.SaveTransaction(result, "An error occurred while saving the data.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<List<CompleteOrderDTO>>> GetOrdersByUserId(int userId)
        {
            var result = new ServiceResult<List<CompleteOrderDTO>>();

            try
            {
                List<Order> orders = await _orderRepository.GetOrdersByUserId(userId);

                List<CompleteOrderDTO> completeOrders = new List<CompleteOrderDTO>();

                foreach (Order order in orders)
                {
                    CompleteOrderDTO completeOrder = new CompleteOrderDTO();

                    var cartItems = await _shoppingCartService.GetCartItems(order.ShoppingCartId);

                    _logger.LogInformation("cart items count is " + cartItems.Data.Count);

                    if (cartItems.Success)
                    {

                        List<CompleteOrderItemDTO> orderItems = new List<CompleteOrderItemDTO>();

                        foreach (var item in cartItems.Data)
                        {

                            _logger.LogInformation("cart item id is " + item.ShoppingCartItemId);

                            var comicBook = await _comicBookService.GetComicBook(item.ComicBookId);
                            if (comicBook.Success)
                            {

                                CompleteOrderItemDTO orderItem = new CompleteOrderItemDTO();

                                orderItem.ShoppingCartItemId = item.ShoppingCartItemId;
                                orderItem.Quantity = item.Quantity;
                                orderItem.ShoppingCartId = item.ShoppingCartId;
                                orderItem.ComicBookTitle = comicBook.Data.Title;
                                orderItem.ComicBookPrice = comicBook.Data.Price;
                                
                                orderItems.Add(orderItem);
                            }
                        }

                        completeOrder.ShoppingCartItems = orderItems;

                        completeOrders.Add(completeOrder);
                    }
                    else
                    {
                        _logger.LogError("Failed to retrieve cart items.");
                    }

                    
                }

                result.Data = completeOrders;

                await _orderRepository.SaveTransaction(result, "An error occurred while retrieving the data.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<CompleteOrderDTO>> GetOrderInformationById(int orderId)
        {
            var result = new ServiceResult<CompleteOrderDTO>();

            try
            {
                var order = await _orderRepository.GetOrder(orderId);

                CompleteOrderDTO completeOrder = new CompleteOrderDTO();

                if(order != null)
                {

                    var cartItems = await _shoppingCartService.GetCartItems(order.ShoppingCartId);

                    _logger.LogInformation("cart items count is " + cartItems.Data.Count);

                    if (cartItems.Success)
                    {

                        List<CompleteOrderItemDTO> orderItems = new List<CompleteOrderItemDTO>();

                        foreach (var item in cartItems.Data)
                        {

                            _logger.LogInformation("cart item id is " + item.ShoppingCartItemId);

                            var comicBook = await _comicBookService.GetComicBook(item.ComicBookId);
                            if (comicBook.Success)
                            {

                                CompleteOrderItemDTO orderItem = new CompleteOrderItemDTO();

                                orderItem.ShoppingCartItemId = item.ShoppingCartItemId;
                                orderItem.Quantity = item.Quantity;
                                orderItem.ShoppingCartId = item.ShoppingCartId;
                                orderItem.ComicBookTitle = comicBook.Data.Title;
                                orderItem.ComicBookPrice = comicBook.Data.Price;
                                
                                orderItems.Add(orderItem);
                            }
                        }

                        completeOrder.ShoppingCartItems = orderItems;

                    }
                    else
                    {
                        _logger.LogError("Failed to retrieve cart items.");
                    }

                    
                }

                result.Data = completeOrder;

                await _orderRepository.SaveTransaction(result, "An error occurred while retrieving the data.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<List<CompleteOrderDTO>>> GetAllOrders()
        {
            var result = new ServiceResult<List<CompleteOrderDTO>>();
            try
            {
                List<Order> orders = await _orderRepository.GetAllOrders();
                List<CompleteOrderDTO> completeOrders = new List<CompleteOrderDTO>();
                foreach (Order order in orders)
                {
                    CompleteOrderDTO completeOrder = new CompleteOrderDTO
                    {
                        OrderId = order.OrderId,
                        TotalCost = order.TotalCost,
                        ShoppingCartId = order.ShoppingCartId,
                        Address = order.Address,
                        PaymentMethod = order.PaymentMethod
                    };

                    var cartItems = await _shoppingCartService.GetCartItems(order.ShoppingCartId);
                    if (cartItems.Success)
                    {
                        List<CompleteOrderItemDTO> orderItems = new List<CompleteOrderItemDTO>();
                        foreach (var item in cartItems.Data)
                        {
                            var comicBook = await _comicBookService.GetComicBook(item.ComicBookId);
                            if (comicBook.Success)
                            {
                                CompleteOrderItemDTO orderItem = new CompleteOrderItemDTO
                                {
                                    ShoppingCartItemId = item.ShoppingCartItemId,
                                    Quantity = item.Quantity,
                                    ShoppingCartId = item.ShoppingCartId,
                                    ComicBookTitle = comicBook.Data.Title,
                                    ComicBookPrice = comicBook.Data.Price
                                };

                                orderItems.Add(orderItem);
                            }
                        }
                        completeOrder.ShoppingCartItems = orderItems;
                    }
                    completeOrders.Add(completeOrder);
                }
                result.Data = completeOrders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return result;
        }

    }
}