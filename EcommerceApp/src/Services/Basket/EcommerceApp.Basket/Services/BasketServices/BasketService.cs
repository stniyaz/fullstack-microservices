using EcommerceApp.Basket.Dtos.BasketDtos;
using EcommerceApp.Basket.Settings;
using System.Text.Json;

namespace EcommerceApp.Basket.Services.BasketServices;

public class BasketService(RedisService _redisService) : IBasketService
{
    public async Task DeleteBasketAsync(string userId)
    {
        await _redisService.GetDb().KeyDeleteAsync(userId);
    }

    public async Task<BasketTotalDto> GetBasketAsync(string userId)
    {
        var existBasket = await _redisService.GetDb().StringGetAsync(userId);

        return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
    }

    public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
    {
        await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, 
                                                   JsonSerializer.Serialize(basketTotalDto));
    }
}