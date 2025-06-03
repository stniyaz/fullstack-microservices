using EcommerceApp.DtoLayer.BasketDtos;

namespace EcommerceApp.WebUI.Services.BasketServices;

public class BasketService(HttpClient _httpClient) : IBasketService
{
    public async Task AddBasketItemAsync(BasketItemDto basketItemDto)
    {
        var values = await GetBasketAsync();

        if (values is not null)
        {
            if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
            {
                values.BasketItems.Add(basketItemDto);
            }
            else
            {
                values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId).Quantity++;
            }
        }
        else
        {
            values = new BasketTotalDto();
            values.BasketItems.Add(basketItemDto);
        }

        await SaveBasketAsync(values);
    }

    public async Task DeleteBasketAsync(string pdtId)
    {
        throw new NotImplementedException();
    }

    public async Task<BasketTotalDto> GetBasketAsync()
    {
        var responseMessage = await _httpClient.GetAsync("baskets");
        var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();

        return values;
    }

    public async Task<int> GetBasketItemCountAsync()
    {
        var values = await GetBasketAsync();

        return values.BasketItems.Count;
    }

    public async Task<bool> RemoveBasketItem(string pdtId)
    {
        var values = await GetBasketAsync();
        var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == pdtId);
        var result = values.BasketItems.Remove(deletedItem);
        await SaveBasketAsync(values);
        return true;
    }

    public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        => await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
}
