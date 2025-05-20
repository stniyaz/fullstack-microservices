using EcommerceApp.Cargo.BusinessLayer.Abstract;
using EcommerceApp.Cargo.BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceApp.Cargo.BusinessLayer.Services;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICargoDetailService, CargoDetailService>();
        services.AddScoped<ICargoCompanyService, CargoCompanyService>();
        services.AddScoped<ICargoCustomerService, CargoCustomerService>();
        services.AddScoped<ICargoOperaitonService, CargoOperationService>();
    }
}
