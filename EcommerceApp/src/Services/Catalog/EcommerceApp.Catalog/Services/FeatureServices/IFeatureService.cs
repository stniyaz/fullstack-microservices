using EcommerceApp.Catalog.Dtos.FeatureDtos;

namespace EcommerceApp.Catalog.Services.FeatureServices;

public interface IFeatureService
{
    Task<GetByIdFeatureDto> GetByIdFeatureAsync(string FeatureId);
    Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
    Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
    Task<List<ResultFeatureDto>> GetAllCategoriesAsync();
    Task DeleteFeatureAsync(string featureId);
}
