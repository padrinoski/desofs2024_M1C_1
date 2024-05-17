﻿using DESOFT.Server.API.Application.DTO.Order;
using DESOFT.Server.API.Application.Interfaces.Services;
using DESOFT.Server.API.Authorization;
using DESOFT.Server.API.Shared.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static DESOFT.Server.API.Shared.Infrastructure.Result;

namespace DESOFT.Server.API.Controllers.PlaceOrder
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceOrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public PlaceOrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

/*         [HttpGet(nameof(GetShoppingCart) + "/{id}")]
        [TypeFilter(typeof(PodeAcederFrontOfficeFilter))]
        public async Task<ServiceResult<List<ShoppingCartItemDTO>>> GetShoppingCart(int id)
        {
            return await _shoppingCartService.GetCartItems(id);
        }

        [HttpPost(nameof(AddToCart))]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public async Task<ServiceResult> AddToCart(ShoppingCartItemDTO shoppingCartItem)
        {
            var result = new ServiceResult();
            try
            {
                var resultFromCall = await _shoppingCartService.AddToCart(shoppingCartItem);
                if (resultFromCall.Success)
                {
                    result.Messages.Add(new KeyVal { Key = "Item was Added to the cart " + shoppingCartItem.ShoppingCartId + "." });
                }
                else
                {
                    result.Errors.Add(new KeyVal { Key = "Item not found." });
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(new KeyVal { Key = "Error processing the request. Exception" + ex.Message });
            }
            return result;

        } */

        [HttpPost(nameof(CreateOrder))]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public async Task<ServiceResult> CreateOrder(OrderDTO order)
        {
            var result = new ServiceResult();
            try
            {
                var resultFromCall = await _orderService.CreateOrder(order);
                if (resultFromCall.Success)
                {
                    result.Messages.Add(new KeyVal { Key = "Cart was created successfully." });
                }
                else
                {
                    result.Errors.Add(new KeyVal { Key = "Error creating the cart." });
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(new KeyVal { Key = "Error processing the request. Exception" + ex.Message });
            }
            return result;
        }

/* 

        [HttpDelete(nameof(RemoveFromCart) + "/{cartId}" + "/{id}")]
        [TypeFilter(typeof(PodeAcederBackOfficeFilter))]
        public async Task<ServiceResult> RemoveFromCart(int cartId, int id)
        {
            var result = new ServiceResult();
            try
            {
                var resultFromCall = await _shoppingCartService.RemoveFromCart(cartId, id);
                if (resultFromCall.Success)
                {
                    result.Messages.Add(new KeyVal { Key = "Item was removed form the cart." });
                }
                else
                {
                    result.Errors.Add(new KeyVal { Key = "Item not found in the cart." });
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(new KeyVal { Key = "Error processing the request. Exception" + ex.Message });
            }
            return result;
        } */

    }
}
