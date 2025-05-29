using EcommerceApp.Catalog.Services.BrandServices;
using EcommerceApp.Catalog.Services.CategoryServices;
using EcommerceApp.Catalog.Services.ContactServices;
using EcommerceApp.Catalog.Services.FeatureServices;
using EcommerceApp.Catalog.Services.ProductServices;
using EcommerceApp.Catalog.Services.SettingServices;
using EcommerceApp.Catalog.Services.SliderServices;
using EcommerceApp.Catalog.Services.SpecialOfferServices;
using EcommerceApp.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace EcommerceApp.Catalog.Services;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["IdentityServer"];
            opt.Audience = "resource_catalog";
            opt.RequireHttpsMetadata = false;
        });

        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IFeatureService, FeatureService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<ISettingService, SettingService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISpecialOfferService, SpecialOfferService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

        services.AddScoped<IDatabaseSettings>(sp =>
        {
            return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
        });

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
