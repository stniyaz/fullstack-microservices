using EcommerceApp.DtoLayer.OrderDtos.OrderingDtos;

namespace EcommerceApp.WebUI.Services.OrderServices.OrderingServices;

public interface IOrderingService
{
    Task<List<ResultOrderingDto>> GetOrderingsByUserIdAsync(string userId);
}
