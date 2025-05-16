using EcommerceApp.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using EcommerceApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceApp.Order.Application.Services;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<CreateAddressCommandHandler>();
        services.AddScoped<UpdateAddressCommandHandler>();
        services.AddScoped<DeleteAddressCommandHandler>();
        services.AddScoped<GetAddressByIdQueryHandler>();
        services.AddScoped<GetAddressQueryHandler>();

        services.AddScoped<CreateOrderDetailCommandHandler>();
        services.AddScoped<UpdateOrderDetailCommandHandler>();
        services.AddScoped<DeleteOrderDetailCommandHandler>();
        services.AddScoped<GetOrderDetailByIdQueryHandler>();
        services.AddScoped<GetOrderDetailQueryHandler>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
    }
}
