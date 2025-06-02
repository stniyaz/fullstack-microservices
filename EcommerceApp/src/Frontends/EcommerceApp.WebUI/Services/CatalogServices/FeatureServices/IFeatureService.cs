using EcommerceApp.DtoLayer.CatalogDtos.FeatureDtos;

namespace EcommerceApp.WebUI.Services.CatalogServices.FeatureServices;

public interface IFeatureService
{
    Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
    Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
    Task<UpdateFeatureDto> GetFeatureByIdAsync(string featureId);
    Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
    Task DeleteFeatureAsync(string featureId);
}
