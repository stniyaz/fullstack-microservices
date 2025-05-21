using EcommerceApp.Basket.Services.BasketServices;
using EcommerceApp.Basket.Services.LoginServices;
using EcommerceApp.Basket.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace EcommerceApp.Basket.Services;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["IdentityServer"];
            opt.Audience = "ResourceBasket";
            opt.RequireHttpsMetadata = false;
            opt.MapInboundClaims = false;
        });

        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddHttpContextAccessor();

        services.Configure<RedisSettings>(configuration.GetSection("RedisSettings"));

        services.AddSingleton<RedisService>(sp =>
        {
            var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
            var redis = new RedisService(redisSettings.Host, redisSettings.Port);
            redis.Connect();
            return redis;
        });
    }
}
