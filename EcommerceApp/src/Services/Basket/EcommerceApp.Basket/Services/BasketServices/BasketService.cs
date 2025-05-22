using EcommerceApp.Basket.Dtos.BasketDtos;
using EcommerceApp.Basket.Settings;
using StackExchange.Redis;
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
        RedisValue? existBasket = await _redisService.GetDb().StringGetAsync(userId);

        if (existBasket.HasValue && !string.IsNullOrWhiteSpace(existBasket))
        {
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        return null;
    }

    public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
    {
        await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId,
                                                   JsonSerializer.Serialize(basketTotalDto));
    }
}