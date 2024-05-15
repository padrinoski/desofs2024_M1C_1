using DESOFT.Server.API.Application.DTO.ShoppingCart;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.ShoppingCart
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet(nameof(GetShoppingCart)+ "/{id}")]
        [TypeFilter(typeof(PodeAcederFrontOfficeFilter))]
        public async Task<ServiceResult<List<ShoppingCartItemDTO>>> GetShoppingCart(int id)
        {
            return await _shoppingCartService.GetCartItems(id);
        }

        [HttpPost(nameof(AddToCart))]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public  async Task<ServiceResult> AddToCart(ShoppingCartItemDTO shoppingCartItem)
        {
            return await _shoppingCartService.AddToCart(shoppingCartItem);
        }

        [HttpPost(nameof(CreateCart))]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public  async Task<ServiceResult> CreateCart(ShoppingCartDTO shoppingCart)
        {
            return await _shoppingCartService.CreateCart(shoppingCart);
        }

        [HttpDelete(nameof(RemoveFromCart))]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public  async Task<ServiceResult> RemoveFromCart(int cartId, int id)
        {
            return await _shoppingCartService.RemoveFromCart(cartId, id);
        }
    }
}
