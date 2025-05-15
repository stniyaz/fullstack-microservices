using Ecommerce.Discount.Dtos.CouponDtos;

namespace Ecommerce.Discount.Services;

public interface ICouponService
{
    Task DeleteCouponAsync(int id);
    Task CreateCouponAsync(CreateCouponDto createCouponDto);
    Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
    Task<List<ResultCouponDto>> GetAllCouponsAsync();
    Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
}
