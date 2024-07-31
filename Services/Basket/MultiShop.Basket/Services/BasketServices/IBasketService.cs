﻿using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
    }
}
