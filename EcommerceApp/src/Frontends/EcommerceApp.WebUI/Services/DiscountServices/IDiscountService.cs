using EcommerceApp.DtoLayer.DiscountDtos;

namespace EcommerceApp.WebUI.Services.DiscountServices;

public interface IDiscountService
{
    Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string code);
}
