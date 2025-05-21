using EcommerceApp.Basket.Dtos.BasketDtos;

namespace EcommerceApp.Basket.Services.BasketServices;

public interface IBasketService
{
    Task DeleteBasketAsync(string userId);
    Task<BasketTotalDto> GetBasketAsync(string userId);
    Task SaveBasketAsync(BasketTotalDto basketTotalDto);
}
