using AutoMapper;
using DESOFT.Server.API.Application.Interfaces.Repositories.Common;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Application.DTO.ShoppingCart;
using DESOFT.Server.API.Domain.Entities.ShoppingCart;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Application.Services

{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ILogger<ShoppingCartService> _logger;
        private readonly IMapper _mapper;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, ILogger<ShoppingCartService> logger, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResult> AddToCart(ShoppingCartItemDTO shoppingCartItemDTO)
        {
            _logger.LogInformation("EntrouServico");
            var result = new ServiceResult();

            try
            {
                var shoppingCartItem = _mapper.Map<ShoppingCartItem>(shoppingCartItemDTO);

                await _shoppingCartRepository.AddToCart(shoppingCartItem);

                await _shoppingCartRepository.SaveTransaction(result, "An error occurred while saving the data.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> CreateCart(ShoppingCartDTO shoppingCartDTO)
        {
            _logger.LogError("EntrouServico");
            var result = new ServiceResult();

            try
            {
                var shoppingCart = _mapper.Map<ShoppingCart>(shoppingCartDTO);

                await _shoppingCartRepository.CreateCart(shoppingCart);

                await _shoppingCartRepository.SaveTransaction(result, "An error occurred while saving the data.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<List<ShoppingCartItemDTO>>> GetCartItems(int cartId)
        {
            var result = new ServiceResult<List<ShoppingCartItemDTO>>();

            try
            {
                var cartItems = await _shoppingCartRepository.GetCartItems(cartId);
                result.Data = _mapper.Map<List<ShoppingCartItemDTO>>(cartItems);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult> RemoveFromCart(int cartId, int id)
        {
            var result = new ServiceResult();

            try
            {
                await _shoppingCartRepository.RemoveFromCart(cartId, id);

                await _shoppingCartRepository.SaveTransaction(result, "An error occurred while removing the item from the cart.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }
    }

}