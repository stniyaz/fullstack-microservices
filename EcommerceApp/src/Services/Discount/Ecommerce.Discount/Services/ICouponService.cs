using Ecommerce.Discount.Dtos.CouponDtos;

namespace Ecommerce.Discount.Services;

public interface ICouponService
{
    Task DeleteCouponAsync(int id);
    Task<int> GetCouponCountAsync();
    Task<int> GetCouponRateByCodeAsync(string code);
    Task<List<ResultCouponDto>> GetAllCouponsAsync();
    Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
    Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
    Task<ResultCouponDto> GetCouponByCodeAsync(string code);
    Task CreateCouponAsync(CreateCouponDto createCouponDto);
}
