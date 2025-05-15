using Dapper;
using Ecommerce.Discount.Context;
using Ecommerce.Discount.Dtos.CouponDtos;

namespace Ecommerce.Discount.Services;

public class CouponService : ICouponService
{
    private readonly DapperContext _context;

    public CouponService(DapperContext dapperContext)
    {
        this._context = dapperContext;
    }

    public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
        var query = "Insert Into Coupons (Code,Rate,IsActive,ValidDate) Values (@code,@rate,@isActive,@validDate)";

        var parameters = new DynamicParameters();

        parameters.Add("@code", createCouponDto.Code);
        parameters.Add("@rate", createCouponDto.Rate);
        parameters.Add("@isActive", createCouponDto.IsActive);
        parameters.Add("@validDate", createCouponDto.ValidDate);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteCouponAsync(int id)
    {
        var query = "Delete From Coupons Where CouponId = @couponId";

        var parameters = new DynamicParameters();

        parameters.Add("@couponId", id);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
    {
        var query = "Select * From Coupons";

        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultCouponDto>(query);

            return values.ToList();
        }
    }

    public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
    {
        var query = "Select * From Coupons Where CouponId=@couponId";

        var parameters = new DynamicParameters();

        parameters.Add("@couponId", id);

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
        }
    }

    public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        var query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate Where CouponId=@couponId";

        var parameters = new DynamicParameters();

        parameters.Add("@code", updateCouponDto.Code);
        parameters.Add("@couponId", updateCouponDto.CouponId);
        parameters.Add("@rate", updateCouponDto.Rate);
        parameters.Add("@isActive", updateCouponDto.IsActive);
        parameters.Add("@validDate", updateCouponDto.ValidDate);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
