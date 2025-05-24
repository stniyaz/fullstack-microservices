using EcommerceApp.Catalog.Services.CategoryServices;
using Microsoft.Extensions.Options;
using EcommerceApp.Catalog.Services.ProductDetailServices;
using EcommerceApp.Catalog.Services.ProductImageServices;
using EcommerceApp.Catalog.Services.ProductImageServicesl;
using System.Reflection;
using EcommerceApp.Catalog.Settings;
using EcommerceApp.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EcommerceApp.Catalog.Services.SliderServices;
using EcommerceApp.Catalog.Services.SpecialOfferServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServer"];
    opt.Audience = "resource_catalog";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
