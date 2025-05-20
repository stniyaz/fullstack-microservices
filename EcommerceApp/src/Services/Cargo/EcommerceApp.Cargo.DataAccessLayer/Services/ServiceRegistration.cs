using EcommerceApp.Cargo.DataAccessLayer.Abstract;
using EcommerceApp.Cargo.DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceApp.Cargo.DataAccessLayer.Services;

public static class ServiceRegistration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICargoDetailRepository, CargoDetailRepository>();
        services.AddScoped<ICargoCompanyRepository, CargoCompanyRepository>();
        services.AddScoped<ICargoCustomerRepository, CargoCustomerRepository>();
        services.AddScoped<ICargoOperationRepository, CargoOperationRepository>();
    }
}
