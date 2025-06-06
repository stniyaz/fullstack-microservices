using EcommerceApp.Catalog.Entities;
using EcommerceApp.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceApp.Catalog.Services.StatisticServices;

public class StatisticService : IStatisticService
{
    private readonly IMongoCollection<Brand> _brandsCollection;
    private readonly IMongoCollection<Product> _productsCollection;
    private readonly IMongoCollection<Category> _categoriesCollection;

    public StatisticService(IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _brandsCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
        _productsCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        _categoriesCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
    }

    public async Task<long> GetBrandCountAsync()
        => await _brandsCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);

    public async Task<long> GetCategoryCountAsync()
        => await _categoriesCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);

    public async Task<long> GetProductCountAsync()
        => await _productsCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);

    public async Task<decimal> GetProductAvgPriceAsync()
    {
        var result = await _productsCollection.Aggregate()
                          .Group(p => 1, g => new { AvgPrice = g.Average(x => x.ProductPrice) })
                          .FirstOrDefaultAsync();

        return result?.AvgPrice ?? 0;
    }

    public async Task<string> GetMaxPriceProductNameAsync()
    {
        var product = await _productsCollection.Find(FilterDefinition<Product>.Empty)
                                         .SortByDescending(x => x.ProductPrice)
                                         .Limit(1)
                                         .FirstOrDefaultAsync();

        return product?.ProductName ?? "Product not found.";
    }

    public async Task<string> GetMinPriceProductNameAsync()
    {
        var product = await _productsCollection.Find(FilterDefinition<Product>.Empty)
                                          .SortBy(x => x.ProductPrice)
                                          .Limit(1)
                                          .FirstOrDefaultAsync();

        return product?.ProductName ?? "Product not found";
    }
}
