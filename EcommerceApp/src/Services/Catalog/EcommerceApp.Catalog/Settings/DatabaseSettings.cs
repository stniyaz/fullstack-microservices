namespace EcommerceApp.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string BrandCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string SliderCollectionName { get; set; }
        public string SettingCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string SpecialOfferCollectionName { get; set; }
    }
}
