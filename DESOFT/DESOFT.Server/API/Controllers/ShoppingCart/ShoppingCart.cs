﻿using DESOFT.Server.API.Application.DTO.ShoppingCart;
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

        [HttpGet(nameof(GetShoppingCart))]
        [TypeFilter(typeof(PodeAcederFrontOfficeFilter))]
        public async Task<ServiceResult<List<ShoppingCartItemDTO>>> GetShoppingCart(int id)
        {
            return await _shoppingCartService.GetCartItems(id);
        }

        [HttpPost(nameof(AddToCart) + "/{cartId}")]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public  async Task<ServiceResult> AddToCart(int cartId, ShoppingCartItemDTO shoppingCartItem)
        {
            return await _shoppingCartService.AddToCart(cartId, shoppingCartItem);
        }
        [HttpDelete(nameof(RemoveFromCart))]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public  async Task<ServiceResult> RemoveFromCart(int cartId, int id)
        {
            return await _shoppingCartService.RemoveFromCart(cartId, id);
        }
    }
}