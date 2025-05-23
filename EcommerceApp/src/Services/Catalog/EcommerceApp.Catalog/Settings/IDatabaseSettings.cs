namespace EcommerceApp.Catalog.Settings;

public interface IDatabaseSettings
{
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
    public string SliderCollectionName { get; set; }
    public string ProductCollectionName { get; set; }
    public string CategoryCollectionName { get; set; }
    public string ProductImageCollectionName { get; set; }
    public string ProductDetailCollectionName { get; set; }
}
