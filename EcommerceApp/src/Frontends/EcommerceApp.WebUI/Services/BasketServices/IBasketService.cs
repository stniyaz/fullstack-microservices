using EcommerceApp.DtoLayer.BasketDtos;

namespace EcommerceApp.WebUI.Services.BasketServices;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasketAsync();
    Task DeleteBasketAsync(string userId);
    Task<bool> RemoveBasketItem(string pdtId);
    Task SaveBasketAsync(BasketTotalDto basketTotalDto);
    Task AddBasketItemAsync(BasketItemDto basketItemDto);
    Task<int> GetBasketItemCountAsync();
}
