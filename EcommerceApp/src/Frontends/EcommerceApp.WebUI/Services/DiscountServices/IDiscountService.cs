using EcommerceApp.DtoLayer.DiscountDtos;

namespace EcommerceApp.WebUI.Services.DiscountServices;

public interface IDiscountService
{
    Task<ResultCouponDto> GetCouponByCodeAsync(string code);
    Task<int> GetCouponRateByCodeAsync(string code);
}
