using AutoMapper;
using EcommerceApp.Catalog.Dtos.CategoryDtos;
using EcommerceApp.Catalog.Dtos.ProductDetailDtos;
using EcommerceApp.Catalog.Dtos.ProductDtos;
using EcommerceApp.Catalog.Dtos.ProductImageDtos;
using EcommerceApp.Catalog.Entities;

namespace EcommerceApp.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        CreateMap<GetByIdCategoryDto, Category>().ReverseMap();
        CreateMap<ResultCategoryDto, Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();

        CreateMap<CreateProductDto, Product>().ReverseMap();
        CreateMap<ResultProductDto, Product>().ReverseMap();
        CreateMap<GetByIdProductDto, Product>().ReverseMap();
        CreateMap<UpdateProductDto, Product>().ReverseMap();

        CreateMap<CreateProductDetailDto, ProductDetail>().ReverseMap();
        CreateMap<UpdateProductDetailDto, ProductDetail>().ReverseMap();
        CreateMap<GetByIdProductDetailDto, ProductDetail>().ReverseMap();
        CreateMap<ResultProductDetailDto, ProductDetail>().ReverseMap();

        CreateMap<CreateProductImageDto, ProductImage>().ReverseMap();
        CreateMap<GetByIdProductImageDto, ProductImage>().ReverseMap();
        CreateMap<UpdateProductImageDto, ProductImage>().ReverseMap();
        CreateMap<ResultProductImageDto, ProductImage>().ReverseMap();
    }
}
